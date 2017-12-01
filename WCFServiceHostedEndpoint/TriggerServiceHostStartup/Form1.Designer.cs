namespace TriggerServiceHostStartup
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
            this.StartWCFServiceButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // StartWCFServiceButton
            // 
            this.StartWCFServiceButton.Location = new System.Drawing.Point(125, 113);
            this.StartWCFServiceButton.Name = "StartWCFServiceButton";
            this.StartWCFServiceButton.Size = new System.Drawing.Size(118, 62);
            this.StartWCFServiceButton.TabIndex = 0;
            this.StartWCFServiceButton.Text = "Start";
            this.StartWCFServiceButton.UseVisualStyleBackColor = true;
            this.StartWCFServiceButton.Click += new System.EventHandler(this.StartWCFServiceButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 296);
            this.Controls.Add(this.StartWCFServiceButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button StartWCFServiceButton;
    }
}

