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
    public partial class Files_Form : Form
    {
        public Files_Form()
        {
            InitializeComponent();
        }

        private void Files_Form_Load(object sender, EventArgs e)
        {
            this.Left = 529;
            this.Top = 227;
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

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
        }
    }
}
