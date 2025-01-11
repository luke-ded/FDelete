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

    public partial class AddInvalidDir : Form
    {
        private string? input;
        private Boolean done;

        public AddInvalidDir()
        {
            InitializeComponent();

            inputTB.Text = "C:\\Users\\JohnSmith\\Documents\\Coding";
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

            if(input == "C:\\Users\\JohnSmith\\Documents\\Coding")
            {
                MessageBox.Show("You left the default input \"C:\\Users\\JohnSmith\\Documents\\Coding\".", "Error",
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
            if (!done)
            {
                inputTB.ForeColor = Color.Black;

                done = true;

                inputTB.Text = string.Empty;
            }
        }
    }
}
