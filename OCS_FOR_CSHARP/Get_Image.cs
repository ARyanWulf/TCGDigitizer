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
        List<cardWrapper> cards = new List<cardWrapper>();
        List<cardWrapper> databaseList = new List<cardWrapper>();
        List<Bitmap> cardImages = new List<Bitmap>();
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
        }

 

        private void Take_Picture_Button_Click(object sender, EventArgs e)
        {
            if (Photo_Filepath != null && Cam_Picture_Box.Image != null)
            {
                CardObject tempCard = new CardObject();
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
                    textBoxString = textBoxString.Replace("â€”", "-");//removes endline characters
                    textBoxString = textBoxString.TrimStart(' ', '-', '_', '.', ',', '\'');//removes spaces
                    textBoxString = textBoxString.TrimEnd('\n', '.', ',', '-', '_');//removes endline characters
                    textBoxString = textBoxString.Trim(' ');//removes spaces
                    tempCard.name = textBoxString;

                    textBox1.Text += "\n" + textBoxString;
                    addToList(findCardsWithName(textBoxString));
                    cardImages.Add(originalImg);
                }
                catch (Exception ex)
                {

                }//need to add exception functionality
            }
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

        public void addToList(cardWrapper sentCard)
        {
            Card_Table_Panel.Visible = false;
            int rowOffset = Card_Table_Panel.RowCount;
            Card_Table_Panel.RowCount ++;
            //if (!Card_Table_Panel.AutoScroll) Card_Table_Panel.AutoScroll = true;
            cards.Add(sentCard);

            // begin popluating rows with cards
            // populate each row with a checkbox
            //Card_Table_Panel.Controls.Add(new CheckBox() { CheckAlign = ContentAlignment.MiddleCenter }, 0, Card_Table_Panel.RowCount - 1);
            Card_Table_Panel.Controls.Add(new Label() { Text = sentCard.card.name, AutoEllipsis = true }, 1, rowOffset);
            Card_Table_Panel.Controls.Add(new Label() { Text = sentCard.card.type, AutoEllipsis = true }, 2, rowOffset);
            Card_Table_Panel.Controls.Add(new Label() { Text = sentCard.card.setCode, AutoEllipsis = true }, 3, rowOffset);
            Card_Table_Panel.Controls.Add(new Label() { Text = sentCard.card.multiverseId.ToString(), AutoEllipsis = true }, 4, rowOffset);
            Card_Table_Panel.Controls.Add(new Label() { Text = sentCard.card.manaCost, AutoEllipsis = true }, 5, rowOffset);
            Card_Table_Panel.Controls.Add(new Label() { Text = "N/A", AutoEllipsis = true }, 6, rowOffset);
            Card_Table_Panel.Visible = true;
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
            if (cards.Count > 0)
            {
                Add_Cards_To_Inventory();
                Close();
            }
            else
            {
                MessageBox.Show("Error! No cards in queue, please scan something or press cancel.");
            }
            if (frame != null)//if webcam is never opened before closing
            {
                frame.Stop(); //I shutdown the webcam if application is closed
            }
        }

        private void Output_Label_Click(object sender, EventArgs e)
        {

        }

        private cardWrapper findCardsWithName(string cardName)
        {
            cardWrapper returnCard = new cardWrapper();

            returnCard.card = new CardObject();
            returnCard.card.cardID = -1;

            connection.Open();

            using (var cmd = new NpgsqlCommand("get_card_with_name", connection))
            {
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("in_name", cardName);

                cardWrapper tempWrapper = new cardWrapper();
                CardObject tempCard = new CardObject();

                tempCard.cardID = System.Convert.ToInt32(cmd.ExecuteScalar());
                tempWrapper.card = tempCard;
                returnCard = tempWrapper;
            }

            using (var cmd = new NpgsqlCommand("SELECT * FROM public.card WHERE card_id = " + returnCard.card.cardID, connection))
            {
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

                    returnCard = tempWrapper;
                }
            }
            connection.Close();

            if(returnCard.card.cardID != -1)
            {
                textBox1.Text += " Success!";
            }
            else
            {
                textBox1.Text += " Failed!";
            }

            return returnCard;
        }

        private void Add_Cards_To_Inventory()
        {
            bool exists = false;
            for (int i = 0; i < cards.Count; i++)
            {
                exists = false;
                connection.Open();

                using (var cmd = new NpgsqlCommand("new_trans_event", connection))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("in_foreign_card_id", cards[i].card.cardID);
                    cmd.Parameters.AddWithValue("in_foreign_user_id", CurrentUser.user_ID);
                    cmd.Parameters.AddWithValue("in_datetime", DateTime.Now);
                    cmd.Parameters.AddWithValue("in_trans_type", 1);

                    cmd.ExecuteScalar();
                }

                connection.Close();


                connection.Open();
                using (var cmd = new NpgsqlCommand("SELECT * FROM public.inventory WHERE card_id = " + cards[i].card.cardID, connection))
                {
                    NpgsqlDataReader reader = cmd.ExecuteReader();


                    if (reader.HasRows)
                    {
                        exists = true;
                    }
                }
                connection.Close();

                if (exists)
                {

                    connection.Open();
                    using (var cmd = new NpgsqlCommand("update_inv_count", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("in_foreign_card_id", cards[i].card.cardID);
                        cmd.Parameters.AddWithValue("in_new_count", 1);

                        cmd.ExecuteScalar();
                    }
                    connection.Close();
                }
                else
                {

                    connection.Open();
                    using (var cmd = new NpgsqlCommand("new_inv_event", connection))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("in_foreign_card_id", cards[i].card.cardID);
                        cmd.Parameters.AddWithValue("in_new_count", 1);

                        cmd.ExecuteScalar();
                    }
                    connection.Close();
                }

            }
        }


        private void EnterCardWithCondition(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)  
            {
                case Keys.N:

                    break;
            }
        }

        private void TakePicture()
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
                    textBoxString = textBoxString.Trim(' ');//removes spaces and return characters
                    textBoxString = textBoxString.Trim('\n');//removes spaces and return characters
                    textBoxString = textBoxString.Trim(' ');//removes spaces and return characters

                    cards.Add(findCardsWithName(textBoxString));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                    connection.Close();
                }//need to add exception functionality
            }
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (cards.Count > 0)
            {
                Add_Cards_To_Inventory();
                Close();
            }
            else
            {
                MessageBox.Show("Error! No cards in queue, please scan something or press cancel.");
            }
            if (frame != null)//if webcam is never opened before closing
            {
                frame.Stop(); //I shutdown the webcam if application is closed
            }
        }
    }



    public class cardWrapper
    {
        public CardObject card;
        public char foil, prerelease;
        public int count, card_ID;
        public char condition;
        public bool needsAttention;

        public cardWrapper()
        {
            foil = 'n';
            prerelease = 'n';
            needsAttention = false;
        }

        ~cardWrapper()
        {
            card = null;
        }
    }
}
