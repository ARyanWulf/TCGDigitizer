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
        VideoCaptureDevice frame;
        FilterInfoCollection Devices;
        String Photo_Filepath = "C:\\Users\\milee\\OneDrive\\Pictures";
        Card currentCard;
        CardService service = new CardService();

        public object DisplayInformation { get; private set; }

        public Form1()
        {
            InitializeComponent();
        }

        void Start_cam()
        {
            Devices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            frame = new VideoCaptureDevice(Devices[0].MonikerString);//may handle lack of camera error handle
            frame.NewFrame += new AForge.Video.NewFrameEventHandler(NewFrame_event);
            frame.Start();
        }
        void NewFrame_event(object send,NewFrameEventArgs e)
        {
            try
            {
                Picture_Box.Image = (Image)e.Frame.Clone();
            }
            catch (Exception ex) { }
        }

        private void open_button(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();

            if (openfile.ShowDialog() == DialogResult.OK)
            {
                var img = new Bitmap(openfile.FileName);
                var ocr = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractAndCube);
                var page = ocr.Process(img);
                textBox1.Text = page.GetText();
                textBox1.Text = textBox1.Text.Trim(' ', '\n');
                var result = service.Where(x => x.Name, textBox1.Text);
                textBox1.Text = result.All().Value[0].Text;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

 

        private void Take_Picture_Button_Click(object sender, EventArgs e)
        {
            if (Photo_Filepath != null && Picture_Box!= null)
            {

                Picture_Box.Image.Save(Photo_Filepath + "\\Image.png");
                var img = new Bitmap(Photo_Filepath + "\\Image.png");
                var ocr = new TesseractEngine("./tessdata", "eng", EngineMode.TesseractAndCube);
                var page = ocr.Process(img);
                textBox1.Text = page.GetText();
            }
        }

        private void Stop_Video_Button_Click(object sender, EventArgs e)
        {
            
            frame.Stop();
            Picture_Box = null;
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
            if (Picture_Box == null)
            {
                frame.Stop(); //I shutdown the webcam if application is closed
            }

        }
    }

   
}
