using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AbdüsShop
{
    public partial class satis_sayfası : Form
    {
        public satis_sayfası()
        {
            InitializeComponent();
        }



        private void button5_Click(object sender, EventArgs e)
        {
            müsteriEkle müsteriEkle = new müsteriEkle();
            this.Hide();
            müsteriEkle.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            müsteriList müsteriList = new müsteriList();
            this.Hide();
            müsteriList.ShowDialog();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
