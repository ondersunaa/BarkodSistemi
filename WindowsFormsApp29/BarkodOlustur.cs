using Ean13Barcode2005;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp29
{
    public partial class BarkodOlustur : Form
    {
        public BarkodOlustur()
        {
            InitializeComponent();
        }
        Random r = new Random();
        private void button1_Click(object sender, EventArgs e)
        {
            Ean13 barcode = new Ean13();
            barcode.CountryCode = "90";
            barcode.ManufacturerCode = r.Next(10000,99999).ToString();
            Random r2 = new Random();
            barcode.ProductCode = r2.Next(10000,99999).ToString();
            barcode.ChecksumDigit = r2.Next(1,10).ToString();
            pictureBox1.Image = barcode.CreateBitmap();
        }

        private void BarkodOlustur_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += new PrintPageEventHandler(Doc_PrintPage);

            doc.Print();
        }

        private void Doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Font drawFont = new Font("Arial", 16);

            SolidBrush drawBrush = new SolidBrush(Color.Black);

            Pen blackPen = new Pen(Color.Black);

            StringFormat drawFormat = new StringFormat();

            drawFormat.Alignment = StringAlignment.Center;

            float x = 150.0F;

            float y = 150.0F;

            float width = 200.0F;

            float height = 50.0F;

            RectangleF drawRect = new RectangleF(x, y, width, height);

            

        }
    }
}
