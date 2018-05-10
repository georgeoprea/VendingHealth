namespace VendingHealthClientApp
{
    partial class SignInPage
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
            this.components = new System.ComponentModel.Container();
            this.userTextBox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.greeting = new System.Windows.Forms.Label();
            this.appDescription = new System.Windows.Forms.Label();
            this.signInButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userTextBox
            // 
            this.userTextBox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.userTextBox.Location = new System.Drawing.Point(255, 246);
            this.userTextBox.Name = "userTextBox";
            this.userTextBox.Size = new System.Drawing.Size(381, 31);
            this.userTextBox.TabIndex = 0;
            this.userTextBox.TextChanged += new System.EventHandler(this.userTextBox_TextChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.passwordTextBox.Location = new System.Drawing.Point(255, 306);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(381, 31);
            this.passwordTextBox.TabIndex = 2;
            this.passwordTextBox.TextChanged += new System.EventHandler(this.passwordTextBox_TextChanged);
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.userLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.userLabel.Location = new System.Drawing.Point(171, 249);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(70, 29);
            this.userLabel.TabIndex = 3;
            this.userLabel.Text = "User:";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.passwordLabel.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.passwordLabel.Location = new System.Drawing.Point(122, 306);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(126, 29);
            this.passwordLabel.TabIndex = 4;
            this.passwordLabel.Text = "Password:";
            // 
            // greeting
            // 
            this.greeting.AutoSize = true;
            this.greeting.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.greeting.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.greeting.Location = new System.Drawing.Point(155, 89);
            this.greeting.Name = "greeting";
            this.greeting.Size = new System.Drawing.Size(492, 44);
            this.greeting.TabIndex = 5;
            this.greeting.Text = "Welcome to VendingHealth!";
            this.greeting.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // appDescription
            // 
            this.appDescription.AutoSize = true;
            this.appDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.appDescription.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.appDescription.Location = new System.Drawing.Point(136, 156);
            this.appDescription.Name = "appDescription";
            this.appDescription.Size = new System.Drawing.Size(545, 29);
            this.appDescription.TabIndex = 6;
            this.appDescription.Text = "Check your credits for the VenidingHealthMachine";
            // 
            // signInButton
            // 
            this.signInButton.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.signInButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signInButton.Location = new System.Drawing.Point(12, 389);
            this.signInButton.Name = "signInButton";
            this.signInButton.Size = new System.Drawing.Size(796, 50);
            this.signInButton.TabIndex = 7;
            this.signInButton.Text = "Sign In";
            this.signInButton.UseVisualStyleBackColor = false;
            this.signInButton.Click += new System.EventHandler(this.signInButton_Click);
            // 
            // SignInPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(819, 451);
            this.Controls.Add(this.signInButton);
            this.Controls.Add(this.appDescription);
            this.Controls.Add(this.greeting);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.userTextBox);
            this.Name = "SignInPage";
            this.Text = "VendingHealth";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userTextBox;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label greeting;
        private System.Windows.Forms.Label appDescription;
        private System.Windows.Forms.Button signInButton;
    }
}

