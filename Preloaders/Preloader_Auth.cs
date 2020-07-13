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
    public partial class Preloader_Auth : Form
    {

        List<Color> colors = new List<Color>();
        int current = 0;
        int textchangevalue = 1;
        public Preloader_Auth()
        {
            InitializeComponent();

            colors.Add(Color.FromArgb(255, 11, 105, 205));
            bunifuCircleProgressbar1.ProgressColor = colors[current];

        }


        int dir = 1;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (bunifuCircleProgressbar1.Value == 90)
            {
                dir = -1;
                bunifuCircleProgressbar1.animationIterval = 4;
                SwitchColor();
            }
            else if (bunifuCircleProgressbar1.Value == 10)
            {
                dir = +1;
                bunifuCircleProgressbar1.animationIterval = 2;
                SwitchColor();
            }

                bunifuCircleProgressbar1.Value += dir;

            timer3.Enabled = false;
            this.Close();
            Main_Form main = new Main_Form();
            main.Show();
            Auth_Form auth = new Auth_Form();
            auth.Close();
        }

        void SwitchColor()
        {
            bunifuColorTransition1.Color1 = colors[current];

            if (current < colors.Count - 1)
            {
                current++;
            }
            else
            {
                current = 0;
            }
            bunifuColorTransition1.Color1 = colors[current];

            timer2.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            bunifuColorTransition1.ProgessValue++;
            bunifuCircleProgressbar1.ProgressColor = bunifuColorTransition1.Value;
        }

        private void Preloader_Load(object sender, EventArgs e)
        {
            timer1.Interval = 5000;
            timer1.Enabled = true;
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            textchangevalue++;

            if (textchangevalue == 2 || textchangevalue == 5)
            {
                label1.Text = "Пожалуйста подождите.";
            }
            else if(textchangevalue == 3)
            {
                label1.Text = "Пожалуйста подождите..";
            }
            else if(textchangevalue == 4)
            {
                label1.Text = "Пожалуйста подождите...";
            }
            else
            {
                label1.Text = "Пожалуйста подождите";
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
