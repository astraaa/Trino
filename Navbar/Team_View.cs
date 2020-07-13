using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Data;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore.Query;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Diplom.Database;
using Microsoft.EntityFrameworkCore;
using ApplicationContext = System.Windows.Forms.ApplicationContext;

namespace Diplom
{
    public partial class Team_View : Form
    {
        public Team_View()
        {
            InitializeComponent();

            var team = Cache.Get<Team>("team");
            var user = Cache.Get<User>("user");

            using (var ctx = new Database.ApplicationContext())
            {
                Team_Users.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Surname",
                    HeaderText = "Фамилия"
                });
                Team_Users.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Firstname",
                    HeaderText = "Имя"
                });
                Team_Users.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Lastname",
                    HeaderText = "Отчество"
                });
                Team_Users.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Email",
                    HeaderText = "Электронная почта"
                });
                Team_Users.AutoGenerateColumns = false;

                Team_Tasks.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Summary",
                    HeaderText = "Название"
                });
              /*  Team_Tasks.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Priority",
                    HeaderText = "Приоритет"
                });
                Team_Tasks.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Status",
                    HeaderText = "Статус"
                });
                */
                Team_Tasks.AutoGenerateColumns = false;

                Team_Users.DataSource = ctx.UsersInTeams.ToList().Where(it => it.TeamId == team.TeamId).Select(it =>
                {
                    return ctx.Users.First(t => t.UserId == it.UserId);
                }).ToList();



                if (user.isAdmin == true)
                {
                    Team_Tasks.DataSource = ctx.Tasks.Where(it => it.TeamId == team.TeamId).ToList();
                }
                else
                {
                    Team_Tasks.DataSource = ctx.Tasks.Where(it => it.TeamId == team.TeamId && it.UserId == user.UserId).ToList();
                }
                
            }
        }

        private void Team_View_Load(object sender, EventArgs e)
        {
            this.Left = 640;
            this.Top = 327;


            var user = Cache.Get<User>("user");

            if (!user.isAdmin)
            {
                label6.Enabled = false;
                label4.Enabled = false;
                label1.Enabled = false;
                label3.Enabled = false;
                toolTip1.Show("Вы не администратор!", label6);
                return;
            }
            else
            {
                label6.Enabled = true;
                label4.Enabled = true;
                label1.Enabled = true;
                label3.Enabled = true;
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

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            label4.ForeColor = Color.Black;
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            label4.ForeColor = Color.FromArgb(255, 126, 133, 142);
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            label1.ForeColor = Color.Black;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.FromArgb(255, 126, 133, 142);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            

            var team = Cache.Get<Team>("team");
            var email = Team_Users.SelectedCells[0].Value as string;

            using (var ctx = new Database.ApplicationContext())
            {
                ctx.UsersInTeams.Remove(ctx.UsersInTeams.First(it => it.TeamId == team.TeamId && it.User.Email == email));
                ctx.SaveChanges();

                Team_Users.Columns.Clear();
                Team_Tasks.Columns.Clear();
                Team_Users.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Surname",
                    HeaderText = "Фамилия"
                });
                Team_Users.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Firstname",
                    HeaderText = "Имя"
                });
                Team_Users.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Lastname",
                    HeaderText = "Отчество"
                });
                Team_Users.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Email",
                    HeaderText = "Электронная почта"
                });
                Team_Users.AutoGenerateColumns = false;

                Team_Tasks.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Summary",
                    HeaderText = "Название"
                });
                /*  Team_Tasks.Columns.Add(new DataGridViewTextBoxColumn()
                  {
                      DataPropertyName = "Priority",
                      HeaderText = "Приоритет"
                  });
                  Team_Tasks.Columns.Add(new DataGridViewTextBoxColumn()
                  {
                      DataPropertyName = "Status",
                      HeaderText = "Статус"
                  });
                  */

                Team_Users.DataSource = ctx.UsersInTeams.ToList().Where(it => it.TeamId == team.TeamId).Select(it =>
                {
                    return ctx.Users.First(t => t.UserId == it.UserId);
                }).ToList();

                Team_Tasks.DataSource = ctx.Tasks.Where(it => it.TeamId == team.TeamId).ToList();
            }
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
            label3.ForeColor = Color.Black;
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            label3.ForeColor = Color.FromArgb(255, 126, 133, 142);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            
            Team_Task_Creation team_Task_Creation = new Team_Task_Creation(() =>
            {
                var team = Cache.Get<Team>("team");

                using (var ctx = new Database.ApplicationContext())
                {
                    Team_Users.Columns.Clear();
                    Team_Tasks.Columns.Clear();
                    Team_Users.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "Surname",
                        HeaderText = "Фамилия"
                    });
                    Team_Users.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "Firstname",
                        HeaderText = "Имя"
                    });
                    Team_Users.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "Lastname",
                        HeaderText = "Отчество"
                    });
                    Team_Users.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "Email",
                        HeaderText = "Электронная почта"
                    });
                    Team_Users.AutoGenerateColumns = false;

                    Team_Tasks.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "Summary",
                        HeaderText = "Название"
                    });

                    Team_Users.DataSource = ctx.UsersInTeams.ToList().Where(it => it.TeamId == team.TeamId).Select(it =>
                    {
                        return ctx.Users.First(t => t.UserId == it.UserId);
                    }).ToList();

                    Team_Tasks.DataSource = ctx.Tasks.Where(it => it.TeamId == team.TeamId).ToList();
                }
            });
            team_Task_Creation.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

            var team = Cache.Get<Team>("team");
            var summary = Team_Tasks.SelectedCells[0].Value as string;

            using (var ctx = new Database.ApplicationContext())
            {
                ctx.Tasks.Remove(ctx.Tasks.First(it => it.Summary == summary && it.TeamId == team.TeamId));
                ctx.SaveChanges();

                Team_Users.Columns.Clear();
                Team_Tasks.Columns.Clear();
                Team_Users.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Surname",
                    HeaderText = "Фамилия"
                });
                Team_Users.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Firstname",
                    HeaderText = "Имя"
                });
                Team_Users.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Lastname",
                    HeaderText = "Отчество"
                });
                Team_Users.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Email",
                    HeaderText = "Электронная почта"
                });
                Team_Users.AutoGenerateColumns = false;

                Team_Tasks.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Summary",
                    HeaderText = "Название"
                });

                Team_Users.DataSource = ctx.UsersInTeams.ToList().Where(it => it.TeamId == team.TeamId).Select(it =>
                {
                    return ctx.Users.First(t => t.UserId == it.UserId);
                }).ToList();

                Team_Tasks.DataSource = ctx.Tasks.Where(it => it.TeamId == team.TeamId).ToList();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Переход на форму для добавления пользователя
            Team_Users_Add team_Users_Add = new Team_Users_Add(() =>
            {
                var team = Cache.Get<Team>("team");

                using (var ctx = new Database.ApplicationContext())
                {
                    Team_Users.Columns.Clear();
                    Team_Tasks.Columns.Clear();
                    Team_Users.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "Surname",
                        HeaderText = "Фамилия"
                    });
                    Team_Users.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "Firstname",
                        HeaderText = "Имя"
                    });
                    Team_Users.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "Lastname",
                        HeaderText = "Отчество"
                    });
                    Team_Users.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "Email",
                        HeaderText = "Электронная почта"
                    });
                    Team_Users.AutoGenerateColumns = false;

                    Team_Tasks.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        DataPropertyName = "Summary",
                        HeaderText = "Название"
                    });


                    Team_Users.DataSource = ctx.UsersInTeams.ToList().Where(it => it.TeamId == team.TeamId).Select(it =>
                    {
                        return ctx.Users.First(t => t.UserId == it.UserId);
                    }).ToList();

                    Team_Tasks.DataSource = ctx.Tasks.Where(it => it.TeamId == team.TeamId).ToList();
                }
            });
            team_Users_Add.Show();
        }

        private void Team_Tasks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedTask = Team_Tasks.SelectedCells[0].Value as string;
            Cache.Add("task", selectedTask);
            Team_Task_More team_Task_More = new Team_Task_More();
            team_Task_More.Show();
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            label6.ForeColor = Color.Black;
            var user = Cache.Get<User>("user");
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.ForeColor = Color.FromArgb(255, 126, 133, 142);
        }
    }
}
