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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BrainStorm0));
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
            this.tboxOutput = new System.Windows.Forms.TextBox();
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
            this.label8 = new System.Windows.Forms.Label();
            this.btnValidate = new System.Windows.Forms.Button();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.cBoxClassification = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnLoadFile = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.BackTestSelector = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cBoxBackTestWait = new System.Windows.Forms.CheckBox();
            this.gBoxType = new System.Windows.Forms.GroupBox();
            this.btnStartTyping = new System.Windows.Forms.Button();
            this.Begin = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.cboxFeatureEvaluation = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
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
            this.groupBox1.SuspendLayout();
            this.gBoxType.SuspendLayout();
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
            this.gboxOutput.Controls.Add(this.tboxOutput);
            this.gboxOutput.Controls.Add(this.label1);
            this.gboxOutput.Location = new System.Drawing.Point(13, 13);
            this.gboxOutput.Name = "gboxOutput";
            this.gboxOutput.Size = new System.Drawing.Size(1428, 101);
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
            // tboxOutput
            // 
            this.tboxOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxOutput.Location = new System.Drawing.Point(76, 15);
            this.tboxOutput.Name = "tboxOutput";
            this.tboxOutput.Size = new System.Drawing.Size(1346, 26);
            this.tboxOutput.TabIndex = 1;
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
            this.pboxInterface.Size = new System.Drawing.Size(1428, 484);
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
            this.gboxControls.Location = new System.Drawing.Point(972, 625);
            this.gboxControls.Name = "gboxControls";
            this.gboxControls.Size = new System.Drawing.Size(469, 138);
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
            this.pboxClear.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.SystemColors.Info;
            this.label8.Location = new System.Drawing.Point(507, 635);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 20);
            this.label8.TabIndex = 22;
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
            this.btnSendEmail.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnSendEmail.Location = new System.Drawing.Point(93, 81);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(119, 40);
            this.btnSendEmail.TabIndex = 24;
            this.btnSendEmail.Text = "Send Email";
            this.btnSendEmail.UseVisualStyleBackColor = false;
            this.btnSendEmail.Click += new System.EventHandler(this.btnSendEmail_Click);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.SystemColors.Info;
            this.label9.Location = new System.Drawing.Point(678, 687);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 20);
            this.label9.TabIndex = 25;
            // 
            // cBoxClassification
            // 
            this.cBoxClassification.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cBoxClassification.AutoSize = true;
            this.cBoxClassification.Checked = true;
            this.cBoxClassification.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxClassification.Location = new System.Drawing.Point(401, 640);
            this.cBoxClassification.Name = "cBoxClassification";
            this.cBoxClassification.Size = new System.Drawing.Size(113, 24);
            this.cBoxClassification.TabIndex = 26;
            this.cBoxClassification.Text = "checkBox1";
            this.cBoxClassification.UseVisualStyleBackColor = true;
            this.cBoxClassification.CheckedChanged += new System.EventHandler(this.cBoxClassification_CheckedChanged);
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.Info;
            this.label10.Location = new System.Drawing.Point(272, 638);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(123, 20);
            this.label10.TabIndex = 27;
            this.label10.Text = "Is Classification:";
            // 
            // btnLoadFile
            // 
            this.btnLoadFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnLoadFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLoadFile.Location = new System.Drawing.Point(84, 87);
            this.btnLoadFile.Name = "btnLoadFile";
            this.btnLoadFile.Size = new System.Drawing.Size(119, 40);
            this.btnLoadFile.TabIndex = 28;
            this.btnLoadFile.Text = "Back Test";
            this.btnLoadFile.UseVisualStyleBackColor = true;
            this.btnLoadFile.Click += new System.EventHandler(this.btnLoadFile_Click);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.Info;
            this.label11.Location = new System.Drawing.Point(16, 97);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 20);
            this.label11.TabIndex = 29;
            this.label11.Text = "Testing:";
            // 
            // BackTestSelector
            // 
            this.BackTestSelector.FileName = "openFileDialog1";
            this.BackTestSelector.Filter = "CSV|*.csv";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.cboxFeatureEvaluation);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.cBoxBackTestWait);
            this.groupBox1.Controls.Add(this.btnLoadFile);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.Info;
            this.groupBox1.Location = new System.Drawing.Point(426, 625);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(219, 142);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BackTesting";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.Info;
            this.label12.Location = new System.Drawing.Point(13, 40);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(93, 20);
            this.label12.TabIndex = 30;
            this.label12.Text = "Max Speed:";
            // 
            // cBoxBackTestWait
            // 
            this.cBoxBackTestWait.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cBoxBackTestWait.AutoSize = true;
            this.cBoxBackTestWait.Checked = true;
            this.cBoxBackTestWait.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cBoxBackTestWait.Location = new System.Drawing.Point(114, 41);
            this.cBoxBackTestWait.Name = "cBoxBackTestWait";
            this.cBoxBackTestWait.Size = new System.Drawing.Size(22, 21);
            this.cBoxBackTestWait.TabIndex = 28;
            this.cBoxBackTestWait.UseVisualStyleBackColor = true;
            this.cBoxBackTestWait.CheckedChanged += new System.EventHandler(this.cBoxBackTestWait_CheckedChanged);
            // 
            // gBoxType
            // 
            this.gBoxType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gBoxType.Controls.Add(this.btnStartTyping);
            this.gBoxType.Controls.Add(this.Begin);
            this.gBoxType.Controls.Add(this.label13);
            this.gBoxType.Controls.Add(this.btnSendEmail);
            this.gBoxType.ForeColor = System.Drawing.SystemColors.Info;
            this.gBoxType.Location = new System.Drawing.Point(651, 625);
            this.gBoxType.Name = "gBoxType";
            this.gBoxType.Size = new System.Drawing.Size(246, 142);
            this.gBoxType.TabIndex = 31;
            this.gBoxType.TabStop = false;
            this.gBoxType.Text = "Typing";
            // 
            // btnStartTyping
            // 
            this.btnStartTyping.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnStartTyping.Enabled = false;
            this.btnStartTyping.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnStartTyping.Location = new System.Drawing.Point(93, 35);
            this.btnStartTyping.Name = "btnStartTyping";
            this.btnStartTyping.Size = new System.Drawing.Size(119, 40);
            this.btnStartTyping.TabIndex = 31;
            this.btnStartTyping.Text = "Start Typing";
            this.btnStartTyping.UseVisualStyleBackColor = true;
            this.btnStartTyping.Click += new System.EventHandler(this.btnStartTyping_Click);
            // 
            // Begin
            // 
            this.Begin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.Begin.AutoSize = true;
            this.Begin.ForeColor = System.Drawing.SystemColors.Info;
            this.Begin.Location = new System.Drawing.Point(27, 45);
            this.Begin.Name = "Begin";
            this.Begin.Size = new System.Drawing.Size(54, 20);
            this.Begin.TabIndex = 32;
            this.Begin.Text = "Begin:";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.Info;
            this.label13.Location = new System.Drawing.Point(13, 91);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 20);
            this.label13.TabIndex = 31;
            this.label13.Text = "Delivery:";
            // 
            // cboxFeatureEvaluation
            // 
            this.cboxFeatureEvaluation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cboxFeatureEvaluation.AutoSize = true;
            this.cboxFeatureEvaluation.Checked = true;
            this.cboxFeatureEvaluation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cboxFeatureEvaluation.Location = new System.Drawing.Point(114, 65);
            this.cboxFeatureEvaluation.Name = "cboxFeatureEvaluation";
            this.cboxFeatureEvaluation.Size = new System.Drawing.Size(22, 21);
            this.cboxFeatureEvaluation.TabIndex = 31;
            this.cboxFeatureEvaluation.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.SystemColors.Info;
            this.label14.Location = new System.Drawing.Point(19, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(87, 20);
            this.label14.TabIndex = 32;
            this.label14.Text = "Evaluation:";
            // 
            // BrainStorm0
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.ClientSize = new System.Drawing.Size(1453, 764);
            this.Controls.Add(this.gBoxType);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cBoxClassification);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnValidate);
            this.Controls.Add(this.label8);
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
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.gBoxType.ResumeLayout(false);
            this.gBoxType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gboxOutput;
        private System.Windows.Forms.TextBox tboxOutput;
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
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnValidate;
        private System.Windows.Forms.Button btnSendEmail;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cBoxClassification;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnLoadFile;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.OpenFileDialog BackTestSelector;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.CheckBox cBoxBackTestWait;
        private System.Windows.Forms.GroupBox gBoxType;
        private System.Windows.Forms.Button btnStartTyping;
        private System.Windows.Forms.Label Begin;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.CheckBox cboxFeatureEvaluation;
        private System.Windows.Forms.Label label14;
    }
}

