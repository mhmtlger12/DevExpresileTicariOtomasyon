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
    public partial class _Products : Form
    {
        public _Products()
        {
            InitializeComponent();
        }
        SqlConnect_ bgl = new SqlConnect_();
        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_URUNLER", bgl.Connect_());
            bgl.Connect_();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void _Products_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into TBL_URUNLER(URUNAD,MARKA,MODEL,YIL,ADET,ALISFIYAT,SATISFIYAT,DETAY) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8)", bgl.Connect_());
                cmd.Parameters.AddWithValue("@p1", TxtAd.Text);
                cmd.Parameters.AddWithValue("@p2", TxtMarka.Text);
                cmd.Parameters.AddWithValue("@p3", TxtModel.Text);
                cmd.Parameters.AddWithValue("@p4", MskYıl.Text);
                cmd.Parameters.AddWithValue("@p5", int.Parse((NudAdet.Value).ToString()));
                cmd.Parameters.AddWithValue("@p6", decimal.Parse(TxtAlis.Text));
                cmd.Parameters.AddWithValue("@p7", decimal.Parse(TxtSatis.Text));
                cmd.Parameters.AddWithValue("@p8", RichDetay.Text);
                cmd.ExecuteNonQuery();
                bgl.Connect_().Close();
                MessageBox.Show("Ürün sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
            }
            catch (Exception hata)
            {

                MessageBox.Show("Alınan Hata : "+ hata.Message + "","Hata Sayfası",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            //Veriler Kaydetme
           

        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmddelete = new SqlCommand("delete from TBL_URUNLER where ID=@p1", bgl.Connect_());
                cmddelete.Parameters.AddWithValue("@p1", TxtId.Text);
                cmddelete.ExecuteNonQuery();
                bgl.Connect_().Close();
                MessageBox.Show("Ürün Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Listele();
            }
            catch (Exception Hata)
            {

                MessageBox.Show("Alınan Hata : " + Hata.Message + "", "Hata Sayfası", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                TxtId.Text = dr["ID"].ToString();
                TxtAd.Text = dr["URUNAD"].ToString();
                TxtMarka.Text = dr["MARKA"].ToString();
                TxtModel.Text = dr["MODEL"].ToString();
                MskYıl.Text = dr["YIL"].ToString();
                NudAdet.Value = decimal.Parse(dr["ADET"].ToString());
                TxtAlis.Text = dr["ALISFIYAT"].ToString();
                TxtSatis.Text = dr["SATISFIYAT"].ToString();
                RichDetay.Text = dr["DETAY"].ToString();
            }
            catch (Exception Hata)
            {

                MessageBox.Show("Alınan Hata : " + Hata.Message + "", "Hata Sayfası", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        [Obsolete]
        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmdupdate = new SqlCommand("update TBL_URUNLER set URUNAD=@P1,MARKA=@P2,MODEL=@P3,YIL=@P4,ADET=@P5,ALISFIYAT=@P6,SATISFIYAT=@P7,DETAY=@p8 where ID=@P9", bgl.Connect_());
                cmdupdate.Parameters.AddWithValue("@p1", TxtAd.Text);
                cmdupdate.Parameters.AddWithValue("@p2", TxtMarka.Text);
                cmdupdate.Parameters.AddWithValue("@p3", TxtModel.Text);
                cmdupdate.Parameters.AddWithValue("@p4", MskYıl.Text);
                cmdupdate.Parameters.AddWithValue("@p5", int.Parse((NudAdet.Value).ToString()));
                cmdupdate.Parameters.AddWithValue("@p6", decimal.Parse(TxtAlis.Text));
                cmdupdate.Parameters.AddWithValue("@p7", decimal.Parse(TxtSatis.Text));
                cmdupdate.Parameters.AddWithValue("@p8", RichDetay.Text);
                cmdupdate.Parameters.Add("@p9", TxtId.Text);
                cmdupdate.ExecuteNonQuery();
                bgl.Connect_().Close();
                MessageBox.Show("Ürün Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();

            }
            catch (Exception Hata)
            {

                MessageBox.Show("Alınan Hata : " + Hata.Message + "", "Hata Sayfası", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
