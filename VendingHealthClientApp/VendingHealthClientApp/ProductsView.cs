using System;
using System.Windows.Forms;

namespace VendingHealthClientApp
{
    public partial class ProductsView : Form
    {
        private MainApp mainApp;
        private ProductInfo productInfo = new ProductInfo();
        
        public ProductsView()
        {           
            InitializeComponent();
        }

        public ProductsView(MainApp mainApp)
        {
            
            this.mainApp = mainApp;
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
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
            Product[] products = productInfo.GetProducts();

            product1NameLabel.Text = products[0].Name;
            product2NameLabel.Text = products[1].Name;

            product1PictureBox.Load(products[0].ImageUri.ToString());
            product2PictureBox.Load(products[1].ImageUri.ToString());

            product1CreditsLabel.Text = products[0].Kcal.ToString();
            product2CreditsLabel.Text = products[1].Kcal.ToString();

        }

        private void ProductsView_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
