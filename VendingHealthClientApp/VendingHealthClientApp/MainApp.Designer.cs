using System;

namespace VendingHealthClientApp
{
    partial class MainApp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.usernameLabel = new System.Windows.Forms.Label();
            this.seeProductsLabel = new System.Windows.Forms.Label();
            this.creditCountDescriptionLabel = new System.Windows.Forms.Label();
            this.creditCountLabel = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.goToProductsButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // usernameLabel
            // 
            this.usernameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usernameLabel.AutoSize = true;
            this.usernameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.usernameLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.usernameLabel.Location = new System.Drawing.Point(3, 0);
            this.usernameLabel.Name = "usernameLabel";
            this.usernameLabel.Size = new System.Drawing.Size(496, 65);
            this.usernameLabel.TabIndex = 0;
            this.usernameLabel.Text = "Welcome back to VendingHealth, Nadina\r\n";
            this.usernameLabel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // seeProductsLabel
            // 
            this.seeProductsLabel.AutoSize = true;
            this.seeProductsLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seeProductsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F);
            this.seeProductsLabel.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.seeProductsLabel.Location = new System.Drawing.Point(3, 229);
            this.seeProductsLabel.Name = "seeProductsLabel";
            this.seeProductsLabel.Size = new System.Drawing.Size(496, 64);
            this.seeProductsLabel.TabIndex = 3;
            this.seeProductsLabel.Text = "To go see the available products";
            this.seeProductsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // creditCountDescriptionLabel
            // 
            this.creditCountDescriptionLabel.AutoSize = true;
            this.creditCountDescriptionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.creditCountDescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.creditCountDescriptionLabel.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.creditCountDescriptionLabel.Location = new System.Drawing.Point(3, 79);
            this.creditCountDescriptionLabel.Name = "creditCountDescriptionLabel";
            this.creditCountDescriptionLabel.Size = new System.Drawing.Size(496, 62);
            this.creditCountDescriptionLabel.TabIndex = 14;
            this.creditCountDescriptionLabel.Text = "Your current credit count:";
            this.creditCountDescriptionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // creditCountLabel
            // 
            this.creditCountLabel.AutoSize = true;
            this.creditCountLabel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.creditCountLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.creditCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.creditCountLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.creditCountLabel.Location = new System.Drawing.Point(3, 141);
            this.creditCountLabel.Name = "creditCountLabel";
            this.creditCountLabel.Size = new System.Drawing.Size(496, 77);
            this.creditCountLabel.TabIndex = 15;
            this.creditCountLabel.Text = "ZZZZ";
            this.creditCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(3, 65);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(100, 14);
            this.label13.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(3, 218);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 11);
            this.label14.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label14, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.usernameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.creditCountLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label13, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.creditCountDescriptionLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.seeProductsLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.goToProductsButton, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.90967F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4.097463F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.99985F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22.52098F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 3.329188F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.76968F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.37316F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(502, 346);
            this.tableLayoutPanel1.TabIndex = 19;
            // 
            // goToProductsButton
            // 
            this.goToProductsButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.goToProductsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.goToProductsButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.goToProductsButton.FlatAppearance.BorderSize = 2;
            this.goToProductsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.goToProductsButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.goToProductsButton.Location = new System.Drawing.Point(3, 296);
            this.goToProductsButton.Name = "goToProductsButton";
            this.goToProductsButton.Size = new System.Drawing.Size(496, 47);
            this.goToProductsButton.TabIndex = 19;
            this.goToProductsButton.Text = "Click Here";
            this.goToProductsButton.UseVisualStyleBackColor = false;
            this.goToProductsButton.Click += new System.EventHandler(this.goToProductsButton_Click);
            // 
            // MainApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(502, 346);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.Name = "MainApp";
            this.Text = "VendingHealth";
            this.Load += new System.EventHandler(this.MainApp_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainApp_FormClosed);
            this.Activated += new EventHandler(this.MainApp_Activated);

        }

        #endregion

        private System.Windows.Forms.Label usernameLabel;
        private System.Windows.Forms.Label seeProductsLabel;
        private System.Windows.Forms.Label creditCountDescriptionLabel;
        private System.Windows.Forms.Label creditCountLabel;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button goToProductsButton;
    }
}