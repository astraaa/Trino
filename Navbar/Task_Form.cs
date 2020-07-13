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
    public partial class Task_Form : Form
    {
        public Task_Form()
        {
            InitializeComponent();

            var user = Cache.Get<User>("user");

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
                    HeaderText = "Создано",
                    DataPropertyName = "CreatedOn"
                });
                table.AutoGenerateColumns = false;
                table.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Завершено",
                    DataPropertyName = "FinishedOn"
                });
                table.AutoGenerateColumns = false;

                table.DataSource = ctx.SoloTasks.Where(it => it.UserId == user.UserId).ToList()
                    .ToList();
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

        private void Task_Form_Load(object sender, EventArgs e)
        {
            this.Left = 529;
            this.Top = 227;
            pictureBox4.Visible = false;
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Task_Creation task_Creation = new Task_Creation(() =>
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
                    table.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        HeaderText = "Завершено",
                        DataPropertyName = "FinishedOn"
                    });
                    table.AutoGenerateColumns = false;

                    table.DataSource = ctx.SoloTasks.Where(it => it.UserId == user.UserId).ToList()
                        .ToList();
                }
            });
            task_Creation.Show();
        }

        private void label12_MouseEnter(object sender, EventArgs e)
        {
            label12.ForeColor = Color.Black;
        }

        private void label12_MouseLeave(object sender, EventArgs e)
        {
            label12.ForeColor = Color.FromArgb(255, 126, 133, 142);
        }

        private void pictureBox3_MouseEnter(object sender, EventArgs e)
        {
            pictureBox3.Image = Diplom.Properties.Resources.filter_24px;
        }

        private void pictureBox3_MouseLeave(object sender, EventArgs e)
        {
            pictureBox3.Image = Diplom.Properties.Resources.filter_24pxGREY;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Image = Diplom.Properties.Resources.generic_sorting_24px;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Image = Diplom.Properties.Resources.generic_sorting_24pxGREY;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = true;
            pictureBox4.Visible = true;
        }

        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            pictureBox4.Image = Diplom.Properties.Resources.generic_sorting_2_24px;
        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            pictureBox4.Image = Diplom.Properties.Resources.generic_sorting_2_24pxGREY;
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.FromArgb(255, 126, 133, 142);
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.FromArgb(255, 126, 133, 142);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
            pictureBox4.Visible = false;
            pictureBox3.Visible = true;
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Black;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.FromArgb(255, 126, 133, 142);
        }


        private void label4_Click(object sender, EventArgs e)
        {
            try
            {
                var taskName = table.SelectedCells[0].Value as string;

                using (var ctx = new Database.ApplicationContext())
                {
                    ctx.SoloTasks.Remove(ctx.SoloTasks.First(it => it.Summary == taskName));
                    ctx.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Список заданий пуст!","Error #2",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
                table.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Завершено",
                    DataPropertyName = "FinishedOn"
                });
                table.AutoGenerateColumns = false;

                table.DataSource = ctx.SoloTasks.Where(it => it.UserId == user.UserId).ToList()
                    .ToList();
            }
        }

        private void table_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var taskStatus = table.SelectedCells[0].Value as string;

                using (var ctx = new Database.ApplicationContext())
                {

                    var task = ctx.SoloTasks

                .Where(it => it.Summary == taskStatus)
                .FirstOrDefault();

                    if (task.Status == "В процессе")
                    {
                        task.FinishedOn = DateTime.Now;


                        task.Status = "Завершено";
                        task.FinishedOn = DateTime.Now;
                        ctx.SoloTasks.Update(task);
                        ctx.SaveChanges();
                    }
                    else
                    {
                        MessageBox.Show("Ошибка! Задание уже завершено!");
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Для завершения задания нажмите дважды на поле 'Название'","Error #1",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
                table.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Завершено",
                    DataPropertyName = "FinishedOn"
                });
                table.AutoGenerateColumns = false;

                table.DataSource = ctx.SoloTasks.Where(it => it.UserId == user.UserId).ToList()
                    .ToList();
            }
        }
    }
}
