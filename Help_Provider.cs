using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;
using Diplom.Database;
using System.Diagnostics;

namespace Diplom
{
    public partial class Help_Provider : Form
    {
        public Help_Provider()
        {
            InitializeComponent();
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Diplom.Properties.Resources.close_window_32pxBlack;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Diplom.Properties.Resources.close_window_32px;
        }

        private void bunifuCustomLabel7_Click(object sender, EventArgs e)
        {
            var user = Cache.Get<User>("user");
            var fromAddress = new MailAddress("trino.commercial@gmail.com", "Trino Support");
            var toAddress = user.Email;
            const string fromPassword = "pmptrino558";
            const string subject = "Тех.Поддержка Trino";
            string body = "<h2>Помощь</h2>" + "Здравствуйте, " + user.Firstname + "<br><br><br>Техническая поддержка Trino будет рада вам помочь<br><br>Для получения ответа на интересующий вас вопрос, отправьте сообщение с подробным описанием проблемы/вопроса в ответ на это сообщение<br><br>С уважением,<em>техническая поддержка Trino";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
           
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(Convert.ToString(fromAddress), toAddress)
            {
                IsBodyHtml = true,
                Subject = subject,
                Body = body
                
            })
            {
                smtp.Send(message);
            }
        }

        private void Help_Provider_Load(object sender, EventArgs e)
        {
            this.Left = 529;
            this.Top = 227;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuCustomLabel10_Click(object sender, EventArgs e)
        {
            var user = Cache.Get<User>("user");
            var fromAddress = new MailAddress("trino.commercial@gmail.com", "Trino Support");
            var toAddress = user.Email;
            const string fromPassword = "pmptrino558";
            const string subject = "Тех.Поддержка Trino";
            string body = "<h2>Жалобы/Предложения</h2>" + "Здравствуйте, " + user.Firstname + "<br><br><br>Техническая поддержка Trino будет рада вам помочь<br><br>Для получения ответа на интересующий вас вопрос, отправьте сообщение с подробным описанием проблемы/вопроса в ответ на это сообщение<br><br>С уважением,<em>техническая поддержка Trino";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,

                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(Convert.ToString(fromAddress), toAddress)
            {
                IsBodyHtml = true,
                Subject = subject,
                Body = body

            })
            {
                smtp.Send(message);
            }
        }

        private void bunifuCustomLabel6_Click(object sender, EventArgs e)
        {
            var user = Cache.Get<User>("user");
            var fromAddress = new MailAddress("trino.commercial@gmail.com", "Trino Marketing");
            var toAddress = user.Email;
            const string fromPassword = "pmptrino558";
            const string subject = "Trino Marketing";
            string body = "<h2>Маркетинг</h2>" + "Здравствуйте, " + user.Firstname + "<br><br><br><b>Вы владелец компании?</b><br><br>Вы можете предложить или просмотреть наши варианты сотрудничества ответив на это сообщение<br><br>С уважением,<em>Trino Marketing";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,

                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(Convert.ToString(fromAddress), toAddress)
            {
                IsBodyHtml = true,
                Subject = subject,
                Body = body

            })
            {
                smtp.Send(message);
            }
        }

        private void bunifuCustomLabel13_Click(object sender, EventArgs e)
        {
            Process.Start(@"C:\Users\admin\Desktop\Trino");
        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel7_MouseEnter(object sender, EventArgs e)
        {
            bunifuCustomLabel7.Font = new Font(bunifuCustomLabel7.Font, FontStyle.Underline);
        }

        private void bunifuCustomLabel7_MouseLeave(object sender, EventArgs e)
        {
            bunifuCustomLabel7.Font = new Font(bunifuCustomLabel7.Font, FontStyle.Regular);
        }

        private void c(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel10_MouseEnter(object sender, EventArgs e)
        {
            bunifuCustomLabel10.Font = new Font(bunifuCustomLabel10.Font, FontStyle.Underline);
        }

        private void bunifuCustomLabel10_MouseLeave(object sender, EventArgs e)
        {
            bunifuCustomLabel10.Font = new Font(bunifuCustomLabel10.Font, FontStyle.Regular);
        }

        private void bunifuCustomLabel6_MouseEnter(object sender, EventArgs e)
        {
            bunifuCustomLabel6.Font = new Font(bunifuCustomLabel6.Font, FontStyle.Underline);
        }

        private void bunifuCustomLabel6_MouseLeave(object sender, EventArgs e)
        {
            bunifuCustomLabel6.Font = new Font(bunifuCustomLabel6.Font, FontStyle.Regular);
        }

        private void bunifuCustomLabel13_MouseEnter(object sender, EventArgs e)
        {
            bunifuCustomLabel13.Font = new Font(bunifuCustomLabel13.Font, FontStyle.Underline);
        }

        private void bunifuCustomLabel13_MouseLeave(object sender, EventArgs e)
        {
            bunifuCustomLabel13.Font = new Font(bunifuCustomLabel13.Font, FontStyle.Regular);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
        }
    }
}
