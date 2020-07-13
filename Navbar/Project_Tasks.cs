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
    public partial class Project_Tasks : Form
    {
        private Action refreshTable;
        public Project_Tasks(Action refreshTable)
        {
            this.refreshTable = refreshTable;
            InitializeComponent();
        }

        private void Project_Tasks_Load(object sender, EventArgs e)
        {
            this.Left = 640;
            this.Top = 327;
            Add_Sucess.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
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

        private void Create_Click(object sender, EventArgs e)
        {
            var taskname = Cache.Get<string>("project_name");
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
                            var project = ctx.SoloProjects.First(it => it.Summary == taskname);

                            ctx.ProjectTasks.Add(new Database.ProjectTask()
                            {
                                Summary = summary.Text,
                                Description = description.Text,
                                Priority = priority.Text,
                                Status = "В процессе",
                                CreatedOn = DateTime.Now,
                                ProjectId = project.SoloProjectId
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
