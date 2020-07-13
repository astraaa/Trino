using Diplom.Database;
using Microsoft.EntityFrameworkCore;
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

    public partial class Team_Task_More : Form
    {
        public Team_Task_More()
        {
            InitializeComponent();

            var taskName = Cache.Get<string>("task");

            using (var ctx = new Database.ApplicationContext())
            {
                var task = ctx.Tasks.First(it => it.Summary == taskName);
                Cache.Add("task_value", task);

                task_name.Text = task.Summary;
                task_priority.Text = Convert.ToString(task.Priority);
                task_status.Text = task.Status;
                task_createdon.Text = Convert.ToString(task.CreatedOn);

                if (task.FinishedOn == null)
                {
                    bunifuCustomLabel8.Text = "Не завершено";
                }
                else
                {
                    bunifuCustomLabel8.Text = $"{task.FinishedOn.Value.ToShortDateString()} {task.FinishedOn.Value.ToShortTimeString()}";
                }

                var abc = ctx.Users.FirstOrDefault(it => it.UserId == task.UserId);

                if (abc == null)
                {
                    bunifuCustomLabel10.Text = "Не назначено";
                }
                else
                {
                    bunifuCustomLabel10.Text = $"{abc.Surname} {abc.Firstname} {abc.Email}";
                }

                var commentaries = ctx.Commentaries.Where(it => it.TaskId == task.TaskId).Include(it => it.User).ToList().Select(it =>
                {
                    return new Commentary()
                    {
                        Text = it.Text,
                        CreatedOn = it.CreatedOn,
                        Author = it.User.Firstname
                    };
                }).ToList();
                Commentary.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Автор",
                    DataPropertyName = "Author"
                });
                Commentary.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Комментарий",
                    DataPropertyName = "Text"
                });
                Commentary.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Дата создания",
                    DataPropertyName = "CreatedOn"
                });
                Commentary.AutoGenerateColumns = false;
                Commentary.DataSource = commentaries;
            }

        }

        private void Team_Task_More_Load(object sender, EventArgs e)
        {
            this.Left = 640;
            this.Top = 327;

                if (Convert.ToInt32(task_priority.Text) <= 3)
                {
                    task_priority.ForeColor = Color.Green;
                }
                else if (Convert.ToInt32(task_priority.Text) >= 4 && Convert.ToInt32(task_priority.Text) <= 6)
                {
                    task_priority.ForeColor = Color.Yellow;
                }
                else
                {
                    task_priority.ForeColor = Color.Red;
                }

                if (task_status.Text == "Завершено")
                {
                    bunifuCustomLabel7.Visible = true;
                }
                else
                {

                    bunifuCustomLabel7.Visible = false;
                }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Create_Click(object sender, EventArgs e)
        {
            Commentary_Add commentary = new Commentary_Add();
            commentary.Show();
        }

        private void bunifuThinButton21_Click(object sender, EventArgs e)
        {
            var task = Cache.Get<Database.Task>("task_value");
            using (var ctx = new Database.ApplicationContext())
            {
                task.Status = "Завершено";
                task.FinishedOn = DateTime.Now;
                ctx.Tasks.Update(task);
                ctx.SaveChanges();
            }
            Close();
        }
    }
}
