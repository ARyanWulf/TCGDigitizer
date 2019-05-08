using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Video;
using AForge.Video.DirectShow;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows;

using Npgsql;
using Tesseract;

using MtgApiManager.Lib.Service;
using MtgApiManager.Lib.Model;
using MtgApiManager.Lib.Core;
using MtgApiManager.Lib.Utility;
using MtgApiManager.Lib.Dto;


namespace OCS_FOR_CSHARP
{
    public partial class get_image_form : Form
    {
        NpgsqlConnection connection = new NpgsqlConnection("Host=localhost; Port=5432;User Id=postgres;Password=tcgdigitizer;Database=TCGDigitizer");
        public Review callingForm;
        public Edit_Card_Form sendingForm;

        private FilterInfoCollection Devices;
        private VideoCaptureDevice frame = null;
        Bitmap currentCamFrame;

        //Changes Webcam Filters
        bool bwWebCam;
        bool rectWebCam;
        bool boarderWebCam;
        short webCamState;

        Timer searchTimer = new Timer();
        List<cardWrapper> selectedCards = new List<cardWrapper>();
        List<cardWrapper> foundCards = new List<cardWrapper>();

        public cardWrapper currentCard;
        List<cardWrapper> cards = new List<cardWrapper>();
        List<cardWrapper> databaseList = new List<cardWrapper>();
        CardService service = new CardService();

        public object DisplayInformation { get; private set; }

        public get_image_form()
        {
            InitializeComponent();

            searchTimer.Tick += new EventHandler(searchEventHandler);
            searchTimer.Interval = 3000;
            searchTimer.Enabled = true;
            searchTimer.Stop();

            card_data_panel.AutoScroll = false;
            card_data_panel.HorizontalScroll.Enabled = false;
            card_data_panel.HorizontalScroll.Visible = false;
            card_data_panel.HorizontalScroll.Maximum = 0;
            card_data_panel.AutoScroll = true;

            Focus_Bar.ValueChanged += new System.EventHandler(Focus_Bar_Changed);

            //var position = this.PointToScreen(Focus_Bar.Location);
            //position = Cam_Picture_Box.PointToClient(position);
            //Focus_Bar.Parent = Cam_Picture_Box;
            //Focus_Bar.Location = position;
            //Focus_Bar.BackColor = Color.Transparent;
            Focus_Bar.Visible = false;

            bwWebCam = false;
            rectWebCam = false;
            boarderWebCam = true;
            webCamState = 0;

            this.Closing += Form1_Closing;
            //var position = this.PointToScreen(Card_Boarder.Location);
            //position = Cam_Picture_Box.PointToClient(position);
            //Card_Boarder.Parent = Cam_Picture_Box;
            //Card_Boarder.Location = position;
            //Card_Boarder.Visible = false;
        }

        private void Form1_Closing(object sender, CancelEventArgs e)
        {
            if (frame != null && frame.IsRunning)//if webcam is never opened before closing
            {
                frame.SignalToStop(); //I shutdown the webcam if application is closed
            }
            if (Cam_Picture_Box != null)
            {
                Cam_Picture_Box.Dispose();
            }
            if (currentCamFrame != null)
            {
                currentCamFrame.Dispose();
            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frame != null && frame.IsRunning)//if webcam is never opened before closing
            {
                frame.SignalToStop(); //I shutdown the webcam if application is closed
            }
            if (Cam_Picture_Box != null)
            {
                Cam_Picture_Box.Dispose();
            }
            if (currentCamFrame != null)
            {
                currentCamFrame.Dispose();
            }
        }

        private void Stop_Cam_Click(object sender, EventArgs e)
        {
            Card_Boarder.Visible = false;
            Focus_Bar.Visible = false;
            if (frame != null)//if webcam is never opened before closing
            {
                frame.Stop(); //I shutdown the webcam if application is closed
            }
            Cam_Picture_Box.Image = null;

            currentCamFrame = null;
        }

        private void Start_Video_Button_Click(object sender, EventArgs e)
        {
            Start_cam();
        }

        private void Webcam_Feed_Box(object sender, EventArgs e)
        {
            webCamState++;
            if (webCamState == 8) { webCamState = 0; }

            //States:   0 = Color,Boarder,NO_Rect
            //          1 = Color,Boarder,Rect
            //          2 = Color,NO_Boarder,NO_Rect
            //          3 = Color,NO_Boarder,Rect
            //          4 = Black&White,Boarder,NO_Rect
            //          5 = Black&White,Boarder,Rect
            //          6 = Black&White,NO_Boarder,NO_Rect
            //          7 = Black&White,NO_Boarder,Rect

            if (webCamState < 4)
            {
                bwWebCam = false;
                if (webCamState < 2)
                {
                    boarderWebCam = true;
                }
                else
                {
                    boarderWebCam = false;
                }

            }
            else
            {
                bwWebCam = true;
                if (webCamState < 6)
                {
                    boarderWebCam = true;
                }
                else
                {
                    boarderWebCam = false;
                }
            }

            if (webCamState % 2 == 1)
            {
                rectWebCam = true;
            }
            else
            {
                rectWebCam = false;
            }
        }

        void Start_cam()
        {
            Devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            for (int i = 0; i < Devices.Count; i++)
            {
                if (Devices[i].Name == "HD USB Camera")
                {
                    frame = new VideoCaptureDevice(Devices[i].MonikerString);//may handle lack of camera error handle
                }
                else
                {
                    frame = new VideoCaptureDevice(Devices[0].MonikerString);//may handle lack of camera error handle
                                                                             //textBox1.Text = "TCG Digitizer camera not found!";
                                                                             //frame = null;
                                                                             //return;

                }

            }
            if (Devices.Count == 0)
            {
                transcribed_textbox.Text = "TCG Digitizer camera not found!";
                frame = null;
            }
            else
            {

                currentCamFrame = null;
                frame.NewFrame += new AForge.Video.NewFrameEventHandler(NewFrame_event);
                Focus_Bar.Visible = true;
                frame.Start();

            }
        }

        private void Focus_Bar_Changed(object sender, System.EventArgs e)
        {
            frame.SetCameraProperty(CameraControlProperty.Focus, Focus_Bar.Value, CameraControlFlags.Manual);
        }

        void NewFrame_event(object send, NewFrameEventArgs e)
        {

            //Clones current raw frame to bitmap and rotates it 90 degrees
            Bitmap bframe = (Bitmap)e.Frame.Clone();
            bframe.RotateFlip(RotateFlipType.Rotate90FlipNone);

            //Will point to last frame for disposal after transition
            var ccfDispose = currentCamFrame;
            currentCamFrame = new Bitmap(bframe);//swap

            if (webCamState != 2)
            {
                Bitmap ibwWebCam = new Bitmap(bframe);
                Black_White_Conversion(ref ibwWebCam, true);
                if (bwWebCam)
                {

                    Black_White_Conversion(ref bframe, true);
                    Bitmap dframe = bframe;
                    bframe = new Bitmap((Bitmap)bframe);
                    dframe.Dispose();
                }

                if (boarderWebCam || rectWebCam)
                {
                    Rectangle rect = Blob_Detector(ibwWebCam, true, 0.25, 0.25);

                    if (!rect.IsEmpty)
                    {
                        Graphics graphic = Graphics.FromImage(bframe);

                        if (rectWebCam)
                        {
                            Pen pen = new Pen(Color.RoyalBlue, 4);
                            pen.Alignment = PenAlignment.Inset;
                            graphic.DrawRectangle(pen, rect);
                        }

                        if (boarderWebCam)
                        {
                            CardIntPoints card = new CardIntPoints(ibwWebCam, rect, 3);
                            
                            if (card.PointF_CornerList.Count() == 4 && card.closetoIsoscelesTrap)
                            {
                                Pen pen2 = new Pen(Color.Yellow, 3);
                                pen2.Alignment = PenAlignment.Inset;

                                graphic.DrawLine(pen2, card.PointF_CornerList[0], card.PointF_CornerList[1]);
                                graphic.DrawLine(pen2, card.PointF_CornerList[1], card.PointF_CornerList[2]);
                                graphic.DrawLine(pen2, card.PointF_CornerList[2], card.PointF_CornerList[3]);
                                graphic.DrawLine(pen2, card.PointF_CornerList[3], card.PointF_CornerList[0]);
                            }
                        }
                    }
                }
            }

            //will hold reference to old image from picture box for disposal after new image takes it's place
            var bdispose = Cam_Picture_Box.Image;//I fix a long persisting memory leak

            //new web cam frame to camera picture box
            Cam_Picture_Box.Image = bframe;

            //disposal of old image
            if (bdispose != null)
            {
                bdispose.Dispose();
            }
            if(ccfDispose != null)
            {
                ccfDispose.Dispose();
            }
        
        }

