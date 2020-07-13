using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Diplom.Database;
using ApplicationContext = System.Windows.Forms.ApplicationContext;

namespace Diplom
{
    public partial class Profile_Form : Form
    {
        public Profile_Form()
        {
            InitializeComponent();
        }

        private void Profile_Form_Load(object sender, EventArgs e)
        {
            this.Left = 529;
            this.Top = 227;
            bunifuThinButton22.Visible = false;

            label5.Visible = false;

            Surname.Enabled = false;
            Firstname.Enabled = false;
            Lastname.Enabled = false;
            Phone.Enabled = false;
            Adress.Enabled = false;
            Otdel.Enabled = false;
            label2.Cursor = Cursors.Default;
            label2.Visible = false;

            var user = Cache.Get<User>("user");
            Surname.Text = user.Surname;
            Firstname.Text = user.Firstname;
            Lastname.Text = user.Lastname;
            Phone.Text = user.Phone;
            Adress.Text = user.Adress;
            Otdel.Text = user.Otdel;


        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (Surname.Text == "" || Firstname.Text == "" || Lastname.Text == "" || Phone.Text == "" || Adress.Text == "" || Otdel.Text == "")
            {
                label5.Visible = true;
            }
                else
            {
                this.Close();
            }
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Diplom.Properties.Resources.close_window_32pxBlack;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Diplom.Properties.Resources.close_window_32px;
        }

        private void Surname_Click(object sender, EventArgs e)
        {
            Surname.Text = "";
        }

        private void User_Name_Click(object sender, EventArgs e)
        {
            Firstname.Text = "";
        }

        private void Dadname_Click(object sender, EventArgs e)
        {
            Lastname.Text = "";
        }

        private void Phone_Click(object sender, EventArgs e)
        {
            Phone.Text = "";
        }

        private void Adress_Click(object sender, EventArgs e)
        {
            Adress.Text = "";
        }

        private void Podrazdel_Click(object sender, EventArgs e)
        {
            Otdel.Text = "";
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            bunifuThinButton21.Visible = false;
            bunifuThinButton22.Visible = true;
            Surname.Enabled = true;
            Firstname.Enabled = true;
            Lastname.Enabled = true;
            Phone.Enabled = true;
            Adress.Enabled = true;
            Otdel.Enabled = true;
            label2.Cursor = Cursors.Hand;
            label2.Visible = true;
        }

        private void bunifuThinButton22_Click(object sender, EventArgs e)
        {
            bunifuThinButton22.Visible = false;
            bunifuThinButton21.Visible = true;
            Surname.Enabled = false;
            Firstname.Enabled = false;
            Lastname.Enabled = false;
            Phone.Enabled = false;
            Adress.Enabled = false;
            Otdel.Enabled = false;
            label2.Cursor = Cursors.Default;
            label2.Visible = false;

            using (var ctx = new Diplom.Database.ApplicationContext())
            {
                var user = Cache.Get<User>("user");

                user.Surname = Surname.Text;
                user.Firstname = Firstname.Text;
                user.Lastname = Lastname.Text;
                user.Phone = Phone.Text;
                user.Adress = Adress.Text;
                user.Otdel = Otdel.Text;

                ctx.Users.Update(user);
                ctx.SaveChanges();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.ShowDialog();
            string FileName = openFileDialog.FileName;
            avatar.ImageLocation = FileName;
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }
    }
}
