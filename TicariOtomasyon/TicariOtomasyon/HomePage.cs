using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicariOtomasyon
{
    public partial class HomePage : Form
    {
        public HomePage()
        {
            InitializeComponent();
        }


        _Products Product_;
        private void BtnUrunler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Product_== null)
            {
             Product_ = new _Products();
            Product_.MdiParent = this;
            Product_.Show();
            }
         
        }
        _Customers Customers_; 
        private void BtnMusteriler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Customers_ == null)
            {
                Customers_ = new _Customers();
                Customers_.MdiParent = this;
                Customers_.Show();
            }

        }
        _Companies Companies_;
        private void BtnFirmalar_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Companies_ == null)
            {
                Companies_ = new _Companies();
                Companies_.MdiParent = this;
                Companies_.Show();
            }
        }
        _Personnel Personel_;
        private void BtnPersoneller_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Personel_==null)
            {
                Personel_ = new _Personnel();
                Personel_.MdiParent = this;
                Personel_.Show();
            }
        }
        _Contact Contact_;
        private void BtnRehber_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Contact_==null)
            {
                Contact_ = new _Contact();
                Contact_.MdiParent = this;
                Contact_.Show();
            }
        }
        _EXPENSES eXPENSES;
        private void BtnGdrler_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (eXPENSES == null)
            {
                eXPENSES = new _EXPENSES();
                eXPENSES.MdiParent = this;
                eXPENSES.Show();
            }
        }
    }
}
