namespace BrainStorm
{
    partial class FormSplashScreen
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
            this.pbarSplash = new System.Windows.Forms.ProgressBar();
            this.tboxTitle = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // pbarSplash
            // 
            this.pbarSplash.BackColor = System.Drawing.SystemColors.ControlText;
            this.pbarSplash.Location = new System.Drawing.Point(467, 485);
            this.pbarSplash.Name = "pbarSplash";
            this.pbarSplash.Size = new System.Drawing.Size(287, 36);
            this.pbarSplash.TabIndex = 2;
            // 
            // tboxTitle
            // 
            this.tboxTitle.BackColor = System.Drawing.SystemColors.InfoText;
            this.tboxTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tboxTitle.Font = new System.Drawing.Font("Dubai", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxTitle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tboxTitle.Location = new System.Drawing.Point(247, 207);
            this.tboxTitle.Name = "tboxTitle";
            this.tboxTitle.Size = new System.Drawing.Size(727, 163);
            this.tboxTitle.TabIndex = 3;
            this.tboxTitle.TabStop = false;
            this.tboxTitle.Text = "Brain Storm";
            this.tboxTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // FormSplashScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlText;
            this.ClientSize = new System.Drawing.Size(1220, 729);
            this.Controls.Add(this.tboxTitle);
            this.Controls.Add(this.pbarSplash);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSplashScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brain Storm";
            this.Shown += new System.EventHandler(this.FormSplashScreen_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ProgressBar pbarSplash;
        private System.Windows.Forms.TextBox tboxTitle;
    }
}