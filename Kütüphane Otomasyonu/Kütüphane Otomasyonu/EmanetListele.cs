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
    public partial class EmanetListele : Form
    {
        public EmanetListele()
        {
            InitializeComponent();
        }

        SqlConnection baglanti =
  new SqlConnection(@"Data Source=BMT;Initial Catalog=kutuphane;Integrated Security=True");
        private void EmanetListele_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutEmanetleriListele = new SqlCommand("SELECT EmanetNo, UyeAd,UyeSoyad,UyeTelefon,KitapAd,EmanetVermeTarih,EmanetGeriAlmaTarih,EmanetNot FROM Emanetler INNER JOIN Uyeler ON Emanetler.UyeNo = Uyeler.UyeNo INNER JOIN Kitaplar ON Kitaplar.KitapNo=Emanetler.KitapNo WHERE EmanetTeslimEdildi='Hayır'", baglanti);


            SqlDataAdapter veri = new SqlDataAdapter(komutEmanetleriListele);

            DataTable dt = new DataTable();
            veri.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();



           /* for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dt.Rows[i]["EmanetGeriAlmaTarih"].ToString().Equals(DateTime.Today.ToString() ))
                {//Eğer Geri alma tarihi bugin ise
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = Color.Red;

                }

            }*/
        }
        public static string EmanetListeleSecilenEmanetNo;

        private void dataGridViewEmanetleriListele_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {


            EmanetListeleSecilenEmanetNo = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["EmanetNo"].Value.ToString();

            Emanetİslem FormEmanetListeleDetay = new Emanetİslem();
            FormEmanetListeleDetay.Show();

        }
    }
}
