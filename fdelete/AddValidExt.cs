using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace fdelete
{

    public partial class AddValidExt : Form
    {
        private string? input;
        private Boolean done;

        public AddValidExt()
        {
            InitializeComponent();

            inputTB.Text = ".extention";
            inputTB.ForeColor = Color.DarkGray;

            done = false;
        }

        public string? GetInput()
        {
            return input;
        }

        private void okBT_Click(object sender, EventArgs e)
        {
            input = inputTB.Text;

            if(input == ".extention")
            {
                MessageBox.Show("You left the default input \".extention\".", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void cancelBT_Click(object sender, EventArgs e)
        {
            input = null;
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private void inputTB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!done)
            {
                inputTB.ForeColor = Color.Black;

                done = true;

                inputTB.Text = string.Empty;
            }
        }
    }
}
