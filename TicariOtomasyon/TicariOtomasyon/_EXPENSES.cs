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

namespace TicariOtomasyon
{
    public partial class _EXPENSES : Form
    {
        public _EXPENSES()
        {
            InitializeComponent();
        }
        SqlConnect_ bgl = new SqlConnect_();

        void GiderListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_GIDERLER",bgl.Connect_());
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }
        void Temizler()
        {
            TxtId.Text = "";
            TxtAd.Text = "";
            TXTDOAGLGAZ.Text = "";
            TXTEKSTRA.Text = "";
            TXTELEKTRK.Text = "";
            TXTINTERNET.Text = "";
            TXTMAASLAR.Text = "";
            TXTSU.Text = "";
            RİCHNOTLAR.Text = "";

        }

        private void _EXPENSES_Load(object sender, EventArgs e)
        {
            GiderListesi();
            Temizler();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("insert into TBL_GIDERLER  (AY,YIL,ELEKTRIK,DOGALGAZ,SU,INTERNET,MAASLAR,EKSTRA,NOTLAR) VALUES (@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9)", bgl.Connect_());
                komut.Parameters.AddWithValue("@p1", CMBAY.Text);
                komut.Parameters.AddWithValue("@p2", CMBYIL.Text);
                komut.Parameters.AddWithValue("@p3", TXTELEKTRK.Text);
                komut.Parameters.AddWithValue("@p4", TXTDOAGLGAZ.Text);
                komut.Parameters.AddWithValue("@p5", TXTSU.Text);
                komut.Parameters.AddWithValue("@p6", TXTINTERNET.Text);
                komut.Parameters.AddWithValue("@p7", TXTMAASLAR.Text);
                komut.Parameters.AddWithValue("@p8", TXTEKSTRA.Text);
                komut.Parameters.AddWithValue("@p9", RİCHNOTLAR.Text);
                komut.ExecuteNonQuery();
                bgl.Connect_().Close();

                MessageBox.Show("Gider Tabloya Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GiderListesi();
            }
            catch (Exception Hata)
            {


                MessageBox.Show("Hata Nedeni :" +Hata+"", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }      

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                TxtId.Text = dr["ID"].ToString();
                CMBAY.Text = dr["AY"].ToString();
                CMBYIL.Text = dr["YIL"].ToString();
                TXTELEKTRK.Text = dr["ELEKTRIK"].ToString();
                TXTDOAGLGAZ.Text = dr["DOGALGAZ"].ToString();
                TXTSU.Text = dr["SU"].ToString();
                TXTINTERNET.Text = dr["INTERNET"].ToString();
                TXTMAASLAR.Text = dr["MAASLAR"].ToString();
                TXTEKSTRA.Text = dr["EKSTRA"].ToString();
                RİCHNOTLAR.Text = dr["NOTLAR"].ToString();



            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutdelete = new SqlCommand("delete from TBL_GIDERLER where ID=@P1", bgl.Connect_()) ;
            komutdelete.Parameters.AddWithValue("@P1", TxtId.Text);
            komutdelete.ExecuteNonQuery();
            bgl.Connect_().Close();
            MessageBox.Show("Silme Başarılı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            GiderListesi();
            Temizler();
        
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("Update  TBL_GIDERLER set   AY=@p1,YIL=@p2,ELEKTRIK=@p3,DOGALGAZ=@p4,SU=@p5,INTERNET=@p6,MAASLAR=@p7,EKSTRA=@p8,NOTLAR=@p9 where ID=@P10 ",  bgl.Connect_());
            komut.Parameters.AddWithValue("@p1", CMBAY.Text);
            komut.Parameters.AddWithValue("@p2", CMBYIL.Text);
            komut.Parameters.AddWithValue("@p3", TXTELEKTRK.Text);
            komut.Parameters.AddWithValue("@p4", TXTDOAGLGAZ.Text);
            komut.Parameters.AddWithValue("@p5", TXTSU.Text);
            komut.Parameters.AddWithValue("@p6", TXTINTERNET.Text);
            komut.Parameters.AddWithValue("@p7", TXTMAASLAR.Text);
            komut.Parameters.AddWithValue("@p8", TXTEKSTRA.Text);
            komut.Parameters.AddWithValue("@p9", RİCHNOTLAR.Text);
            komut.Parameters.AddWithValue("@p10", TxtId.Text);
            komut.ExecuteNonQuery();
            bgl.Connect_().Close();

            MessageBox.Show("Gider Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            GiderListesi();
        }
    }
}
