using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AbdüsShop
{
    public partial class müsteriEkle : Form
    {
        public müsteriEkle()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=LAPTOP-M65KS4BD;Initial Catalog=db;Integrated Security=True");


        public void textboxSil()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            maskedTextBox1.Text = "";
            textBox5.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            baglan.Open();
            SqlCommand sqlcmd = new SqlCommand("insert into müsteri(tc,adsoyad,telefon,adres,email) values('" + textBox1.Text + "','" + textBox2.Text + "','" + maskedTextBox1.Text + "','" + textBox3.Text + "','" + textBox5.Text + "')", baglan);
            sqlcmd.ExecuteNonQuery();

            MessageBox.Show("' "+textBox2.Text+" ' kişisi başarıyla eklendi");

            textboxSil();
            baglan.Close();
        }

        private void müsteriEkle_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            satis_sayfası satis_Sayfası = new satis_sayfası();
            this.Hide();
            satis_Sayfası.ShowDialog();

        }
    }
}
