namespace BrainStorm
{
    partial class BrainStorm0
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
            this.gboxOutput = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numFreq = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.numShapeRow = new System.Windows.Forms.NumericUpDown();
            this.numShapeCol = new System.Windows.Forms.NumericUpDown();
            this.btnAddShape = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numRows = new System.Windows.Forms.NumericUpDown();
            this.numCols = new System.Windows.Forms.NumericUpDown();
            this.btnTest = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pboxInterface = new System.Windows.Forms.PictureBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.gboxControls = new System.Windows.Forms.GroupBox();
            this.pboxUndo = new System.Windows.Forms.PictureBox();
            this.pboxClear = new System.Windows.Forms.PictureBox();
            this.btnAutoComplete = new System.Windows.Forms.Button();
            this.tboxPhrase = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnTrain = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnStopRecord = new System.Windows.Forms.Button();
            this.tboxPrediction = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.gboxOutput.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numShapeRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numShapeCol)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCols)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxInterface)).BeginInit();
            this.gboxControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pboxUndo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxClear)).BeginInit();
            this.SuspendLayout();
            // 
            // gboxOutput
            // 
            this.gboxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxOutput.Controls.Add(this.label6);
            this.gboxOutput.Controls.Add(this.numFreq);
            this.gboxOutput.Controls.Add(this.label4);
            this.gboxOutput.Controls.Add(this.label5);
            this.gboxOutput.Controls.Add(this.numShapeRow);
            this.gboxOutput.Controls.Add(this.numShapeCol);
            this.gboxOutput.Controls.Add(this.btnAddShape);
            this.gboxOutput.Controls.Add(this.label3);
            this.gboxOutput.Controls.Add(this.label2);
            this.gboxOutput.Controls.Add(this.numRows);
            this.gboxOutput.Controls.Add(this.numCols);
            this.gboxOutput.Controls.Add(this.btnTest);
            this.gboxOutput.Controls.Add(this.textBox1);
            this.gboxOutput.Controls.Add(this.label1);
            this.gboxOutput.Location = new System.Drawing.Point(13, 13);
            this.gboxOutput.Name = "gboxOutput";
            this.gboxOutput.Size = new System.Drawing.Size(1293, 101);
            this.gboxOutput.TabIndex = 0;
            this.gboxOutput.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.Info;
            this.label6.Location = new System.Drawing.Point(350, 66);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 20);
            this.label6.TabIndex = 13;
            this.label6.Text = "Hz.:";
            // 
            // numFreq
            // 
            this.numFreq.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numFreq.Location = new System.Drawing.Point(413, 63);
            this.numFreq.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numFreq.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numFreq.Name = "numFreq";
            this.numFreq.Size = new System.Drawing.Size(77, 26);
            this.numFreq.TabIndex = 12;
            this.numFreq.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.Info;
            this.label4.Location = new System.Drawing.Point(177, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Col:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.SystemColors.Info;
            this.label5.Location = new System.Drawing.Point(15, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 20);
            this.label5.TabIndex = 10;
            this.label5.Text = "Row:";
            // 
            // numShapeRow
            // 
            this.numShapeRow.Location = new System.Drawing.Point(84, 62);
            this.numShapeRow.Name = "numShapeRow";
            this.numShapeRow.Size = new System.Drawing.Size(77, 26);
            this.numShapeRow.TabIndex = 9;
            // 
            // numShapeCol
            // 
            this.numShapeCol.Location = new System.Drawing.Point(237, 62);
            this.numShapeCol.Name = "numShapeCol";
            this.numShapeCol.Size = new System.Drawing.Size(77, 26);
            this.numShapeCol.TabIndex = 8;
            // 
            // btnAddShape
            // 
            this.btnAddShape.Location = new System.Drawing.Point(532, 57);
            this.btnAddShape.Name = "btnAddShape";
            this.btnAddShape.Size = new System.Drawing.Size(132, 39);
            this.btnAddShape.TabIndex = 7;
            this.btnAddShape.Text = "Add Shape";
            this.btnAddShape.UseVisualStyleBackColor = true;
            this.btnAddShape.Click += new System.EventHandler(this.btnAddShape_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.Info;
            this.label3.Location = new System.Drawing.Point(877, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Cols:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.Info;
            this.label2.Location = new System.Drawing.Point(715, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Rows:";
            // 
            // numRows
            // 
            this.numRows.Location = new System.Drawing.Point(784, 62);
            this.numRows.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numRows.Name = "numRows";
            this.numRows.Size = new System.Drawing.Size(77, 26);
            this.numRows.TabIndex = 4;
            this.numRows.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // numCols
            // 
            this.numCols.Location = new System.Drawing.Point(937, 62);
            this.numCols.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numCols.Name = "numCols";
            this.numCols.Size = new System.Drawing.Size(77, 26);
            this.numCols.TabIndex = 3;
            this.numCols.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(1042, 56);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(202, 39);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Sim. Event";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(76, 15);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1211, 26);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.Info;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Output:";
            // 
            // pboxInterface
            // 
            this.pboxInterface.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pboxInterface.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.pboxInterface.Location = new System.Drawing.Point(13, 120);
            this.pboxInterface.Name = "pboxInterface";
            this.pboxInterface.Size = new System.Drawing.Size(1293, 484);
            this.pboxInterface.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxInterface.TabIndex = 1;
            this.pboxInterface.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.Location = new System.Drawing.Point(12, 713);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(119, 40);
            this.btnClear.TabIndex = 14;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // gboxControls
            // 
            this.gboxControls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.gboxControls.Controls.Add(this.pboxUndo);
            this.gboxControls.Controls.Add(this.pboxClear);
            this.gboxControls.ForeColor = System.Drawing.SystemColors.Info;
            this.gboxControls.Location = new System.Drawing.Point(833, 625);
            this.gboxControls.Name = "gboxControls";
            this.gboxControls.Size = new System.Drawing.Size(473, 138);
            this.gboxControls.TabIndex = 16;
            this.gboxControls.TabStop = false;
            this.gboxControls.Text = "Controls";
            // 
            // pboxUndo
            // 
            this.pboxUndo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pboxUndo.Location = new System.Drawing.Point(280, 15);
            this.pboxUndo.Name = "pboxUndo";
            this.pboxUndo.Size = new System.Drawing.Size(178, 112);
            this.pboxUndo.TabIndex = 1;
            this.pboxUndo.TabStop = false;
            // 
            // pboxClear
            // 
            this.pboxClear.Location = new System.Drawing.Point(106, 15);
            this.pboxClear.Name = "pboxClear";
            this.pboxClear.Size = new System.Drawing.Size(168, 112);
            this.pboxClear.TabIndex = 0;
            this.pboxClear.TabStop = false;
            // 
            // btnAutoComplete
            // 
            this.btnAutoComplete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAutoComplete.Location = new System.Drawing.Point(12, 667);
            this.btnAutoComplete.Name = "btnAutoComplete";
            this.btnAutoComplete.Size = new System.Drawing.Size(119, 40);
            this.btnAutoComplete.TabIndex = 17;
            this.btnAutoComplete.Text = "Complete";
            this.btnAutoComplete.UseVisualStyleBackColor = true;
            this.btnAutoComplete.Click += new System.EventHandler(this.btnAutoComplete_ClickAsync);
            // 
            // tboxPhrase
            // 
            this.tboxPhrase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tboxPhrase.Location = new System.Drawing.Point(81, 635);
            this.tboxPhrase.Name = "tboxPhrase";
            this.tboxPhrase.Size = new System.Drawing.Size(185, 26);
            this.tboxPhrase.TabIndex = 14;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.Info;
            this.label7.Location = new System.Drawing.Point(12, 635);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 20);
            this.label7.TabIndex = 14;
            this.label7.Text = "Phrase:";
            // 
            // btnTrain
            // 
            this.btnTrain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTrain.Location = new System.Drawing.Point(262, 667);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(119, 40);
            this.btnTrain.TabIndex = 18;
            this.btnTrain.Text = "Train";
            this.btnTrain.UseVisualStyleBackColor = true;
            this.btnTrain.Click += new System.EventHandler(this.btnTrain_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConnect.Location = new System.Drawing.Point(137, 667);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(119, 40);
            this.btnConnect.TabIndex = 19;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnStopRecord
            // 
            this.btnStopRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStopRecord.Enabled = false;
            this.btnStopRecord.Location = new System.Drawing.Point(137, 712);
            this.btnStopRecord.Name = "btnStopRecord";
            this.btnStopRecord.Size = new System.Drawing.Size(119, 40);
            this.btnStopRecord.TabIndex = 20;
            this.btnStopRecord.Text = "Stop Record";
            this.btnStopRecord.UseVisualStyleBackColor = true;
            this.btnStopRecord.Click += new System.EventHandler(this.btnStopRecord_Click);
            // 
            // tboxPrediction
            // 
            this.tboxPrediction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tboxPrediction.Location = new System.Drawing.Point(672, 635);
            this.tboxPrediction.Name = "tboxPrediction";
            this.tboxPrediction.Size = new System.Drawing.Size(112, 26);
            this.tboxPrediction.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.Info;
            this.label8.Location = new System.Drawing.Point(507, 635);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 20);
            this.label8.TabIndex = 22;
            this.label8.Text = "Predicted Frequency:";
            // 
            // btnValidate
            // 
            this.btnValidate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnValidate.Enabled = false;
            this.btnValidate.Location = new System.Drawing.Point(262, 712);
            this.btnValidate.Name = "btnValidate";
            this.btnValidate.Size = new System.Drawing.Size(119, 40);
            this.btnValidate.TabIndex = 23;
            this.btnValidate.Text = "Validate";
            this.btnValidate.UseVisualStyleBackColor = true;
            this.btnValidate.Click += new System.EventHandler(this.btnValidate_Click);
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSendEmail.Location = new System.Drawing.Point(672, 667);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(119, 40);
            this.btnSendEmail.TabIndex = 24;
            this.btnSendEmail.Text = "Send Email";
            this.btnSendEmail.UseVisualStyleBackColor = true;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.Info;
            this.label9.Location = new System.Drawing.Point(598, 667);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 20);
            this.label9.TabIndex = 25;
            this.label9.Text = "Delivery:";
            // 
            // BrainStorm0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1318, 764);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnSendEmail);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tboxPrediction);
            this.Controls.Add(this.btnStopRecord);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnTrain);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tboxPhrase);
            this.Controls.Add(this.btnAutoComplete);
            this.Controls.Add(this.gboxControls);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.pboxInterface);
            this.Controls.Add(this.gboxOutput);
            this.Name = "BrainStorm0";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Brain Storm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.BrainStorm0_FormClosed);
            this.Load += new System.EventHandler(this.BrainStorm0_Load);
            this.gboxOutput.ResumeLayout(false);
            this.gboxOutput.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numShapeRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numShapeCol)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCols)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxInterface)).EndInit();
            this.gboxControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pboxUndo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pboxClear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxOutput;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pboxInterface;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.NumericUpDown numCols;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numRows;
        private System.Windows.Forms.Button btnAddShape;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numShapeRow;
        private System.Windows.Forms.NumericUpDown numShapeCol;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numFreq;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox gboxControls;
        private System.Windows.Forms.PictureBox pboxUndo;
        private System.Windows.Forms.PictureBox pboxClear;
        private System.Windows.Forms.Button btnAutoComplete;
        private System.Windows.Forms.TextBox tboxPhrase;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnStopRecord;
        private System.Windows.Forms.TextBox tboxPrediction;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.Label label9;
    }
}

