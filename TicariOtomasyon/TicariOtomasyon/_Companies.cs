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
    public partial class _Companies : Form
    {
        public _Companies()
        {
            InitializeComponent();
        }
        SqlConnect_ bgl = new SqlConnect_();

        void FirmaListesi()
        {
            try
            {
                SqlDataAdapter da = new SqlDataAdapter("select * from TBL_FIRMA", bgl.Connect_());
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;
            }
            catch (Exception hata)
            {

                MessageBox.Show(hata.Message);
            }

        }
        void temizle()
        {
            TxtAd.Text = "";
            txtFirmaMail.Text = "";
            TXTKOD1.Text = "";
            TXTKOD2.Text = "";
            TXTKOD3.Text = "";
            TxtSektör.Text = "";
            TxtTel1.Text = "";
            TxtTel2.Text = "";
            TxtTel3.Text = "";
            TxtYetkili.Text = "";
            TxtYetkiliGorev.Text = "";
            tXTıd.Text = "";
            MSKDFAX.Text = "";
            MSKDTC.Text = "";
            Cmbil.Text = "";
            Cmbilce.Text = "";
            RichAdres.Text = "";
            richTextBox3.Text = "";
            RichÖzelKod2.Text = "";
            RichÖzelKod1.Text = "";
            TxtVergi.Text = "";
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
        void carikodaaciklama()
        {
            SqlCommand komut = new SqlCommand("select FIRMAKOD1 from TBL_KODLAR", bgl.Connect_());
            SqlDataReader DR = komut.ExecuteReader();
            while (DR.Read())
            {
                RichÖzelKod1.Text = DR[0].ToString();
            }
            bgl.Connect_().Close();
        }
        private void xtraTabPage2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void _Companies_Load(object sender, EventArgs e)
        {
            FirmaListesi();
            temizle();
            sehirlistesi();
            carikodaaciklama();

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr != null)
            {
                tXTıd.Text = dr["ID"].ToString();
                TxtAd.Text = dr["AD"].ToString();
                TxtYetkiliGorev.Text = dr["YETKILISTATU"].ToString();
                TxtYetkili.Text = dr["YETKILIADSOYAD"].ToString();
                MSKDTC.Text = dr["YETKILITC"].ToString();
                TxtSektör.Text = dr["SEKTOR"].ToString();
                TxtTel1.Text = dr["TELEFON1"].ToString();
                TxtTel2.Text = dr["TELEFON2"].ToString();
                TxtTel3.Text = dr["TELEFON3"].ToString();
                txtFirmaMail.Text = dr["MAIL"].ToString();
                MSKDFAX.Text = dr["FAX"].ToString();
                Cmbil.Text = dr["IL"].ToString();
                Cmbilce.Text = dr["ILCE"].ToString();
                TxtVergi.Text = dr["VERGIDAIRE"].ToString();
                RichAdres.Text = dr["ADRES"].ToString();
                TXTKOD1.Text = dr["OZELKOD"].ToString();
                TXTKOD2.Text = dr["OZELKOD1"].ToString();
                TXTKOD3.Text = dr["OZELKOD2"].ToString();


            }
        }


        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand komut = new SqlCommand("insert into TBL_FIRMA (AD,YETKILISTATU,YETKILIADSOYAD,YETKILITC,SEKTOR,TELEFON1,TELEFON2,TELEFON3,MAIL,FAX,IL,ILCE,VERGIDAIRE,ADRES,OZELKOD,OZELKOD1,OZELKOD2) VALUES(@P1,@P2,@P3,@P4,@P5,@P6,@P7,@P8,@P9,@P10,@P11,@P12,@P13,@P14,@P5,@P16,@P17)", bgl.Connect_());
                komut.Parameters.AddWithValue("@p1", TxtAd.Text);
                komut.Parameters.AddWithValue("@p2", TxtYetkiliGorev.Text);
                komut.Parameters.AddWithValue("@p3", TxtYetkili.Text);
                komut.Parameters.AddWithValue("@p4", MSKDTC.Text);
                komut.Parameters.AddWithValue("@p5", TxtSektör.Text);
                komut.Parameters.AddWithValue("@p6", TxtTel1.Text);
                komut.Parameters.AddWithValue("@p7", TxtTel2.Text);
                komut.Parameters.AddWithValue("@p8", TxtTel3.Text);
                komut.Parameters.AddWithValue("@p9", txtFirmaMail.Text);
                komut.Parameters.AddWithValue("@p10", MSKDFAX.Text);
                komut.Parameters.AddWithValue("@p11", Cmbil.Text);
                komut.Parameters.AddWithValue("@p12", Cmbilce.Text);
                komut.Parameters.AddWithValue("@p13", TxtVergi.Text);
                komut.Parameters.AddWithValue("@p14", RichAdres.Text);
                komut.Parameters.AddWithValue("@p15", TXTKOD1.Text);
                komut.Parameters.AddWithValue("@p16", TXTKOD2.Text);
                komut.Parameters.AddWithValue("@p17", TXTKOD3.Text);
                komut.ExecuteNonQuery();
                bgl.Connect_().Close();
                MessageBox.Show("Firma Sisteme Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FirmaListesi();
                temizle();

            }
            catch (Exception Hata)
            {
                MessageBox.Show("Hatanın Nedeni :"+Hata.Message+"", "Bilgi");
                
            }
            
        }

        private void Cmbil_SelectedIndexChanged(object sender, EventArgs e)
        {

            Cmbilce.Properties.Items.Clear();
            SqlCommand komut = new SqlCommand("select ILCE from ilceler where SEHIR=@P1 ", bgl.Connect_());
            komut.Parameters.AddWithValue("@p1", Cmbil.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                Cmbilce.Properties.Items.Add(dr[0]);
            }
            bgl.Connect_().Close();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutdelete = new SqlCommand("delete from TBL_FIRMA where ID=@P1", bgl.Connect_());
            komutdelete.Parameters.AddWithValue("@P1", tXTıd.Text);
            komutdelete.ExecuteNonQuery();
            bgl.Connect_().Close();
            FirmaListesi();
            MessageBox.Show("Firma Listeden silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            temizle();

        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komutupdate = new SqlCommand("update TBL_FIRMA SET AD=@P1,YETKILISTATU=@P2,YETKILIADSOYAD=@P3,YETKILITC=@P4,SEKTOR=@P5,TELEFON1=@P6,TELEFON2=@P7,TELEFON3=@P8,MAIL=@P9,FAX=@P10,IL=@P11,ILCE=@P12,VERGIDAIRE=@P13,ADRES=@P14,OZELKOD=@P15,OZELKOD1=@P16,OZELKOD2=@P17 where ID=@P18", bgl.Connect_());
            komutupdate.Parameters.AddWithValue("@p1", TxtAd.Text);
            komutupdate.Parameters.AddWithValue("@p2", TxtYetkiliGorev.Text);
            komutupdate.Parameters.AddWithValue("@p3", TxtYetkili.Text);
            komutupdate.Parameters.AddWithValue("@p4", MSKDTC.Text);
            komutupdate.Parameters.AddWithValue("@p5", TxtSektör.Text);
            komutupdate.Parameters.AddWithValue("@p6", TxtTel1.Text);
            komutupdate.Parameters.AddWithValue("@p7", TxtTel2.Text);
            komutupdate.Parameters.AddWithValue("@p8", TxtTel3.Text);
            komutupdate.Parameters.AddWithValue("@p9", txtFirmaMail.Text);
            komutupdate.Parameters.AddWithValue("@p10", MSKDFAX.Text);
            komutupdate.Parameters.AddWithValue("@p11", Cmbil.Text);
            komutupdate.Parameters.AddWithValue("@p12", Cmbilce.Text);
            komutupdate.Parameters.AddWithValue("@p13", TxtVergi.Text);
            komutupdate.Parameters.AddWithValue("@p14", RichAdres.Text);
            komutupdate.Parameters.AddWithValue("@p15", TXTKOD1.Text);
            komutupdate.Parameters.AddWithValue("@p16", TXTKOD2.Text);
            komutupdate.Parameters.AddWithValue("@p17", TXTKOD3.Text);
            komutupdate.Parameters.AddWithValue("@p18", tXTıd.Text);
            komutupdate.ExecuteNonQuery();
            bgl.Connect_().Close();
            MessageBox.Show("Firma Güncelleme Başarılı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            FirmaListesi();
            temizle();
        }
    }
}
