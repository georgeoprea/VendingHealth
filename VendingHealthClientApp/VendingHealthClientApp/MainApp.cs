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
    public partial class MainApp : Form
    {
        private ProductsView prodView;
        private User user;

        public MainApp()
        {
            InitializeComponent();
        }

        public MainApp(User user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void displayCredits()
        {
            
        }

        private void MainApp_Load(object sender, EventArgs e)
        {

        }

        private void goToProductsButton_Click(object sender, EventArgs e)
        {
            
            prodView = new ProductsView();
            prodView.Visible = true;
            prodView.Activate();
            this.Close();
        }

        private void MainApp_Activated(object sender, System.EventArgs e)
        {
            
        }

        private void MainApp_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
