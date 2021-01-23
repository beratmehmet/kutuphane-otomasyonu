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
    public partial class KitapListele : Form
    {
        public KitapListele()
        {
            InitializeComponent();
        }
        SqlConnection baglanti =
  new SqlConnection(@"Data Source=BMT;Initial Catalog=kutuphane;Integrated Security=True");

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void KitapListele_Load(object sender, EventArgs e)
        {
           
             baglanti.Open();
            SqlCommand komut = new SqlCommand("SELECT *  FROM kitaplar", baglanti);


            SqlDataAdapter veri = new SqlDataAdapter(komut);

            DataTable dt = new DataTable();
            veri.Fill(dt);

            dataGridView1.DataSource = dt;

            baglanti.Close();
            
      
        }
        public static string KitapListeleSecilen;
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)

        {
            KitapListeleSecilen = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["KitapNo"].Value.ToString();
            KitapDuzenle FormDuzenle = new KitapDuzenle();
            FormDuzenle.Show();

        }
    }
}
