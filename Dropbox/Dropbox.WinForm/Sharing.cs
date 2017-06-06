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
    public partial class Sharing : Form
    {
        public Guid userId { get; set; }

        public Sharing()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            userId = new Guid(tb_id.Text);
            Close();
        }
    }
}
