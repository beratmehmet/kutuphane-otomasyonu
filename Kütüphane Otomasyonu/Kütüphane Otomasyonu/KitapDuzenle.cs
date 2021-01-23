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
    public partial class KitapDuzenle : Form
    {
        public KitapDuzenle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti =
   new SqlConnection(@"Data Source=BMT;Initial Catalog=kutuphane;Integrated Security=True");
        private void KitapDuzenle_Load(object sender, EventArgs e)
        {
            List<string> KitapYayinEvleri = new List<string>();
            List<string> KitapDil = new List<string>();



            #region KitapYayinEviListeyeAktar
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("SELECT KitapYayinEvi  FROM kitaplar", baglanti);

            SqlDataReader sonuclar2 = komut2.ExecuteReader();
            while (sonuclar2.Read())
            {
                string gelendeger = sonuclar2["KitapYayinEvi"].ToString();
                if (KitapYayinEvleri.Contains(gelendeger))
                { }
                else
                { KitapYayinEvleri.Add(sonuclar2["KitapYayinEvi"].ToString()); }
            }
            baglanti.Close();
            #endregion


            #region YayinEvleriComboboxaEkle
            for (int i = 0; i < KitapYayinEvleri.Count; i++)
            {
                comboBox2.Items.Add(KitapYayinEvleri[i].ToString());
            }
            #endregion
            #region SecilenKitabiListele
            string secilen = KitapListele.KitapListeleSecilen.ToString();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *  FROM kitaplar WHERE KitapNo = @secilen  ", baglanti);
            komut.Parameters.Add("@secilen", SqlDbType.Int).Value = KitapListele.KitapListeleSecilen.ToString();
            SqlDataReader sonuclar = komut.ExecuteReader();
            while (sonuclar.Read())
            {
                label7.Text = sonuclar["KitapNo"].ToString();
                textBox1.Text = sonuclar["KitapAd"].ToString();
                textBox2.Text = (sonuclar["KitapBaskiYil"].ToString());
                textBox3.Text = (sonuclar["KitapSayfaSayi"].ToString());
                comboBox1.Text = sonuclar["KitapDil"].ToString();
                comboBox2.Text = sonuclar["KitapYayinEvi"].ToString();
                textBox4.Text = sonuclar["KitapAciklama"].ToString();


            }
            baglanti.Close();


            #endregion





            #region KitapDilListeyeAktar
            baglanti.Open();
            SqlCommand komutKitapDil = new SqlCommand("SELECT KitapDil  FROM kitaplar", baglanti);

            SqlDataReader sonuclarKitapDil = komutKitapDil.ExecuteReader();
            while (sonuclarKitapDil.Read())
            {
                string gelendeger = sonuclarKitapDil["KitapDil"].ToString();
                if (KitapDil.Contains(gelendeger))
                { }
                else
                { KitapDil.Add(sonuclarKitapDil["KitapDil"].ToString()); }
            }
            baglanti.Close();
            #endregion


            #region KitapDilleriComboboxaEkle
            for (int i = 0; i < KitapDil.Count; i++)
            {
                comboBox1.Items.Add(KitapDil[i].ToString());
            }

            #endregion



        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Kitabı silmek istediğinizden emin misiniz?", "Uyarı", MessageBoxButtons.OKCancel);
            if (sonuc == DialogResult.OK)
            {
                try
                {
                    string secilen = KitapListele.KitapListeleSecilen.ToString();

                    baglanti.Open();
                    SqlCommand KayitSil = new SqlCommand("DELETE FROM kitaplar WHERE KitapNo=@secilen  ", baglanti);
                    KayitSil.Parameters.Add("@secilen", SqlDbType.Int).Value = KitapListele.KitapListeleSecilen.ToString();
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

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("UPDATE Kitaplar  SET KitapAd=@KitapAd,KitapBaskiYil=@KitapBaskiYil,KitapSayfaSayi=@KitapSayfaSayi,KitapDil=@KitapDil,KitapYayinEvi=@KitapYayinEvi,KitapAciklama=@KitapAciklama WHERE KitapNo = @secilen  ", baglanti);

            komut.Parameters.Add("@secilen", SqlDbType.Int).Value = KitapListele.KitapListeleSecilen.ToString();
            komut.Parameters.Add("@KitapAd", SqlDbType.NVarChar).Value = textBox1.Text;
            komut.Parameters.Add("@KitapBaskiYil", SqlDbType.NChar).Value = Int16.Parse(textBox2.Text);
            komut.Parameters.Add("@KitapSayfaSayi", SqlDbType.NChar).Value = Int16.Parse(textBox3.Text);
            komut.Parameters.Add("@KitapDil", SqlDbType.NVarChar).Value = comboBox1.Text;
            komut.Parameters.Add("@KitapYayinEvi", SqlDbType.NVarChar).Value = comboBox2.Text;
            komut.Parameters.Add("@KitapAciklama", SqlDbType.Text).Value = textBox4.Text;



            baglanti.Open();
            komut.ExecuteNonQuery();
            MessageBox.Show("Kitap Düzenlendi");
            baglanti.Close();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

