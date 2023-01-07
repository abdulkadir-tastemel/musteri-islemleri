using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbdüsShop
{
    public partial class müsteriList : Form
    {
        public müsteriList()
        {
            InitializeComponent();
        }

        SqlConnection baglan = new SqlConnection("Data Source=LAPTOP-M65KS4BD;Initial Catalog=db;Integrated Security=True");
        DataSet daset = new DataSet();


        public void kayıt_goster()
        {
            baglan.Open();

            SqlDataAdapter sqladptr = new SqlDataAdapter("select *from müsteri", baglan);
            sqladptr.Fill(daset,"müsteri");
            dataGridView1.DataSource = daset.Tables["müsteri"];
            baglan.Close();

            baglan.Close();
        }

        public void textboxSil()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            maskedTextBox1.Text= "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void müsteriList_Load(object sender, EventArgs e)
        {
            // TODO: Bu kod satırı 'dbDataSet.müsteri' tablosuna veri yükler. Bunu gerektiği şekilde taşıyabilir, veya kaldırabilirsiniz.
            this.müsteriTableAdapter.Fill(this.dbDataSet.müsteri);
            kayıt_goster();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["tc"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["adsoyad"].Value.ToString();
            maskedTextBox1.Text = dataGridView1.CurrentRow.Cells["telefon"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["adres"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["email"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand sqladptr = new SqlCommand("delete from müsteri where tc='"+dataGridView1.CurrentRow.Cells["tc"].Value.ToString()+"'",baglan);
            sqladptr.ExecuteNonQuery();
            baglan.Close();

            daset.Tables["müsteri"].Clear();
            kayıt_goster();
            MessageBox.Show("'"+textBox2.Text +"' kişisi silindi");
            textboxSil();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglan.Open();
            SqlCommand sqlCommand = new SqlCommand("update müsteri set adsoyad=@adsoyad,telefon=@telefon,adres=@adres,email=@email where tc=@tc", baglan);
            sqlCommand.Parameters.AddWithValue("tc", textBox1.Text);
            sqlCommand.Parameters.AddWithValue("adsoyad", textBox2.Text);
            sqlCommand.Parameters.AddWithValue("telefon", maskedTextBox1.Text);
            sqlCommand.Parameters.AddWithValue("adres", textBox4.Text);
            sqlCommand.Parameters.AddWithValue("email", textBox5.Text);
            sqlCommand.ExecuteNonQuery();
            baglan.Close();

            daset.Tables["müsteri"].Clear();
            kayıt_goster();

            textboxSil();
        }

       

        private void button3_Click(object sender, EventArgs e)
        {
            satis_sayfası satis = new satis_sayfası();
            this.Hide();
            satis.ShowDialog();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            baglan.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from müsteri where tc like '%" + textBox1.Text + "%'", baglan);
            adapter.Fill(table);
            dataGridView1.DataSource = table;
            baglan.Close();
        }

       
    }
}
