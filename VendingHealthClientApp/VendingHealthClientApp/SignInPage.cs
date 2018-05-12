using System;
using System.Windows.Forms;

namespace VendingHealthClientApp
{
    public partial class SignInPage : Form
    {
        private MainApp mainApp;
        private UserInfo userInfo = new UserInfo();
        private string username = "";
        private string password = "";

        public SignInPage()
        {
            InitializeComponent();
        }

        private void userTextBox_TextChanged(object sender, EventArgs e)
       {
            this.username = userTextBox.Text;
        }

        private void passwordTextBox_TextChanged(object sender, EventArgs e)
        {
            this.password = passwordTextBox.Text;
        }

        private void signInButton_Click(object sender, EventArgs e)
        {
            //MessageBox.Show(username + " " + password);
            User user = userInfo.GetUser(username, password);
            if (user == null)
            {
                userTextBox.Clear();
                passwordTextBox.Clear();
                MessageBox.Show("The username or password is not correct! Try Again", "Unable to sign in", MessageBoxButtons.OK);
            }
            else
            {
                mainApp = new MainApp(user);
                mainApp.Visible = true;
                mainApp.Activate();
                this.Hide();
            }
        }
    }
}
