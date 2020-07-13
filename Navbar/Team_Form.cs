using Diplom.Database;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Diplom
{
    public partial class Team_Form : Form
    {
        public Team_Form()
        {
            InitializeComponent();

            var user = Cache.Get<User>("user");

            using (var ctx = new Database.ApplicationContext())
            {
                table.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Название",
                    DataPropertyName = "TeamName"
                });
                table.AutoGenerateColumns = false;

                table.DataSource = ctx.UsersInTeams.Where(it => it.UserId == user.UserId).Select(it => it.Team)
                    .ToList();
            }
        }

        private void Team_Form_Load(object sender, EventArgs e)
        {
            this.Left = 529;
            this.Top = 227;
            Add_Failed_2.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Team_Creation team_Creation = new Team_Creation(() =>
            {
                table.Columns.Clear();
                using (var ctx = new Database.ApplicationContext())
                {
                    var user = Cache.Get<User>("user");

                    table.Columns.Add(new DataGridViewTextBoxColumn()
                    {
                        HeaderText = "Название",
                        DataPropertyName = "TeamName"
                    });
                    table.AutoGenerateColumns = false;

                    table.DataSource = ctx.UsersInTeams.Where(it => it.UserId == user.UserId).Select(it => it.Team)
                        .ToList();
                }
            });
            team_Creation.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        { 
            if (table.SelectedRows.Count == 0)
            {
                Add_Failed_2.Visible = true;
                return;
            }
            Team team;
            using (var ctx = new Database.ApplicationContext())
            {
                team = ctx.Teams.FirstOrDefault(it => it.TeamName == (table.SelectedCells[0].Value as string));
            }

            Cache.Add("team", team);
             
            Team_View team_View = new Team_View();
            team_View.Show();
            Close();
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Diplom.Properties.Resources.close_window_32pxBlack;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Diplom.Properties.Resources.close_window_32px;
        }

        private void label12_MouseEnter(object sender, EventArgs e)
        {
            label12.ForeColor = Color.Black;
        }

        private void label12_MouseLeave(object sender, EventArgs e)
        {
            label12.ForeColor = Color.FromArgb(255, 126, 133, 142);
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
         //   label1.ForeColor = Color.Black;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
         //   label1.ForeColor = Color.FromArgb(255, 126, 133, 142);
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.FromArgb(255, 126, 133, 142);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            var teamName = table.SelectedCells[0].Value as string;
            var user = Cache.Get<User>("user");

            if (teamName == null)
            {
                Add_Failed_2.Visible = true;
                return;
            }

            using (var ctx = new Database.ApplicationContext())
            {
                var team = ctx.Teams.First(it => it.TeamName == teamName);
                ctx.UsersInTeams.Remove(ctx.UsersInTeams.FirstOrDefault(it => it.TeamId == team.TeamId && it.UserId == user.UserId));

                ctx.SaveChanges();
            }

            table.Columns.Clear();
            using (var ctx = new Database.ApplicationContext())
            {
                table.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    HeaderText = "Название",
                    DataPropertyName = "TeamName"
                });
                table.AutoGenerateColumns = false;

                table.DataSource = ctx.UsersInTeams.Where(it => it.UserId == user.UserId).Select(it => it.Team)
                    .ToList();
            }
        }

        private void table_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (table.SelectedRows.Count == 0)
            {
                Add_Failed_2.Visible = true;
                return;
            }
            Team team;
            using (var ctx = new Database.ApplicationContext())
            {
                team = ctx.Teams.FirstOrDefault(it => it.TeamName == (table.SelectedCells[0].Value as string));
            }

            Cache.Add("team", team);

            Team_View team_View = new Team_View();
            team_View.Show();
            Close();
        }
    }
}
