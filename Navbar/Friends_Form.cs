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
    public partial class Friends_Form : Form
    {
        public Friends_Form()
        {
            InitializeComponent();
            // Surname, Firstname, Lastname, Email

            table.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Surname",
                HeaderText = "Фамилия"
            });
            table.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Firstname",
                HeaderText = "Имя"
            });
            table.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Lastname",
                HeaderText = "Отчество"
            });
            table.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Email",
                HeaderText = "Электронная почта"
            });
            table.AutoGenerateColumns = false;

            var user = Cache.Get<User>("user");

            using (var ctx = new ApplicationContext())
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

        private void Friends_Form_Load(object sender, EventArgs e)
        {
            this.Left = 529;
            this.Top = 227;
            Add_Failed_2.Visible = false;
        }

        private void label12_Click(object sender, EventArgs e)
        {
            Friends_Add_Form FAF = new Friends_Add_Form();
            FAF.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Friends_Req_Form FRF = new Friends_Req_Form(() =>
            {
                table.Columns.Clear();
                table.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Surname",
                    HeaderText = "Фамилия"
                });
                table.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Firstname",
                    HeaderText = "Имя"
                });
                table.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Lastname",
                    HeaderText = "Отчество"
                });
                table.Columns.Add(new DataGridViewTextBoxColumn()
                {
                    DataPropertyName = "Email",
                    HeaderText = "Электронная почта"
                });
                table.AutoGenerateColumns = false;

                var user = Cache.Get<User>("user");

                using (var ctx = new ApplicationContext())
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
            });
            FRF.Show();
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
            label1.ForeColor = Color.Black;
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            label1.ForeColor = Color.FromArgb(255, 126, 133, 142);
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            label2.ForeColor = Color.Black;
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            label2.ForeColor = Color.FromArgb(255, 126, 133, 142);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            var user = Cache.Get<User>("user");
            var selectedRows = table.SelectedCells[0].Value as string;

            using (var ctx = new Database.ApplicationContext())
            {
                var allFriends = ctx.FriendDetails.Include(it => it.Friend).Where(it => it.UserId == user.UserId && it.Friend.AreFriends).Select(it => it.Friend)
                    .ToList();

                foreach (var friend in allFriends)
                {
                    var fr = ctx.FriendDetails.FirstOrDefault(it => it.FriendId == friend.FriendId && it.User.Email == selectedRows);

                    if (fr != null)
                    {
                        ctx.Friends.Remove(friend);
                        ctx.SaveChanges();
                    }
                }
            }

            table.Columns.Clear();
            table.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Surname",
                HeaderText = "Фамилия"
            });
            table.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Firstname",
                HeaderText = "Имя"
            });
            table.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Lastname",
                HeaderText = "Отчество"
            });
            table.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Email",
                HeaderText = "Электронная почта"
            });
            table.AutoGenerateColumns = false;

            using (var ctx = new ApplicationContext())
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
        }
    }
}
