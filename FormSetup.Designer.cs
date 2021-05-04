namespace BrainStorm
{
    partial class FormSetup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSetup));
            this.tboxTitle = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnLaunch = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gBoxSetup = new System.Windows.Forms.GroupBox();
            this.tboxEmotivSecret = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cBoxPrefilled = new System.Windows.Forms.CheckBox();
            this.tboxEmailPword = new System.Windows.Forms.TextBox();
            this.tboxEmailAddress = new System.Windows.Forms.TextBox();
            this.tboxEmotivID = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gBoxSetup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tboxTitle
            // 
            this.tboxTitle.BackColor = System.Drawing.SystemColors.InfoText;
            this.tboxTitle.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tboxTitle.Font = new System.Drawing.Font("Dubai", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tboxTitle.ForeColor = System.Drawing.SystemColors.Highlight;
            this.tboxTitle.Location = new System.Drawing.Point(268, 34);
            this.tboxTitle.Name = "tboxTitle";
            this.tboxTitle.Size = new System.Drawing.Size(727, 95);
            this.tboxTitle.TabIndex = 4;
            this.tboxTitle.TabStop = false;
            this.tboxTitle.Text = "Welcome to Brainstorm";
            this.tboxTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.InfoText;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Dubai", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.SystemColors.Control;
            this.textBox1.Location = new System.Drawing.Point(268, 102);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(727, 61);
            this.textBox1.TabIndex = 5;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "Develop and use BCI keyboard technology.";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnLaunch
            // 
            this.btnLaunch.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnLaunch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaunch.Location = new System.Drawing.Point(554, 589);
            this.btnLaunch.Name = "btnLaunch";
            this.btnLaunch.Size = new System.Drawing.Size(155, 60);
            this.btnLaunch.TabIndex = 33;
            this.btnLaunch.Text = "Launch";
            this.btnLaunch.UseVisualStyleBackColor = false;
            this.btnLaunch.Click += new System.EventHandler(this.btnLaunch_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(96, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 29);
            this.label1.TabIndex = 32;
            this.label1.Text = "EMOTIV ID:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(61, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(175, 29);
            this.label2.TabIndex = 31;
            this.label2.Text = "Email Address:";
            // 
            // gBoxSetup
            // 
            this.gBoxSetup.Controls.Add(this.tboxEmotivSecret);
            this.gBoxSetup.Controls.Add(this.label4);
            this.gBoxSetup.Controls.Add(this.cBoxPrefilled);
            this.gBoxSetup.Controls.Add(this.tboxEmailPword);
            this.gBoxSetup.Controls.Add(this.tboxEmailAddress);
            this.gBoxSetup.Controls.Add(this.tboxEmotivID);
            this.gBoxSetup.Controls.Add(this.label3);
            this.gBoxSetup.Controls.Add(this.label1);
            this.gBoxSetup.Controls.Add(this.label2);
            this.gBoxSetup.ForeColor = System.Drawing.SystemColors.Info;
            this.gBoxSetup.Location = new System.Drawing.Point(364, 219);
            this.gBoxSetup.Name = "gBoxSetup";
            this.gBoxSetup.Size = new System.Drawing.Size(535, 280);
            this.gBoxSetup.TabIndex = 33;
            this.gBoxSetup.TabStop = false;
            this.gBoxSetup.Text = "Setup";
            // 
            // tboxEmotivSecret
            // 
            this.tboxEmotivSecret.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tboxEmotivSecret.Location = new System.Drawing.Point(242, 89);
            this.tboxEmotivSecret.Name = "tboxEmotivSecret";
            this.tboxEmotivSecret.Size = new System.Drawing.Size(185, 26);
            this.tboxEmotivSecret.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Info;
            this.label4.Location = new System.Drawing.Point(49, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(187, 29);
            this.label4.TabIndex = 38;
            this.label4.Text = "EMOTIV Secret:";
            // 
            // cBoxPrefilled
            // 
            this.cBoxPrefilled.AutoSize = true;
            this.cBoxPrefilled.Checked = true;
            this.cBoxPrefilled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxPrefilled.Location = new System.Drawing.Point(353, 239);
            this.cBoxPrefilled.Name = "cBoxPrefilled";
            this.cBoxPrefilled.Size = new System.Drawing.Size(166, 24);
            this.cBoxPrefilled.TabIndex = 36;
            this.cBoxPrefilled.Text = "Use Saved Values";
            this.cBoxPrefilled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cBoxPrefilled.UseVisualStyleBackColor = true;
            this.cBoxPrefilled.CheckedChanged += new System.EventHandler(this.cBoxPrefilled_CheckedChanged);
            // 
            // tboxEmailPword
            // 
            this.tboxEmailPword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tboxEmailPword.Location = new System.Drawing.Point(242, 196);
            this.tboxEmailPword.Name = "tboxEmailPword";
            this.tboxEmailPword.Size = new System.Drawing.Size(185, 26);
            this.tboxEmailPword.TabIndex = 35;
            // 
            // tboxEmailAddress
            // 
            this.tboxEmailAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tboxEmailAddress.Location = new System.Drawing.Point(242, 141);
            this.tboxEmailAddress.Name = "tboxEmailAddress";
            this.tboxEmailAddress.Size = new System.Drawing.Size(185, 26);
            this.tboxEmailAddress.TabIndex = 34;
            // 
            // tboxEmotivID
            // 
            this.tboxEmotivID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tboxEmotivID.Location = new System.Drawing.Point(242, 36);
            this.tboxEmotivID.Name = "tboxEmotivID";
            this.tboxEmotivID.Size = new System.Drawing.Size(185, 26);
            this.tboxEmotivID.TabIndex = 32;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(43, 192);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(193, 29);
            this.label3.TabIndex = 33;
            this.label3.Text = "Email Password:";
            // 
            // FormSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1198, 758);
            this.Controls.Add(this.gBoxSetup);
            this.Controls.Add(this.btnLaunch);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.tboxTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormSetup";
            this.gBoxSetup.ResumeLayout(false);
            this.gBoxSetup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tboxTitle;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnLaunch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gBoxSetup;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cBoxPrefilled;
        private System.Windows.Forms.TextBox tboxEmailPword;
        private System.Windows.Forms.TextBox tboxEmailAddress;
        private System.Windows.Forms.TextBox tboxEmotivID;
        private System.Windows.Forms.TextBox tboxEmotivSecret;
        private System.Windows.Forms.Label label4;
    }
}