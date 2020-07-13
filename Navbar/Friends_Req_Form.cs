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
using Microsoft.EntityFrameworkCore;
using ApplicationContext = Diplom.Database.ApplicationContext;

namespace Diplom
{
    public partial class Friends_Req_Form : Form
    {
        private Action refreshTable;

        public Friends_Req_Form(Action refreshTable = null)
        {
            this.refreshTable = refreshTable;
            InitializeComponent();

            var user = Cache.Get<User>("user");

            Subscribers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Surname",
                HeaderText = "Фамилия"
            });
            Subscribers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Firstname",
                HeaderText = "Имя"
            });
            Subscribers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Lastname",
                HeaderText = "Отчество"
            });
            Subscribers.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Email",
                HeaderText = "Электронная почта"
            });

            using (var ctx = new ApplicationContext())
            {
                var allFriends = ctx.FriendDetails.Include(it => it.Friend).Where(it => it.UserId == user.UserId && it.Type == "ToUser" && !it.Friend.AreFriends).Select(it => it.Friend)
                    .ToList();

                var list = new List<User>();

                foreach (var friend in allFriends)
                {
                    list.AddRange(ctx.FriendDetails.Where(it => it.FriendId == friend.FriendId && it.UserId != user.UserId).Select(it => it.User).ToList());
                }

                Subscribers.AutoGenerateColumns = false;
                Subscribers.DataSource = list;
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Friends_Req_Form_Load(object sender, EventArgs e)
        {
            this.Left = 640;
            this.Top = 327;
            Add_Failed_2.Visible = false;
            Add_Sucess.Visible = false;
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

        private void pictureBox2_MouseEnter(object sender, EventArgs e)
        {
            pictureBox2.Image = Diplom.Properties.Resources.close_window_32pxBlack;
        }

        private void pictureBox2_MouseLeave(object sender, EventArgs e)
        {
            pictureBox2.Image = Diplom.Properties.Resources.close_window_32px;
        }

        private void label1_Click(object sender, EventArgs e)
        {
           var user = Cache.Get<User>("user");
           var selectedRows = Subscribers.SelectedCells;

           if (selectedRows.Count == 0)
           {
                Add_Failed_2.Visible = true;
               return;
           }
            Add_Sucess.Visible = true;

            var secondUser = selectedRows[0].Value as string;

            using (var ctx = new Database.ApplicationContext())
            {
                var secUserList = ctx.FriendDetails.Where(it => it.User.Email == secondUser).ToList();
                var userList = ctx.FriendDetails.Where(it => it.UserId == user.UserId).ToList();

                foreach (var secUserDetail in secUserList)
                {
                    if (userList.FirstOrDefault(it => it.FriendId == secUserDetail.FriendId) != null)
                    {
                        var friend = ctx.Friends.FirstOrDefault(it => it.FriendId == secUserDetail.FriendId);
                        friend.AreFriends = true;
                        ctx.Friends.Update(friend);
                        ctx.SaveChanges();
                        break;
                    }

                }
            }

            refreshTable();
        }
    }
}
