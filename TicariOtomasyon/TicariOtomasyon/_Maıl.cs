using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace TicariOtomasyon
{
    public partial class _Maıl : Form
    {
        public _Maıl()
        {
            InitializeComponent();
        }
        public string Mail;
        private void _Maıl_Load(object sender, EventArgs e)
        {
            textEdit.Text = Mail;
        }

        private void TxtGonder_Click(object sender, EventArgs e)
        {
            MailMessage mesaj = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new System.Net.NetworkCredential("mhmtgler12@outlook.com", "Mehmet.1997");
            istemci.Port = 587;
            istemci.Host = "smtp.live.com";
            istemci.EnableSsl = true;
            mesaj.To.Add(textEdit.Text);
            mesaj.From = new MailAddress("mhmtgler12@outlook.com");
            mesaj.Subject = textEdit1.Text;
            mesaj.Body = richTextBox.Text;

            istemci.Send ( mesaj);

                
                
        }
    }
}
