/////////////////////////////////////////////////////
// Course: CSC 289
// Team: Team Discovery
//
// Class: UIForm.Designer.cs
// Description: 
//
// Name: Nick Burnette
// Last Edit: 11/3/17
/////////////////////////////////////////////////////

namespace Vision
{
    partial class UIForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UIForm));
            this.populateMarqueeButton = new System.Windows.Forms.Button();
            this.createASegmentGroupBox = new System.Windows.Forms.GroupBox();
            this.secondsPerCharacterLabel = new System.Windows.Forms.Label();
            this.displayDurationControl = new System.Windows.Forms.NumericUpDown();
            this.colorLabel = new System.Windows.Forms.Label();
            this.colorButton = new System.Windows.Forms.Button();
            this.longTextPopUp = new System.Windows.Forms.Label();
            this.randomColorCheckBox = new System.Windows.Forms.CheckBox();
            this.exitEffectLabel = new System.Windows.Forms.Label();
            this.staticEffectLabel = new System.Windows.Forms.Label();
            this.scrollSpeedControl = new System.Windows.Forms.NumericUpDown();
            this.scrollSpeedLabel = new System.Windows.Forms.Label();
            this.entranceEffectLabel = new System.Windows.Forms.Label();
            this.exitEffectComboBox = new System.Windows.Forms.ComboBox();
            this.middleEffectComboBox = new System.Windows.Forms.ComboBox();
            this.entranceEffectComboBox = new System.Windows.Forms.ComboBox();
            this.scrollingTextButton = new System.Windows.Forms.RadioButton();
            this.specialEffectButton = new System.Windows.Forms.RadioButton();
            this.displayDurationLabel = new System.Windows.Forms.Label();
            this.textTextBox = new System.Windows.Forms.TextBox();
            this.textLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.borderColorLabel = new System.Windows.Forms.Label();
            this.borderEffectComboBox = new System.Windows.Forms.ComboBox();
            this.runButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.logoLabel = new System.Windows.Forms.Label();
            this.textTabLabel = new System.Windows.Forms.Label();
            this.imageTabLabel = new System.Windows.Forms.Label();
            this.textPanel = new System.Windows.Forms.Panel();
            this.ignoreCheckBox = new System.Windows.Forms.CheckBox();
            this.borderOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.borderColorButton = new System.Windows.Forms.Button();
            this.exitFullScreen = new System.Windows.Forms.PictureBox();
            this.SegmentHolderPanel = new System.Windows.Forms.Panel();
            this.lastSegmentPopUp = new System.Windows.Forms.Label();
            this.startNewMessageButton = new System.Windows.Forms.Button();
            this.imagePanel = new System.Windows.Forms.Panel();
            this.previewButton = new System.Windows.Forms.Button();
            this.scaledImageGroupBox = new System.Windows.Forms.GroupBox();
            this.scaledPictureBox = new System.Windows.Forms.PictureBox();
            this.fileLocationTextBox = new System.Windows.Forms.TextBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.originalPictureBox = new System.Windows.Forms.PictureBox();
            this.marqueeBackgroundColorLabel = new System.Windows.Forms.Label();
            this.backToMenuButton = new System.Windows.Forms.Button();
            this.colorDialogBox = new System.Windows.Forms.ColorDialog();
            this.borderColorDialogBox = new System.Windows.Forms.ColorDialog();
            this.marqueeBackgroundColorButton = new System.Windows.Forms.Button();
            this.marqueeBackgroundColorDialogBox = new System.Windows.Forms.ColorDialog();
            this.pauseButton = new System.Windows.Forms.Button();
            this.playButton = new System.Windows.Forms.Button();
            this.animateSegmentTimer = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveButton = new System.Windows.Forms.Button();
            this.goToFullScreenButton = new System.Windows.Forms.Button();
            this.loadXMLButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.marquee1 = new Vision.Marquee();
            this.createASegmentGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.displayDurationControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrollSpeedControl)).BeginInit();
            this.textPanel.SuspendLayout();
            this.borderOptionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitFullScreen)).BeginInit();
            this.SegmentHolderPanel.SuspendLayout();
            this.imagePanel.SuspendLayout();
            this.scaledImageGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.scaledPictureBox)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originalPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // populateMarqueeButton
            // 
            this.populateMarqueeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.populateMarqueeButton.Location = new System.Drawing.Point(198, 463);
            this.populateMarqueeButton.Name = "populateMarqueeButton";
            this.populateMarqueeButton.Size = new System.Drawing.Size(106, 37);
            this.populateMarqueeButton.TabIndex = 1;
            this.populateMarqueeButton.Text = "Populate Marquee";
            this.populateMarqueeButton.UseVisualStyleBackColor = true;
            this.populateMarqueeButton.Visible = false;
            this.populateMarqueeButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // createASegmentGroupBox
            // 
            this.createASegmentGroupBox.Controls.Add(this.secondsPerCharacterLabel);
            this.createASegmentGroupBox.Controls.Add(this.displayDurationControl);
            this.createASegmentGroupBox.Controls.Add(this.colorLabel);
            this.createASegmentGroupBox.Controls.Add(this.colorButton);
            this.createASegmentGroupBox.Controls.Add(this.longTextPopUp);
            this.createASegmentGroupBox.Controls.Add(this.randomColorCheckBox);
            this.createASegmentGroupBox.Controls.Add(this.exitEffectLabel);
            this.createASegmentGroupBox.Controls.Add(this.staticEffectLabel);
            this.createASegmentGroupBox.Controls.Add(this.scrollSpeedControl);
            this.createASegmentGroupBox.Controls.Add(this.scrollSpeedLabel);
            this.createASegmentGroupBox.Controls.Add(this.entranceEffectLabel);
            this.createASegmentGroupBox.Controls.Add(this.exitEffectComboBox);
            this.createASegmentGroupBox.Controls.Add(this.middleEffectComboBox);
            this.createASegmentGroupBox.Controls.Add(this.entranceEffectComboBox);
            this.createASegmentGroupBox.Controls.Add(this.scrollingTextButton);
            this.createASegmentGroupBox.Controls.Add(this.specialEffectButton);
            this.createASegmentGroupBox.Controls.Add(this.displayDurationLabel);
            this.createASegmentGroupBox.Controls.Add(this.textTextBox);
            this.createASegmentGroupBox.Controls.Add(this.textLabel);
            this.createASegmentGroupBox.Location = new System.Drawing.Point(12, 16);
            this.createASegmentGroupBox.Name = "createASegmentGroupBox";
            this.createASegmentGroupBox.Size = new System.Drawing.Size(770, 206);
            this.createASegmentGroupBox.TabIndex = 5;
            this.createASegmentGroupBox.TabStop = false;
            // 
            // secondsPerCharacterLabel
            // 
            this.secondsPerCharacterLabel.AutoSize = true;
            this.secondsPerCharacterLabel.Location = new System.Drawing.Point(136, 153);
            this.secondsPerCharacterLabel.Name = "secondsPerCharacterLabel";
            this.secondsPerCharacterLabel.Size = new System.Drawing.Size(117, 13);
            this.secondsPerCharacterLabel.TabIndex = 44;
            this.secondsPerCharacterLabel.Text = "Seconds Per Character";
            this.secondsPerCharacterLabel.Visible = false;
            // 
            // displayDurationControl
            // 
            this.displayDurationControl.Location = new System.Drawing.Point(104, 59);
            this.displayDurationControl.Maximum = new decimal(new int[] {
            2147482,
            0,
            0,
            0});
            this.displayDurationControl.Name = "displayDurationControl";
            this.displayDurationControl.Size = new System.Drawing.Size(120, 20);
            this.displayDurationControl.TabIndex = 43;
            this.displayDurationControl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.displayDurationControl.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.displayDurationControl.ValueChanged += new System.EventHandler(this.displayDurationControl_ValueChanged);
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(328, 63);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(34, 13);
            this.colorLabel.TabIndex = 41;
            this.colorLabel.Text = "Color:";
            // 
            // colorButton
            // 
            this.colorButton.BackColor = System.Drawing.Color.Red;
            this.colorButton.Location = new System.Drawing.Point(380, 58);
            this.colorButton.Name = "colorButton";
            this.colorButton.Size = new System.Drawing.Size(75, 23);
            this.colorButton.TabIndex = 40;
            this.colorButton.UseVisualStyleBackColor = false;
            this.colorButton.Click += new System.EventHandler(this.colorButton_Click);
            // 
            // longTextPopUp
            // 
            this.longTextPopUp.AutoSize = true;
            this.longTextPopUp.BackColor = System.Drawing.Color.Transparent;
            this.longTextPopUp.ForeColor = System.Drawing.Color.Red;
            this.longTextPopUp.Location = new System.Drawing.Point(103, 10);
            this.longTextPopUp.Name = "longTextPopUp";
            this.longTextPopUp.Size = new System.Drawing.Size(395, 13);
            this.longTextPopUp.TabIndex = 17;
            this.longTextPopUp.Text = "Messages with more than 9 characters must be split up or use Scrolling Text Effec" +
    "t";
            this.longTextPopUp.Visible = false;
            // 
            // randomColorCheckBox
            // 
            this.randomColorCheckBox.AutoSize = true;
            this.randomColorCheckBox.Location = new System.Drawing.Point(299, 152);
            this.randomColorCheckBox.Name = "randomColorCheckBox";
            this.randomColorCheckBox.Size = new System.Drawing.Size(98, 17);
            this.randomColorCheckBox.TabIndex = 23;
            this.randomColorCheckBox.Text = "Random Colors";
            this.randomColorCheckBox.UseVisualStyleBackColor = true;
            this.randomColorCheckBox.Visible = false;
            this.randomColorCheckBox.CheckedChanged += new System.EventHandler(this.randomColorCheckBox_CheckedChanged);
            // 
            // exitEffectLabel
            // 
            this.exitEffectLabel.AutoSize = true;
            this.exitEffectLabel.Location = new System.Drawing.Point(571, 134);
            this.exitEffectLabel.Name = "exitEffectLabel";
            this.exitEffectLabel.Size = new System.Drawing.Size(55, 13);
            this.exitEffectLabel.TabIndex = 16;
            this.exitEffectLabel.Text = "Exit Effect";
            // 
            // staticEffectLabel
            // 
            this.staticEffectLabel.AutoSize = true;
            this.staticEffectLabel.Location = new System.Drawing.Point(315, 134);
            this.staticEffectLabel.Name = "staticEffectLabel";
            this.staticEffectLabel.Size = new System.Drawing.Size(69, 13);
            this.staticEffectLabel.TabIndex = 15;
            this.staticEffectLabel.Text = "Middle Effect";
            // 
            // scrollSpeedControl
            // 
            this.scrollSpeedControl.DecimalPlaces = 2;
            this.scrollSpeedControl.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.scrollSpeedControl.Location = new System.Drawing.Point(14, 151);
            this.scrollSpeedControl.Maximum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.scrollSpeedControl.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.scrollSpeedControl.Name = "scrollSpeedControl";
            this.scrollSpeedControl.Size = new System.Drawing.Size(120, 20);
            this.scrollSpeedControl.TabIndex = 6;
            this.scrollSpeedControl.Tag = "";
            this.scrollSpeedControl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.scrollSpeedControl.Value = new decimal(new int[] {
            25,
            0,
            0,
            131072});
            this.scrollSpeedControl.Visible = false;
            this.scrollSpeedControl.ValueChanged += new System.EventHandler(this.scrollSpeedControl_ValueChanged);
            // 
            // scrollSpeedLabel
            // 
            this.scrollSpeedLabel.AutoSize = true;
            this.scrollSpeedLabel.Location = new System.Drawing.Point(31, 134);
            this.scrollSpeedLabel.Name = "scrollSpeedLabel";
            this.scrollSpeedLabel.Size = new System.Drawing.Size(67, 13);
            this.scrollSpeedLabel.TabIndex = 21;
            this.scrollSpeedLabel.Text = "Scroll Speed";
            this.scrollSpeedLabel.Visible = false;
            // 
            // entranceEffectLabel
            // 
            this.entranceEffectLabel.AutoSize = true;
            this.entranceEffectLabel.Location = new System.Drawing.Point(60, 134);
            this.entranceEffectLabel.Name = "entranceEffectLabel";
            this.entranceEffectLabel.Size = new System.Drawing.Size(81, 13);
            this.entranceEffectLabel.TabIndex = 14;
            this.entranceEffectLabel.Text = "Entrance Effect";
            // 
            // exitEffectComboBox
            // 
            this.exitEffectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.exitEffectComboBox.FormattingEnabled = true;
            this.exitEffectComboBox.Items.AddRange(new object[] {
            "No effect",
            "Exit Top",
            "Exit Bottom",
            "Exit Left",
            "Exit Right",
            "Horizontal Split",
            "Disolve",
            "Diagonal Exit Top",
            "Diagonal Exit Bottom"});
            this.exitEffectComboBox.Location = new System.Drawing.Point(506, 150);
            this.exitEffectComboBox.Name = "exitEffectComboBox";
            this.exitEffectComboBox.Size = new System.Drawing.Size(191, 21);
            this.exitEffectComboBox.TabIndex = 13;
            this.exitEffectComboBox.SelectedIndexChanged += new System.EventHandler(this.exitEffectComboBox_SelectedIndexChanged);
            // 
            // middleEffectComboBox
            // 
            this.middleEffectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.middleEffectComboBox.FormattingEnabled = true;
            this.middleEffectComboBox.Items.AddRange(new object[] {
            "No effect",
            "Random Colored Dots",
            "Flashing",
            "The Wave",
            "The Spotlight"});
            this.middleEffectComboBox.Location = new System.Drawing.Point(256, 150);
            this.middleEffectComboBox.Name = "middleEffectComboBox";
            this.middleEffectComboBox.Size = new System.Drawing.Size(191, 21);
            this.middleEffectComboBox.TabIndex = 12;
            this.middleEffectComboBox.SelectedIndexChanged += new System.EventHandler(this.staticEffectComboBox_SelectedIndexChanged);
            // 
            // entranceEffectComboBox
            // 
            this.entranceEffectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.entranceEffectComboBox.FormattingEnabled = true;
            this.entranceEffectComboBox.Items.AddRange(new object[] {
            "No effect",
            "From Top",
            "From Bottom",
            "From Left",
            "From Right",
            "Horizontal Split",
            "Disolve",
            "The Schwoop",
            "Crooked From Top",
            "Crooked From Bottom"});
            this.entranceEffectComboBox.Location = new System.Drawing.Point(6, 150);
            this.entranceEffectComboBox.Name = "entranceEffectComboBox";
            this.entranceEffectComboBox.Size = new System.Drawing.Size(191, 21);
            this.entranceEffectComboBox.TabIndex = 11;
            this.entranceEffectComboBox.SelectedIndexChanged += new System.EventHandler(this.entranceEffectComboBox_SelectedIndexChanged);
            // 
            // scrollingTextButton
            // 
            this.scrollingTextButton.AutoSize = true;
            this.scrollingTextButton.Location = new System.Drawing.Point(168, 105);
            this.scrollingTextButton.Name = "scrollingTextButton";
            this.scrollingTextButton.Size = new System.Drawing.Size(89, 17);
            this.scrollingTextButton.TabIndex = 10;
            this.scrollingTextButton.Text = "Scrolling Text";
            this.scrollingTextButton.UseVisualStyleBackColor = true;
            this.scrollingTextButton.CheckedChanged += new System.EventHandler(this.scrollingTextButton_CheckedChanged);
            // 
            // specialEffectButton
            // 
            this.specialEffectButton.AutoSize = true;
            this.specialEffectButton.Checked = true;
            this.specialEffectButton.Location = new System.Drawing.Point(17, 105);
            this.specialEffectButton.Name = "specialEffectButton";
            this.specialEffectButton.Size = new System.Drawing.Size(96, 17);
            this.specialEffectButton.TabIndex = 6;
            this.specialEffectButton.TabStop = true;
            this.specialEffectButton.Text = "Special Effects";
            this.specialEffectButton.UseVisualStyleBackColor = true;
            this.specialEffectButton.CheckedChanged += new System.EventHandler(this.specialEffectButton_CheckedChanged);
            // 
            // displayDurationLabel
            // 
            this.displayDurationLabel.AutoSize = true;
            this.displayDurationLabel.Location = new System.Drawing.Point(14, 63);
            this.displayDurationLabel.Name = "displayDurationLabel";
            this.displayDurationLabel.Size = new System.Drawing.Size(87, 13);
            this.displayDurationLabel.TabIndex = 8;
            this.displayDurationLabel.Text = "Display Duration:";
            // 
            // textTextBox
            // 
            this.textTextBox.Location = new System.Drawing.Point(104, 23);
            this.textTextBox.Name = "textTextBox";
            this.textTextBox.Size = new System.Drawing.Size(351, 20);
            this.textTextBox.TabIndex = 1;
            this.textTextBox.TextChanged += new System.EventHandler(this.textTextBox_TextChanged);
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = true;
            this.textLabel.Location = new System.Drawing.Point(14, 26);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(34, 13);
            this.textLabel.TabIndex = 0;
            this.textLabel.Text = "Text: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "Border Effect:";
            // 
            // borderColorLabel
            // 
            this.borderColorLabel.AutoSize = true;
            this.borderColorLabel.Location = new System.Drawing.Point(317, 33);
            this.borderColorLabel.Name = "borderColorLabel";
            this.borderColorLabel.Size = new System.Drawing.Size(68, 13);
            this.borderColorLabel.TabIndex = 4;
            this.borderColorLabel.Text = "Border Color:";
            // 
            // borderEffectComboBox
            // 
            this.borderEffectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.borderEffectComboBox.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.borderEffectComboBox.FormattingEnabled = true;
            this.borderEffectComboBox.Items.AddRange(new object[] {
            "No Border",
            "Static Border",
            "Rotating",
            "Flashing Random Colors",
            "Oscillating Random Colors"});
            this.borderEffectComboBox.Location = new System.Drawing.Point(91, 30);
            this.borderEffectComboBox.Name = "borderEffectComboBox";
            this.borderEffectComboBox.Size = new System.Drawing.Size(191, 21);
            this.borderEffectComboBox.TabIndex = 3;
            this.borderEffectComboBox.SelectedIndexChanged += new System.EventHandler(this.borderEffectComboBox_SelectedIndexChanged);
            // 
            // runButton
            // 
            this.runButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.runButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.runButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.runButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Lime;
            this.runButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.runButton.Location = new System.Drawing.Point(1052, 463);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(75, 37);
            this.runButton.TabIndex = 27;
            this.runButton.Text = "Run";
            this.runButton.UseVisualStyleBackColor = false;
            this.runButton.Click += new System.EventHandler(this.saveAndRunButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.exitButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.exitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Red;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.Location = new System.Drawing.Point(1133, 463);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 37);
            this.exitButton.TabIndex = 29;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = false;
            this.exitButton.Click += new System.EventHandler(this.saveAndExitButton_Click);
            // 
            // logoLabel
            // 
            this.logoLabel.AutoSize = true;
            this.logoLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.logoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 34F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoLabel.ForeColor = System.Drawing.Color.DeepSkyBlue;
            this.logoLabel.Location = new System.Drawing.Point(-2, 0);
            this.logoLabel.Name = "logoLabel";
            this.logoLabel.Size = new System.Drawing.Size(355, 53);
            this.logoLabel.TabIndex = 31;
            this.logoLabel.Text = "Team Discovery";
            this.logoLabel.Click += new System.EventHandler(this.logoLabel_Click);
            // 
            // textTabLabel
            // 
            this.textTabLabel.AutoSize = true;
            this.textTabLabel.BackColor = System.Drawing.Color.White;
            this.textTabLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textTabLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textTabLabel.ForeColor = System.Drawing.Color.Black;
            this.textTabLabel.Location = new System.Drawing.Point(353, 0);
            this.textTabLabel.Name = "textTabLabel";
            this.textTabLabel.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.textTabLabel.Size = new System.Drawing.Size(80, 55);
            this.textTabLabel.TabIndex = 32;
            this.textTabLabel.Text = "Text";
            this.textTabLabel.BackColorChanged += new System.EventHandler(this.textTabLabel_BackColorChanged);
            this.textTabLabel.Click += new System.EventHandler(this.textTabLabel_Click);
            this.textTabLabel.MouseEnter += new System.EventHandler(this.textTabLabel_MouseEnter);
            this.textTabLabel.MouseLeave += new System.EventHandler(this.textTabLabel_MouseLeave);
            // 
            // imageTabLabel
            // 
            this.imageTabLabel.AutoSize = true;
            this.imageTabLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.imageTabLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imageTabLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.imageTabLabel.ForeColor = System.Drawing.Color.White;
            this.imageTabLabel.Location = new System.Drawing.Point(432, 0);
            this.imageTabLabel.Name = "imageTabLabel";
            this.imageTabLabel.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.imageTabLabel.Size = new System.Drawing.Size(107, 55);
            this.imageTabLabel.TabIndex = 33;
            this.imageTabLabel.Text = "Image";
            this.imageTabLabel.Click += new System.EventHandler(this.imageTabLabel_Click);
            this.imageTabLabel.MouseEnter += new System.EventHandler(this.imageTabLabel_MouseEnter);
            this.imageTabLabel.MouseLeave += new System.EventHandler(this.imageTabLabel_MouseLeave);
            // 
            // textPanel
            // 
            this.textPanel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textPanel.BackColor = System.Drawing.Color.White;
            this.textPanel.Controls.Add(this.ignoreCheckBox);
            this.textPanel.Controls.Add(this.borderOptionsGroupBox);
            this.textPanel.Controls.Add(this.createASegmentGroupBox);
            this.textPanel.Location = new System.Drawing.Point(354, 55);
            this.textPanel.Name = "textPanel";
            this.textPanel.Size = new System.Drawing.Size(854, 402);
            this.textPanel.TabIndex = 34;
            // 
            // ignoreCheckBox
            // 
            this.ignoreCheckBox.AutoSize = true;
            this.ignoreCheckBox.Checked = true;
            this.ignoreCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ignoreCheckBox.Location = new System.Drawing.Point(797, 3);
            this.ignoreCheckBox.Name = "ignoreCheckBox";
            this.ignoreCheckBox.Size = new System.Drawing.Size(56, 17);
            this.ignoreCheckBox.TabIndex = 24;
            this.ignoreCheckBox.Text = "Ignore";
            this.ignoreCheckBox.UseVisualStyleBackColor = true;
            this.ignoreCheckBox.CheckedChanged += new System.EventHandler(this.ignoreCheckBox_CheckedChanged);
            // 
            // borderOptionsGroupBox
            // 
            this.borderOptionsGroupBox.Controls.Add(this.borderColorButton);
            this.borderOptionsGroupBox.Controls.Add(this.borderEffectComboBox);
            this.borderOptionsGroupBox.Controls.Add(this.label2);
            this.borderOptionsGroupBox.Controls.Add(this.borderColorLabel);
            this.borderOptionsGroupBox.Location = new System.Drawing.Point(12, 227);
            this.borderOptionsGroupBox.Name = "borderOptionsGroupBox";
            this.borderOptionsGroupBox.Size = new System.Drawing.Size(770, 100);
            this.borderOptionsGroupBox.TabIndex = 22;
            this.borderOptionsGroupBox.TabStop = false;
            this.borderOptionsGroupBox.Text = "Border Options";
            // 
            // borderColorButton
            // 
            this.borderColorButton.BackColor = System.Drawing.Color.Red;
            this.borderColorButton.Location = new System.Drawing.Point(405, 30);
            this.borderColorButton.Name = "borderColorButton";
            this.borderColorButton.Size = new System.Drawing.Size(75, 23);
            this.borderColorButton.TabIndex = 42;
            this.borderColorButton.UseVisualStyleBackColor = false;
            this.borderColorButton.Click += new System.EventHandler(this.borderColorButton_Click);
            // 
            // exitFullScreen
            // 
            this.exitFullScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.exitFullScreen.Image = ((System.Drawing.Image)(resources.GetObject("exitFullScreen.Image")));
            this.exitFullScreen.Location = new System.Drawing.Point(1142, 0);
            this.exitFullScreen.Name = "exitFullScreen";
            this.exitFullScreen.Size = new System.Drawing.Size(73, 73);
            this.exitFullScreen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.exitFullScreen.TabIndex = 46;
            this.exitFullScreen.TabStop = false;
            this.exitFullScreen.Visible = false;
            this.exitFullScreen.MouseClick += new System.Windows.Forms.MouseEventHandler(this.exitFullScreen_MouseClick);
            // 
            // SegmentHolderPanel
            // 
            this.SegmentHolderPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.SegmentHolderPanel.Controls.Add(this.lastSegmentPopUp);
            this.SegmentHolderPanel.Controls.Add(this.startNewMessageButton);
            this.SegmentHolderPanel.Location = new System.Drawing.Point(0, 55);
            this.SegmentHolderPanel.Name = "SegmentHolderPanel";
            this.SegmentHolderPanel.Size = new System.Drawing.Size(354, 402);
            this.SegmentHolderPanel.TabIndex = 36;
            // 
            // lastSegmentPopUp
            // 
            this.lastSegmentPopUp.AutoSize = true;
            this.lastSegmentPopUp.ForeColor = System.Drawing.Color.Red;
            this.lastSegmentPopUp.Location = new System.Drawing.Point(3, 44);
            this.lastSegmentPopUp.Name = "lastSegmentPopUp";
            this.lastSegmentPopUp.Size = new System.Drawing.Size(159, 13);
            this.lastSegmentPopUp.TabIndex = 45;
            this.lastSegmentPopUp.Text = "Can not delete the only segment";
            this.lastSegmentPopUp.Visible = false;
            // 
            // startNewMessageButton
            // 
            this.startNewMessageButton.Location = new System.Drawing.Point(117, 374);
            this.startNewMessageButton.Name = "startNewMessageButton";
            this.startNewMessageButton.Size = new System.Drawing.Size(120, 23);
            this.startNewMessageButton.TabIndex = 0;
            this.startNewMessageButton.Text = "Start New Message";
            this.startNewMessageButton.UseVisualStyleBackColor = true;
            this.startNewMessageButton.Click += new System.EventHandler(this.startNewMessageButton_Click);
            // 
            // imagePanel
            // 
            this.imagePanel.BackColor = System.Drawing.Color.White;
            this.imagePanel.Controls.Add(this.previewButton);
            this.imagePanel.Controls.Add(this.scaledImageGroupBox);
            this.imagePanel.Controls.Add(this.fileLocationTextBox);
            this.imagePanel.Controls.Add(this.browseButton);
            this.imagePanel.Controls.Add(this.groupBox1);
            this.imagePanel.Location = new System.Drawing.Point(354, 55);
            this.imagePanel.Name = "imagePanel";
            this.imagePanel.Size = new System.Drawing.Size(854, 401);
            this.imagePanel.TabIndex = 35;
            this.imagePanel.Visible = false;
            // 
            // previewButton
            // 
            this.previewButton.Location = new System.Drawing.Point(758, 24);
            this.previewButton.Name = "previewButton";
            this.previewButton.Size = new System.Drawing.Size(75, 23);
            this.previewButton.TabIndex = 9;
            this.previewButton.Text = "Preview";
            this.previewButton.UseVisualStyleBackColor = true;
            this.previewButton.Click += new System.EventHandler(this.previewButton_Click);
            // 
            // scaledImageGroupBox
            // 
            this.scaledImageGroupBox.Controls.Add(this.scaledPictureBox);
            this.scaledImageGroupBox.Location = new System.Drawing.Point(12, 217);
            this.scaledImageGroupBox.Name = "scaledImageGroupBox";
            this.scaledImageGroupBox.Size = new System.Drawing.Size(697, 142);
            this.scaledImageGroupBox.TabIndex = 5;
            this.scaledImageGroupBox.TabStop = false;
            this.scaledImageGroupBox.Text = "Scaled Image";
            // 
            // scaledPictureBox
            // 
            this.scaledPictureBox.Location = new System.Drawing.Point(8, 18);
            this.scaledPictureBox.Name = "scaledPictureBox";
            this.scaledPictureBox.Size = new System.Drawing.Size(672, 112);
            this.scaledPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.scaledPictureBox.TabIndex = 3;
            this.scaledPictureBox.TabStop = false;
            // 
            // fileLocationTextBox
            // 
            this.fileLocationTextBox.Location = new System.Drawing.Point(242, 26);
            this.fileLocationTextBox.Name = "fileLocationTextBox";
            this.fileLocationTextBox.Size = new System.Drawing.Size(396, 20);
            this.fileLocationTextBox.TabIndex = 8;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(658, 24);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 6;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.originalPictureBox);
            this.groupBox1.Location = new System.Drawing.Point(12, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(697, 142);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Original Image";
            // 
            // originalPictureBox
            // 
            this.originalPictureBox.Location = new System.Drawing.Point(8, 18);
            this.originalPictureBox.Name = "originalPictureBox";
            this.originalPictureBox.Size = new System.Drawing.Size(672, 112);
            this.originalPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.originalPictureBox.TabIndex = 3;
            this.originalPictureBox.TabStop = false;
            // 
            // marqueeBackgroundColorLabel
            // 
            this.marqueeBackgroundColorLabel.AutoSize = true;
            this.marqueeBackgroundColorLabel.ForeColor = System.Drawing.Color.White;
            this.marqueeBackgroundColorLabel.Location = new System.Drawing.Point(976, 12);
            this.marqueeBackgroundColorLabel.Name = "marqueeBackgroundColorLabel";
            this.marqueeBackgroundColorLabel.Size = new System.Drawing.Size(137, 13);
            this.marqueeBackgroundColorLabel.TabIndex = 37;
            this.marqueeBackgroundColorLabel.Text = "Marquee Background Color";
            // 
            // backToMenuButton
            // 
            this.backToMenuButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.backToMenuButton.Location = new System.Drawing.Point(561, 463);
            this.backToMenuButton.Name = "backToMenuButton";
            this.backToMenuButton.Size = new System.Drawing.Size(105, 37);
            this.backToMenuButton.TabIndex = 39;
            this.backToMenuButton.Text = "Back to Menu";
            this.backToMenuButton.UseVisualStyleBackColor = true;
            this.backToMenuButton.Visible = false;
            this.backToMenuButton.Click += new System.EventHandler(this.backToMenuButton_Click);
            // 
            // colorDialogBox
            // 
            this.colorDialogBox.Color = System.Drawing.Color.White;
            // 
            // marqueeBackgroundColorButton
            // 
            this.marqueeBackgroundColorButton.BackColor = System.Drawing.Color.Black;
            this.marqueeBackgroundColorButton.Location = new System.Drawing.Point(1122, 7);
            this.marqueeBackgroundColorButton.Name = "marqueeBackgroundColorButton";
            this.marqueeBackgroundColorButton.Size = new System.Drawing.Size(75, 23);
            this.marqueeBackgroundColorButton.TabIndex = 42;
            this.marqueeBackgroundColorButton.UseVisualStyleBackColor = false;
            this.marqueeBackgroundColorButton.Click += new System.EventHandler(this.marqueeBackgroundColorButton_Click);
            // 
            // pauseButton
            // 
            this.pauseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pauseButton.Location = new System.Drawing.Point(6, 463);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(65, 37);
            this.pauseButton.TabIndex = 43;
            this.pauseButton.Text = "Pause";
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Visible = false;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // playButton
            // 
            this.playButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.playButton.Location = new System.Drawing.Point(6, 463);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(65, 37);
            this.playButton.TabIndex = 44;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Visible = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog";
            this.openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG)|*.BMP;*.JPG;*.GIF;*.PNG;*.JPEG";
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.saveButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.saveButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Blue;
            this.saveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.saveButton.Location = new System.Drawing.Point(88, 463);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 37);
            this.saveButton.TabIndex = 45;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = false;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // goToFullScreenButton
            // 
            this.goToFullScreenButton.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.goToFullScreenButton.Location = new System.Drawing.Point(561, 5);
            this.goToFullScreenButton.Name = "goToFullScreenButton";
            this.goToFullScreenButton.Size = new System.Drawing.Size(105, 37);
            this.goToFullScreenButton.TabIndex = 47;
            this.goToFullScreenButton.Text = "Go To FullScreen";
            this.goToFullScreenButton.UseVisualStyleBackColor = true;
            this.goToFullScreenButton.Visible = false;
            this.goToFullScreenButton.Click += new System.EventHandler(this.goToFullScreenButton_Click);
            // 
            // loadXMLButton
            // 
            this.loadXMLButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.loadXMLButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.loadXMLButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.loadXMLButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.loadXMLButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loadXMLButton.Location = new System.Drawing.Point(7, 463);
            this.loadXMLButton.Name = "loadXMLButton";
            this.loadXMLButton.Size = new System.Drawing.Size(75, 37);
            this.loadXMLButton.TabIndex = 48;
            this.loadXMLButton.Text = "Load XML";
            this.loadXMLButton.UseVisualStyleBackColor = false;
            // 
            // marquee1
            // 
            this.marquee1.BackColor = System.Drawing.Color.Black;
            this.marquee1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.marquee1.Location = new System.Drawing.Point(0, 0);
            this.marquee1.Name = "marquee1";
            this.marquee1.Size = new System.Drawing.Size(1214, 504);
            this.marquee1.TabIndex = 28;
            this.marquee1.Text = "marquee";
            this.marquee1.Visible = false;
            // 
            // UIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(1214, 504);
            this.Controls.Add(this.loadXMLButton);
            this.Controls.Add(this.goToFullScreenButton);
            this.Controls.Add(this.marqueeBackgroundColorButton);
            this.Controls.Add(this.exitFullScreen);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.backToMenuButton);
            this.Controls.Add(this.marqueeBackgroundColorLabel);
            this.Controls.Add(this.SegmentHolderPanel);
            this.Controls.Add(this.imageTabLabel);
            this.Controls.Add(this.textTabLabel);
            this.Controls.Add(this.logoLabel);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.populateMarqueeButton);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.pauseButton);
            this.Controls.Add(this.textPanel);
            this.Controls.Add(this.imagePanel);
            this.Controls.Add(this.marquee1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(500, 200);
            this.Name = "UIForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vision";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UIForm_FormClosed);
            this.Load += new System.EventHandler(this.UIForm_Load);
            this.createASegmentGroupBox.ResumeLayout(false);
            this.createASegmentGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.displayDurationControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scrollSpeedControl)).EndInit();
            this.textPanel.ResumeLayout(false);
            this.textPanel.PerformLayout();
            this.borderOptionsGroupBox.ResumeLayout(false);
            this.borderOptionsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.exitFullScreen)).EndInit();
            this.SegmentHolderPanel.ResumeLayout(false);
            this.SegmentHolderPanel.PerformLayout();
            this.imagePanel.ResumeLayout(false);
            this.imagePanel.PerformLayout();
            this.scaledImageGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scaledPictureBox)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.originalPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button populateMarqueeButton;
        private System.Windows.Forms.Button runButton;
        private Marquee marquee1;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label logoLabel;
        private System.Windows.Forms.GroupBox createASegmentGroupBox;
        private System.Windows.Forms.Label exitEffectLabel;
        private System.Windows.Forms.Label staticEffectLabel;
        private System.Windows.Forms.Label entranceEffectLabel;
        private System.Windows.Forms.ComboBox exitEffectComboBox;
        private System.Windows.Forms.ComboBox middleEffectComboBox;
        private System.Windows.Forms.ComboBox entranceEffectComboBox;
        private System.Windows.Forms.RadioButton scrollingTextButton;
        private System.Windows.Forms.RadioButton specialEffectButton;
        private System.Windows.Forms.Label displayDurationLabel;
        private System.Windows.Forms.Label borderColorLabel;
        private System.Windows.Forms.ComboBox borderEffectComboBox;
        private System.Windows.Forms.TextBox textTextBox;
        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.Label longTextPopUp;
        private System.Windows.Forms.Label textTabLabel;
        private System.Windows.Forms.Label imageTabLabel;
        private System.Windows.Forms.Panel textPanel;
        private System.Windows.Forms.Panel imagePanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel SegmentHolderPanel;
        private System.Windows.Forms.Label scrollSpeedLabel;
        private System.Windows.Forms.NumericUpDown scrollSpeedControl;
        private System.Windows.Forms.GroupBox borderOptionsGroupBox;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox originalPictureBox;
        private System.Windows.Forms.CheckBox ignoreCheckBox;
        private System.Windows.Forms.CheckBox randomColorCheckBox;
        private System.Windows.Forms.Label marqueeBackgroundColorLabel;
        private System.Windows.Forms.Button backToMenuButton;
        private System.Windows.Forms.ColorDialog colorDialogBox;
        private System.Windows.Forms.Button colorButton;
        private System.Windows.Forms.Label colorLabel;
        private System.Windows.Forms.Button borderColorButton;
        private System.Windows.Forms.ColorDialog borderColorDialogBox;
        private System.Windows.Forms.Button marqueeBackgroundColorButton;
        private System.Windows.Forms.ColorDialog marqueeBackgroundColorDialogBox;
        private System.Windows.Forms.NumericUpDown displayDurationControl;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.TextBox fileLocationTextBox;
        private System.Windows.Forms.Button startNewMessageButton;
        private System.Windows.Forms.Timer animateSegmentTimer;
        private System.Windows.Forms.Label lastSegmentPopUp;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.GroupBox scaledImageGroupBox;
        private System.Windows.Forms.PictureBox scaledPictureBox;
        private System.Windows.Forms.Button previewButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.PictureBox exitFullScreen;
        private System.Windows.Forms.Button goToFullScreenButton;
        private System.Windows.Forms.Label secondsPerCharacterLabel;
        private System.Windows.Forms.Button loadXMLButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}

