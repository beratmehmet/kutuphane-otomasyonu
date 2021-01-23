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
    public partial class Emanetİslem : Form
    {
        public Emanetİslem()
        {
            InitializeComponent();
        }
        SqlConnection baglanti =
  new SqlConnection(@"Data Source=BMT;Initial Catalog=kutuphane;Integrated Security=True");

        private void button2_Click(object sender, EventArgs e)
        {
            

        }

        private void labelEmanetNoVeri_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonKitapTeslimAlindi_Click(object sender, EventArgs e)
        {
            DialogResult sonuc;
            sonuc = MessageBox.Show("Kitabın Alındığını teyit ediyormusunuz?", "Uyarı", MessageBoxButtons.OKCancel);
            if (sonuc == DialogResult.OK)
            {
                try
                {


                    baglanti.Open();
                    SqlCommand EmanetTeslimEdildi = new SqlCommand("UPDATE Emanetler SET EmanetTeslimEdildi='Evet' WHERE EmanetNo = @secilen   ", baglanti);
                    EmanetTeslimEdildi.Parameters.Add("@secilen", SqlDbType.Int).Value = EmanetListele.EmanetListeleSecilenEmanetNo.ToString();
                    EmanetTeslimEdildi.ExecuteNonQuery();
                    baglanti.Close();
                    MessageBox.Show("Kitap Teslim Alındı");
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
            this.Hide();
        }

        private void Emanetİslem_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand EmanetListeleDetay = new SqlCommand("SELECT * FROM Emanetler INNER JOIN Uyeler ON Emanetler.UyeNo = Uyeler.UyeNo INNER JOIN Kitaplar ON Kitaplar.KitapNo=Emanetler.KitapNo WHERE Emanetler.EmanetNo = @secilenEmanetNo", baglanti);
            EmanetListeleDetay.Parameters.Add("@secilenEmanetNo", SqlDbType.Int).Value = EmanetListele.EmanetListeleSecilenEmanetNo.ToString();

            SqlDataReader sonuclar = EmanetListeleDetay.ExecuteReader();
            while (sonuclar.Read())
            {
                textBox1.Text = sonuclar["EmanetNo"].ToString();
                textBox2.Text = sonuclar["EmanetVermeTarih"].ToString();
                textBox3.Text = sonuclar["EmanetGeriAlmaTarih"].ToString();
                textBox4.Text = sonuclar["EmanetIslemTarih"].ToString();
                textBox5.Text = sonuclar["EmanetNot"].ToString();

                textBox14.Text = sonuclar["UyeNo"].ToString();
                textBox15.Text = sonuclar["UyeAd"].ToString();
                textBox16.Text = sonuclar["UyeSoyad"].ToString();
                textBox17.Text = sonuclar["UyeTelefon"].ToString();
                textBox18.Text = sonuclar["UyeEposta"].ToString();
                textBox19.Text = sonuclar["UyeAdres"].ToString();

                textBox6.Text = sonuclar["KitapNo"].ToString();
                textBox7.Text = sonuclar["KitapAd"].ToString();
                textBox8.Text = sonuclar["KitapYazari"].ToString();
                textBox9.Text = sonuclar["KitapBaskiYil"].ToString();
                textBox10.Text = sonuclar["KitapSayfaSayi"].ToString();
                textBox11.Text = sonuclar["KitapDil"].ToString();
                textBox12.Text = sonuclar["KitapYayinEvi"].ToString();
                textBox13.Text = sonuclar["KitapAciklama"].ToString();


            }

            baglanti.Close();

        }
    }
}
