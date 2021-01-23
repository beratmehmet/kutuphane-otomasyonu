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

namespace Kütüphane_Otomasyonu
{
    public partial class UyeEkle : Form
    {
        public UyeEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti =
   new SqlConnection(@"Data Source=BMT;Initial Catalog=kutuphane;Integrated Security=True");
        private void UyeEkle_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komutUyeEkle = new SqlCommand("INSERT INTO Uyeler (UyeAd,UyeSoyad,UyeTelefon,UyeEposta,UyeAdres) VALUES (@UyeAd,@UyeSoyad,@UyeTelefon,@UyeEposta,@UyeAdres)", baglanti);
                komutUyeEkle.Parameters.Add("@UyeAd", SqlDbType.NVarChar).Value = textBox1.Text;
                komutUyeEkle.Parameters.Add("@UyeSoyad", SqlDbType.NVarChar).Value = textBox2.Text;
                komutUyeEkle.Parameters.Add("@UyeTelefon", SqlDbType.NVarChar).Value = maskedTextBox1.Text.ToString();
                komutUyeEkle.Parameters.Add("@UyeEposta", SqlDbType.NVarChar).Value = textBox4.Text;
                komutUyeEkle.Parameters.Add("@UyeAdres", SqlDbType.NVarChar).Value = textBox5.Text;
                baglanti.Open();
                komutUyeEkle.ExecuteNonQuery();
                MessageBox.Show("Üye Başarıyla Eklendi");
                baglanti.Close();

                textBox1.Text = "";
                textBox2.Text = "";
                maskedTextBox1.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";



            }
            catch (Exception x)
            {
                MessageBox.Show(x.ToString());

            }
        }
    }
}
