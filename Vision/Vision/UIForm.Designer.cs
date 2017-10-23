/////////////////////////////////////////////////////
// Course: CSC 289
// Team: Team Discovery
//
// Class: UIForm.Designer.cs
// Description: 
//
// Name: 
// Last Edit: 
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
            this.marquee = new System.Windows.Forms.Panel();
            this.populateMarqueeButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.textTab = new System.Windows.Forms.TabPage();
            this.createAMessageGroupBox = new System.Windows.Forms.GroupBox();
            this.repeatComboBox = new System.Windows.Forms.ComboBox();
            this.repeatLabel = new System.Windows.Forms.Label();
            this.transitionComboBox = new System.Windows.Forms.ComboBox();
            this.transitionLabel = new System.Windows.Forms.Label();
            this.textTextBox = new System.Windows.Forms.TextBox();
            this.textLabel = new System.Windows.Forms.Label();
            this.uploadButton = new System.Windows.Forms.Button();
            this.browseButton = new System.Windows.Forms.Button();
            this.fileLocationTextBox = new System.Windows.Forms.TextBox();
            this.uploadMessageFromFileButton = new System.Windows.Forms.RadioButton();
            this.createNewMessageButton = new System.Windows.Forms.RadioButton();
            this.imageTab = new System.Windows.Forms.TabPage();
            this.colorLabel = new System.Windows.Forms.Label();
            this.colorComboBox = new System.Windows.Forms.ComboBox();
            this.transitionSpeedLabel = new System.Windows.Forms.Label();
            this.transitionSpeedComboBox = new System.Windows.Forms.ComboBox();
            this.tabControl.SuspendLayout();
            this.textTab.SuspendLayout();
            this.createAMessageGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // marquee
            // 
            this.marquee.Location = new System.Drawing.Point(12, 27);
            this.marquee.Name = "marquee";
            this.marquee.Size = new System.Drawing.Size(1179, 238);
            this.marquee.TabIndex = 0;
            this.marquee.Visible = false;
            // 
            // populateMarqueeButton
            // 
            this.populateMarqueeButton.Location = new System.Drawing.Point(12, 452);
            this.populateMarqueeButton.Name = "populateMarqueeButton";
            this.populateMarqueeButton.Size = new System.Drawing.Size(122, 52);
            this.populateMarqueeButton.TabIndex = 1;
            this.populateMarqueeButton.Text = "Populate Marquee";
            this.populateMarqueeButton.UseVisualStyleBackColor = true;
            this.populateMarqueeButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.textTab);
            this.tabControl.Controls.Add(this.imageTab);
            this.tabControl.Location = new System.Drawing.Point(12, 12);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1176, 434);
            this.tabControl.TabIndex = 0;
            // 
            // textTab
            // 
            this.textTab.Controls.Add(this.createAMessageGroupBox);
            this.textTab.Controls.Add(this.uploadButton);
            this.textTab.Controls.Add(this.browseButton);
            this.textTab.Controls.Add(this.fileLocationTextBox);
            this.textTab.Controls.Add(this.uploadMessageFromFileButton);
            this.textTab.Controls.Add(this.createNewMessageButton);
            this.textTab.Location = new System.Drawing.Point(4, 22);
            this.textTab.Name = "textTab";
            this.textTab.Padding = new System.Windows.Forms.Padding(3);
            this.textTab.Size = new System.Drawing.Size(1168, 408);
            this.textTab.TabIndex = 0;
            this.textTab.Text = "Text";
            this.textTab.UseVisualStyleBackColor = true;
            // 
            // createAMessageGroupBox
            // 
            this.createAMessageGroupBox.Controls.Add(this.transitionSpeedComboBox);
            this.createAMessageGroupBox.Controls.Add(this.transitionSpeedLabel);
            this.createAMessageGroupBox.Controls.Add(this.colorComboBox);
            this.createAMessageGroupBox.Controls.Add(this.colorLabel);
            this.createAMessageGroupBox.Controls.Add(this.repeatComboBox);
            this.createAMessageGroupBox.Controls.Add(this.repeatLabel);
            this.createAMessageGroupBox.Controls.Add(this.transitionComboBox);
            this.createAMessageGroupBox.Controls.Add(this.transitionLabel);
            this.createAMessageGroupBox.Controls.Add(this.textTextBox);
            this.createAMessageGroupBox.Controls.Add(this.textLabel);
            this.createAMessageGroupBox.Location = new System.Drawing.Point(15, 65);
            this.createAMessageGroupBox.Name = "createAMessageGroupBox";
            this.createAMessageGroupBox.Size = new System.Drawing.Size(1140, 319);
            this.createAMessageGroupBox.TabIndex = 5;
            this.createAMessageGroupBox.TabStop = false;
            this.createAMessageGroupBox.Text = "Create A Message";
            this.createAMessageGroupBox.Visible = false;
            // 
            // repeatComboBox
            // 
            this.repeatComboBox.FormattingEnabled = true;
            this.repeatComboBox.Location = new System.Drawing.Point(351, 67);
            this.repeatComboBox.Name = "repeatComboBox";
            this.repeatComboBox.Size = new System.Drawing.Size(191, 21);
            this.repeatComboBox.TabIndex = 5;
            this.repeatComboBox.Visible = false;
            // 
            // repeatLabel
            // 
            this.repeatLabel.AutoSize = true;
            this.repeatLabel.Location = new System.Drawing.Point(293, 70);
            this.repeatLabel.Name = "repeatLabel";
            this.repeatLabel.Size = new System.Drawing.Size(45, 13);
            this.repeatLabel.TabIndex = 4;
            this.repeatLabel.Text = "Repeat:";
            this.repeatLabel.Visible = false;
            // 
            // transitionComboBox
            // 
            this.transitionComboBox.FormattingEnabled = true;
            this.transitionComboBox.Location = new System.Drawing.Point(77, 67);
            this.transitionComboBox.Name = "transitionComboBox";
            this.transitionComboBox.Size = new System.Drawing.Size(191, 21);
            this.transitionComboBox.TabIndex = 3;
            this.transitionComboBox.Visible = false;
            // 
            // transitionLabel
            // 
            this.transitionLabel.AutoSize = true;
            this.transitionLabel.Location = new System.Drawing.Point(14, 70);
            this.transitionLabel.Name = "transitionLabel";
            this.transitionLabel.Size = new System.Drawing.Size(56, 13);
            this.transitionLabel.TabIndex = 2;
            this.transitionLabel.Text = "Transition:";
            this.transitionLabel.Visible = false;
            // 
            // textTextBox
            // 
            this.textTextBox.Location = new System.Drawing.Point(69, 23);
            this.textTextBox.Name = "textTextBox";
            this.textTextBox.Size = new System.Drawing.Size(1045, 20);
            this.textTextBox.TabIndex = 1;
            // 
            // textLabel
            // 
            this.textLabel.AutoSize = true;
            this.textLabel.Location = new System.Drawing.Point(14, 26);
            this.textLabel.Name = "textLabel";
            this.textLabel.Size = new System.Drawing.Size(34, 13);
            this.textLabel.TabIndex = 0;
            this.textLabel.Text = "Text: ";
            this.textLabel.Visible = false;
            // 
            // uploadButton
            // 
            this.uploadButton.Location = new System.Drawing.Point(1080, 27);
            this.uploadButton.Name = "uploadButton";
            this.uploadButton.Size = new System.Drawing.Size(75, 23);
            this.uploadButton.TabIndex = 4;
            this.uploadButton.Text = "Upload";
            this.uploadButton.UseVisualStyleBackColor = true;
            this.uploadButton.Visible = false;
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(951, 27);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 3;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Visible = false;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // fileLocationTextBox
            // 
            this.fileLocationTextBox.Location = new System.Drawing.Point(193, 29);
            this.fileLocationTextBox.Name = "fileLocationTextBox";
            this.fileLocationTextBox.Size = new System.Drawing.Size(707, 20);
            this.fileLocationTextBox.TabIndex = 2;
            this.fileLocationTextBox.Visible = false;
            // 
            // uploadMessageFromFileButton
            // 
            this.uploadMessageFromFileButton.AutoSize = true;
            this.uploadMessageFromFileButton.Location = new System.Drawing.Point(6, 29);
            this.uploadMessageFromFileButton.Name = "uploadMessageFromFileButton";
            this.uploadMessageFromFileButton.Size = new System.Drawing.Size(150, 17);
            this.uploadMessageFromFileButton.TabIndex = 1;
            this.uploadMessageFromFileButton.TabStop = true;
            this.uploadMessageFromFileButton.Text = "Upload Message From File";
            this.uploadMessageFromFileButton.UseVisualStyleBackColor = true;
            this.uploadMessageFromFileButton.CheckedChanged += new System.EventHandler(this.uploadMessageFromFileButton_CheckedChanged);
            // 
            // createNewMessageButton
            // 
            this.createNewMessageButton.AutoSize = true;
            this.createNewMessageButton.Location = new System.Drawing.Point(6, 6);
            this.createNewMessageButton.Name = "createNewMessageButton";
            this.createNewMessageButton.Size = new System.Drawing.Size(127, 17);
            this.createNewMessageButton.TabIndex = 0;
            this.createNewMessageButton.TabStop = true;
            this.createNewMessageButton.Text = "Create New Message";
            this.createNewMessageButton.UseVisualStyleBackColor = true;
            this.createNewMessageButton.CheckedChanged += new System.EventHandler(this.createNewMessageButton_CheckedChanged);
            // 
            // imageTab
            // 
            this.imageTab.Location = new System.Drawing.Point(4, 22);
            this.imageTab.Name = "imageTab";
            this.imageTab.Padding = new System.Windows.Forms.Padding(3);
            this.imageTab.Size = new System.Drawing.Size(1168, 408);
            this.imageTab.TabIndex = 1;
            this.imageTab.Text = "Image";
            this.imageTab.UseVisualStyleBackColor = true;
            // 
            // colorLabel
            // 
            this.colorLabel.AutoSize = true;
            this.colorLabel.Location = new System.Drawing.Point(571, 70);
            this.colorLabel.Name = "colorLabel";
            this.colorLabel.Size = new System.Drawing.Size(34, 13);
            this.colorLabel.TabIndex = 6;
            this.colorLabel.Text = "Color:";
            this.colorLabel.Visible = false;
            // 
            // colorComboBox
            // 
            this.colorComboBox.FormattingEnabled = true;
            this.colorComboBox.Location = new System.Drawing.Point(614, 67);
            this.colorComboBox.Name = "colorComboBox";
            this.colorComboBox.Size = new System.Drawing.Size(191, 21);
            this.colorComboBox.TabIndex = 7;
            this.colorComboBox.Visible = false;
            // 
            // transitionSpeedLabel
            // 
            this.transitionSpeedLabel.AutoSize = true;
            this.transitionSpeedLabel.Location = new System.Drawing.Point(833, 70);
            this.transitionSpeedLabel.Name = "transitionSpeedLabel";
            this.transitionSpeedLabel.Size = new System.Drawing.Size(90, 13);
            this.transitionSpeedLabel.TabIndex = 8;
            this.transitionSpeedLabel.Text = "Transition Speed:";
            this.transitionSpeedLabel.Visible = false;
            // 
            // transitionSpeedComboBox
            // 
            this.transitionSpeedComboBox.FormattingEnabled = true;
            this.transitionSpeedComboBox.Location = new System.Drawing.Point(932, 67);
            this.transitionSpeedComboBox.Name = "transitionSpeedComboBox";
            this.transitionSpeedComboBox.Size = new System.Drawing.Size(191, 21);
            this.transitionSpeedComboBox.TabIndex = 9;
            this.transitionSpeedComboBox.Visible = false;
            // 
            // UIForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1203, 516);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.populateMarqueeButton);
            this.Controls.Add(this.marquee);
            this.Name = "UIForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.UIForm_Load);
            this.tabControl.ResumeLayout(false);
            this.textTab.ResumeLayout(false);
            this.textTab.PerformLayout();
            this.createAMessageGroupBox.ResumeLayout(false);
            this.createAMessageGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel marquee;
        private System.Windows.Forms.Button populateMarqueeButton;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage textTab;
        private System.Windows.Forms.TabPage imageTab;
        private System.Windows.Forms.RadioButton uploadMessageFromFileButton;
        private System.Windows.Forms.RadioButton createNewMessageButton;
        private System.Windows.Forms.Button uploadButton;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.TextBox fileLocationTextBox;
        private System.Windows.Forms.GroupBox createAMessageGroupBox;
        private System.Windows.Forms.ComboBox repeatComboBox;
        private System.Windows.Forms.Label repeatLabel;
        private System.Windows.Forms.ComboBox transitionComboBox;
        private System.Windows.Forms.Label transitionLabel;
        private System.Windows.Forms.TextBox textTextBox;
        private System.Windows.Forms.Label textLabel;
        private System.Windows.Forms.ComboBox transitionSpeedComboBox;
        private System.Windows.Forms.Label transitionSpeedLabel;
        private System.Windows.Forms.ComboBox colorComboBox;
        private System.Windows.Forms.Label colorLabel;
    }
}

