using AForge.Video;
using AForge.Video.DirectShow;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

using System.Drawing;
using System.Linq;
using System.Text;
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
    public partial class Form1 : Form
    {
        NpgsqlConnection connection = new NpgsqlConnection("Host=localhost; Port=5432;User Id=postgres;Password=tcgdigitizer;Database=TCGDigitizer");
        public Review callingForm;
        public Edit_Card_Form sendingForm;
        VideoCaptureDevice frame = null;
        FilterInfoCollection Devices;
        String Photo_Filepath = "C:\\Users\\milee\\OneDrive\\Pictures";
        
        public cardWrapper currentCard = new cardWrapper();
        List<cardWrapper> cardList;
        List<cardWrapper> cards = new List<cardWrapper>();
        CardService service = new CardService();

        public object DisplayInformation { get; private set; }

        public Form1()
        {
            InitializeComponent();
            var position = this.PointToScreen(Card_Boarder.Location);
            position = Cam_Picture_Box.PointToClient(position);
            Card_Boarder.Parent = Cam_Picture_Box;
            Card_Boarder.Location = position;
            Card_Boarder.Visible = false;
        }

        void Start_cam()
        {
            Devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            for(int i = 0; i < Devices.Count; i++)
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
                textBox1.Text = "TCG Digitizer camera not found!";
                frame = null;
            }
            else
            {
                frame.NewFrame += new AForge.Video.NewFrameEventHandler(NewFrame_event);
                frame.Start();
            }
        }

        void NewFrame_event(object send,NewFrameEventArgs e)
        {
            try
            {
                Cam_Picture_Box.Image = (Image)e.Frame.Clone();
            }
            catch (Exception ex) { }
        }

        void Adjust_Tesseract_Img(int contrast_threshold/*{-100, 100}*/, Bitmap nameHeaderBitmap)
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


                    //nameHeaderBitmap.SetPixel(x, y, Color.FromArgb(a, pixAvg, pixAvg, pixAvg));
                    nameHeaderBitmap.SetPixel(x, y, Color.FromArgb(pixel.A, (int)r, (int)g, (int)b)); 
                }
            }     
            return;
        }

        private void Open_Button(object sender, EventArgs e)
        {
            /*OpenFileDialog openfile = new OpenFileDialog();

            if (openfile.ShowDialog() == DialogResult.OK)
            {
                var img = new Bitmap(openfile.FileName);
                try
                {

                    Display_Picture_Box.Image = img;
                    Name_Header_Pic_Box.Image = img;
                    string textBoxString;
                    
                    //creation of tesseract settings and retreival varibles
                    var ocr = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractAndCube);
                    var page = ocr.Process(img);

                    textBoxString = page.GetText();
                    textBoxString = textBoxString.Trim(' ', '\n');
                    //
                    textBox1.Text = textBoxString;
                    //
                    var result = service.Where(x => x.Name, textBoxString);
                    middleMan = result.All().Value;
                    if (middleMan.Count < 1)
                    {
                        textBox1.Text = "Card not valid, try manual entry.";
                    }
                    else if (middleMan.Count > 1)
                    {
                        for (int i = 0; i < middleMan.Count; i++)
                        {
                            if (middleMan[i].Name == textBox1.Text)
                            {
                                if (currentCard.card == null || currentCard.card.Name != middleMan[i].Name)
                                    currentCard.card = middleMan[i];
                                else
                                    currentCard.printing.Add(middleMan[i].Set);
                            }
                        }
                        cards.Add(currentCard);
                    }
                    else
                    {
                        currentCard.card = middleMan[0];
                        cards.Add(currentCard);
                    }
                    textBox1.Text = textBoxString;
                }
                catch (Exception ex) { }
            }*/
        }

        private void Tess_TextBox(object sender, EventArgs e)
        {
            if (textBox1.Text.Length < 1)
            {
                Search_Card_Button.Enabled = false;
            }
            else
            {
                Search_Card_Button.Enabled = true;
            }
        }

 

        private void Take_Picture_Button_Click(object sender, EventArgs e)
        {
            if (Photo_Filepath != null && Cam_Picture_Box.Image != null)
            {
                try
                {
                    //picture from web cam
                    Bitmap originalImg = (Bitmap)Cam_Picture_Box.Image.Clone();
                    //rotate 90 degrees
                    originalImg.RotateFlip(RotateFlipType.Rotate90FlipNone);
    
                    //Dim of saved image
                    int xStart = 1;
                    int yStart = 1;
                    int xEnd = originalImg.Width - xStart;
                    int yEnd = originalImg.Height - yStart;
                    int xWidth = (xEnd - xStart);
                    int yHeight = (yEnd - yStart);

                    //Establishing size of crop area based off original image (x,y,width,height)
                    //All percents are measured/calulated ratios based off card dimensions
                    Rectangle nameHeaderCropRect = new Rectangle(Convert.ToInt32((xWidth * 0.08/*0.063786008*/) + xStart), Convert.ToInt32((yHeight * 0.055/*0.040481481*/) + yStart), Convert.ToInt32(xWidth * 0.69753086), Convert.ToInt32(yHeight * 0.06/*0.05037037*/));
                    
                    //Bitmap that will store altered image (width,height)
                    Bitmap nameHeaderBitmap = new Bitmap(nameHeaderCropRect.Width, nameHeaderCropRect.Height);
                    
                    //blank bitmap to graphics object. ready for changes
                    Graphics nameHeadGraphics = Graphics.FromImage(nameHeaderBitmap);
                    
                    //original image cropped to two different images
                    nameHeadGraphics.DrawImage(originalImg, 0, 0, nameHeaderCropRect, GraphicsUnit.Pixel);

                    //calls picture alteration function to increase contrast and adjust image color
                    Adjust_Tesseract_Img(15, nameHeaderBitmap);

                    //displays original image in picture preview box
                    Display_Picture_Box.Image = originalImg;
                    //displays name header image in name header picture box
                    Name_Header_Pic_Box.Image = nameHeaderBitmap;

                    //will hold tesseract return string
                    string textBoxString;
                    var ocr = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractAndCube);
                    var page = ocr.Process(nameHeaderBitmap);//sends name header bitmap to tesseract
                    textBoxString = page.GetText();//gets tesseract text
                    textBox1.Text = textBoxString;
                    textBoxString = textBoxString.Trim(' ', '\n');//removes spaces and return characters

                    cards = findCardsWithName(textBoxString);
                }
                catch (Exception ex) { }//need to add exception functionality
            }
        }

        private void Stop_Video_Button_Click(object sender, EventArgs e)
        {

            Card_Boarder.Visible = false;
            if (frame != null)//if webcam is never opened before closing
            {
                frame.Stop(); //I shutdown the webcam if application is closed
            }
            Cam_Picture_Box.Image = null;
        }

        private void Start_Video_Button_Click(object sender, EventArgs e)
        {
            Start_cam();
        }

        private void Webcam_Feed_Box(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (frame != null)//if webcam is never opened before closing
            {
                frame.Stop(); //I shutdown the webcam if application is closed
            }
        }

        private void Display_Picture_Box_Click(object sender, EventArgs e)
        {

        }

        private void Card_Boarder_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Name_Header_Pic_Box_Click(object sender, EventArgs e)
        {

        }

        public cardWrapper getCard()
        {
            return currentCard;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (currentCard.card != null)
            {
                callingForm.addToList(cardList);
                /*var getImageForm = new Edit_Card_Form();
                sendingForm = getImageForm;
                sendingForm.populate(currentCard);
                getImageForm.Show();*/
                cardList.Clear();
                //Close();
            }
            if (frame != null)//if webcam is never opened before closing
            {
                frame.Stop(); //I shutdown the webcam if application is closed
            }
        }

        

        private void Output_Label_Click(object sender, EventArgs e)
        {

        }

        private void Search_Card_Button_Click(object sender, EventArgs e)
        {
            /*string searchString = textBox1.Text;
            Manual_Entry_Toggle.Checked = false;
            textBox1.Text = "Searching...";
            if (textBox1.Text.Length > 141)
            {
                textBox1.Text = "Card not found. Check for typos and try again.";
            }
            else
            {
                service.Where(x => x.Name, searchString);
                middleMan = service.All().Value;
                if (middleMan == null)
                {
                    textBox1.Text = "Card not found. Check for typos and try again.";
                }
                else if (middleMan.Count > 1)
                {
                    textBox1.Text = "Multiple cards found!";
                    for (int i = 0; i < middleMan.Count; i++)
                    {
                        if (middleMan[i].Name == textBox1.Text)
                        {
                            if (currentCard.card == null || currentCard.card.Name != middleMan[i].Name)
                            {
                                currentCard.card = middleMan[i];
                                textBox1.Text += "\r\n" + currentCard.card.Name;
                            }
                            else
                            {
                                currentCard.printing.Add(middleMan[i].Set);
                                textBox1.Text += "\r\n" + middleMan[i].Name + " - " + middleMan[i].Number.ToString();
                            }
                        }
                    }
                    cards.Add(currentCard);
                }
                else
                {
                    currentCard.card = middleMan[0];
                    cards.Add(currentCard);
                    textBox1.Text = "Card found!\r\n" + currentCard.card.Name;
                    Display_Picture_Box.ImageLocation = currentCard.card.ImageUrl.OriginalString;
                }
            }*/
        }

        private void Manual_Entry_Toggle_CheckedChanged(object sender, EventArgs e)
        {
            if (Manual_Entry_Toggle.Checked)
            {
                Output_Label.Text = "Card Name";
                textBox1.Text = "";
                textBox1.Multiline = false;
                textBox1.ReadOnly = false;
                Search_Card_Button.Visible = true;
            }
            else
            {
                Output_Label.Text = "Output";
                textBox1.ReadOnly = true;
                Search_Card_Button.Visible = false;
                textBox1.Multiline = true;
            }
        }

        private List<cardWrapper> findCardsWithName(string cardName)
        {
            List<cardWrapper> tempList = new List<cardWrapper>();

            connection.Open();

            var cmd = new NpgsqlCommand("SELECT * FROM public.card WHERE card_name ILIKE '" + cardName + "'", connection);

            NpgsqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                string temp;
                cardWrapper tempWrapper = new cardWrapper();
                CardObject tempCard = new CardObject();
                tempCard.cardID = System.Convert.ToInt32(reader[0].ToString());
                tempCard.name = reader[2].ToString();
                tempCard.type = reader[3].ToString();
                tempCard.manaCost = reader[4].ToString();
                tempCard.setCode = reader[5].ToString();
                tempCard.multiverseId = System.Convert.ToInt32(reader[9].ToString());
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

                tempList.Add(tempWrapper);
            }


            connection.Close();
            return tempList;
        }
    }

    public class cardWrapper
    {
        public CardObject card;
        public char foil, prerelease;
        public int count, card_ID;

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
