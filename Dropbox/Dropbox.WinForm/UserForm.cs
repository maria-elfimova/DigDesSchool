using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dropbox.Model;

namespace Dropbox.WinForms
{
    public partial class UserForm : Form
    {
        public User User { get; set; }
        private readonly ServiceClient _client;

        public UserForm(ServiceClient client)
        {
            _client = client;
            InitializeComponent();
        }

        private void UserForm_keyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                btn_enter_Click(sender, e);
            if (e.KeyData == Keys.Escape)
                Close();
        }

        private void btn_enter_Click(object sender, EventArgs e)
        {
            if (tb_id.Text == "" && tb_email.Text != "" && tb_login.Text != "")
            {
                try
                {
                    User = new User
                    {
                        Name = tb_login.Text,
                        Email = tb_email.Text
                    };
                    User = _client.AddNewUser(User);
                    Close();
                }
                catch
                {
                    MessageBox.Show("Данные введены неверно, либо эту электронную почту указал другой пользователь");
                }
            }
            else
            {
                try
                {
                    User = _client.GetUser(new Guid(tb_id.Text));
                    Close();
                }
                catch
                {
                    MessageBox.Show("Не удалось найти пользователя. Проверьте введенные данные.");
                }
            }
        }

        private void lb_id_Click(object sender, EventArgs e)
        {

        }

        private void tb_id_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
