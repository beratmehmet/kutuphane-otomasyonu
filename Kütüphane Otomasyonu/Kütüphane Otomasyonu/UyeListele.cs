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
    public partial class UyeListele : Form
    {
        public UyeListele()
        {
            InitializeComponent();
        }
        SqlConnection baglanti =
   new SqlConnection(@"Data Source=BMT;Initial Catalog=kutuphane;Integrated Security=True");
        private void UyeListele_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand UyeListele = new SqlCommand("SELECT *  FROM Uyeler", baglanti);
            SqlDataAdapter veri = new SqlDataAdapter(UyeListele);
            DataTable dt = new DataTable();
            veri.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
    public static string UyeListeleSecilen;

    private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
    {

        UyeListeleSecilen = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells["UyeNo"].Value.ToString();

        UyeDuzenle FormUyeDuzenle = new UyeDuzenle();
        FormUyeDuzenle.Show();
    }

    }

    
}
