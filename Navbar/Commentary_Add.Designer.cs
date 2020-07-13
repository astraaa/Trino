namespace Diplom
{
    partial class Commentary_Add
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Commentary_Add));
            this.bunifuElipse1 = new Bunifu.Framework.UI.BunifuElipse(this.components);
            this.com = new Bunifu.Framework.UI.BunifuMaterialTextbox();
            this.label1 = new System.Windows.Forms.Label();
            this.Create = new Bunifu.Framework.UI.BunifuThinButton2();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bunifuElipse1
            // 
            this.bunifuElipse1.ElipseRadius = 5;
            this.bunifuElipse1.TargetControl = this;
            // 
            // com
            // 
            this.com.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.com.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.com.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(126)))), ((int)(((byte)(133)))), ((int)(((byte)(142)))));
            this.com.HintForeColor = System.Drawing.Color.Empty;
            this.com.HintText = "";
            this.com.isPassword = false;
            this.com.LineFocusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(105)))), ((int)(((byte)(205)))));
            this.com.LineIdleColor = System.Drawing.Color.Gray;
            this.com.LineMouseHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(105)))), ((int)(((byte)(205)))));
            this.com.LineThickness = 3;
            this.com.Location = new System.Drawing.Point(13, 126);
            this.com.Margin = new System.Windows.Forms.Padding(4);
            this.com.Name = "com";
            this.com.Size = new System.Drawing.Size(324, 32);
            this.com.TabIndex = 78;
            this.com.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 23);
            this.label1.TabIndex = 79;
            this.label1.Text = "Текст комментария:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Create
            // 
            this.Create.ActiveBorderThickness = 1;
            this.Create.ActiveCornerRadius = 25;
            this.Create.ActiveFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(105)))), ((int)(((byte)(205)))));
            this.Create.ActiveForecolor = System.Drawing.Color.White;
            this.Create.ActiveLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(105)))), ((int)(((byte)(205)))));
            this.Create.BackColor = System.Drawing.Color.White;
            this.Create.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Create.BackgroundImage")));
            this.Create.ButtonText = "Добавить";
            this.Create.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Create.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Create.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(105)))), ((int)(((byte)(205)))));
            this.Create.IdleBorderThickness = 1;
            this.Create.IdleCornerRadius = 25;
            this.Create.IdleFillColor = System.Drawing.Color.White;
            this.Create.IdleForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(105)))), ((int)(((byte)(205)))));
            this.Create.IdleLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(105)))), ((int)(((byte)(205)))));
            this.Create.Location = new System.Drawing.Point(108, 167);
            this.Create.Margin = new System.Windows.Forms.Padding(5);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(133, 39);
            this.Create.TabIndex = 116;
            this.Create.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // label5
            // 
            this.label5.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(108, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 17);
            this.label5.TabIndex = 117;
            this.label5.Text = "Заполните поля";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Commentary_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(350, 220);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Create);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.com);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Commentary_Add";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Commentary_Add";
            this.Load += new System.EventHandler(this.Commentary_Add_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Bunifu.Framework.UI.BunifuElipse bunifuElipse1;
        private System.Windows.Forms.Label label1;
        private Bunifu.Framework.UI.BunifuMaterialTextbox com;
        private Bunifu.Framework.UI.BunifuThinButton2 Create;
        private System.Windows.Forms.Label label5;
    }
}