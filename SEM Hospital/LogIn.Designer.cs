
namespace SEM_Hospital
{
    partial class LogIn
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogIn));
            this.label5 = new System.Windows.Forms.Label();
            this.LResetBtn = new System.Windows.Forms.Button();
            this.LLoginBtn = new System.Windows.Forms.Button();
            this.LPassTb = new System.Windows.Forms.TextBox();
            this.LPNameTb = new System.Windows.Forms.TextBox();
            this.CUserCb = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.ForeColor = System.Drawing.Color.DarkRed;
            this.label5.Location = new System.Drawing.Point(133, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(160, 31);
            this.label5.TabIndex = 23;
            this.label5.Text = "Choose Type :";
            // 
            // LResetBtn
            // 
            this.LResetBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.LResetBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LResetBtn.ForeColor = System.Drawing.Color.Black;
            this.LResetBtn.Location = new System.Drawing.Point(466, 458);
            this.LResetBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LResetBtn.Name = "LResetBtn";
            this.LResetBtn.Size = new System.Drawing.Size(112, 41);
            this.LResetBtn.TabIndex = 22;
            this.LResetBtn.Text = "Reset";
            this.LResetBtn.UseVisualStyleBackColor = false;
            this.LResetBtn.Click += new System.EventHandler(this.LResetBtn_Click);
            // 
            // LLoginBtn
            // 
            this.LLoginBtn.BackColor = System.Drawing.Color.LimeGreen;
            this.LLoginBtn.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.LLoginBtn.ForeColor = System.Drawing.Color.Black;
            this.LLoginBtn.Location = new System.Drawing.Point(322, 458);
            this.LLoginBtn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LLoginBtn.Name = "LLoginBtn";
            this.LLoginBtn.Size = new System.Drawing.Size(112, 41);
            this.LLoginBtn.TabIndex = 21;
            this.LLoginBtn.Text = "Log In";
            this.LLoginBtn.UseVisualStyleBackColor = false;
            this.LLoginBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // LPassTb
            // 
            this.LPassTb.Location = new System.Drawing.Point(322, 383);
            this.LPassTb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LPassTb.Name = "LPassTb";
            this.LPassTb.Size = new System.Drawing.Size(255, 27);
            this.LPassTb.TabIndex = 20;
            // 
            // LPNameTb
            // 
            this.LPNameTb.Location = new System.Drawing.Point(322, 320);
            this.LPNameTb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.LPNameTb.Name = "LPNameTb";
            this.LPNameTb.Size = new System.Drawing.Size(255, 27);
            this.LPNameTb.TabIndex = 19;
            // 
            // CUserCb
            // 
            this.CUserCb.FormattingEnabled = true;
            this.CUserCb.Items.AddRange(new object[] {
            "Admin",
            "Doctor",
            "Nurse",
            "Receptionist"});
            this.CUserCb.Location = new System.Drawing.Point(322, 258);
            this.CUserCb.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CUserCb.Name = "CUserCb";
            this.CUserCb.Size = new System.Drawing.Size(255, 28);
            this.CUserCb.TabIndex = 18;
            this.CUserCb.Text = "Choose User...";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.DarkRed;
            this.label3.Location = new System.Drawing.Point(133, 383);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 32);
            this.label3.TabIndex = 17;
            this.label3.Text = "Password :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.DarkRed;
            this.label2.Location = new System.Drawing.Point(133, 315);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(146, 32);
            this.label2.TabIndex = 16;
            this.label2.Text = "User Name:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(321, 51);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(256, 179);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Chartreuse;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Location = new System.Drawing.Point(0, -4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(919, 59);
            this.panel1.TabIndex = 24;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.DarkRed;
            this.label1.Location = new System.Drawing.Point(299, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "SEM HOSPITAL..";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(723, 4);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(63, 42);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 15;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // LogIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(796, 563);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.LResetBtn);
            this.Controls.Add(this.LLoginBtn);
            this.Controls.Add(this.LPassTb);
            this.Controls.Add(this.LPNameTb);
            this.Controls.Add(this.CUserCb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "LogIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LogIn";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button LResetBtn;
        private System.Windows.Forms.Button LLoginBtn;
        private System.Windows.Forms.TextBox LPassTb;
        private System.Windows.Forms.TextBox LPNameTb;
        private System.Windows.Forms.ComboBox CUserCb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}

