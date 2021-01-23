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
using Kütüphane_Otomasyonu.kutuphaneDataSetTableAdapters;

namespace Kütüphane_Otomasyonu
{
    public partial class EmanetEkle : Form
    {
        public EmanetEkle()
        {
            InitializeComponent();
        }
        SqlConnection baglanti =
   new SqlConnection(@"Data Source=BMT;Initial Catalog=kutuphane;Integrated Security=True");


     
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime dtime1 = dateTimePicker1.Value;
                DateTime dtime2 = dateTimePicker2.Value;
                DateTime simdikizaman = DateTime.Now;
                int sonuc = DateTime.Compare(dtime1, dtime2);

                if (sonuc == 1)

                {
                    MessageBox.Show("Emanet Geri Alma Tarihi Emanet Vermeden Önce Olamaz");
                }

                else
                {


                    SqlCommand komut = new SqlCommand("INSERT INTO Emanetler (UyeNo,KitapNo,EmanetVermeTarih,EmanetGeriAlmaTarih,EmanetIslemTarih,EmanetNot) VALUES (@UyeNo,@KitapNo,@EmanetVermeTarih,@EmanetGeriAlmaTarih,@EmanetIslemTarih,@EmanetNot)", baglanti);
                    komut.Parameters.Add("@UyeNo", SqlDbType.Int).Value = comboBox1.SelectedValue.ToString();
                    komut.Parameters.Add("@KitapNo", SqlDbType.Int).Value = comboBox2.SelectedValue.ToString();
                    komut.Parameters.Add("@EmanetVermeTarih", SqlDbType.DateTime).Value = dateTimePicker1.Value;
                    komut.Parameters.Add("@EmanetGeriAlmaTarih", SqlDbType.DateTime).Value = dateTimePicker2.Value;
                    komut.Parameters.Add("@EmanetIslemTarih", SqlDbType.DateTime).Value = simdikizaman;
                    komut.Parameters.Add("@EmanetNot", SqlDbType.NVarChar).Value = textBox1.Text;

                    baglanti.Open();
                    komut.ExecuteNonQuery();
                    MessageBox.Show("Emanet Başarıyla Eklendi");

                    baglanti.Close();

                }


            }
            catch (Exception)
            {

                MessageBox.Show("Bir Hata Oluştu");
            }
        }

        private void EmanetEkle_Load(object sender, EventArgs e)
        {
            #region ComboboxUyeListeleDTile
            SqlDataAdapter adp = new SqlDataAdapter("SELECT UyeNo,(UyeAd + ' ' + UyeSoyad + ' TEL: ' + UyeTelefon ) AS UyeBilgi FROM Uyeler ORDER BY UyeAd ASC", baglanti);
            dateTimePicker1.Value = DateTime.Today;
            dateTimePicker2.Value = DateTime.Today.AddDays(1);
            DataTable ComboboxUyeAd = new DataTable();
            adp.Fill(ComboboxUyeAd);

            comboBox1.DataSource = ComboboxUyeAd;

            comboBox1.DisplayMember = "UyeBilgi";// Combobox ta görünecek olan hücre
            comboBox1.ValueMember = "UyeNo"; // Arka Planda tutulacak olan hücre
            #endregion
            #region ComboboxKitapListeleDTile

            SqlDataAdapter EmanetKitapListele = new SqlDataAdapter("SELECT KitapNo,(KitapAd + ' - ' + KitapYazari  + ' - ' + KitapYayinEvi ) AS KitapBilgi FROM Kitaplar ORDER BY KitapAd ASC", baglanti);
            //SqlDataAdapter EmanetKitapListele = new SqlDataAdapter("SELECT * FROM Emanetler");
            DataTable ComboboxKitapAd = new DataTable();
            EmanetKitapListele.Fill(ComboboxKitapAd);

            comboBox2.DataSource = ComboboxKitapAd;

            comboBox2.DisplayMember = "KitapBilgi";// Combobox ta görünecek olan hücre
            comboBox2.ValueMember = "KitapNo"; // Arka Planda tutulacak olan hücre
            #endregion

            
        }
    }
}
