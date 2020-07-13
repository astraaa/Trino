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
    public partial class Team_Task_Creation : Form
    {
        private Action refreshTable;

        public Team_Task_Creation(Action refreshTable = null)
        {
            this.refreshTable = refreshTable;
            InitializeComponent();

            using (var ctx = new Database.ApplicationContext())
            {
                var users = ctx.UsersInTeams.Where(it => it.TeamId == Cache.Get<Team>("team").TeamId).Include(it => it.User).Select(it => it.User).ToList();

                foreach (var user in users)
                {
                    comboBox1.Items.Add(user.Email);
                }
            }
        }

        private void Team_Task_Creation_Load(object sender, EventArgs e)
        {
            this.Left = 530;
            this.Top = 327;
            Add_Failed_2.Visible = false;
            label4.Visible = false;
            label5.Visible = false;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Create_Click(object sender, EventArgs e)
        {
            try
            {
                using (var ctx = new Database.ApplicationContext())
                {
                    if (Convert.ToString(priority.Text) == "" || summary.Text == "")
                    {
                        label5.Visible = true;
                        label4.Visible = false;
                    }
                    else
                    {
                        if (Convert.ToInt32(priority.Text) > 0 && Convert.ToInt32(priority.Text) <= 10)
                        {

                            ctx.Tasks.Add(new Database.Task()
                            {
                                Summary = summary.Text,
                                Description = description.Text,
                                Priority = priority.Text,
                                Status = "В процессе",
                                CreatedOn = DateTime.Now,
                                TeamId = Cache.Get<Team>("team").TeamId,
                                UserId = ctx.Users.First(it => it.Email == (comboBox1.SelectedItem as string)).UserId
                            });
                            Add_Failed_2.Visible = true;
                            label4.Visible = false;
                            ctx.SaveChanges();
                        }
                        else
                        {
                            label4.Visible = true;
                            label5.Visible = false;
                            return;
                        }
                    }
                }


                refreshTable();
            }
            catch (Exception)
            {
                MessageBox.Show("Введите число в поле приоритета");
                return;
            }
        }
    }
}

