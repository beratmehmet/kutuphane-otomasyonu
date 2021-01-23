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
using System.Linq.Expressions;

namespace Kütüphane_Otomasyonu
{
    public partial class KitapEkle : Form
    {
        public KitapEkle()
        {
            InitializeComponent();
        }

        SqlConnection baglanti =
   new SqlConnection(@"Data Source=BMT;Initial Catalog=kutuphane;Integrated Security=True");

        private void KitapEkle_Load(object sender, EventArgs e)
        {
            #region ComboboxDoldur 

            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            List<string> KitapYayinEvleri = new List<string>();
            List<string> KitapDil = new List<string>();
            List<string> KitapYazar = new List<string>();



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


            for (int i = 0; i < KitapYayinEvleri.Count; i++)
            {
                comboBox3.Items.Add(KitapYayinEvleri[i].ToString());
            }


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

            for (int i = 0; i < KitapDil.Count; i++)
            {
                comboBox2.Items.Add(KitapDil[i].ToString());
            }



            baglanti.Open();
            SqlCommand komutKitapYazar = new SqlCommand("SELECT KitapYazari  FROM kitaplar", baglanti);

            SqlDataReader sonuclarKitapYazar = komutKitapYazar.ExecuteReader();
            while (sonuclarKitapYazar.Read())
            {
                string gelendeger = sonuclarKitapYazar["KitapYazari"].ToString();
                if (KitapDil.Contains(gelendeger))
                { }
                else
                { KitapYazar.Add(sonuclarKitapYazar["KitapYazari"].ToString()); }
            }
            baglanti.Close();

            for (int i = 0; i < KitapYazar.Count; i++)
            {
                comboBox1.Items.Add(KitapYazar[i].ToString());
            }




            #endregion

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                SqlCommand komut = new SqlCommand("INSERT INTO Kitaplar (KitapAd,KitapYazari,KitapBaskiYil,KitapSayfaSayi,KitapDil,KitapYayinEvi,KitapAciklama) VALUES (@KitapAd,@KitapYazari,@KitapBaskiYil,@KitapSayfaSayi,@KitapDil,@KitapYayinEvi,@KitapAciklama)", baglanti);
                komut.Parameters.Add("@KitapAd", SqlDbType.NVarChar).Value = textBox1.Text;
                komut.Parameters.Add("@KitapYazari", SqlDbType.NVarChar).Value = comboBox1.Text;
                komut.Parameters.Add("@KitapBaskiYil", SqlDbType.Int).Value = Int16.Parse(textBox6.Text);
                komut.Parameters.Add("@KitapSayfaSayi", SqlDbType.Int).Value = Int16.Parse(textBox8.Text);
                komut.Parameters.Add("@KitapDil", SqlDbType.NVarChar).Value = comboBox2.Text;
                komut.Parameters.Add("@KitapYayinEvi", SqlDbType.NVarChar).Value = comboBox3.Text;
                komut.Parameters.Add("@KitapAciklama", SqlDbType.Text).Value = textBox13.Text;
                baglanti.Open();
                komut.ExecuteNonQuery();
                MessageBox.Show("Kitap Başarıyla Eklendi");
                
                baglanti.Close(); }
        catch (Exception){MessageBox.Show("Bir Hata Oluştu");}
            }
       

    private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
