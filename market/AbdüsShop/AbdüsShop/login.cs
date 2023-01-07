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
    public partial class login : Form
    {

        public login()
        {
            InitializeComponent();
        }

            SqlConnection baglan = new SqlConnection("Data Source=LAPTOP-M65KS4BD;Initial Catalog=db;Integrated Security=True");


        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;



        public void giris()
        {
            SqlCommand sqlcmd = new SqlCommand("SELECT * FROM login where kullanıcıAd = '" + textBox1.Text + "' AND sifre = '" + textBox2.Text + "'", baglan);
            dr = sqlcmd.ExecuteReader();

            if (dr.Read())
            {


                satis_sayfası satis_Sayfası = new satis_sayfası();
                this.Hide();
                MessageBox.Show("HOŞGELDİNİZ " + textBox1.Text + " BEY");
                satis_Sayfası.ShowDialog();

                
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ya da şifre yanlış");
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {

            baglan.Open();

            giris();
           
            baglan.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }
    }
}
