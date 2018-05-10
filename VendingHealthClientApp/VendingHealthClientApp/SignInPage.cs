using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VendingHealthClientApp
{
    public partial class SignInPage : Form
    {
        private MainApp mainApp;

        public SignInPage()
        {
            InitializeComponent();
        }

        private void userTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            mainApp = new MainApp();
            mainApp.Visible = true;
            mainApp.Activate();
            this.Hide();
        }
    }
}
