using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Diplom.Database;

namespace Diplom
{
    public partial class Reg_Form : Form
    {
        public Reg_Form()
        {
            InitializeComponent();

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Auth_Form auth = new Auth_Form();
            auth.Show();

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

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.FromArgb(255, 0, 83, 215);
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.FromArgb(255, 11, 105, 205);
        }

        private void Reg_Form_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)0x1B)
            {
                this.Close();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Auth_Form auth = new Auth_Form();
            auth.Show();
            this.Close();
        }
        private void Reg_Click(object sender, EventArgs e)
        {

        }


        private void label4_Click_1(object sender, EventArgs e)
        {
            Auth_Form auth = new Auth_Form();
            auth.Show();
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

        private void Reg_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new Database.ApplicationContext())
                {

                    if (!email.Text.Contains("@gmail.com") && !email.Text.Contains("@yandex.by") && !email.Text.Contains("@mail.ru"))
                    {
                        Reg_Failed.Visible = true;
                        return;
                    }
                    else
                    {
                        ctx.Users.Add(new User()
                        {
                            Email = email.Text,
                            Password = password.Text
                        });
                        ctx.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Пользователь с таким e-mail уже зарегистрирован");
                return;
            }

            Reg_Sucess.Visible = true;

            Auth_Form auth = new Auth_Form();
            auth.Show();

            this.Close();
        }

        private void Reg_Form_Load(object sender, EventArgs e)
        {
            Reg_Failed.Visible = false;
            Reg_Sucess.Visible = false;
        }
    }
}
