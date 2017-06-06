namespace Dropbox.WinForms
{
    partial class UserForm
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
            this.tb_login = new System.Windows.Forms.TextBox();
            this.tb_email = new System.Windows.Forms.TextBox();
            this.lbl_login = new System.Windows.Forms.Label();
            this.lbl_email = new System.Windows.Forms.Label();
            this.btn_enter = new System.Windows.Forms.Button();
            this.lb_id = new System.Windows.Forms.Label();
            this.tb_id = new System.Windows.Forms.TextBox();
            this.lb_text = new System.Windows.Forms.Label();
            this.lb_text2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_login
            // 
            this.tb_login.Location = new System.Drawing.Point(13, 134);
            this.tb_login.Name = "tb_login";
            this.tb_login.Size = new System.Drawing.Size(100, 20);
            this.tb_login.TabIndex = 0;
            // 
            // tb_email
            // 
            this.tb_email.Location = new System.Drawing.Point(13, 173);
            this.tb_email.Name = "tb_email";
            this.tb_email.Size = new System.Drawing.Size(100, 20);
            this.tb_email.TabIndex = 1;
            // 
            // lbl_login
            // 
            this.lbl_login.AutoSize = true;
            this.lbl_login.Location = new System.Drawing.Point(10, 118);
            this.lbl_login.Name = "lbl_login";
            this.lbl_login.Size = new System.Drawing.Size(32, 13);
            this.lbl_login.TabIndex = 2;
            this.lbl_login.Text = "Имя:";
            // 
            // lbl_email
            // 
            this.lbl_email.AutoSize = true;
            this.lbl_email.Location = new System.Drawing.Point(10, 157);
            this.lbl_email.Name = "lbl_email";
            this.lbl_email.Size = new System.Drawing.Size(107, 13);
            this.lbl_email.TabIndex = 3;
            this.lbl_email.Text = "Электронная почта:";
            // 
            // btn_enter
            // 
            this.btn_enter.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_enter.Location = new System.Drawing.Point(208, 171);
            this.btn_enter.Name = "btn_enter";
            this.btn_enter.Size = new System.Drawing.Size(134, 23);
            this.btn_enter.TabIndex = 5;
            this.btn_enter.Text = "Войти в систему";
            this.btn_enter.UseVisualStyleBackColor = true;
            this.btn_enter.Click += new System.EventHandler(this.btn_enter_Click);
            // 
            // lb_id
            // 
            this.lb_id.AutoSize = true;
            this.lb_id.Location = new System.Drawing.Point(10, 18);
            this.lb_id.Name = "lb_id";
            this.lb_id.Size = new System.Drawing.Size(160, 13);
            this.lb_id.TabIndex = 6;
            this.lb_id.Text = "Введите свой идентификатор:";
            this.lb_id.Click += new System.EventHandler(this.lb_id_Click);
            // 
            // tb_id
            // 
            this.tb_id.Location = new System.Drawing.Point(12, 35);
            this.tb_id.Name = "tb_id";
            this.tb_id.Size = new System.Drawing.Size(165, 20);
            this.tb_id.TabIndex = 7;
            this.tb_id.TextChanged += new System.EventHandler(this.tb_id_TextChanged);
            // 
            // lb_text
            // 
            this.lb_text.AutoSize = true;
            this.lb_text.Location = new System.Drawing.Point(12, 78);
            this.lb_text.Name = "lb_text";
            this.lb_text.Size = new System.Drawing.Size(192, 13);
            this.lb_text.TabIndex = 8;
            this.lb_text.Text = "Или создайте нового пользователя.";
            // 
            // lb_text2
            // 
            this.lb_text2.AutoSize = true;
            this.lb_text2.Location = new System.Drawing.Point(9, 91);
            this.lb_text2.Name = "lb_text2";
            this.lb_text2.Size = new System.Drawing.Size(186, 13);
            this.lb_text2.TabIndex = 9;
            this.lb_text2.Text = " Введите имя и электронную почту:";
            // 
            // UserForm
            // 
            this.AcceptButton = this.btn_enter;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 206);
            this.Controls.Add(this.lb_text2);
            this.Controls.Add(this.lb_text);
            this.Controls.Add(this.tb_id);
            this.Controls.Add(this.lb_id);
            this.Controls.Add(this.btn_enter);
            this.Controls.Add(this.lbl_email);
            this.Controls.Add(this.lbl_login);
            this.Controls.Add(this.tb_email);
            this.Controls.Add(this.tb_login);
            this.Location = new System.Drawing.Point(50, 50);
            this.MaximumSize = new System.Drawing.Size(370, 245);
            this.MinimumSize = new System.Drawing.Size(370, 245);
            this.Name = "UserForm";
            this.Text = "Авторизация";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserForm_keyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_login;
        private System.Windows.Forms.TextBox tb_email;
        private System.Windows.Forms.Label lbl_login;
        private System.Windows.Forms.Label lbl_email;
        private System.Windows.Forms.Button btn_enter;
        private System.Windows.Forms.Label lb_id;
        private System.Windows.Forms.TextBox tb_id;
        private System.Windows.Forms.Label lb_text;
        private System.Windows.Forms.Label lb_text2;
    }
}