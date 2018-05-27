using System;
using System.Windows.Forms;

namespace VendingHealthClientApp
{
    public partial class MainApp : Form
    {
        private ProductsView prodView;
        private User user;
        private readonly string GREETING = "Welcome back to VendingHealth, ";
        public MainApp()
        {
            InitializeComponent();
        }

        public MainApp(User user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void displayUserInfo()
        {
            creditCountLabel.Text = user.Balance.ToString();
            usernameLabel.Text = this.GREETING + user.Username; 
        }

        private void MainApp_Load(object sender, EventArgs e)
        {
            displayUserInfo();
        }

        private void goToProductsButton_Click(object sender, EventArgs e)
        {
            prodView = new ProductsView(this);
            prodView.Visible = true;
            prodView.Activate();
            this.Hide();
        }

        private void MainApp_Activated(object sender, System.EventArgs e)
        {
            displayUserInfo();
        }

        private void MainApp_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
