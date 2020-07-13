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
    public partial class Team_Creation : Form
    {
        private Action refreshTable;

        public Team_Creation(Action refreshTable)
        {
            InitializeComponent();
            this.refreshTable = refreshTable;
        }

        private void Team_Creation_Load(object sender, EventArgs e)
        {
            this.Left = 640;
            this.Top = 327;
            Add_Sucess.Visible = false;
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
            var user = Cache.Get<User>("user");


            if (team_name.Text != "")
            {

                using (var ctx = new Database.ApplicationContext())
                {
                    var entryEntity = ctx.Teams.Add(new Team()
                    {
                        TeamName = team_name.Text
                    });
                    ctx.SaveChanges();

                    var team = entryEntity.Entity;

                  //  ctx.Users.Where(it => it.isAdmin == true);
                    user.isAdmin = true;
                    ctx.Users.Update(user);

                    ctx.UsersInTeams.Add(new UserInTeam()
                    {
                        TeamId = team.TeamId,
                        UserId = user.UserId
                    });
                    ctx.SaveChanges();
                }
                Add_Sucess.Visible = true;

                refreshTable();
            }
            else
            {
                label5.Visible = true;
                return;
            }
        }
    }
}
