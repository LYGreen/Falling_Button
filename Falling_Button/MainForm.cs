using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Falling_Button
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Title titleForm = new Title();
            titleForm.TopLevel = false;//顶级控件改成false
            titleForm.Dock = DockStyle.Fill;//填充panel控件
            panel_Main.Controls.Add(titleForm);
            titleForm.Show();
        }
    }
}
