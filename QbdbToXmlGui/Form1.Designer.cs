namespace QbdbToXmlGui
{
    partial class Form1
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
            this.TrainerHdwBrowse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TrainerHdwText = new System.Windows.Forms.TextBox();
            this.ConvertButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.TrainerPntText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TrainerPntBrowse = new System.Windows.Forms.Button();
            this.CustomerHdwText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.CustomerHdwBrowse = new System.Windows.Forms.Button();
            this.CustomerPntText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CustomerPntBrowse = new System.Windows.Forms.Button();
            this.SuccessLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TrainerHdwBrowse
            // 
            this.TrainerHdwBrowse.Location = new System.Drawing.Point(495, 119);
            this.TrainerHdwBrowse.Name = "TrainerHdwBrowse";
            this.TrainerHdwBrowse.Size = new System.Drawing.Size(75, 23);
            this.TrainerHdwBrowse.TabIndex = 0;
            this.TrainerHdwBrowse.Text = "Browse";
            this.TrainerHdwBrowse.UseVisualStyleBackColor = true;
            this.TrainerHdwBrowse.Click += new System.EventHandler(this.TrainerHdwBrowse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(227, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Trainer Hdw File";
            // 
            // TrainerHdwText
            // 
            this.TrainerHdwText.Location = new System.Drawing.Point(230, 119);
            this.TrainerHdwText.Name = "TrainerHdwText";
            this.TrainerHdwText.Size = new System.Drawing.Size(259, 20);
            this.TrainerHdwText.TabIndex = 2;
            // 
            // ConvertButton
            // 
            this.ConvertButton.Location = new System.Drawing.Point(349, 288);
            this.ConvertButton.Name = "ConvertButton";
            this.ConvertButton.Size = new System.Drawing.Size(75, 23);
            this.ConvertButton.TabIndex = 3;
            this.ConvertButton.Text = "Convert";
            this.ConvertButton.UseVisualStyleBackColor = true;
            this.ConvertButton.Click += new System.EventHandler(this.ConvertButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // TrainerPntText
            // 
            this.TrainerPntText.Location = new System.Drawing.Point(230, 158);
            this.TrainerPntText.Name = "TrainerPntText";
            this.TrainerPntText.Size = new System.Drawing.Size(259, 20);
            this.TrainerPntText.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(227, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Trainer Pnt File";
            // 
            // TrainerPntBrowse
            // 
            this.TrainerPntBrowse.Location = new System.Drawing.Point(495, 158);
            this.TrainerPntBrowse.Name = "TrainerPntBrowse";
            this.TrainerPntBrowse.Size = new System.Drawing.Size(75, 23);
            this.TrainerPntBrowse.TabIndex = 4;
            this.TrainerPntBrowse.Text = "Browse";
            this.TrainerPntBrowse.UseVisualStyleBackColor = true;
            this.TrainerPntBrowse.Click += new System.EventHandler(this.TrainerPntBrowse_Click);
            // 
            // CustomerHdwText
            // 
            this.CustomerHdwText.Location = new System.Drawing.Point(230, 197);
            this.CustomerHdwText.Name = "CustomerHdwText";
            this.CustomerHdwText.Size = new System.Drawing.Size(259, 20);
            this.CustomerHdwText.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(229, 181);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Customer Hdw File";
            // 
            // CustomerHdwBrowse
            // 
            this.CustomerHdwBrowse.Location = new System.Drawing.Point(495, 197);
            this.CustomerHdwBrowse.Name = "CustomerHdwBrowse";
            this.CustomerHdwBrowse.Size = new System.Drawing.Size(75, 23);
            this.CustomerHdwBrowse.TabIndex = 7;
            this.CustomerHdwBrowse.Text = "Browse";
            this.CustomerHdwBrowse.UseVisualStyleBackColor = true;
            this.CustomerHdwBrowse.Click += new System.EventHandler(this.CustomerHdwBrowse_Click);
            // 
            // CustomerPntText
            // 
            this.CustomerPntText.Location = new System.Drawing.Point(230, 236);
            this.CustomerPntText.Name = "CustomerPntText";
            this.CustomerPntText.Size = new System.Drawing.Size(259, 20);
            this.CustomerPntText.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(229, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Customer Pnt File";
            // 
            // CustomerPntBrowse
            // 
            this.CustomerPntBrowse.Location = new System.Drawing.Point(495, 236);
            this.CustomerPntBrowse.Name = "CustomerPntBrowse";
            this.CustomerPntBrowse.Size = new System.Drawing.Size(75, 23);
            this.CustomerPntBrowse.TabIndex = 10;
            this.CustomerPntBrowse.Text = "Browse";
            this.CustomerPntBrowse.UseVisualStyleBackColor = true;
            this.CustomerPntBrowse.Click += new System.EventHandler(this.CustomerPntBrowse_Click);
            // 
            // SuccessLabel
            // 
            this.SuccessLabel.AutoSize = true;
            this.SuccessLabel.Location = new System.Drawing.Point(361, 331);
            this.SuccessLabel.Name = "SuccessLabel";
            this.SuccessLabel.Size = new System.Drawing.Size(51, 13);
            this.SuccessLabel.TabIndex = 13;
            this.SuccessLabel.Text = "Success!";
            this.SuccessLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SuccessLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SuccessLabel);
            this.Controls.Add(this.CustomerPntText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CustomerPntBrowse);
            this.Controls.Add(this.CustomerHdwText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CustomerHdwBrowse);
            this.Controls.Add(this.TrainerPntText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TrainerPntBrowse);
            this.Controls.Add(this.ConvertButton);
            this.Controls.Add(this.TrainerHdwText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TrainerHdwBrowse);
            this.Name = "Form1";
            this.Text = "QBDB Converter to Point Info XML";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TrainerHdwBrowse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TrainerHdwText;
        private System.Windows.Forms.Button ConvertButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox TrainerPntText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button TrainerPntBrowse;
        private System.Windows.Forms.TextBox CustomerHdwText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button CustomerHdwBrowse;
        private System.Windows.Forms.TextBox CustomerPntText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CustomerPntBrowse;
        private System.Windows.Forms.Label SuccessLabel;
    }
}

