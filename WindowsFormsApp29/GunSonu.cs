using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp29.Model;

namespace WindowsFormsApp29
{
    public partial class GunSonu : Form
    {
        public GunSonu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string a, b, c;
            double az = 0 ,nakit =0, kredi=0 ;
            Satis satis = new Satis();
            DatabaseIslem di = new DatabaseIslem();
            a = dateTimePicker2.Value.ToString("yyyy/MM/dd");
            b = dateTimePicker1.Value.ToString("yyyy/MM/dd");
            string stoksorgusu = $"select * from Satis where '{b}'<= SatisTarihi and SatisTarihi <= '{a}'";
            DataTable dt = Sorgu.SQLSorguCalistir(stoksorgusu);
            dataGridView1.DataSource = di.SatisList(dt);
            foreach (DataRow item in dt.Rows)
            {
                az = Convert.ToInt32(item["SatisTipi"]);
                c = item["SatisTutar"].ToString();
                if (az == 1)
                {
                    nakit += Convert.ToDouble(c);
                }
                else
                {
                    kredi += Convert.ToDouble(c);
                }
            }
            label6.Text = nakit.ToString() + " TL";
            label7.Text = kredi.ToString() + " TL";
            label8.Text = (nakit + kredi).ToString()+" TL";
            dataGridView1.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridView1.Columns[0].DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns[2].DefaultCellStyle.BackColor = Color.Black;
            dataGridView1.Columns[0].DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.Columns[2].DefaultCellStyle.ForeColor = Color.White;
            dataGridView1.RowsDefaultCellStyle.Font = new Font("Comic Sans", 12, FontStyle.Bold);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.Red;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;


        }
    }
}
