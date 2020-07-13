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
    public partial class Friends_Add_Form : Form
    {
        public Friends_Add_Form()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Friends_Add_Form_Load(object sender, EventArgs e)
        {
            this.Left = 640;
            this.Top = 327;
            Add_Failed.Visible = false;
            Add_Sucess.Visible = false;
            Add_Failed_2.Visible = false;
        }

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Diplom.Properties.Resources.close_window_32pxBlack;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Diplom.Properties.Resources.close_window_32px;
        }

        private void Login_Click(object sender, EventArgs e)
        {
            var user = Cache.Get<User>("user");

            using (var ctx = new Database.ApplicationContext())
            {
                var secondUser = ctx.Users.FirstOrDefault(it => it.Email == email.Text);

                if (secondUser == null)
                {
                    Add_Failed.Visible = true;
                    return;
                }

                Add_Sucess.Visible = true;

                var secUserList = ctx.FriendDetails.Where(it => it.UserId == secondUser.UserId).ToList();
                var userList = ctx.FriendDetails.Where(it => it.UserId == user.UserId).ToList();

                foreach (var secUserDetail in secUserList)
                {
                    if (userList.FirstOrDefault(it => it.FriendId == secUserDetail.FriendId) != null)
                    {
                        Add_Failed_2.Visible = true;
                    }
                }

                var friendEntity = ctx.Friends.Add(new Friend()
                {
                    AreFriends = false
                });

                ctx.SaveChanges();

                var friend = friendEntity.Entity;

                ctx.FriendDetails.Add(new FriendDetail()
                {
                    FriendId = friend.FriendId,
                    UserId = user.UserId,
                    Type = "Sender"
                });
                ctx.FriendDetails.Add(new FriendDetail()
                {
                    FriendId = friend.FriendId,
                    UserId = secondUser.UserId,
                    Type = "ToUser"
                });

                ctx.SaveChanges();
            }
        }

        private void Add_Failed_Click(object sender, EventArgs e)
        {

        }
    }
}
