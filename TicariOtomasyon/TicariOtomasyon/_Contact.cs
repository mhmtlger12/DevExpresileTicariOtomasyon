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
    public partial class _Contact : Form
    {
        public _Contact()
        {
            InitializeComponent();
        }
        SqlConnect_ bgl = new SqlConnect_();
        private void gridControl1_Click(object sender, EventArgs e)
        {

        }

        private void _Contact_Load(object sender, EventArgs e)
        {
            //Müşteri Bilgilerini Çağırma
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select AD,SOYAD,TELEFON,TELEFON2,MAIL from TBL_MUSTERILER", bgl.Connect_());
            da.Fill(dt);
            gridControl1.DataSource = dt;


            //Firma Bilgilerini Çağırma

            DataTable dt2 = new DataTable();
            SqlDataAdapter da2 = new SqlDataAdapter("select AD,YETKILISTATU,YETKILIADSOYAD,YETKILITC,TELEFON1,TELEFON2,TELEFON2,MAIL,FAX  from TBL_FIRMA", bgl.Connect_());
            da2.Fill(dt2);
            gridControl2.DataSource = dt2;
        }

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            _Maıl mail = new _Maıl();
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            if (dr!=null)
            {
                mail.Mail = dr["MAIL"].ToString();

            }
            mail.Show();
        }

        private void gridView2_DoubleClick(object sender, EventArgs e)
        {
            _Maıl mail = new _Maıl();
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            if (dr != null)
            {
                mail.Mail = dr["MAIL"].ToString();

            }
            mail.Show();
        }
    }
    }
