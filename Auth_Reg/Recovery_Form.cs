using Diplom.Database;
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

namespace Diplom
{
    public partial class Recovery_Form : Form
    {
        public Recovery_Form()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Diplom.Properties.Resources.close_window_32pxBlack;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Diplom.Properties.Resources.close_window_32px;
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.Font = new Font(label2.Font, FontStyle.Underline);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.Font = new Font(label2.Font, FontStyle.Regular);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Auth_Form auth = new Auth_Form();
            auth.Show();
            this.Close();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            User user;
            using (var ctx = new Database.ApplicationContext())
            {
                user = ctx.Users.FirstOrDefault(it => it.Email == email.Text);


                if (user == null)
                {
                    label3.Visible = true;
                    return;
                }

                Cache.Add("user", user);
                
            }
            


            user = Cache.Get<User>("user");
            var fromAddress = new MailAddress("trino.commercial@gmail.com", "Trino Support");
            var toAddress = user.Email;
            const string fromPassword = "pmptrino558";
            const string subject = "Тех.Поддержка Trino";
            string body = "<h2>Восстановление пароля</h2>" + "Здравствуйте, " + user.Firstname + "<br><br><br>Ваш пароль от аккаунта Trino: " + user.Password + "<br><br><br>С уважением, команда Trino";

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
                Recovery_Sucess.Visible = true;
            }
        }

        private void Recovery_Form_Load(object sender, EventArgs e)
        {
            label3.Visible = false;
            Recovery_Sucess.Visible = false;
        }
    }
}

