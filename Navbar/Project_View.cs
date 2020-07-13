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
    public partial class Project_View : Form
    {
        public Project_View()
        {
            InitializeComponent();
            var taskname = Cache.Get<string>("project_name");

            using (var ctx = new Database.ApplicationContext())
            {
                table.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Название",
                    DataPropertyName = "Summary"
                });
                table.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Описание",
                    DataPropertyName = "Description"
                });
                table.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Приоритет",
                    DataPropertyName = "Priority"
                });
                table.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Статус",
                    DataPropertyName = "Status"
                });
                table.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Создан",
                    DataPropertyName = "CreatedOn"
                });
                table.AutoGenerateColumns = false;

                table.DataSource = ctx.ProjectTasks.Where(it => it.SoloProject.Summary == taskname).ToList();
            }
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

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Black;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.ForeColor = Color.FromArgb(255, 126, 133, 142);
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Black;
        }

        private void label4_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.FromArgb(255, 126, 133, 142);
        }

        private void Project_View_Load(object sender, EventArgs e)
        {
            this.Left = 640;
            this.Top = 327;
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Project_Tasks task_Creation = new Project_Tasks(() =>
            {
                var user = Cache.Get<User>("user");

                table.Columns.Clear();
                using (var ctx = new Database.ApplicationContext())
                {
                    table.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        HeaderText = "Название",
                        DataPropertyName = "Summary"
                    });
                    table.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        HeaderText = "Описание",
                        DataPropertyName = "Description"
                    });
                    table.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        HeaderText = "Приоритет",
                        DataPropertyName = "Priority"
                    });
                    table.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        HeaderText = "Статус",
                        DataPropertyName = "Status"
                    });
                    table.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        HeaderText = "Создан",
                        DataPropertyName = "CreatedOn"
                    });
                    table.AutoGenerateColumns = false;

                    table.DataSource = ctx.ProjectTasks.Where(it => it.ProjectId == user.UserId).ToList()
                        .ToList();
                }
            });
            task_Creation.Show();
            
        }

        private void table_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var cells = table.SelectedCells[0].Value as string;

            using (var ctx = new Database.ApplicationContext())
            {
                var task = ctx.ProjectTasks.First(it => it.Summary == cells);
                task.Status = "Завершено";
                task.FinishedOn = DateTime.Now;
                ctx.ProjectTasks.Update(task);
                ctx.SaveChanges();

                table.Columns.Clear();
                table.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Название",
                    DataPropertyName = "Summary"
                });
                table.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Описание",
                    DataPropertyName = "Description"
                });
                table.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Приоритет",
                    DataPropertyName = "Priority"
                });
                table.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Статус",
                    DataPropertyName = "Status"
                });
                table.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Создан",
                    DataPropertyName = "CreatedOn"
                });
                table.AutoGenerateColumns = false;
                var taskname = Cache.Get<string>("project_name");
                table.DataSource = ctx.ProjectTasks.Where(it => it.SoloProject.Summary == taskname).ToList();
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            try
            {
                var taskName = table.SelectedCells[0].Value as string;

                using (var ctx = new Database.ApplicationContext())
                {
                    ctx.ProjectTasks.Remove(ctx.ProjectTasks.First(it => it.Summary == taskName));
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Список заданий пуст!", "Error #2", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var user = Cache.Get<User>("user");

            table.Columns.Clear();
            using (var ctx = new Database.ApplicationContext())
            {
                table.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Название",
                    DataPropertyName = "Summary"
                });
                table.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Описание",
                    DataPropertyName = "Description"
                });
                table.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Приоритет",
                    DataPropertyName = "Priority"
                });
                table.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Статус",
                    DataPropertyName = "Status"
                });
                table.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Создан",
                    DataPropertyName = "CreatedOn"
                });
                table.AutoGenerateColumns = false;

                table.DataSource = ctx.ProjectTasks.Where(it => it.ProjectId == user.UserId).ToList()
                    .ToList();
            }
        }

        private void table_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var taskStatus = table.SelectedCells[0].Value as string;

                using (var ctx = new Database.ApplicationContext())
                {

                    var task = ctx.ProjectTasks

                .Where(it => it.Summary == taskStatus)
                .FirstOrDefault();

                    task.Status = "Завершено";
                    task.FinishedOn = DateTime.Now;
                    ctx.ProjectTasks.Update(task);
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Для завершения задания нажмите дважды на поле 'Название'", "Error #1", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            var user = Cache.Get<User>("user");

            table.Columns.Clear();
            using (var ctx = new Database.ApplicationContext())
            {
                table.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Название",
                    DataPropertyName = "Summary"
                });
                table.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Описание",
                    DataPropertyName = "Description"
                });
                table.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Приоритет",
                    DataPropertyName = "Priority"
                });
                table.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Статус",
                    DataPropertyName = "Status"
                });
                table.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Создан",
                    DataPropertyName = "CreatedOn"
                });
                table.AutoGenerateColumns = false;

                table.DataSource = ctx.ProjectTasks.Where(it => it.ProjectId == user.UserId).ToList()
                    .ToList();
            }
        }
    }
}
