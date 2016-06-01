namespace SwissTransport.UI
{
    partial class SendMail
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SendMail));
            this.label1 = new System.Windows.Forms.Label();
            this.tbEmailEmpfaenger = new System.Windows.Forms.TextBox();
            this.tbBetreff = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rtbText = new System.Windows.Forms.RichTextBox();
            this.btnSenden = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "An:";
            // 
            // tbEmailEmpfaenger
            // 
            this.tbEmailEmpfaenger.Location = new System.Drawing.Point(88, 34);
            this.tbEmailEmpfaenger.Name = "tbEmailEmpfaenger";
            this.tbEmailEmpfaenger.Size = new System.Drawing.Size(274, 20);
            this.tbEmailEmpfaenger.TabIndex = 1;
            // 
            // tbBetreff
            // 
            this.tbBetreff.Location = new System.Drawing.Point(88, 79);
            this.tbBetreff.Name = "tbBetreff";
            this.tbBetreff.Size = new System.Drawing.Size(274, 20);
            this.tbBetreff.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Betreff";
            // 
            // rtbText
            // 
            this.rtbText.Location = new System.Drawing.Point(15, 143);
            this.rtbText.Name = "rtbText";
            this.rtbText.Size = new System.Drawing.Size(380, 273);
            this.rtbText.TabIndex = 11;
            this.rtbText.Text = "";
            // 
            // btnSenden
            // 
            this.btnSenden.Location = new System.Drawing.Point(320, 437);
            this.btnSenden.Name = "btnSenden";
            this.btnSenden.Size = new System.Drawing.Size(75, 23);
            this.btnSenden.TabIndex = 12;
            this.btnSenden.Text = "Senden";
            this.btnSenden.UseVisualStyleBackColor = true;
            // 
            // SendMail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 472);
            this.Controls.Add(this.btnSenden);
            this.Controls.Add(this.rtbText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbBetreff);
            this.Controls.Add(this.tbEmailEmpfaenger);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SendMail";
            this.Text = "SendMail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbEmailEmpfaenger;
        private System.Windows.Forms.TextBox tbBetreff;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox rtbText;
        private System.Windows.Forms.Button btnSenden;
    }
}