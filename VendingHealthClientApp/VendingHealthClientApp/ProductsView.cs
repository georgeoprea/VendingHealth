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
    public partial class ProductsView : Form
    {
        private MainApp mainApp;

        public ProductsView()
        {           
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            mainApp = new MainApp();
            mainApp.Visible = true;
            mainApp.Activate();
            this.Hide();
        }

        private void product1PictureBox_Click(object sender, EventArgs e)
        {

        }

        private void product2PictureBox_Click(object sender, EventArgs e)
        {

        }

        private void ProductsView_Activated(object sender, System.EventArgs e)
        {

        }

        private void ProductsView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
