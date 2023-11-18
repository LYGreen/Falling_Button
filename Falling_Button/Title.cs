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
    public partial class Title : Form
    {
        public Title()
        {
            InitializeComponent();
        }

        private void button_Start_Click(object sender, EventArgs e)
        {
            GamePlay gamePlayForm = new GamePlay();
            gamePlayForm.TopLevel = false;
            gamePlayForm.Dock = DockStyle.Fill;
            this.Parent.Controls.Add(gamePlayForm);
            gamePlayForm.Show();
            gamePlayForm.Focus();//使该控件获取焦点
            this.Dispose();
        }

        private void button_Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_BOTTON_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Thanks for playing !", "MessageBox");
        }
    }
}
