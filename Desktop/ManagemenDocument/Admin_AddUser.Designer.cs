﻿namespace ManagemenDocument
{
    partial class Admin_AddUser
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_noIdentitas = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_nama = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rd_user = new System.Windows.Forms.RadioButton();
            this.rd_admin = new System.Windows.Forms.RadioButton();
            this.cb_nameidentitas = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tb_password = new System.Windows.Forms.TextBox();
            this.ck_password = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tb_username = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(224, 379);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(146, 29);
            this.button1.TabIndex = 48;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(70, 379);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(146, 29);
            this.button2.TabIndex = 47;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 204);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Jenis Identitas";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 32;
            this.label3.Text = "No Identitas";
            // 
            // tb_noIdentitas
            // 
            this.tb_noIdentitas.Location = new System.Drawing.Point(14, 172);
            this.tb_noIdentitas.Name = "tb_noIdentitas";
            this.tb_noIdentitas.Size = new System.Drawing.Size(408, 20);
            this.tb_noIdentitas.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Name";
            // 
            // tb_nama
            // 
            this.tb_nama.Location = new System.Drawing.Point(14, 79);
            this.tb_nama.Name = "tb_nama";
            this.tb_nama.Size = new System.Drawing.Size(408, 20);
            this.tb_nama.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 25);
            this.label1.TabIndex = 28;
            this.label1.Text = "User";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 333);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 13);
            this.label6.TabIndex = 55;
            this.label6.Text = "Level :";
            // 
            // rd_user
            // 
            this.rd_user.AutoSize = true;
            this.rd_user.Location = new System.Drawing.Point(82, 332);
            this.rd_user.Name = "rd_user";
            this.rd_user.Size = new System.Drawing.Size(47, 17);
            this.rd_user.TabIndex = 56;
            this.rd_user.TabStop = true;
            this.rd_user.Text = "User";
            this.rd_user.UseVisualStyleBackColor = true;
            this.rd_user.CheckedChanged += new System.EventHandler(this.rd_user_CheckedChanged);
            // 
            // rd_admin
            // 
            this.rd_admin.AutoSize = true;
            this.rd_admin.Location = new System.Drawing.Point(141, 332);
            this.rd_admin.Name = "rd_admin";
            this.rd_admin.Size = new System.Drawing.Size(54, 17);
            this.rd_admin.TabIndex = 57;
            this.rd_admin.TabStop = true;
            this.rd_admin.Text = "Admin";
            this.rd_admin.UseVisualStyleBackColor = true;
            this.rd_admin.CheckedChanged += new System.EventHandler(this.rd_admin_CheckedChanged);
            // 
            // cb_nameidentitas
            // 
            this.cb_nameidentitas.FormattingEnabled = true;
            this.cb_nameidentitas.Location = new System.Drawing.Point(15, 224);
            this.cb_nameidentitas.Name = "cb_nameidentitas";
            this.cb_nameidentitas.Size = new System.Drawing.Size(408, 21);
            this.cb_nameidentitas.TabIndex = 58;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 272);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 60;
            this.label8.Text = "Password ";
            // 
            // tb_password
            // 
            this.tb_password.Location = new System.Drawing.Point(16, 291);
            this.tb_password.Name = "tb_password";
            this.tb_password.Size = new System.Drawing.Size(408, 20);
            this.tb_password.TabIndex = 59;
            this.tb_password.UseSystemPasswordChar = true;
            // 
            // ck_password
            // 
            this.ck_password.AutoSize = true;
            this.ck_password.Location = new System.Drawing.Point(293, 271);
            this.ck_password.Name = "ck_password";
            this.ck_password.Size = new System.Drawing.Size(131, 17);
            this.ck_password.TabIndex = 61;
            this.ck_password.Text = "Use Default Password";
            this.ck_password.UseVisualStyleBackColor = true;
            this.ck_password.CheckedChanged += new System.EventHandler(this.ck_password_CheckedChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 106);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 13);
            this.label9.TabIndex = 63;
            this.label9.Text = "Username";
            // 
            // tb_username
            // 
            this.tb_username.Location = new System.Drawing.Point(12, 125);
            this.tb_username.Name = "tb_username";
            this.tb_username.Size = new System.Drawing.Size(408, 20);
            this.tb_username.TabIndex = 62;
            // 
            // Admin_AddUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 436);
            this.ControlBox = false;
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tb_username);
            this.Controls.Add(this.ck_password);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tb_password);
            this.Controls.Add(this.cb_nameidentitas);
            this.Controls.Add(this.rd_admin);
            this.Controls.Add(this.rd_user);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_noIdentitas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_nama);
            this.Controls.Add(this.label1);
            this.Name = "Admin_AddUser";
            this.Text = "Admin_AddUser";
            this.Load += new System.EventHandler(this.Admin_AddUser_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_noIdentitas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_nama;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rd_user;
        private System.Windows.Forms.RadioButton rd_admin;
        private System.Windows.Forms.ComboBox cb_nameidentitas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tb_password;
        private System.Windows.Forms.CheckBox ck_password;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tb_username;
    }
}