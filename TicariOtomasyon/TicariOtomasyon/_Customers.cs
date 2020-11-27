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
    public partial class _Customers : Form
    {
        public _Customers()
        {
            InitializeComponent();
        }
        SqlConnect_ bgl = new SqlConnect_();
        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * from TBL_MUSTERILER", bgl.Connect_());
            bgl.Connect_();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void sehirlistesi()
        {
            SqlCommand citylist = new SqlCommand("select SEHIR from iller", bgl.Connect_());
            SqlDataReader dr = citylist.ExecuteReader();
            while (dr.Read())
            {
                Cmbil.Properties.Items.Add(dr[0]);
            }
        }
        private void _Customers_Load(object sender, EventArgs e)
        {
            Listele();
            sehirlistesi();
        }

        private void Cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cmbilce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("select ILCE from ilceler where SEHIR=@P1 ", bgl.Connect_());
            komut.Parameters.AddWithValue("@p1", Cmbil.SelectedIndex+1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbilce.Properties.Items.Add(dr[0]);
            }
            bgl.Connect_().Close();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("insert into TBL_MUSTERILER(AD,SOYAD,TELEFON,TELEFON2,TC,MAIL,IL,ILCE,ADRES,VERGIDAIRE) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", bgl.Connect_());
                cmd.Parameters.AddWithValue("@p1", TxtAd.Text);
                cmd.Parameters.AddWithValue("@p2",TxtSoyad.Text);
                cmd.Parameters.AddWithValue("@p3", MskTel1.Text);
                cmd.Parameters.AddWithValue("@p4", MskTel2.Text);
                cmd.Parameters.AddWithValue("@p5", MSKTC.Text);
                cmd.Parameters.AddWithValue("@p6", TxtMail.Text);
                cmd.Parameters.AddWithValue("@p7",Cmbil.Text);
                cmd.Parameters.AddWithValue("@p8", Cmbilce.Text);
                cmd.Parameters.AddWithValue("@p9", RichAdres.Text);
                cmd.Parameters.AddWithValue("@p10", TxtVergi.Text);
                cmd.ExecuteNonQuery();
                bgl.Connect_().Close();
                MessageBox.Show("Müşteri sisteme eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Listele();
            }
            catch (Exception hata)
            {

                MessageBox.Show("Alınan Hata : " + hata.Message + "", "Hata Sayfası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //Veriler Kaydetme
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand cmdelete = new SqlCommand("Delete from TBL_MUSTERILER where ID=@P1", bgl.Connect_());
            cmdelete.Parameters.AddWithValue("@p1", TxtId.Text);
            cmdelete.ExecuteNonQuery();
            bgl.Connect_().Close();
            MessageBox.Show("Müşteri Silindi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            Listele();
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
                MskTel2.Text = dr["TELEFON2"].ToString();
                MSKTC.Text = dr["TC"].ToString();
                TxtMail.Text = dr["MAIL"].ToString();
                Cmbil.Text = dr["IL"].ToString();
                Cmbilce.Text = dr["ILCE"].ToString();
                TxtVergi.Text = dr["VERGIDAIRE"].ToString();
                RichAdres.Text = dr["ADRES"].ToString();


            }
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand cmdupdate = new SqlCommand("Update TBL_MUSTERILER set AD=@p1,SOYAD=@p2,TELEFON=@p3,TELEFON2=@p4,TC=@p5,MAIL=@p6,IL=@p7,ILCE=@p8,ADRES=@p9,VERGIDAIRE=@p10 where ID=@P11 ", bgl.Connect_());
            cmdupdate.Parameters.AddWithValue("@p1", TxtAd.Text);
            cmdupdate.Parameters.AddWithValue("@p2", TxtSoyad.Text);
            cmdupdate.Parameters.AddWithValue("@p3", MskTel1.Text);
            cmdupdate.Parameters.AddWithValue("@p4", MskTel2.Text);
            cmdupdate.Parameters.AddWithValue("@p5", MSKTC.Text);
            cmdupdate.Parameters.AddWithValue("@p6", TxtMail.Text);
            cmdupdate.Parameters.AddWithValue("@p7", Cmbil.Text);
            cmdupdate.Parameters.AddWithValue("@p8", Cmbilce.Text);
            cmdupdate.Parameters.AddWithValue("@p9", RichAdres.Text);
            cmdupdate.Parameters.AddWithValue("@p10", TxtVergi.Text);
            cmdupdate.Parameters.AddWithValue("@p11", TxtId.Text);
            cmdupdate.ExecuteNonQuery();
            bgl.Connect_().Close();
            MessageBox.Show("Müşteri Bilgiler Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }
    }
}
