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
    public partial class UyeDuzenle : Form
    {
        public UyeDuzenle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti =
   new SqlConnection(@"Data Source=BMT;Initial Catalog=kutuphane;Integrated Security=True");

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void UyeDuzenle_Load(object sender, EventArgs e)
        {
            string secilen = UyeListele.UyeListeleSecilen.ToString();
            baglanti.Open();
            SqlCommand UyeListeleDuzenle = new SqlCommand("SELECT *  FROM Uyeler WHERE UyeNo = @secilen  ", baglanti);
            UyeListeleDuzenle.Parameters.Add("@secilen", SqlDbType.Int).Value = UyeListele.UyeListeleSecilen.ToString();
            SqlDataReader sonuclar = UyeListeleDuzenle.ExecuteReader();
            while (sonuclar.Read())
            {
                label7.Text = sonuclar["UyeNo"].ToString();
                textBox1.Text = sonuclar["UyeAd"].ToString();
                textBox2.Text = sonuclar["UyeSoyad"].ToString();
                maskedTextBox1.Text = sonuclar["UyeTelefon"].ToString();
                textBox4.Text = sonuclar["UyeEposta"].ToString();
                textBox6.Text = sonuclar["UyeAdres"].ToString();


            }
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komutUyeListeleDuzenle = new SqlCommand("UPDATE Uyeler SET UyeAd=@UyeAd,UyeSoyad=@UyeSoyad,UyeTelefon=@UyeTelefon,UyeEposta=@UyeEposta,UyeAdres=@UyeAdres WHERE UyeNo = @secilen  ", baglanti);
                komutUyeListeleDuzenle.Parameters.Add("@secilen", SqlDbType.Int).Value = UyeListele.UyeListeleSecilen.ToString();
                komutUyeListeleDuzenle.Parameters.Add("@UyeAd", SqlDbType.NVarChar).Value = textBox1.Text;
                komutUyeListeleDuzenle.Parameters.Add("@UyeSoyad", SqlDbType.NVarChar).Value = textBox2.Text;
                komutUyeListeleDuzenle.Parameters.Add("@UyeTelefon", SqlDbType.NVarChar).Value = maskedTextBox1.Text.ToString();
                komutUyeListeleDuzenle.Parameters.Add("@UyeEposta", SqlDbType.NVarChar).Value = textBox4.Text;
                komutUyeListeleDuzenle.Parameters.Add("@UyeAdres", SqlDbType.NVarChar).Value = textBox6.Text;



                baglanti.Open();
                komutUyeListeleDuzenle.ExecuteNonQuery();
                MessageBox.Show("Üye Düzenlendi");
                baglanti.Close();
                this.Hide();
            }
            catch (Exception)
            {

                MessageBox.Show("hata");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Üyeyi silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.OKCancel);
            if (sonuc == DialogResult.OK)
            {
                try
                {
                    string secilen = UyeListele.UyeListeleSecilen.ToString();

                    baglanti.Open();
                    SqlCommand KayitSil = new SqlCommand("DELETE FROM Uyeler WHERE UyeNo=@secilen  ", baglanti);
                    KayitSil.Parameters.Add("@secilen", SqlDbType.Int).Value = UyeListele.UyeListeleSecilen.ToString();
                    KayitSil.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kayıt başarıyla silindi");
                    this.Hide();
                }
                catch (Exception)
                {

                    MessageBox.Show("Bir hata oluştu");
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
