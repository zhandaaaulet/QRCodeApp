using System;
using System.Windows.Forms;
using ZXing;
using ZXing.QrCode;

namespace QRCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var options = new QrCodeEncodingOptions
            {
                Height = pictureBox1.Height,
                Width = pictureBox1.Width
            };
            //create instance of BarcocodeWrider
            var writer = new BarcodeWriter
            {
                //set format
                Format = BarcodeFormat.QR_CODE,
                Options = options
            };
            var text = textBox1.Text;
            var result = writer.Write(text);
            pictureBox1.Image = result;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string initialDIR = @"C:\Users\77071\OneDrive\Рабочий стол\QRCodeFiles";
            var dialog = new SaveFileDialog
            {
                InitialDirectory = initialDIR,
                Filter = "PNG|*.png|JPEG|*.jpg|BMP|*.bmp|GIF|*.gif"
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image.Save(dialog.FileName);
                var result = $"Your QR code has been successfully saved! Please check it out.";
                button3.Text = result;

            }
        }
    }
}
