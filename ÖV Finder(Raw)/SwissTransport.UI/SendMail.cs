using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwissTransport.UI
{
    public partial class SendMail : Form
    {
        public SendMail(ListView resultate)
        {
            InitializeComponent();

            foreach (ListViewItem item in resultate.Items)
            {
                foreach (ListViewItem.ListViewSubItem subitem in item.SubItems)
                {
                    rtbText.Text += subitem.Text + @"; ";
                }
                rtbText.Text += Environment.NewLine;
            }
        }
        private void btnSenden_Click(object sender, EventArgs e)
        {
            //Test mail-account : modul318vfi@gmail.com
            //test mail-account password: vfibeschte
            if (string.IsNullOrEmpty(tbEmailEmpfaenger.Text) || string.IsNullOrEmpty(rtbText.Text))
            {
                MessageBox.Show(@"Bitte alle Felder ausfüllen", @"Fehlende Angaben", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                var fromAddress = new MailAddress("modul318vfi@gmail.com", "OV Schweiz");
                var toAddress = new MailAddress(tbEmailEmpfaenger.Text);
                const string fromPassword = "vfibeschte";
                string subject = tbBetreff.Text;
                string body = rtbText.Text;

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
                };
                if (body != null)
                {
                    using (var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = subject,
                        Body = body
                    })
                    {
                        smtp.Send(message);
                    }
                }
                MessageBox.Show(@"Ihr Mail wurde erfolgreich gesendet", @"Mail versendet", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
