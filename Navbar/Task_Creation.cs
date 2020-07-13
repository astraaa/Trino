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
    public partial class Task_Creation : Form
    {
        private Action refreshTable;

        public Task_Creation(Action refreshTable = null)
        {
            this.refreshTable = refreshTable;
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Task_Creation_Load(object sender, EventArgs e)
        {
            this.Left = 640;
            this.Top = 327;
            Add_Sucess.Visible = false;
            label4.Visible = false;
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

        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox2_MouseEnter_1(object sender, EventArgs e)
        {
            pictureBox2.Image = Diplom.Properties.Resources.close_window_32pxBlack;
        }

        private void pictureBox2_MouseLeave_1(object sender, EventArgs e)
        {
            pictureBox2.Image = Diplom.Properties.Resources.close_window_32px;
        }

        private void Create_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new Database.ApplicationContext())
                {
                    if (Convert.ToString(priority.Text) == "" || summary.Text == "")
                    {
                        label5.Visible = true;
                        label4.Visible = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(priority.Text) > 0 && Convert.ToInt32(priority.Text) <= 10)
                        {

                            ctx.SoloTasks.Add(new Database.SoloTask()
                            {
                                Summary = summary.Text,
                                Description = description.Text,
                                Priority = priority.Text,
                                Status = "В процессе",
                                CreatedOn = DateTime.Now,
                                UserId = Cache.Get<User>("user").UserId,
                            });
                            Add_Sucess.Visible = true;
                            label4.Visible = false;
                            ctx.SaveChanges();
                        }
                        else
                        {
                            label4.Visible = true;
                            label5.Visible = false;
                            return;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Введите число в поле приоритета");
            }

            refreshTable();
        }
    }
}
