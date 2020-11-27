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
    public partial class _Personnel : Form
    {
        public _Personnel()
        {
            InitializeComponent();
        }
        SqlConnect_ bgl = new SqlConnect_();

        void PersonelListesi()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from TBL_PERSONELLER ", bgl.Connect_());
            da.Fill(dt);
            gridControl1.DataSource = dt;

        }
        void Temizle()
        {
            TxtId.Text = "";
            TxtAd.Text = "";
            TxtSoyad.Text = "";
            TXTgorev.Text = "";
            TxtMail.Text = "";
            RichAdres.Text = "";
            Cmbil.Text = "";
            Cmbilce.Text = "";
            MSKTC.Text = "";
            MskTel1.Text = "";
        }

        private void _Personnel_Load(object sender, EventArgs e)
        {
            PersonelListesi();
            Temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into TBL_PERSONELLER(AD,SOYAD,TELEFON,TC,MAIL,IL,ILCE,ADRES,GOREV) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)", bgl.Connect_());
                cmd.Parameters.AddWithValue("@p1", TxtAd.Text);
                cmd.Parameters.AddWithValue("@p2", TxtSoyad.Text);
                cmd.Parameters.AddWithValue("@p3", MskTel1.Text);
                cmd.Parameters.AddWithValue("@p4", MSKTC.Text);
                cmd.Parameters.AddWithValue("@p5", TxtMail.Text);
                cmd.Parameters.AddWithValue("@p6", Cmbil.Text);
                cmd.Parameters.AddWithValue("@p7", Cmbilce.Text);
                cmd.Parameters.AddWithValue("@p8", RichAdres.Text);
                cmd.Parameters.AddWithValue("@p9", TXTgorev.Text);

                cmd.ExecuteNonQuery();
                bgl.Connect_().Close();
                MessageBox.Show("Personel sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PersonelListesi();
                Temizle();
            }
            catch (Exception hata)
            {

                MessageBox.Show("Alınan Hata : " + hata.Message + "", "Hata Sayfası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Veriler Kaydetme
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                TxtId.Text = dr["ID"].ToString();
                TxtAd.Text = dr["AD"].ToString();
                TxtSoyad.Text = dr["SOYAD"].ToString();
                MskTel1.Text = dr["TELEFON"].ToString();
                MSKTC.Text = dr["TC"].ToString();
                TxtMail.Text = dr["MAIL"].ToString();
                RichAdres.Text = dr["ADRES"].ToString();
                Cmbil.Text = dr["IL"].ToString();
                Cmbilce.Text = dr["ILCE"].ToString();

            }
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmdelete = new SqlCommand("Delete from TBL_PERSONELLER where ID=@P1", bgl.Connect_());
                cmdelete.Parameters.AddWithValue("@p1", TxtId.Text);
                cmdelete.ExecuteNonQuery();
                bgl.Connect_().Close();
                MessageBox.Show("Personel Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                PersonelListesi();
            }
            catch (Exception hata) 
            {

                MessageBox.Show("Alınan Hata : " + hata.Message + "", "Hata Sayfası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
  
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {

            SqlCommand cmdupdate = new SqlCommand("Update TBL_PERSONELLER set AD=@p1,SOYAD=@p2,TELEFON=@p3,TC=@p4,MAIL=@p5,IL=@p6,ILCE=@p7,ADRES=@p8,GOREV=@p9 where ID=@P10 ", bgl.Connect_());
            cmdupdate.Parameters.AddWithValue("@p1", TxtAd.Text);
            cmdupdate.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            cmdupdate.Parameters.AddWithValue("@p3", MskTel1.Text);
            cmdupdate.Parameters.AddWithValue("@p4", MSKTC.Text);
            cmdupdate.Parameters.AddWithValue("@p5",TxtMail.Text );
            cmdupdate.Parameters.AddWithValue("@p6",Cmbil.Text );
            cmdupdate.Parameters.AddWithValue("@p7", Cmbilce.Text);
            cmdupdate.Parameters.AddWithValue("@p8", RichAdres.Text);
            cmdupdate.Parameters.AddWithValue("@p9", TXTgorev.Text);
            cmdupdate.Parameters.AddWithValue("@p10", TxtId.Text);
            cmdupdate.ExecuteNonQuery();
            bgl.Connect_().Close();
            MessageBox.Show("Müşteri Bilgiler Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            PersonelListesi();
        }
    }
}

