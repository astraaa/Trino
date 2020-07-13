using Diplom.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Diplom
{
    public partial class Commentary_Add : Form
    {
        public Commentary_Add()
        {
            InitializeComponent();
        }

        private void Commentary_Add_Load(object sender, EventArgs e)
        {
            this.Left = 850;
            this.Top = 580;
            label5.Visible = false;
        }

        private void Create_Click(object sender, EventArgs e)
        {
            var task = Cache.Get<Task>("task_value");
            var user = Cache.Get<User>("user");

            if (com.Text != "")
            {

                using (var ctx = new Database.ApplicationContext())
                {
                    ctx.Commentaries.Add(new Database.Commentary()
                    {
                        TaskId = task.TaskId,
                        UserId = user.UserId,
                        CreatedOn = DateTime.Now,
                        Text = com.Text
                    });

                    ctx.SaveChanges();
                }
                this.Close();
            }
            else
            {
                label5.Visible = true;
            }
        }
    }
}
