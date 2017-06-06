namespace Dropbox.WinForms
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.lb_files = new System.Windows.Forms.ListBox();
            this.lb_shares = new System.Windows.Forms.ListBox();
            this.lbl_myFIles = new System.Windows.Forms.Label();
            this.lbl_shares = new System.Windows.Forms.Label();
            this.btn_addFile = new System.Windows.Forms.Button();
            this.btn_deleteFile = new System.Windows.Forms.Button();
            this.btn_downloadFile = new System.Windows.Forms.Button();
            this.lb_hi = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lb_comments = new System.Windows.Forms.ListBox();
            this.tb_comments = new System.Windows.Forms.TextBox();
            this.btn_addComment = new System.Windows.Forms.Button();
            this.btn_deleteComment = new System.Windows.Forms.Button();
            this.btn_authorization = new System.Windows.Forms.Button();
            this.btn_createShare = new System.Windows.Forms.Button();
            this.btn_dloadSharingFile = new System.Windows.Forms.Button();
            this.btn_deleteShareComm = new System.Windows.Forms.Button();
            this.btn_addShareComm = new System.Windows.Forms.Button();
            this.tb_shareComments = new System.Windows.Forms.TextBox();
            this.lb_shareComments = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lb_files
            // 
            this.lb_files.DisplayMember = "Name";
            this.lb_files.FormattingEnabled = true;
            this.lb_files.Location = new System.Drawing.Point(12, 87);
            this.lb_files.Name = "lb_files";
            this.lb_files.Size = new System.Drawing.Size(213, 212);
            this.lb_files.TabIndex = 0;
            this.lb_files.ValueMember = "Name";
            this.lb_files.SelectedIndexChanged += new System.EventHandler(this.lb_files_SelectedIndexChanged);
            // 
            // lb_shares
            // 
            this.lb_shares.DisplayMember = "Name";
            this.lb_shares.FormattingEnabled = true;
            this.lb_shares.Location = new System.Drawing.Point(453, 87);
            this.lb_shares.Name = "lb_shares";
            this.lb_shares.Size = new System.Drawing.Size(177, 212);
            this.lb_shares.TabIndex = 1;
            this.lb_shares.ValueMember = "Name";
            // 
            // lbl_myFIles
            // 
            this.lbl_myFIles.AutoSize = true;
            this.lbl_myFIles.Location = new System.Drawing.Point(85, 71);
            this.lbl_myFIles.Name = "lbl_myFIles";
            this.lbl_myFIles.Size = new System.Drawing.Size(65, 13);
            this.lbl_myFIles.TabIndex = 2;
            this.lbl_myFIles.Text = "Мои файлы";
            // 
            // lbl_shares
            // 
            this.lbl_shares.AutoSize = true;
            this.lbl_shares.Location = new System.Drawing.Point(479, 71);
            this.lbl_shares.Name = "lbl_shares";
            this.lbl_shares.Size = new System.Drawing.Size(124, 13);
            this.lbl_shares.TabIndex = 3;
            this.lbl_shares.Text = "Доступные мне файлы";
            // 
            // btn_addFile
            // 
            this.btn_addFile.Location = new System.Drawing.Point(12, 305);
            this.btn_addFile.Name = "btn_addFile";
            this.btn_addFile.Size = new System.Drawing.Size(98, 23);
            this.btn_addFile.TabIndex = 4;
            this.btn_addFile.Text = "Добавить файл";
            this.btn_addFile.UseVisualStyleBackColor = true;
            this.btn_addFile.Click += new System.EventHandler(this.btn_addFile_Click);
            // 
            // btn_deleteFile
            // 
            this.btn_deleteFile.Location = new System.Drawing.Point(13, 334);
            this.btn_deleteFile.Name = "btn_deleteFile";
            this.btn_deleteFile.Size = new System.Drawing.Size(98, 23);
            this.btn_deleteFile.TabIndex = 5;
            this.btn_deleteFile.Text = "Удалить файл";
            this.btn_deleteFile.UseVisualStyleBackColor = true;
            this.btn_deleteFile.Click += new System.EventHandler(this.btn_deleteFile_Click);
            // 
            // btn_downloadFile
            // 
            this.btn_downloadFile.Location = new System.Drawing.Point(116, 305);
            this.btn_downloadFile.Name = "btn_downloadFile";
            this.btn_downloadFile.Size = new System.Drawing.Size(110, 23);
            this.btn_downloadFile.TabIndex = 6;
            this.btn_downloadFile.Text = "Скачать файл";
            this.btn_downloadFile.UseVisualStyleBackColor = true;
            this.btn_downloadFile.Click += new System.EventHandler(this.btn_downloadFile_Click);
            // 
            // lb_hi
            // 
            this.lb_hi.AutoSize = true;
            this.lb_hi.Location = new System.Drawing.Point(229, 32);
            this.lb_hi.Name = "lb_hi";
            this.lb_hi.Size = new System.Drawing.Size(47, 13);
            this.lb_hi.TabIndex = 8;
            this.lb_hi.Text = "Привет!";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(233, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Комментарии:";
            // 
            // lb_comments
            // 
            this.lb_comments.DisplayMember = "Text";
            this.lb_comments.FormattingEnabled = true;
            this.lb_comments.Location = new System.Drawing.Point(232, 103);
            this.lb_comments.Name = "lb_comments";
            this.lb_comments.Size = new System.Drawing.Size(165, 95);
            this.lb_comments.TabIndex = 10;
            this.lb_comments.ValueMember = "Text";
            this.lb_comments.SelectedIndexChanged += new System.EventHandler(this.lb_comments_SelectedIndexChanged);
            // 
            // tb_comments
            // 
            this.tb_comments.Location = new System.Drawing.Point(232, 204);
            this.tb_comments.Multiline = true;
            this.tb_comments.Name = "tb_comments";
            this.tb_comments.Size = new System.Drawing.Size(165, 34);
            this.tb_comments.TabIndex = 11;
            // 
            // btn_addComment
            // 
            this.btn_addComment.Location = new System.Drawing.Point(232, 244);
            this.btn_addComment.Name = "btn_addComment";
            this.btn_addComment.Size = new System.Drawing.Size(143, 23);
            this.btn_addComment.TabIndex = 12;
            this.btn_addComment.Text = "Добавить комметарий";
            this.btn_addComment.UseVisualStyleBackColor = true;
            this.btn_addComment.Click += new System.EventHandler(this.btn_addComment_Click);
            // 
            // btn_deleteComment
            // 
            this.btn_deleteComment.Location = new System.Drawing.Point(254, 273);
            this.btn_deleteComment.Name = "btn_deleteComment";
            this.btn_deleteComment.Size = new System.Drawing.Size(143, 23);
            this.btn_deleteComment.TabIndex = 13;
            this.btn_deleteComment.Text = "Удалить комметарий";
            this.btn_deleteComment.UseVisualStyleBackColor = true;
            this.btn_deleteComment.Click += new System.EventHandler(this.btn_deleteComment_Click);
            // 
            // btn_authorization
            // 
            this.btn_authorization.Location = new System.Drawing.Point(13, 13);
            this.btn_authorization.Name = "btn_authorization";
            this.btn_authorization.Size = new System.Drawing.Size(97, 23);
            this.btn_authorization.TabIndex = 14;
            this.btn_authorization.Text = "Авторизация";
            this.btn_authorization.UseVisualStyleBackColor = true;
            this.btn_authorization.Click += new System.EventHandler(this.btn_authorization_Click);
            // 
            // btn_createShare
            // 
            this.btn_createShare.Location = new System.Drawing.Point(116, 334);
            this.btn_createShare.Name = "btn_createShare";
            this.btn_createShare.Size = new System.Drawing.Size(109, 23);
            this.btn_createShare.TabIndex = 15;
            this.btn_createShare.Text = "Разрешить доступ";
            this.btn_createShare.UseVisualStyleBackColor = true;
            this.btn_createShare.Click += new System.EventHandler(this.btn_createShare_Click);
            // 
            // btn_dloadSharingFile
            // 
            this.btn_dloadSharingFile.Location = new System.Drawing.Point(453, 305);
            this.btn_dloadSharingFile.Name = "btn_dloadSharingFile";
            this.btn_dloadSharingFile.Size = new System.Drawing.Size(110, 23);
            this.btn_dloadSharingFile.TabIndex = 16;
            this.btn_dloadSharingFile.Text = "Скачать файл";
            this.btn_dloadSharingFile.UseVisualStyleBackColor = true;
            this.btn_dloadSharingFile.Click += new System.EventHandler(this.btn_dloadSharingFile_Click);
            // 
            // btn_deleteShareComm
            // 
            this.btn_deleteShareComm.Location = new System.Drawing.Point(658, 273);
            this.btn_deleteShareComm.Name = "btn_deleteShareComm";
            this.btn_deleteShareComm.Size = new System.Drawing.Size(143, 23);
            this.btn_deleteShareComm.TabIndex = 21;
            this.btn_deleteShareComm.Text = "Удалить комметарий";
            this.btn_deleteShareComm.UseVisualStyleBackColor = true;
            this.btn_deleteShareComm.Click += new System.EventHandler(this.btn_deleteShareComm_Click);
            // 
            // btn_addShareComm
            // 
            this.btn_addShareComm.Location = new System.Drawing.Point(636, 244);
            this.btn_addShareComm.Name = "btn_addShareComm";
            this.btn_addShareComm.Size = new System.Drawing.Size(143, 23);
            this.btn_addShareComm.TabIndex = 20;
            this.btn_addShareComm.Text = "Добавить комметарий";
            this.btn_addShareComm.UseVisualStyleBackColor = true;
            this.btn_addShareComm.Click += new System.EventHandler(this.btn_addShareComm_Click);
            // 
            // tb_shareComments
            // 
            this.tb_shareComments.Location = new System.Drawing.Point(636, 204);
            this.tb_shareComments.Multiline = true;
            this.tb_shareComments.Name = "tb_shareComments";
            this.tb_shareComments.Size = new System.Drawing.Size(165, 34);
            this.tb_shareComments.TabIndex = 19;
            // 
            // lb_shareComments
            // 
            this.lb_shareComments.DisplayMember = "Text";
            this.lb_shareComments.FormattingEnabled = true;
            this.lb_shareComments.Location = new System.Drawing.Point(636, 103);
            this.lb_shareComments.Name = "lb_shareComments";
            this.lb_shareComments.Size = new System.Drawing.Size(165, 95);
            this.lb_shareComments.TabIndex = 18;
            this.lb_shareComments.ValueMember = "Text";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(636, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Комментарии:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 377);
            this.Controls.Add(this.btn_deleteShareComm);
            this.Controls.Add(this.btn_addShareComm);
            this.Controls.Add(this.tb_shareComments);
            this.Controls.Add(this.lb_shareComments);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_dloadSharingFile);
            this.Controls.Add(this.btn_createShare);
            this.Controls.Add(this.btn_authorization);
            this.Controls.Add(this.btn_deleteComment);
            this.Controls.Add(this.btn_addComment);
            this.Controls.Add(this.tb_comments);
            this.Controls.Add(this.lb_comments);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_hi);
            this.Controls.Add(this.btn_downloadFile);
            this.Controls.Add(this.btn_deleteFile);
            this.Controls.Add(this.btn_addFile);
            this.Controls.Add(this.lbl_shares);
            this.Controls.Add(this.lbl_myFIles);
            this.Controls.Add(this.lb_shares);
            this.Controls.Add(this.lb_files);
            this.MaximumSize = new System.Drawing.Size(7640, 5004);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dropbox";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lb_files;
        private System.Windows.Forms.ListBox lb_shares;
        private System.Windows.Forms.Label lbl_myFIles;
        private System.Windows.Forms.Label lbl_shares;
        private System.Windows.Forms.Button btn_addFile;
        private System.Windows.Forms.Button btn_deleteFile;
        private System.Windows.Forms.Button btn_downloadFile;
        private System.Windows.Forms.Label lb_hi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lb_comments;
        private System.Windows.Forms.TextBox tb_comments;
        private System.Windows.Forms.Button btn_addComment;
        private System.Windows.Forms.Button btn_deleteComment;
        private System.Windows.Forms.Button btn_authorization;
        private System.Windows.Forms.Button btn_createShare;
        private System.Windows.Forms.Button btn_dloadSharingFile;
        private System.Windows.Forms.Button btn_deleteShareComm;
        private System.Windows.Forms.Button btn_addShareComm;
        private System.Windows.Forms.TextBox tb_shareComments;
        private System.Windows.Forms.ListBox lb_shareComments;
        private System.Windows.Forms.Label label1;
    }
}

