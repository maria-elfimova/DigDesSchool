using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dropbox.Model;
using File = System.IO.File;

namespace Dropbox.WinForms
{
    public partial class MainForm : Form
    {
        private Guid _userId = new Guid("9bbbbb5f-db09-4b36-9f94-920ec86ffafb");
        private ServiceClient _client;
        private UserForm userForm;
        private Sharing shareForm;

        public MainForm()
        {
            InitializeComponent();
            //_userId = UserForm;
            _client = new ServiceClient("http://localhost:62315/api/", _userId);
            lb_hi.Text = "Привет!";
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //RefreshFileList();
            //RefreshCommentList();
            //RefreshSharesList();
            lb_comments.DisplayMember = "Dropbox.Model.Comment.Name";
            lb_shareComments.DisplayMember = "Name";
        }

        private void RefreshFileList()
        {
            lb_files.DataSource = _client.GetUserFiles();
            lb_shares.DataSource = _client.GetSharesFiles();
        }

        private void RefreshSharesList()
        {
            lb_shares.DataSource = _client.GetSharesFiles();
        }

        private void RefreshCommentList()
        {
            var file = lb_files.SelectedItem as Model.File;
            lb_comments.DataSource = null;
            lb_comments.DisplayMember = "Text";
            if (file != null)
                lb_comments.DataSource = _client.GetFilesComments(file.Id);
        }

        private void RefreshShareCommentList()
        {
            var file = lb_shares.SelectedItem as Model.File;
            lb_shareComments.DataSource = null;
            lb_shareComments.DisplayMember = "Text";
            if (file != null)
                lb_shareComments.DataSource = _client.GetFilesComments(file.Id);
        }

        private void btn_addFile_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dialog = new OpenFileDialog())
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        var fileContent = File.ReadAllBytes(dialog.FileName);
                        var file = new Model.File
                        {
                            Name = Path.GetFileName(dialog.FileName),
                            Owner = new User
                            {
                                Id = _userId,
                            }
                        };
                        var fileId = _client.CreateFile(file);
                        _client.UploadFileContent(fileId, fileContent);
                        RefreshFileList();

                        MessageBox.Show($"Файл {file.Name} успешно загружен", "Загрузка файла", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Не удалось загрузить файл, текст ошибки: {Environment.NewLine}{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_deleteFile_Click(object sender, EventArgs e)
        {
            try
            {
                var item = lb_files.SelectedItem as Model.File;
                if (item != null)
                {
                    _client.DeleteFile(item.Id);
                    RefreshFileList();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Не удалось удалить файл, текст ошибки: {Environment.NewLine}{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_downloadFile_Click(object sender, EventArgs e)
        {
            try
            {
                var item = lb_files.SelectedItem as Model.File;
                if (item != null)
                {
                    using (var dialog = new SaveFileDialog())
                    {
                        dialog.FileName = item.Name;
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            var content = _client.DownloadFile(item.Id);
                            File.WriteAllBytes(dialog.FileName, content);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Не удалось скачать файл, текст ошибки: {Environment.NewLine}{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lb_files_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshCommentList();
        }

        private void btn_addComment_Click(object sender, EventArgs e)
        {
            try
            {
                var text = tb_comments.Text;
                if (text != "")
                {
                    var file = lb_files.SelectedItem as Model.File;
                    var comment = new Comment
                    {
                        Text = text,
                        UserId = _userId,
                        FileId = file.Id
                    };
                    _client.AddCommentOfFile(comment);
                    tb_comments.Text = "";
                }
                else
                {
                    MessageBox.Show("Нельзя оставлять пустые комментарии. Лучше выключить компьютер и пойти погулять.");
                }
                RefreshCommentList();
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Не удалось добавить комментарий, текст ошибки: {Environment.NewLine}{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_deleteComment_Click(object sender, EventArgs e)
        {
            try
            {
                var item = lb_comments.SelectedItem as Model.Comment;
                if (item != null)
                {
                    _client.DeleteComment(item.Id);
                    RefreshCommentList();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Не удалось удалить комментарий, текст ошибки: {Environment.NewLine}{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UserFormExit(object sender, EventArgs e)
        {
            if (userForm.User != null)
            {
                _userId = userForm.User.Id;
                _client = new ServiceClient("http://localhost:62315/api/", _userId);
                lb_hi.Text = "Привет, " + userForm.User.Name + "! Твой идентификатор: " + userForm.User.Id;
            }
            RefreshFileList();
            RefreshCommentList();
            RefreshSharesList();
            RefreshShareCommentList();
        }

        private void ShareFormExit(object sender, EventArgs e)
        {
            var file = lb_files.SelectedItem as Model.File;
            try
            {
                var share = new Share
                {
                    UserId = shareForm.userId,
                    FileId = file.Id
                };
                _client.AddNewShare(share);
            }
            catch
            {
                MessageBox.Show("Не удалось разрешить доступ. Возможно, он уже разрешен?");
            }
        }

        private void btn_authorization_Click(object sender, EventArgs e)
        {
            userForm = new UserForm(_client);
            userForm.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserFormExit);
            userForm.Show();
        }

        private void btn_createShare_Click(object sender, EventArgs e)
        {
            shareForm = new Sharing();
            shareForm.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ShareFormExit);
            shareForm.Show();
        }

        private void btn_dloadSharingFile_Click(object sender, EventArgs e)
        {
            try
            {
                var item = lb_shares.SelectedItem as Model.File;
                if (item != null)
                {
                    using (var dialog = new SaveFileDialog())
                    {
                        dialog.FileName = item.Name;
                        if (dialog.ShowDialog() == DialogResult.OK)
                        {
                            var content = _client.DownloadFile(item.Id);
                            File.WriteAllBytes(dialog.FileName, content);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Не удалось скачать файл, текст ошибки: {Environment.NewLine}{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_addShareComm_Click(object sender, EventArgs e)
        {
            try
            {
                var text = tb_shareComments.Text;
                if (text != "")
                {
                    var file = lb_shares.SelectedItem as Model.File;
                    var comment = new Comment
                    {
                        Text = text,
                        UserId = _userId,
                        FileId = file.Id
                    };
                    _client.AddCommentOfFile(comment);
                    tb_shareComments.Text = "";
                }
                else
                {
                    MessageBox.Show("Нельзя оставлять пустые комментарии. Лучше выключить компьютер и пойти погулять.");
                }
                RefreshShareCommentList();
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Не удалось добавить комментарий, текст ошибки: {Environment.NewLine}{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_deleteShareComm_Click(object sender, EventArgs e)
        {
            try
            {
                var item = lb_shareComments.SelectedItem as Model.Comment;
                if (item != null)
                {
                    _client.DeleteComment(item.Id);
                    RefreshShareCommentList();
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show($"Не удалось удалить комментарий, текст ошибки: {Environment.NewLine}{exception.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lb_comments_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