        void Adjust_Tesseract_Img(int contrast_threshold/*{-100, 100}*/, ref Bitmap nameHeaderBitmap)
        {
            //width and height of tesseract image
            int nameHeadWidth = nameHeaderBitmap.Width;
            int nameHeadHeight = nameHeaderBitmap.Height;

            var contrast = Math.Pow((100.0 + contrast_threshold) / 100.0, 2);

            int rAvg = 0;
            int gAvg = 0;
            int bAvg = 0;
            int count = 0;
            for (int y = Convert.ToInt32(0.25 * nameHeadHeight); y < (0.75 * nameHeadHeight); y++)
            {
                for (int x = Convert.ToInt32(0.65 * nameHeadWidth); x < (0.75 * nameHeadWidth); x++)
                {
                    Color pixel = nameHeaderBitmap.GetPixel(x, y);
                    rAvg += pixel.R;
                    gAvg += pixel.G;
                    bAvg += pixel.B;
                    count++;
                }
            }



            for (int y = 0; y < nameHeadHeight; y++)
            {
                for (int x = 0; x < nameHeadWidth; x++)
                {
                    Color pixel = nameHeaderBitmap.GetPixel(x, y);

                    //adjust contrast via threshold
                    var r = ((((pixel.R / 255.0) - 0.5) * contrast) + 0.5) * 255.0;
                    var g = ((((pixel.G / 255.0) - 0.5) * contrast) + 0.5) * 255.0;
                    var b = ((((pixel.B / 255.0) - 0.5) * contrast) + 0.5) * 255.0;

                    if (r > 255)
                        r = 255;
                    if (r < 0)
                        r = 0;
                    if (g > 255)
                        g = 255;
                    if (g < 0)
                        g = 0;
                    if (b > 255)
                        b = 255;
                    if (b < 0)
                        b = 0;

                    //invert image
                    //r = 255 - r;
                    //g = 255 - g;
                    //b = 255 - b;

                    nameHeaderBitmap.SetPixel(x, y, Color.FromArgb(255, (int)r, (int)g, (int)b)); 
                }
            }     
            return;
        }

        private void Open_Button(object sender, EventArgs e)
        {

        }

        private void Tess_TextBox(object sender, EventArgs e)
        {
        }

        private Rectangle Blob_Detector(Bitmap image, bool already_Black_White, double min_width_percent, double min_height_percent)
        {
            if (min_height_percent > 0.99 || min_width_percent > 0.99 || min_height_percent < 0 || min_width_percent < 0)
            if (!already_Black_White)
            {
                Black_White_Conversion(ref image, true);
            }
            float maxImgPercent = (float)0.99;
            BlobCounter blobCounter = new BlobCounter();
            blobCounter.FilterBlobs = true;
            blobCounter.MinHeight = (int)(image.Height * min_height_percent);
            blobCounter.MinWidth = (int)(image.Width * min_width_percent);
            blobCounter.MaxHeight = (int)((double)image.Height * maxImgPercent);
            blobCounter.MaxWidth = (int)((double)image.Width * maxImgPercent);
            blobCounter.ProcessImage(image);

            Rectangle[] blobRectangles = blobCounter.GetObjectsRectangles();
            int largestRect = 0;
            double areaLargestRect = 0;
            if (blobRectangles.Count() > 0)
            {
                for(int i = 0; i < blobRectangles.Count(); i++)
                {
                    if (blobRectangles[i].Width * blobRectangles[i].Height > areaLargestRect)
                    {
                        areaLargestRect = blobRectangles[i].Width * blobRectangles[i].Height;
                        largestRect = i;
                    }
                }
                return blobRectangles[largestRect];
            }
            else
            {
                return Rectangle.Empty;
            }
        }
 
        private void Black_White_Conversion(ref Bitmap image, bool invert)
        {
            Grayscale gfilter = new Grayscale(0.2125, 0.7154, 0.0721);
            BradleyLocalThresholding thfilter = new BradleyLocalThresholding();
            image = gfilter.Apply(image);
            thfilter.ApplyInPlace(image); //To greyscale then to black and white
            if (invert)
            {
                Invert ifilter = new Invert();
                ifilter.ApplyInPlace(image);//invert image for white blob detection
            }
            return;
        }

