using Diplom.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom
{
    public partial class Main_Form : Form
    {
        public Main_Form()
        {
            InitializeComponent();
               
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            panel3.Visible = true;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            panel3.Visible = false;
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            panel4.Visible = true;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            panel4.Visible = false;
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            panel5.Visible = true;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            panel5.Visible = false;
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            panel6.Visible = true;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            panel6.Visible = false;
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            panel7.Visible = true;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            panel7.Visible = false;
        }

        private void label7_MouseEnter(object sender, EventArgs e)
        {
            panel8.Visible = true;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            panel8.Visible = false;
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            bunifuCards1.Visible = false;
            panel18.Visible = false;
            pictureBox4.Visible = false;
            panel23.Visible = false; 
            label34.Visible = false;
            label35.Visible = false;
            label36.Visible = false;
            label37.Visible = false;
            timer1.Start();

        }

        private void label10_MouseEnter(object sender, EventArgs e)
        {
            panel18.Visible = true;
        }

        private void label10_MouseLeave(object sender, EventArgs e)
        {
            panel18.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Main_Form_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)0x1B)
            {
                this.Close();
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(255, 23, 31, 70);
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label5.ForeColor = Color.White;
            label7.ForeColor = Color.White;
        }

        private void label16_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.White;
            label1.ForeColor = Color.Black;
            label2.ForeColor = Color.Black;
            label3.ForeColor = Color.Black;
            label4.ForeColor = Color.Black;
            label5.ForeColor = Color.Black;
            label7.ForeColor = Color.Black;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            bunifuCards1.Visible = true;
            pictureBox3.Visible = false;
            pictureBox4.Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            bunifuCards1.Visible = false;
            pictureBox3.Visible = true;
            pictureBox4.Visible = false;
        }


        private void label26_Click(object sender, EventArgs e)
        {
            label6.BackColor = Color.FromArgb(255, 23, 31, 70);
            label6.ForeColor = Color.White;
        }

        private void label27_Click(object sender, EventArgs e)
        {
            label6.BackColor = Color.FromArgb(255, 11, 105, 205);
            label6.ForeColor = Color.White;
        }

        private void label28_Click(object sender, EventArgs e)
        {
            label6.BackColor = Color.FromArgb(255, 255, 11, 55);
            label6.ForeColor = Color.White;
        }

        private void label29_Click(object sender, EventArgs e)
        {
            label6.BackColor = Color.FromArgb(255, 107, 56, 251);
            label6.ForeColor = Color.White;
        }

        private void label30_Click(object sender, EventArgs e)
        {
            label6.BackColor = Color.BlanchedAlmond;
            label6.ForeColor = Color.Black;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Diplom.Properties.Resources.close_window_32pxBlack;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Diplom.Properties.Resources.close_window_32px;
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Image = Diplom.Properties.Resources.double_left_24pxActive;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Diplom.Properties.Resources.double_left_24px;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Image = Diplom.Properties.Resources.double_right_24pxActive;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Image = Diplom.Properties.Resources.double_right_24px;
        }

        private void label14_MouseEnter(object sender, EventArgs e)
        {
            panel23.Visible = true;
        }

        private void label14_MouseLeave(object sender, EventArgs e)
        {
            panel23.Visible = false;
        }

        private void pictureBox2_MouseEnter_1(object sender, EventArgs e)
        {
            pictureBox2.Image = Diplom.Properties.Resources.close_window_32pxBlack;
        }

        private void pictureBox2_MouseLeave_1(object sender, EventArgs e)
        {
            pictureBox2.Image = Diplom.Properties.Resources.close_window_32px;
        }

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void label14_MouseEnter_1(object sender, EventArgs e)
        {
            panel23.Visible = true;
        }

        private void label14_MouseLeave_1(object sender, EventArgs e)
        {
            panel23.Visible = false;
        }

        private void label10_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            bunifuCards1.Visible = false;
            panel18.Visible = false;
            pictureBox4.Visible = false;
            panel23.Visible = false;
            panel9.Visible = true;
            label34.Visible = false;
            label35.Visible = false;
            label36.Visible = false;
            label37.Visible = false;
            label9.Visible = true;
            label11.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
            label20.Visible = true;
        }

        private void label14_Click(object sender, EventArgs e)
        {
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            bunifuCards1.Visible = false;
            panel18.Visible = false;
            pictureBox4.Visible = false;
            panel23.Visible = true;
            panel9.Visible = false;
            label34.Visible = true;
            label35.Visible = true;
            label36.Visible = true;
            label37.Visible = true;
            label9.Visible = false;
            label11.Visible = false;
            label15.Visible = false;
            label16.Visible = false;
            label18.Visible = false;
            label19.Visible = false;
            label20.Visible = false;    
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Task_Form task = new Task_Form();
            task.Show();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Profile_Form profile = new Profile_Form();
            profile.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Files_Form files = new Files_Form();
            files.Show();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Project_Form project = new Project_Form();
            project.Show();
        }


        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            Help_Provider help = new Help_Provider();
            help.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Preloader_Auth preloader = new Preloader_Auth();
            preloader.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(255, 23, 31, 70);
            label10.ForeColor = Color.White;
            label14.ForeColor = Color.White;
            panel23.BackColor = Color.White;
            panel18.BackColor = Color.White;
            pictureBox2.Image = Diplom.Properties.Resources.close_window_32pxWhite;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.White;
            label10.ForeColor = Color.Black;
            label14.ForeColor = Color.Black;
            panel23.BackColor = Color.FromArgb(255, 11, 105, 205);
            panel18.BackColor = Color.FromArgb(255, 11, 105, 205);
            pictureBox2.Image = Diplom.Properties.Resources.close_window_32px;
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(255, 255, 11, 55);
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label5.ForeColor = Color.White;
            label7.ForeColor = Color.White;

            panel3.BackColor = Color.White;
            panel4.BackColor = Color.White;
            panel5.BackColor = Color.White;
            panel6.BackColor = Color.White;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.White;

            label12.ForeColor = Color.White;

            bunifuFlatButton1.BackColor = Color.White;
            bunifuFlatButton1.Textcolor = Color.Black;
            bunifuFlatButton1.Normalcolor = Color.White;
            bunifuFlatButton1.OnHovercolor = Color.FromArgb(255, 148, 149, 150);
            pictureBox1.Image = Diplom.Properties.Resource1._12345;

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(255, 11, 105, 205);
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label5.ForeColor = Color.White;
            label7.ForeColor = Color.White;
            label12.ForeColor = Color.White;
            bunifuFlatButton1.BackColor = Color.FromArgb(255, 23, 31, 70);
            bunifuFlatButton1.Normalcolor = Color.FromArgb(255, 23, 31, 70);
            bunifuFlatButton1.OnHovercolor = Color.FromArgb(255, 0, 83, 215);
            bunifuFlatButton1.Textcolor = Color.White;
            pictureBox1.Image = Diplom.Properties.Resource1._12345;

            panel3.BackColor = Color.White;
            panel4.BackColor = Color.White;
            panel5.BackColor = Color.White;
            panel6.BackColor = Color.White;
            panel7.BackColor = Color.White;
            panel8.BackColor = Color.White;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(255, 11, 105, 205);
            label10.ForeColor = Color.White;
            label14.ForeColor = Color.White;
            panel23.BackColor = Color.White;
            panel18.BackColor = Color.White;
            pictureBox2.Image = Diplom.Properties.Resources.close_window_32pxWhite;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.FromArgb(255, 255, 11, 55);
            label10.ForeColor = Color.White;
            label14.ForeColor = Color.White;
            panel23.BackColor = Color.White;
            panel18.BackColor = Color.White;

            pictureBox2.Image = Diplom.Properties.Resources.close_window_32pxWhite;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            panel2.BackColor = Color.BlanchedAlmond;
            label10.ForeColor = Color.Black;
            label14.ForeColor = Color.Black;
            panel23.BackColor = Color.Black;
            panel18.BackColor = Color.Black;

            pictureBox2.Image = Diplom.Properties.Resources.close_window_32pxBlack;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(255, 23, 31, 70);
            label1.ForeColor = Color.White;
            label2.ForeColor = Color.White;
            label3.ForeColor = Color.White;
            label4.ForeColor = Color.White;
            label5.ForeColor = Color.White;
            label7.ForeColor = Color.White;

            label12.ForeColor = Color.FromArgb(255, 126, 133, 142);

            pictureBox1.Image = Diplom.Properties.Resources.help_44px2;

            panel3.BackColor = Color.FromArgb(255, 11, 105, 205);
            panel4.BackColor = Color.FromArgb(255, 11, 105, 205);
            panel5.BackColor = Color.FromArgb(255, 11, 105, 205);
            panel6.BackColor = Color.FromArgb(255, 11, 105, 205);
            panel7.BackColor = Color.FromArgb(255, 11, 105, 205);
            panel8.BackColor = Color.FromArgb(255, 11, 105, 205);

            bunifuFlatButton1.BackColor = Color.FromArgb(255, 11, 105, 205);
            bunifuFlatButton1.Normalcolor = Color.FromArgb(255, 11, 105, 205);
            bunifuFlatButton1.OnHovercolor = Color.FromArgb(255, 0, 83, 215);
            bunifuFlatButton1.Textcolor = Color.White;
        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            label6.BackColor = Color.FromArgb(255, 23, 31, 70);
            label6.ForeColor = Color.White;
        }

        private void pictureBox14_Click(object sender, EventArgs e)
        {
            label6.BackColor = Color.FromArgb(255, 11, 105, 205);
            label6.ForeColor = Color.White;
        }

        private void pictureBox15_Click(object sender, EventArgs e)
        {
            label6.BackColor = Color.FromArgb(255, 107, 56, 251);
            label6.ForeColor = Color.White;
        }

        private void pictureBox16_Click(object sender, EventArgs e)
        {
            label6.BackColor = Color.FromArgb(255, 255, 11, 55);
            label6.ForeColor = Color.White;
        }

        private void pictureBox17_Click(object sender, EventArgs e)
        {
            label6.BackColor = Color.BlanchedAlmond;
            label6.ForeColor = Color.Black;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Friends_Form friends = new Friends_Form();
            friends.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Team_Form team = new Team_Form();
            team.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            using (var ctx = new Database.ApplicationContext())
            {
                label18.Text = Convert.ToString(ctx.Users.Count());
                label19.Text = Convert.ToString(ctx.SoloProjects.Count());
                label20.Text = Convert.ToString(ctx.Teams.Count());
            }
        }
    }
}
