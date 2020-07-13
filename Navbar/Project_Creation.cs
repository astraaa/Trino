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
    public partial class Project_Creation : Form
    {
        private Action refreshTable;

        public Project_Creation(Action refreshTable = null)
        {
            this.refreshTable = refreshTable;
            InitializeComponent();
        }

        private void email_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Click(object sender, EventArgs e)
        {

        }

        private void Project_Creation_Load(object sender, EventArgs e)
        {
            this.Left = 640;
            this.Top = 327;
            Add_Sucess.Visible = false;
            label5.Visible = false;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Diplom.Properties.Resources.close_window_32pxBlack;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Diplom.Properties.Resources.close_window_32px;
        }

        private void Create_Click(object sender, EventArgs e)
        {
            if (summary.Text != "" || description.Text != "")
            {

                using (var ctx = new Database.ApplicationContext())
                {

                    var user = Cache.Get<User>("user");
                    ctx.SoloProjects.Add(new Database.SoloProject()
                    {
                        Summary = summary.Text,
                        Description = description.Text,
                        Status = "В процессе",
                        CreatedOn = DateTime.Now,
                        UserId = user.UserId
                    });
                    ctx.SaveChanges();

                    Add_Sucess.Visible = true;
                }
            }
            else
            {
                label5.Visible = true;
                return;
            }

            refreshTable();
        }
    }
}
