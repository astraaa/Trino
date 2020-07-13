using Diplom.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Diplom
{
    public partial class Team_Users_Add : Form
    {
        private Action refreshTable;

        public Team_Users_Add(Action refreshTable = null)
        {
            this.refreshTable = refreshTable;
            InitializeComponent();

            table.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Surname",
                HeaderText = "Фамилия"
            });
            table.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Email",
                HeaderText = "E-mail"
            });
            table.AutoGenerateColumns = false;

            var user = Cache.Get<User>("user");
            var team = Cache.Get<Team>("team");
            using (var ctx = new Database.ApplicationContext())
            {
                var allFriends = ctx.FriendDetails.Include(it => it.Friend).Where(it => it.UserId == user.UserId && it.Friend.AreFriends).Select(it => it.Friend)
                    .ToList();

                var list = new List<User>();

                foreach (var friend in allFriends)
                {
                    list.AddRange(ctx.FriendDetails.Where(it => it.FriendId == friend.FriendId && it.UserId != user.UserId).Select(it => it.User).ToList());
                }

                table.DataSource = list;
            }

            table.ColumnHeadersVisible = true;
        }

        private void Team_Users_Add_Load(object sender, EventArgs e)
        {
            this.Left = 640;
            this.Top = 327;
            Add_Sucess.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            Auth_Failed.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Login_Click(object sender, EventArgs e)
        {
            var team = Cache.Get<Team>("team");
            var user = Cache.Get<User>("user");

            var userEmail = table.SelectedCells[0].Value as string;

            using (var ctx = new Database.ApplicationContext())
            {
                var secUser = ctx.Users.FirstOrDefault(it => it.Email == userEmail);

                if (secUser == null)
                {
                    Auth_Failed.Visible = true;
                    return;
                }

                if (ctx.UsersInTeams.FirstOrDefault(it => it.UserId == secUser.UserId && it.TeamId == team.TeamId) !=
                    null)
                {
                    label2.Visible = true;
                    return;
                }

                var allFriends = ctx.FriendDetails.Include(it => it.Friend).Where(it => it.UserId == user.UserId && it.Friend.AreFriends).Select(it => it.Friend)
                    .ToList();

                var ok = false;
                foreach (var friend in allFriends)
                {
                    var fr = ctx.FriendDetails.FirstOrDefault(it =>
                        it.FriendId == friend.FriendId && it.UserId != user.UserId && it.UserId == secUser.UserId);

                    if (fr != null)
                    {
                        ok = true;
                        break;
                    }
                }

                if (!ok)
                {
                    label3.Visible = true;
                    return;
                }

                ctx.UsersInTeams.Add(new UserInTeam()
                {
                    TeamId = team.TeamId,
                    UserId = secUser.UserId
                });
                ctx.SaveChanges();
                Add_Sucess.Visible = true;
            }
            refreshTable();
            Close();
        }
    }
}
