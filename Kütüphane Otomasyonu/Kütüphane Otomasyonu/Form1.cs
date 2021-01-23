using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kütüphane_Otomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            KitapEkle ekle = new KitapEkle();
            ekle.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EmanetListele ekle = new EmanetListele();
            ekle.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            KitapListele ekle = new KitapListele();
            ekle.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            UyeEkle ekle = new UyeEkle();
            ekle.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EmanetEkle ekle = new EmanetEkle();
            ekle.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            UyeListele ekle = new UyeListele();
            ekle.Show();
        }
    }
}
