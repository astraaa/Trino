using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Diplom.Database;
using System.Text.RegularExpressions;
using System.Net;

namespace Diplom
{
    public partial class Auth_Form : Form
    {
        public Auth_Form()
        {
            InitializeComponent();
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            Recovery_button.ForeColor = Color.FromArgb(255, 0, 83, 215);
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            Recovery_button.ForeColor = Color.FromArgb(255, 11, 105, 205);
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            Recovery_button.ForeColor = Color.FromArgb(255, 0, 83, 215);
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            Recovery_button.ForeColor = Color.FromArgb(255, 11, 105, 205);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)0x1B)
            {
                this.Close();
            }
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Main_Form main = new Main_Form();
            main.Show();

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(60);
                this.Opacity = this.Opacity - 0.1;
            }

            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(60);
                this.Opacity = this.Opacity + 0.1;
            }

            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Reg_Form reg = new Reg_Form();
            reg.Show();
            

            this.Hide();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            /*
            var Email = email.Text;
            var Password = password.Text;
            var url = $"http://localhost:1337/login?email={email}&password={password}";
            var request = WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                MessageBox.Show("пользователь авторизован");
            }
            else
            {
                MessageBox.Show("Ошибка. Повторите ввод данных");
            }
            */

             using (var ctx = new Database.ApplicationContext())
             {
                 var user = ctx.Users.FirstOrDefault(it => it.Email == email.Text && it.Password == password.Text);


                 if (user == null)
                 {
                     Auth_Failed.Visible = true;
                     email.LineFocusedColor = Color.Red;
                     password.LineFocusedColor = Color.Red;
                     email.LineIdleColor = Color.Red;
                     password.LineIdleColor = Color.Red;
                     Recovery_button.Visible = true;
                     return;
                 }

                 Cache.Add("user", user);
             }
             

            Preloader_Auth preloader = new Preloader_Auth();
            preloader.Show();

        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Diplom.Properties.Resources.close_window_32pxBlack;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Diplom.Properties.Resources.close_window_32px;
        }

        private void Auth_Form_Load(object sender, EventArgs e)
        {
            Auth_Failed.Visible = false;
        }



        private void label3_Click(object sender, EventArgs e)
        {
            Recovery_Form recovery = new Recovery_Form();
            recovery.Show();
            this.Hide();
        }


    }
}