        private void Take_Picture_Button_Click(object sender, EventArgs e)
        {
            //If webcam feed is on
            if (Cam_Picture_Box.Image != null)
            {

                //picture from web cam
                Bitmap originalImg = new Bitmap(currentCamFrame);   //color image
                Bitmap invertBWImg = new Bitmap(originalImg);       //future black/white image

                Black_White_Conversion(ref invertBWImg, true);      //make image black and white, true -> invert

                //rectangle containing blob (BITMAP, BOOL Black_White_Conversion_alreadycalled, DOUBLE (0 <= MinBlobWidth < 0.99), DOUBLE (0 <= MinBlobHeight < 0.99))
                Rectangle rect = Blob_Detector(invertBWImg, true, 0.25, 0.25);

                //if blobs are detected and Blob_Detector parameters are correct
                if (!rect.IsEmpty)
                {
                    try
                    {
                        //if a image of webcam is stored
                        if (currentCamFrame != null) //FUTURE OPTIMIZE DONT STORE IMAGE UNTIL A FLAG - not implemented
                        {

                            //Bitmap that will store blob rectangle (width,height)
                            Bitmap trans_Inbw_img = new Bitmap(rect.Width, rect.Height);
                            Bitmap trans_Color_img = new Bitmap(rect.Width, rect.Height);

                            //Graphics object for blob bitmaps
                            Graphics graphicImage = Graphics.FromImage(trans_Inbw_img);
                            Graphics graphicIBWImage = Graphics.FromImage(trans_Color_img);
                                                       
                            //Creates class and stores calculated corners (IMAGE, RECTANGLE, INT number of edge checks per side)
                            CardIntPoints card = new CardIntPoints(invertBWImg, rect, 3);
                                                                                 
                            //if four corners were found
                            if (card.IntPoint_CornerList.Count == 4)
                            {
                                //stretch quadrilateral formed by corners into blob image
                                QuadrilateralTransformation filter = new QuadrilateralTransformation(card.IntPoint_CornerList, rect.Width, rect.Height);
                                trans_Inbw_img = filter.Apply(invertBWImg);
                                trans_Color_img = filter.Apply(originalImg);
                            }
                            else
                            {   
                                //default unfix blob crop - no stretching
                                graphicImage.DrawImage(originalImg, new Rectangle(0, 0, trans_Color_img.Width, trans_Color_img.Height), rect, GraphicsUnit.Pixel);
                                graphicIBWImage.DrawImage(invertBWImg, new Rectangle(0, 0, trans_Inbw_img.Width, trans_Inbw_img.Height), rect, GraphicsUnit.Pixel);

                            }

                            //Dim of saved image
                            int xStart = 1;
                            int yStart = 1;
                            int xEnd = trans_Color_img.Width - xStart;
                            int yEnd = trans_Color_img.Height - yStart;
                            int xWidth = (xEnd - xStart);
                            int yHeight = (yEnd - yStart);

                            //Dim of card name header by percent
                            int xheader = Convert.ToInt32((xWidth * 0.076/*0.063786008*/) + xStart);
                            int yheader = Convert.ToInt32((yHeight * 0.050/*0.040481481*/) + yStart);
                            int headerWidth = Convert.ToInt32(xWidth * 0.69753086);
                            int headerHeight = Convert.ToInt32(yHeight * 0.045/*0.05037037*/);

                            //Dim of card color section by percent - used to detect card color
                            int xColor = Convert.ToInt32((xWidth * 0.08/*0.063786008*/) + xStart);
                            int yColor = Convert.ToInt32((yHeight * 0.026/*0.040481481*/) + yStart);
                            int colorWidth = Convert.ToInt32(xWidth * 0.69753086);
                            int colorHeight = Convert.ToInt32(yHeight * 0.015/*0.05037037*/);

                            //create color header bitmap
                            Rectangle colorHeaderCropRect = new Rectangle(xColor, yColor, colorWidth, colorHeight);
                            Bitmap colorHeaderBitmap = new Bitmap(colorHeaderCropRect.Width, colorHeaderCropRect.Height);
                            Graphics colorHeadGraphics = Graphics.FromImage(colorHeaderBitmap);
                            colorHeadGraphics.DrawImage(trans_Color_img, 0, 0, colorHeaderCropRect, GraphicsUnit.Pixel);


                            //create name header bitmap and increase size by -v (currently 4)
                            Bitmap nameHeaderBitmap = new Bitmap(headerWidth * 4, headerHeight * 4);
                            List<AForge.IntPoint> headerCorners = new List<AForge.IntPoint> { new AForge.IntPoint(xheader, yheader), new AForge.IntPoint(headerWidth + xheader, yheader), new AForge.IntPoint(headerWidth + xheader, headerHeight + yheader), new AForge.IntPoint(xheader, headerHeight + yheader) };
                            QuadrilateralTransformation headFilter = new QuadrilateralTransformation(headerCorners, nameHeaderBitmap.Width, nameHeaderBitmap.Height);
                            nameHeaderBitmap = headFilter.Apply(trans_Color_img);

                            //fixes image to get better tesseract accuracy (INT contrast, BITMAP REF image)
                            Adjust_Tesseract_Img(15, ref nameHeaderBitmap);

                            //convert to black/white, dont invert
                            Black_White_Conversion(ref nameHeaderBitmap, false);

                            //put black/white header into larger image and center
                            //tesseract work better if there is more empty space around text. Increase size here -v (currently 0.5 width increase and 1.5 height increase)
                            Bitmap blk_wht_header = new Bitmap((int)(nameHeaderBitmap.Width * 1.5), (int)(nameHeaderBitmap.Height * 2.5));
                            Rectangle blk_wht_hRect = new Rectangle(0, 0, blk_wht_header.Width, blk_wht_header.Height);
                            Rectangle name_hRect = new Rectangle(0, 0, nameHeaderBitmap.Width, nameHeaderBitmap.Height);
                            Graphics blk_wht_hGraphics = Graphics.FromImage(blk_wht_header);
                            blk_wht_hGraphics.FillRectangle(Brushes.White, blk_wht_hRect);
                            blk_wht_hGraphics.DrawImage(nameHeaderBitmap, (int)((blk_wht_header.Width - nameHeaderBitmap.Width) / 2), (int)((blk_wht_header.Height - nameHeaderBitmap.Height) / 2), name_hRect, GraphicsUnit.Pixel);
                                                       
                            //displays original image in picture preview box
                            card_preview_box.Image = trans_Color_img;

                            //displays name header image in name header picture box
                            Name_Header_Pic_Box.Image = blk_wht_header;//black and white

                            //gets estimated card colors in char list
                            List <char> theCardColor  = Find_Card_Color(colorHeaderBitmap);
                            
                            //will hold tesseract return string
                            string textBoxString;

                            //local tesseract directory
                            string tesseractPath = Path.GetFullPath(Path.Combine(System.IO.Directory.GetCurrentDirectory(), @"..\..\")) + "Tesseract\\tessdata";

                            //instance of tesseract engine (DIR, "traindata", Type of enginemode)
                            TesseractEngine ocr = new TesseractEngine(tesseractPath, "eng", EngineMode.TesseractAndCube);
                            var page = ocr.Process(blk_wht_header);//sends name header bitmap to tesseract
                            textBoxString = page.GetText();//gets tesseract text

                            //fix punctuation issues with tesseract returned string
                            textBoxString = new string(textBoxString.Where(c => !char.IsPunctuation(c)).ToArray());
                            textBoxString = textBoxString.Replace("â€”", "-");//removes endline characters
                            textBoxString = textBoxString.Replace('\n', ' ');
                            textBoxString = textBoxString.TrimStart(' ', '-', '_', '.', ',', '\'', '[', '{', ']', '}');//removes spaces
                            textBoxString = textBoxString.TrimEnd('\n', '.', ',', '-', '_');//removes endline characters
                            textBoxString = textBoxString.Trim(' ');//removes spaces
                            textBoxString = textBoxString.TrimStart(' ', '-', '_', '.', ',', '\'', '[', '{', ']', '}');//removes spaces
                            textBoxString = textBoxString.TrimEnd('\n', '.', ',', '-', '_');//removes endline characters
                            textBoxString = textBoxString.Trim(' ');//removes spaces
                            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
                            textBoxString = textInfo.ToTitleCase(textBoxString);


                            //FIRST POSTGRESS CALL WITH HEADER STRING
                            connection.Open();
                            bool foundMatch = false;
                            string sqlQuery = "SELECT card_name, similarity(card_name, '" + textBoxString + "') AS sml";//"SELECT * FROM public.card WHERE LOWER(card_name) = LOWER('" + textBoxString + "')";
                            sqlQuery += " FROM card WHERE foil = 'n' ORDER BY sml DESC, card_name";

                            List<String[]> dblist = new List<string[]>();
                            List<String[]> dbtextlist = new List<string[]>();
                            using (var cmd = new NpgsqlCommand(sqlQuery, connection))
                            {
                                NpgsqlDataReader reader = cmd.ExecuteReader();
                                
                                int count = 0;
                                while (reader.Read() && count < 10)
                                {
                                    //foundMatch = true;
                                    //textBoxString = reader[0].ToString();
                                    dblist.Add(new string[] { reader[0].ToString(), reader[1].ToString() });
                                    count++;
                                }
                            }
                            connection.Close();

                            if (Convert.ToDouble(dblist[0][1]) >= 0.70)
                            {
                                textBoxString = dblist[0][0];
                                foundMatch = true;
                            }

                            //SECOND POSTGRESS CALL WITH TEXT STRING
                            if (!foundMatch)
                            {

                                int xtext = Convert.ToInt32((xWidth * 0.076/*0.063786008*/) + xStart);
                                int ytext = Convert.ToInt32((yHeight * 0.6252/*0.040481481*/) + yStart);
                                int textWidth = Convert.ToInt32(xWidth * 0.85753086);
                                int textHeight = Convert.ToInt32(yHeight * 0.141/*0.05037037*/);

                                Bitmap textBitmap = new Bitmap(textWidth * 2, textHeight * 2);
                                List<AForge.IntPoint> textCorners = new List<AForge.IntPoint> { new AForge.IntPoint(xtext, ytext), new AForge.IntPoint(textWidth + xtext, ytext), new AForge.IntPoint(textWidth + xtext, textHeight + ytext), new AForge.IntPoint(xtext, textHeight + ytext) };
                                QuadrilateralTransformation textFilter = new QuadrilateralTransformation(textCorners, textBitmap.Width, textBitmap.Height);
                                textBitmap = textFilter.Apply(trans_Color_img);
                                Black_White_Conversion(ref textBitmap, false);

                                page.Dispose();
                                page = ocr.Process(textBitmap);
                                string text = page.GetText();


                                //Display_Picture_Box.Image = textBitmap;//----------------------------------------------------------<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<
                                text = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());
                                text = text.Replace("â€”", "-");//removes endline characters
                                text = text.Replace('\n', ' ');
                                text = text.Replace('\\', ' ');
                                text = text.Replace('|', ' ');
                                text = text.TrimStart(' ', '-', '_', '.', ',', '\'', '[', '{', ']', '}');//removes spaces
                                text = text.TrimEnd('\n', '.', ',', '-', '_');//removes endline characters
                                text = text.Trim(' ');//removes spaces
                                text = text.TrimStart(' ', '-', '_', '.', ',', '\'', '[', '{', ']', '}');//removes spaces
                                text = text.TrimEnd('\n', '.', ',', '-', '_');//removes endline characters
                                text = text.Trim(' ');//removes spaces


                                //TEXT CHEKC
                                connection.Open(); 
                                string begQueryFuzzy = "SELECT card_name, 1 - ((1 - similarity(card_text, '" + text + "')) * (1 - similarity(card_name, '" + textBoxString + "'";
                                string sqlQueryFuzzy = begQueryFuzzy + "))) AS sml FROM card WHERE foil = 'n' ORDER BY sml DESC";
                                using (var cmd = new NpgsqlCommand(sqlQueryFuzzy, connection))
                                {
                                    NpgsqlDataReader reader = cmd.ExecuteReader();
                                    int readCount = 0;
                                    //bool sameCard = true;
                                    //string tempNameReader = "";
                                    
                                    while (reader.Read() && readCount < 10)
                                    {
                                        dbtextlist.Add(new string[] { reader[0].ToString(), reader[1].ToString() });
                                        readCount++;
                                    }

                                }
                                connection.Close();

                                //FLAVOR TEXT CHECK
                                if (dbtextlist.Count == 0)
                                {
                                    connection.Open();

                                    begQueryFuzzy = "SELECT card_name, 1 - ((1 - similarity(card_flavor, '" + text + "')) * (1 - similarity(card_name, '" + textBoxString + "'";
                                    sqlQueryFuzzy = begQueryFuzzy + "))) AS sml FROM card WHERE foil = 'n' ORDER BY sml DESC";
                                    using (var cmd = new NpgsqlCommand(sqlQueryFuzzy, connection))
                                    {
                                        NpgsqlDataReader reader = cmd.ExecuteReader();
                                        int readCount = 0;
                                        //bool sameCard = true;
                                        //string tempNameReader = "";

                                        while (reader.Read() && readCount < 10)
                                        {
                                            dbtextlist.Add(new string[] { reader[0].ToString(), reader[1].ToString() });
                                            readCount++;
                                        }

                                    }
                                    connection.Close();
                                }
                                
                                if (dbtextlist.Count != 0 && Convert.ToDouble(dbtextlist[0][1]) >= 0.50)
                                {
                                    textBoxString = dbtextlist[0][0];
                                    foundMatch = true;
                                }

                            }
                            


                            transcribed_textbox.Text = textBoxString;
                            CardName.Text = textBoxString;

                            //CREATE EXTENSION pg_trgm;
                            addToList(findCardWithName(textBoxString));

                            if (dbtextlist.Count > 0 && Convert.ToDouble(dbtextlist[0][1]) <= 0.70 && Convert.ToDouble(dbtextlist[0][1]) >= 0.50)
                            {
                                textBoxString += "\nProbability: " + dbtextlist[0][0];
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //System.Windows.MessageBox.Show(ex.ToString());
                        transcribed_textbox.Text = "Unknown Card";
                        cardWrapper tempCard = new cardWrapper();
                        if (CardName.Text != "Name" && CardName.Text != "")
                        {
                            tempCard.card = new CardObject { name = CardName.Text, };
                        }
                        else
                        {
                            tempCard.card = new CardObject { name = "Unknown Card" };
                        }
                        tempCard.cardStatus = Color.FromArgb(255, 66, 49, 57);
                        tempCard.tempImg = (Bitmap)card_preview_box.Image.Clone();
                        addToList(tempCard);
                        if (connection.State == ConnectionState.Open) connection.Close();
                    }//need to add exception functionality
                }
            }
        }

        private List<char> Find_Card_Color(Bitmap colorHeaderBitmap)
        {
            double[] avgCardColor = new double[3];
            double count = 0;
            for (int x = 0; x < colorHeaderBitmap.Width; x += 2)
            {
                for (int y = 0; y < colorHeaderBitmap.Height; y += 2)
                {
                    Color pixel = colorHeaderBitmap.GetPixel(x, y);
                    avgCardColor[0] += pixel.R;
                    avgCardColor[1] += pixel.G;
                    avgCardColor[2] += pixel.B;
                    count++;
                }
            }

            Color cardColor = Color.FromArgb(0, (int)(avgCardColor[0] / count), (int)(avgCardColor[1] / count), (int)(avgCardColor[2] / count));

            List<char>[] cardColorList = new List<char>[3];
            cardColorList[0] = new List<char>();
            cardColorList[1] = new List<char>();
            cardColorList[2] = new List<char>();

            //Average RGB values based on testing (Multi was not tested)

            CharColor[] avgTestedRGB = new CharColor[7];
            avgTestedRGB[0] = new CharColor('R', Color.FromArgb(0, 118, 70, 74));//Red
            avgTestedRGB[1] = new CharColor('G', Color.FromArgb(0, 100, 113, 113));//Green
            avgTestedRGB[2] = new CharColor('U', Color.FromArgb(0, 78, 107, 142));//Blue
            avgTestedRGB[3] = new CharColor('B', Color.FromArgb(0, 70, 63, 72));//Black
            avgTestedRGB[4] = new CharColor('W', Color.FromArgb(0, 134, 125, 116));//White
            avgTestedRGB[5] = new CharColor('N', Color.FromArgb(0, 125, 133, 142));//None
            avgTestedRGB[6] = new CharColor('M', Color.FromArgb(0, 194, 177, 93));//Multi (not confirmed)


            int range = 10;
            bool colorFound = false;
            bool rangeTooBig = false;
            bool lastLoop = false;

            List<char> theCardColor = new List<char>();

            while (!colorFound)
            {
                cardColorList[0].Clear();
                cardColorList[1].Clear();
                cardColorList[2].Clear();
                for (int colorDex = 0; colorDex < avgTestedRGB.Count(); colorDex++)
                {
                    //Checks if average R is within range of tested colors
                    if (avgTestedRGB[colorDex].cardColor.R - range < cardColor.R && avgTestedRGB[colorDex].cardColor.R + range > cardColor.R)
                    {
                        cardColorList[0].Add(avgTestedRGB[colorDex].colorChar);
                    }
                    //Checks if average G is within range of tested colors
                    if (avgTestedRGB[colorDex].cardColor.G - range < cardColor.G && avgTestedRGB[colorDex].cardColor.G + range > cardColor.G)
                    {
                        cardColorList[1].Add(avgTestedRGB[colorDex].colorChar);
                    }
                    //Checks if average B is within range of tested colors
                    if (avgTestedRGB[colorDex].cardColor.B - range < cardColor.B && avgTestedRGB[colorDex].cardColor.B + range > cardColor.B)
                    {
                        cardColorList[2].Add(avgTestedRGB[colorDex].colorChar);
                    }
                }
                theCardColor = cardColorList[0].Intersect(cardColorList[1].Intersect(cardColorList[2].ToList())).ToList();
                if (theCardColor.Contains('N'))
                {

                }
                if (theCardColor.Count() == 1)
                {
                    colorFound = true;
                }
                else if (theCardColor.Count() == 0)
                {
                    if (!rangeTooBig)
                    {
                        range += 5;
                    }
                    else
                    {
                        range += 1;
                        lastLoop = true;
                    }
                }
                else if (lastLoop == true)
                {
                    colorFound = true;
                }
                else
                {
                    range -= 1;
                    rangeTooBig = true;
                }

                
            }

            //Cards with no color and cards that are green are too close on RGB spectrum
            if (theCardColor.Contains('N') && !theCardColor.Contains('W'))
            {
                theCardColor.Add('W');
            }
            else if (theCardColor.Contains('W') && !theCardColor.Contains('N'))
            {
                theCardColor.Add('N');
            }

            return theCardColor;
        }

        public void addToList(cardWrapper sentCard)
        {
            //hide table during row creation
            review_cards_table.Visible = false;

            //offset rows
            int rowOffset = review_cards_table.RowCount;

            //increment rows
            review_cards_table.RowCount ++;

            //create a new row
            review_cards_table.RowStyles.Add(new RowStyle() { SizeType = SizeType.Absolute, Height = 50 });

            //if card not in list add to list - mainly used for updating card info
            if(!cards.Contains(sentCard)) cards.Add(sentCard);
            
            /*
             * each cell in the row is tagged with sentCard
             * the row color is set to the sentCard status
             */
            //create checkbox
            var tempCheck = new CheckBox() { CheckAlign = ContentAlignment.MiddleCenter, Dock = DockStyle.Fill, BackColor = sentCard.cardStatus, Tag = sentCard, Margin = new Padding(0, 0, 0, 0) };
            tempCheck.CheckStateChanged += new EventHandler(cardCheckChanged);
            review_cards_table.Controls.Add(tempCheck, 0, review_cards_table.RowCount - 1);

            //create name label
            var tempLabel = new Label() { Text = sentCard.card.name, AutoEllipsis = true, AutoSize = true, TextAlign = ContentAlignment.MiddleCenter, Anchor = AnchorStyles.None, Dock = DockStyle.Fill, Margin = new Padding(0, 0, 0, 0), BackColor = sentCard.cardStatus, Tag = sentCard };
            tempLabel.Click += new EventHandler(Label_Clicked);
            review_cards_table.Controls.Add(tempLabel, 1, rowOffset);

            //create type label
            tempLabel = new Label() { Text = sentCard.card.type, AutoEllipsis = true, AutoSize = true, TextAlign = ContentAlignment.MiddleCenter, Anchor = AnchorStyles.None, Dock = DockStyle.Fill, Margin = new Padding(0, 0, 0, 0), BackColor = sentCard.cardStatus, Tag = sentCard };
            tempLabel.Click += new EventHandler(Label_Clicked);
            review_cards_table.Controls.Add(tempLabel, 2, rowOffset);

            //create set label
            tempLabel = new Label() { Text = sentCard.card.setCode, AutoEllipsis = true, AutoSize = true, TextAlign = ContentAlignment.MiddleCenter, Anchor = AnchorStyles.None, Dock = DockStyle.Fill, Margin = new Padding(0, 0, 0, 0), BackColor = sentCard.cardStatus, Tag = sentCard };
            tempLabel.Click += new EventHandler(Label_Clicked);
            review_cards_table.Controls.Add(tempLabel, 3, rowOffset);

            //create number label
            tempLabel = new Label() { Text = sentCard.card.number, AutoEllipsis = true, AutoSize = true, TextAlign = ContentAlignment.MiddleCenter, Anchor = AnchorStyles.None, Dock = DockStyle.Fill, Margin = new Padding(0, 0, 0, 0), BackColor = sentCard.cardStatus, Tag = sentCard };
            tempLabel.Click += new EventHandler(Label_Clicked);
            review_cards_table.Controls.Add(tempLabel, 4, rowOffset);

            //create mana label
            tempLabel = new Label() { Text = sentCard.card.manaCost, AutoEllipsis = true, AutoSize = true, TextAlign = ContentAlignment.MiddleCenter, Anchor = AnchorStyles.None, Dock = DockStyle.Fill, Margin = new Padding(0, 0, 0, 0), BackColor = sentCard.cardStatus, Tag = sentCard };
            tempLabel.Click += new EventHandler(Label_Clicked);
            review_cards_table.Controls.Add(tempLabel, 5, rowOffset);

            //make table visible
            review_cards_table.Visible = true;
        }


        private void cardCheckChanged(Object sender, EventArgs eventArgs)
        {
            var temp = sender as CheckBox; //checkbox holder

            //if checked
            if (temp.Checked)
            {
                //add tag to selected cards list
                selectedCards.Add(temp.Tag as cardWrapper);
            }
            else
            {
                //remove tag from selected cards list
                selectedCards.Remove(temp.Tag as cardWrapper);
            }
        }

        private void Label_Clicked(Object sender, EventArgs eventArgs)
        {
            //get card data from sender
            var returnCard = (sender as Label).Tag as cardWrapper;

            //set current card to the clicked card
            currentCard = returnCard;

            //set card preview to card info
            card_preview_box.Image = currentCard.tempImg;
            CardName.Text = returnCard.card.name;
            Card_Set_Combobox.Text = returnCard.card.setCode;
            Card_Type_TextBox.Text = returnCard.card.type;
            if (returnCard.card.text != "n/a" && returnCard.card.text != null)
            {
                cardTextTextbox.Visible = true;
                cardTextLabel.Visible = true;
                cardTextTextbox.Text = returnCard.card.text;
            }
            else
            {
                cardTextLabel.Visible = false;
                cardTextTextbox.Visible = false;
            }

            if (returnCard.card.flavorText != "n/a" && returnCard.card.flavorText != null)
            {
                cardFlavorLabel.Visible = true;
                cardFlavorTextbox.Visible = true;
                cardFlavorTextbox.Text = returnCard.card.flavorText;
            }
            else
            {
                cardFlavorLabel.Visible = false;
                cardFlavorTextbox.Visible = false;
            }

            if (returnCard.card.loyalty != "n/a" && returnCard.card.loyalty != null)
            {
                cardLoyaltyLabel.Visible = true;
                cardPTLabel.Visible = false;
                cardPTLTextbox.Visible = true;
                cardPTLTextbox.Text = returnCard.card.loyalty;
            }
            else if (returnCard.card.power != "n/a" && returnCard.card.power != null)
            {
                cardPTLabel.Visible = true;
                cardPTLTextbox.Visible = true;
                cardLoyaltyLabel.Visible = false;
                cardPTLTextbox.Text = returnCard.card.power + "/" + returnCard.card.toughness;
            }
            else
            {
                cardPTLabel.Visible = false;
                cardPTLTextbox.Visible = false;
                cardLoyaltyLabel.Visible = false;
            }
        }

        /*
         * finds card with name in database
         */
        private cardWrapper findCardWithName(string cardName)
        {
            cardWrapper returnCard = new cardWrapper(); //card to be returned
            cardWrapper tempWrapper = new cardWrapper(); //temporary card for querying purposes

            //open connection
            connection.Open();

            //get all cards that contain the name
            using (var cmd = new NpgsqlCommand("get_cards_containing_name", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("in_name", cardName);
                var reader = cmd.ExecuteReader();
                int rowsAffected = 0; //number of rows returned

                //for each row
                while(reader.Read())
                {
                    //ignores foils and prerelease versions
                    if(reader[2].ToString().Contains("FOIL") || reader[2].ToString().Contains("PRERELEASE"))
                    rowsAffected++;
                }

                //if multiple cards
                if(rowsAffected > 1)
                {
                    //marks card for review
                    tempWrapper.cardStatus = Color.FromArgb(255, 102, 102, 70);//brown gold
                }
                else
                {
                    //marks card as normal
                    tempWrapper.cardStatus = this.BackColor;
                }
            }

            //close connection
            connection.Close();

            //open connection
            connection.Open();

            //finds card with exact name not case-sensitive
            using (var cmd = new NpgsqlCommand("get_card_with_name", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("in_name", cardName);

                CardObject tempCard = new CardObject(); //holds card data

                //get card ID
                tempCard.cardID = Convert.ToInt32(cmd.ExecuteScalar());

                //set return card
                returnCard.card = tempCard;
            }

            //close connection
            connection.Close();

            //open connection
            connection.Open();

            //gets card with card ID
            using (var cmd = new NpgsqlCommand("SELECT * FROM public.card WHERE card_id = " + returnCard.card.cardID, connection))
            {
                NpgsqlDataReader reader = cmd.ExecuteReader();

                //reads the card data into the return card
                while (reader.Read())
                {
                    string temp;
                    CardObject tempCard = new CardObject();
                    tempCard.cardID = Convert.ToInt32(reader[0].ToString());
                    tempCard.name = reader[2].ToString();
                    tempCard.type = reader[3].ToString();
                    tempCard.manaCost = reader[4].ToString();
                    tempCard.setCode = reader[5].ToString();
                    tempCard.multiverseId = Convert.ToInt32(reader[9].ToString());
                    tempCard.power = reader[10].ToString();
                    tempCard.toughness = reader[11].ToString();

                    temp = reader[13].ToString().TrimEnd('}');
                    temp = temp.TrimStart('{');
                    tempCard.colors = temp.Split(',').ToList<string>();

                    temp = reader[14].ToString().TrimEnd('}');
                    temp = temp.TrimStart('{');
                    tempCard.colorIdentity = temp.Split(',').ToList<string>();

                    tempCard.text = reader[15].ToString();
                    tempCard.convertedManaCost = float.Parse(reader[16].ToString());

                    tempCard.flavorText = reader[17].ToString();
                    tempCard.rarity = reader[18].ToString();
                    tempCard.borderColor = reader[19].ToString();
                    tempCard.loyalty = reader[20].ToString();
                    tempCard.artist = reader[21].ToString();
                    tempCard.number = reader[24].ToString();

                    tempWrapper.card = tempCard;

                    returnCard = tempWrapper;
                    Card_Set_Combobox.Items.Add(tempCard.setCode);
                    CardName.Items.Add(tempCard.name);
                }
            }

            //close connection
            connection.Close();

            //if card is valid
            if (returnCard.card != null)
            {
                //report success
                transcribed_textbox.Text += " Success!";
            }
            else
            {
                //report failure
                transcribed_textbox.Text += " Failed!";
            }

            //set card preview data to the returned card's data
            CardName.Text = returnCard.card.name;
            Card_Set_Combobox.Text = returnCard.card.setCode;
            Card_Type_TextBox.Text = returnCard.card.type;
            if (returnCard.card.text != "n/a")
            {
                cardTextTextbox.Visible = true;
                cardTextLabel.Visible = true;
                cardTextTextbox.Text = returnCard.card.text;
            }
            else
            {
                cardTextLabel.Visible = false;
                cardTextTextbox.Visible = false;
            }

            if (returnCard.card.flavorText != "n/a")
            {
                cardFlavorLabel.Visible = true;
                cardFlavorTextbox.Visible = true;
                cardFlavorTextbox.Text = returnCard.card.flavorText;
            }
            else
            {
                cardFlavorLabel.Visible = false;
                cardFlavorTextbox.Visible = false;
            }

            if(returnCard.card.loyalty != "n/a")
            {
                cardLoyaltyLabel.Visible = true;
                cardPTLabel.Visible = false;
                cardPTLTextbox.Visible = true;
                cardPTLTextbox.Text = returnCard.card.loyalty;
            }
            else if(returnCard.card.power != "n/a")
            {
                cardPTLabel.Visible = true;
                cardPTLTextbox.Visible = true;
                cardLoyaltyLabel.Visible = false;
                cardPTLTextbox.Text = returnCard.card.power + "/" + returnCard.card.toughness;
            }
            else
            {
                cardPTLabel.Visible = false;
                cardPTLTextbox.Visible = false;
                cardLoyaltyLabel.Visible = false;
            }

            //set card image
            returnCard.tempImg = (Bitmap)card_preview_box.Image.Clone();

            //set current card
            currentCard = returnCard;

            //return
            return returnCard;
        }

        /*
         * adds the currently selected cards to the inventory
         */
        private void Add_Cards_To_Inventory()
        {
            bool exists = false; //holds whether or not the card is already in the inventory table

            //for each selected card
            for (int i = 0; i < selectedCards.Count; i++)
            {

                //if cards status is not red
                if(selectedCards[i].cardStatus != Color.FromArgb(255, 66, 49, 57))
                {
                    //reset exists flag
                    exists = false;

                    //open database connection
                    connection.Open();

                    //transaction query
                    using (var cmd = new NpgsqlCommand("new_trans_event", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("in_foreign_card_id", selectedCards[i].card.cardID);
                        cmd.Parameters.AddWithValue("in_foreign_user_id", CurrentUser.user_ID);
                        cmd.Parameters.AddWithValue("in_datetime", DateTime.Now);
                        cmd.Parameters.AddWithValue("in_trans_type", 1);

                        //executes query
                        cmd.ExecuteScalar();
                    }

                    //close connection
                    connection.Close();

                    //open connection
                    connection.Open();

                    //inventory query
                    using (var cmd = new NpgsqlCommand("SELECT * FROM public.inventory WHERE card_id = " + selectedCards[i].card.cardID, connection))
                    {
                        NpgsqlDataReader reader = cmd.ExecuteReader();

                        //finds out if card is in inventory
                        if (reader.HasRows)
                        {
                            exists = true;
                        }
                    }

                    //close connection
                    connection.Close();

                    //if the card is in inventory
                    if (exists)
                    {
                        //open connection
                        connection.Open();

                        //add to the current inventory count
                        using (var cmd = new NpgsqlCommand("update_inv_count", connection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("in_foreign_card_id", selectedCards[i].card.cardID);
                            cmd.Parameters.AddWithValue("in_new_count", 1);

                            cmd.ExecuteScalar();
                        }

                        //close connection
                        connection.Close();
                    }
                    else
                    {
                        //open connection
                        connection.Open();

                        //create a new inventory item for the card
                        using (var cmd = new NpgsqlCommand("new_inv_event", connection))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;

                            cmd.Parameters.AddWithValue("in_foreign_card_id", selectedCards[i].card.cardID);
                            cmd.Parameters.AddWithValue("in_new_count", 1);

                            cmd.ExecuteScalar();
                        }

                        //close connection
                        connection.Close();
                    }
                }
            }
        }

        
        private void EnterCardWithCondition(object sender, KeyEventArgs e)
        {
            //future card condition declaration
        }

        private void add_cards_Click(object sender, EventArgs e)
        {
            //if there are cards selected
            if (selectedCards.Count > 0)
            {
                Add_Cards_To_Inventory();
                deleteSelected();
            }

            //if webcam is never opened before closing
            if (frame != null)
            {
                //shutdown the webcam if application is closed
                frame.Stop(); 
            }
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            //delete selected cards
            deleteSelected();
        }

        /*
         * removes the selected cards from the table
         */
        private void deleteSelected()
        {
            //removes the selected cards from list
            while (selectedCards.Count > 0)
            {
                cards.Remove(selectedCards[0]);
                selectedCards.Remove(selectedCards[0]);
            }

            //resets table
            resetList();
        }

        private void CardName_SelectedIndexChanged(object sender, EventArgs e)
        {
            //resets timer
            searchTimer.Stop();

            //if the selected index is valid
            if (currentCard != null && foundCards.Count > CardName.SelectedIndex)
            {
                //sets selected card
                var selectedCard = foundCards[CardName.SelectedIndex];

                //resets card info
                currentCard.card = selectedCard.card; 
                currentCard.card_ID = selectedCard.card_ID;
                currentCard.condition = selectedCard.condition;
                currentCard.cardStatus = this.BackColor;

                //reset card list
                resetList();
            }
        }

        private void searchEventHandler(Object myObject, EventArgs eventArgs)
        {
            //stops timer
            searchTimer.Stop();

            //clears list of found cards
            foundCards.Clear();

            //repopultes list of found cards with new search
            foundCards = findCardsWithName(CardName.Text);

            //clears the card name items
            CardName.Items.Clear();

            //repopulates the card name items
            for (int i = 0; i < foundCards.Count; i++)
            {
                CardName.Items.Add(foundCards[i].card.name + " " + foundCards[i].card.setCode);
            }

        }

        /*
         * resets review table
         */
        private void resetList()
        {
            //clears table rows and sets count to 0
            review_cards_table.Controls.Clear();
            review_cards_table.RowCount = 0;

            //repopulates the table with cards
            for (int i = 0; i < cards.Count; i++)
            {
                addToList(cards[i]);
            }
        }

        private void CardName_TextChanged(object sender, EventArgs e)
        {
            //if the new card name is valid
            if((CardName.Text != transcribed_textbox.Text) && (CardName.Text != "") && (CardName.Text.Length >= 3) && (CardName.SelectedText != CardName.Text))
            {
                //stop timer
                searchTimer.Stop();

                //start timer
                searchTimer.Start(); 
            }
            else
            {
                //stop timer
                searchTimer.Stop();
            }
        }

        /*
         * queries the database for cards with names containing the given string
         */
        private List<cardWrapper> findCardsWithName(string cardName)
        {
            List<cardWrapper> returnList = new List<cardWrapper>(); //list of cards to be returned

            List<int> tempIDs = new List<int>(); //temporary list of card ids 

            connection.Open(); //opens the database connection

            //database query
            using (var cmd = new NpgsqlCommand("get_cards_containing_name", connection))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("in_name", cardName);

                //get tuples
                var reader = cmd.ExecuteReader();

                
                //reads in the data from each tuple
                while(reader.Read())
                {
                    string temp;
                    cardWrapper tempWrapper = new cardWrapper();
                    CardObject tempCard = new CardObject();
                    tempCard.cardID = Convert.ToInt32(reader[0].ToString());
                    tempCard.name = reader[2].ToString();
                    tempCard.type = reader[3].ToString();
                    tempCard.manaCost = reader[4].ToString();
                    tempCard.setCode = reader[5].ToString();
                    tempCard.multiverseId = Convert.ToInt32(reader[9].ToString());
                    tempCard.power = reader[10].ToString();
                    tempCard.toughness = reader[11].ToString();

                    temp = reader[13].ToString().TrimEnd('}');
                    temp = temp.TrimStart('{');
                    tempCard.colors = temp.Split(',').ToList<string>();

                    temp = reader[14].ToString().TrimEnd('}');
                    temp = temp.TrimStart('{');
                    tempCard.colorIdentity = temp.Split(',').ToList<string>();

                    tempCard.text = reader[15].ToString();
                    tempCard.convertedManaCost = float.Parse(reader[16].ToString());

                    tempCard.flavorText = reader[17].ToString();
                    tempCard.rarity = reader[18].ToString();
                    tempCard.borderColor = reader[19].ToString();
                    tempCard.loyalty = reader[20].ToString();
                    tempCard.artist = reader[21].ToString();
                    tempCard.number = reader[24].ToString();

                    tempWrapper.card = tempCard;

                    returnList.Add(tempWrapper);
                }
            }

            connection.Close(); //closes database connection

            return returnList; //returns list of cards
        }

        private void Inventory_Checkbox_CheckedChanged(object sender, EventArgs e)
        {
            var temp = sender as CheckBox;

            if(temp.Checked) //if the checkbox is checked
            {
                //adds all cards to the selected list
                selectedCards.Clear();
                for(int i = 0; i < cards.Count; i++)
                {
                    selectedCards.Add(cards[i]);
                }

                //checks all the checkboxes in the table
                foreach(var cb in review_cards_table.Controls.OfType<CheckBox>())
                {
                    cb.Checked = true;
                }
            }
            else
            {
                //clears selected cards
                selectedCards.Clear();

                //unchecks all checkboxes in the table
                foreach (var cb in review_cards_table.Controls.OfType<CheckBox>())
                {
                    cb.Checked = false;
                }
            }
        }
    }

    public class CardIntPoints
    {

        public List<AForge.IntPoint> IntPoint_CornerList { get; set; }
        public List<PointF> PointF_CornerList { get; set; }
        public bool closetoIsoscelesTrap;
        public Bitmap alteredImg;
        

        public CardIntPoints(Bitmap image, Rectangle rect, int iterations)
        {
            ////////////////////////////////////
            // CARD EDGE DETECTION ALOGORITHM //
            ////////////////////////////////////
            IntPoint_CornerList = new List<AForge.IntPoint>();
            PointF_CornerList = new List<PointF>();
            closetoIsoscelesTrap = true;
            alteredImg = new Bitmap(image);

            if (iterations < 3)
            {
                iterations = 3;
            }


            int[,,] edgePoints = new int[4, iterations, 2];




            //Side Edge Detection Algorithm
            for (int yIndex = 0; yIndex < iterations; yIndex++)
            {
                int y = (((yIndex + 1) * (int)(rect.Height / (iterations + 1))) + rect.Y);

                bool edgeFound = false;
                int x = rect.X;
                
                int curColor = 0;

                //Left side edge detection
                int xStart = x;
                while (!edgeFound && x < rect.X + rect.Width - 1)
                {
                    Color pixel = image.GetPixel(x, y);
                    curColor = pixel.R + pixel.G + pixel.B;
                    if (curColor > 400)//White
                    {
                        if (x == xStart)
                        {
                            if (xStart - 10 < 0)
                            {
                                x = 0;
                                edgeFound = true;
                            }
                            else
                            {
                                x = xStart - 10;
                                xStart -= 10;
                            }

                        }
                        else
                        {
                            edgePoints[0, yIndex, 0] = x;
                            edgePoints[0, yIndex, 1] = -y;
                            edgeFound = true;
                            alteredImg.SetPixel(x, y, Color.Red);
                        }
                    }
                    else//Black
                    {
                        x += 1;
                    }

                }

                edgeFound = false;
                x = rect.X + rect.Width - 1;
                curColor = 0;

                //Right side edge detection
                xStart = x;
                while (!edgeFound && x > rect.X + 1)
                {
                    Color pixel = image.GetPixel(x, y);
                    curColor = pixel.R + pixel.G + pixel.B;
                    if (curColor > 400)//White
                    {
                        if (x == xStart)
                        {
                            if (xStart + 10 > image.Width - 1)
                            {
                                x = image.Width - 1;
                                edgeFound = true;
                            }
                            else
                            {
                                x = xStart + 10;
                                xStart += 10;
                            }

                        }
                        else
                        {
                            edgePoints[1, yIndex, 0] = x;
                            edgePoints[1, yIndex, 1] = -y;
                            edgeFound = true;
                            alteredImg.SetPixel(x, y, Color.Red);
                        }
                    }
                    else//Black
                    {
                        x -= 1;
                    }

                }

            }

            //Top/Bottom Edge Detection Algorithm
            for (int xIndex = 0; xIndex < iterations; xIndex++)
            {
                int x = (((xIndex + 1) * (int)(rect.Width / (iterations + 1))) + rect.X);

                bool edgeFound = false;
                int y = rect.Y;
                int curColor = 0;


                //Top edge detection
                int yStart = y;
                while (!edgeFound && y < rect.Y + rect.Height - 1)
                {
                    Color pixel = image.GetPixel(x, y);
                    curColor = pixel.R + pixel.G + pixel.B;
                    if (curColor > 400)//White
                    {
                        if (y == yStart)
                        {
                            if (yStart - 10 < 0)
                            {
                                y = 0;
                                edgeFound = true;
                            }
                            else
                            {
                                y = yStart - 10;
                                yStart -= 10;
                            }

                        }
                        else
                        {
                            edgePoints[2, xIndex, 0] = x;
                            edgePoints[2, xIndex, 1] = -y;
                            edgeFound = true;
                            alteredImg.SetPixel(x, y, Color.Red);
                        }
                    }
                    else//Black
                    {
                        y += 1;
                    }

                }

                edgeFound = false;
                y = rect.Y + rect.Height - 1;
                curColor = 0;

                //Bottom edge detection
                yStart = y;
                while (!edgeFound && y > rect.Y + 1)
                {
                    Color pixel = image.GetPixel(x, y);
                    curColor = pixel.R + pixel.G + pixel.B;
                    alteredImg.SetPixel(x, y, Color.Red);
                    if (curColor > 400)//White
                    {
                        if (y == yStart)
                        {
                            if (yStart + 10 > image.Height - 1)
                            {
                                y = image.Height - 1;
                                edgeFound = true;
                            }
                            else
                            {
                                y = yStart + 10;
                                yStart += 10;
                            }

                        }
                        else
                        {
                            edgePoints[3, xIndex, 0] = x;
                            edgePoints[3, xIndex, 1] = -y;
                            edgeFound = true;
                            alteredImg.SetPixel(x, y, Color.Red);
                        }
                    }
                    else//Black
                    {
                        y -= 1;
                    }

                }

            }

            //0:left, 1:Right, 2:Top, 3:Bottom
            int iterationMid = (int)(iterations / 2);
            int iterationDex = 0;
            double[] avgSlope = new double[4];
            double[] yIntercept = new double[4];
            double deviance = 0.02;


            //for each side
            for (int i = 0; i < 4; i++)
            {
                //for each iteration
                bool passedCorner = false;
                int sampleCount = 0;
                iterationDex = iterationMid;
                while (iterationDex < iterations - 1 && !passedCorner)
                {
                    double slope = ((double)edgePoints[i, iterationDex, 1] - (double)edgePoints[i, iterationDex + 1, 1]) / ((double)edgePoints[i, iterationDex, 0] - (double)edgePoints[i, iterationDex + 1, 0]);
                    if (avgSlope[i] == 0)
                    {
                        sampleCount++;
                        avgSlope[i] = avgSlope[i] + slope;
                    }
                    else if (avgSlope[i] < 0)
                    {
                        if ((avgSlope[i] / sampleCount) * (1.0 - deviance) > slope && (avgSlope[i] / sampleCount) * (1.0 + deviance) < slope)
                        {
                            sampleCount++;
                            avgSlope[i] = avgSlope[i] + slope;
                        }
                        else
                        {
                            passedCorner = true;
                        }
                    }
                    else
                    {
                        if ((avgSlope[i] / sampleCount) * (1.0 - deviance) < slope && (avgSlope[i] / sampleCount) * (1.0 + deviance) > slope)
                        {
                            sampleCount++;
                            avgSlope[i] = avgSlope[i] + slope;
                        }
                        else
                        {
                            passedCorner = true;
                        }
                    }
                    iterationDex++;
                }
                passedCorner = false;
                iterationDex = iterationMid;
                while (iterationDex > 0 + 1 && !passedCorner)
                {
                    double slope = ((double)edgePoints[i, iterationDex, 1] - (double)edgePoints[i, iterationDex - 1, 1]) / ((double)edgePoints[i, iterationDex, 0] - (double)edgePoints[i, iterationDex - 1, 0]);
                    if (avgSlope[i] < 0)
                    {
                        if ((avgSlope[i] / sampleCount) * (1.0 - deviance) > slope && (avgSlope[i] / sampleCount) * (1.0 + deviance) < slope)
                        {
                            sampleCount++;
                            avgSlope[i] = avgSlope[i] + slope;
                        }
                        else
                        {
                            passedCorner = true;
                        }
                    }
                    else
                    {
                        if ((avgSlope[i] / sampleCount) * (1.0 - deviance) < slope && (avgSlope[i] / sampleCount) * (1.0 + deviance) > slope)
                        {
                            sampleCount++;
                            avgSlope[i] = avgSlope[i] + slope;
                        }
                        else
                        {
                            passedCorner = true;
                        }
                    }
                    iterationDex--;
                }


                avgSlope[i] /= (double)sampleCount;
                //  b = y - (m * x)
                yIntercept[i] = (double)edgePoints[i, iterationDex, 1] - (avgSlope[i] * (double)edgePoints[i, iterationDex, 0]);
            }

            //02, 12, 13, 03
            int virtEdge = 0;
            for (int horzEdge = 2; horzEdge < 4;)
            {
                double xDub = 0.0;
                int yCorner = 0;
                int xCorner = 0;

                if (Double.IsInfinity(avgSlope[virtEdge]))
                {
                    xCorner = edgePoints[virtEdge, 0, 0];
                    yCorner = (int)(-((avgSlope[horzEdge] * xCorner) + yIntercept[horzEdge]));
                    if (yCorner < 0)
                    {
                        yCorner = 0;
                    }
                    else if (yCorner > (image.Height))
                    {
                        yCorner = (-image.Height);
                    }
                }
                else
                {
                    xDub = ((yIntercept[horzEdge] - yIntercept[virtEdge]) / (avgSlope[virtEdge] - avgSlope[horzEdge]));
                    yCorner = (int)(-((avgSlope[horzEdge] * xDub) + yIntercept[horzEdge]));
                    xCorner = (int)xDub;
                }

                if (yCorner >= 0 && xCorner >= 0)//Check for too large
                {
                    this.IntPoint_CornerList.Add(new AForge.IntPoint(xCorner, yCorner));
                    this.PointF_CornerList.Add(new PointF(xCorner, yCorner));
                    if (closetoIsoscelesTrap)
                    {
                        double thetaDeg = (Math.Atan(Math.Abs((double)((avgSlope[horzEdge] - avgSlope[virtEdge]) / (1 + (avgSlope[horzEdge] * avgSlope[virtEdge]))))))/(Math.PI/180);
                        int thetaRange = 20;
                        if (thetaDeg < 90 - thetaRange || thetaDeg > 90 + thetaRange)
                        {
                            closetoIsoscelesTrap = false;
                        }
                    }
                }

                //even
                if ((virtEdge + horzEdge) % 2 == 0)
                {
                    virtEdge = (virtEdge + 1) % 2;
                }
                else//odd
                {
                    horzEdge += 1;
                }
            }

            
        }
        ~CardIntPoints()
        {
        }
    }

    public class cardWrapper
    {
        public CardObject card;
        public char foil, prerelease;
        public int count, card_ID;
        public char condition;
        public Color cardStatus;
        public Bitmap tempImg;

        public cardWrapper()
        {
            foil = 'n';
            prerelease = 'n';
        }

        ~cardWrapper()
        {
            card = null;
        }
    }
}
