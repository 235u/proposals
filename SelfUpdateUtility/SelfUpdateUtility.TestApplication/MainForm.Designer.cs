namespace SelfUpdateUtility.TestApplication
{
    partial class MainForm
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
            this.pushButton = new System.Windows.Forms.Button();
            this.pullButton = new System.Windows.Forms.Button();
            this.lastModifiedTextBox = new System.Windows.Forms.TextBox();
            this.lastModifiedLabel = new System.Windows.Forms.Label();
            this.argumentsLabel = new System.Windows.Forms.Label();
            this.argumentsTextBox = new System.Windows.Forms.TextBox();
            this.processIdLabel = new System.Windows.Forms.Label();
            this.processIdTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // pushButton
            // 
            this.pushButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pushButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pushButton.Location = new System.Drawing.Point(15, 131);
            this.pushButton.Name = "pushButton";
            this.pushButton.Size = new System.Drawing.Size(69, 23);
            this.pushButton.TabIndex = 0;
            this.pushButton.Text = "Push";
            this.pushButton.UseVisualStyleBackColor = true;
            this.pushButton.Click += new System.EventHandler(this.OnPushButtonClick);
            // 
            // pullButton
            // 
            this.pullButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pullButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.pullButton.Location = new System.Drawing.Point(90, 131);
            this.pullButton.Name = "pullButton";
            this.pullButton.Size = new System.Drawing.Size(76, 23);
            this.pullButton.TabIndex = 1;
            this.pullButton.Text = "Pull";
            this.pullButton.UseVisualStyleBackColor = true;
            this.pullButton.Click += new System.EventHandler(this.OnPullButtonClick);
            // 
            // lastModifiedTextBox
            // 
            this.lastModifiedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lastModifiedTextBox.Location = new System.Drawing.Point(15, 103);
            this.lastModifiedTextBox.Name = "lastModifiedTextBox";
            this.lastModifiedTextBox.ReadOnly = true;
            this.lastModifiedTextBox.Size = new System.Drawing.Size(151, 20);
            this.lastModifiedTextBox.TabIndex = 3;
            // 
            // lastModifiedLabel
            // 
            this.lastModifiedLabel.AutoSize = true;
            this.lastModifiedLabel.Location = new System.Drawing.Point(12, 87);
            this.lastModifiedLabel.Name = "lastModifiedLabel";
            this.lastModifiedLabel.Size = new System.Drawing.Size(132, 13);
            this.lastModifiedLabel.TabIndex = 4;
            this.lastModifiedLabel.Text = "Last modified (local value):";
            // 
            // argumentsLabel
            // 
            this.argumentsLabel.AutoSize = true;
            this.argumentsLabel.Location = new System.Drawing.Point(12, 9);
            this.argumentsLabel.Name = "argumentsLabel";
            this.argumentsLabel.Size = new System.Drawing.Size(128, 13);
            this.argumentsLabel.TabIndex = 6;
            this.argumentsLabel.Text = "Command line arguments:";
            // 
            // argumentsTextBox
            // 
            this.argumentsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.argumentsTextBox.Location = new System.Drawing.Point(15, 25);
            this.argumentsTextBox.Name = "argumentsTextBox";
            this.argumentsTextBox.ReadOnly = true;
            this.argumentsTextBox.Size = new System.Drawing.Size(151, 20);
            this.argumentsTextBox.TabIndex = 5;
            // 
            // processIdLabel
            // 
            this.processIdLabel.AutoSize = true;
            this.processIdLabel.Location = new System.Drawing.Point(12, 48);
            this.processIdLabel.Name = "processIdLabel";
            this.processIdLabel.Size = new System.Drawing.Size(59, 13);
            this.processIdLabel.TabIndex = 8;
            this.processIdLabel.Text = "Process id:";
            // 
            // processIdTextBox
            // 
            this.processIdTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.processIdTextBox.Location = new System.Drawing.Point(15, 64);
            this.processIdTextBox.Name = "processIdTextBox";
            this.processIdTextBox.ReadOnly = true;
            this.processIdTextBox.Size = new System.Drawing.Size(151, 20);
            this.processIdTextBox.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(178, 166);
            this.Controls.Add(this.processIdLabel);
            this.Controls.Add(this.processIdTextBox);
            this.Controls.Add(this.argumentsLabel);
            this.Controls.Add(this.argumentsTextBox);
            this.Controls.Add(this.lastModifiedLabel);
            this.Controls.Add(this.lastModifiedTextBox);
            this.Controls.Add(this.pullButton);
            this.Controls.Add(this.pushButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Self-Update Utility";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button pushButton;
        private System.Windows.Forms.Button pullButton;
        private System.Windows.Forms.TextBox lastModifiedTextBox;
        private System.Windows.Forms.Label lastModifiedLabel;
        private System.Windows.Forms.Label argumentsLabel;
        private System.Windows.Forms.TextBox argumentsTextBox;
        private System.Windows.Forms.Label processIdLabel;
        private System.Windows.Forms.TextBox processIdTextBox;
    }
}

