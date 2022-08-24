using Automation.ResolumeCompositionSwitcher.WinForms.Controls;

namespace Automation.ResolumeCompositionSwitcher.WinForms
{
    partial class ResolumeCompositionSwitcher
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.connectionStatusLabel = new System.Windows.Forms.Label();
            this.numberOfColumnsLabel = new System.Windows.Forms.Label();
            this.minTimeToChangeMsLabel = new System.Windows.Forms.Label();
            this.maxTimeToChangeMsLabel = new System.Windows.Forms.Label();
            this.numberOfColumnsNumeric = new System.Windows.Forms.NumericUpDown();
            this.minTimeToChangeMsNumeric = new System.Windows.Forms.NumericUpDown();
            this.maxTimeToChangeMsNumeric = new System.Windows.Forms.NumericUpDown();
            this.currentColumnLabel = new System.Windows.Forms.Label();
            this.nextSwitchInLabel = new System.Windows.Forms.Label();
            this.nextSwitchMsTextBox = new System.Windows.Forms.TextBox();
            this.msUnitLabel = new System.Windows.Forms.Label();
            this.currentColumnTextBox = new System.Windows.Forms.TextBox();
            this.loadingPictureBox = new System.Windows.Forms.PictureBox();
            playPauseButton = new PlayPauseButton(loadingPictureBox);
            this.processStatusLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfColumnsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minTimeToChangeMsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxTimeToChangeMsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.AutoSize = true;
            this.connectionStatusLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.connectionStatusLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.connectionStatusLabel.Location = new System.Drawing.Point(17, 18);
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(213, 23);
            this.connectionStatusLabel.TabIndex = 0;
            this.connectionStatusLabel.Text = "Composition disconnected";
            // 
            // numberOfColumnsLabel
            // 
            this.numberOfColumnsLabel.AutoSize = true;
            this.numberOfColumnsLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.numberOfColumnsLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.numberOfColumnsLabel.Location = new System.Drawing.Point(15, 107);
            this.numberOfColumnsLabel.Margin = new System.Windows.Forms.Padding(10);
            this.numberOfColumnsLabel.Name = "numberOfColumnsLabel";
            this.numberOfColumnsLabel.Size = new System.Drawing.Size(202, 28);
            this.numberOfColumnsLabel.TabIndex = 4;
            this.numberOfColumnsLabel.Text = "Number of Columns";
            // 
            // minTimeToChangeMsLabel
            // 
            this.minTimeToChangeMsLabel.AutoSize = true;
            this.minTimeToChangeMsLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.minTimeToChangeMsLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.minTimeToChangeMsLabel.Location = new System.Drawing.Point(17, 155);
            this.minTimeToChangeMsLabel.Margin = new System.Windows.Forms.Padding(10);
            this.minTimeToChangeMsLabel.Name = "minTimeToChangeMsLabel";
            this.minTimeToChangeMsLabel.Size = new System.Drawing.Size(253, 28);
            this.minTimeToChangeMsLabel.TabIndex = 5;
            this.minTimeToChangeMsLabel.Text = "Min Time To Change [ms]";
            // 
            // maxTimeToChangeMsLabel
            // 
            this.maxTimeToChangeMsLabel.AutoSize = true;
            this.maxTimeToChangeMsLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.maxTimeToChangeMsLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.maxTimeToChangeMsLabel.Location = new System.Drawing.Point(17, 203);
            this.maxTimeToChangeMsLabel.Margin = new System.Windows.Forms.Padding(10);
            this.maxTimeToChangeMsLabel.Name = "maxTimeToChangeMsLabel";
            this.maxTimeToChangeMsLabel.Size = new System.Drawing.Size(257, 28);
            this.maxTimeToChangeMsLabel.TabIndex = 6;
            this.maxTimeToChangeMsLabel.Text = "Max Time To Change [ms]";
            // 
            // numberOfColumnsNumeric
            // 
            this.numberOfColumnsNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.numberOfColumnsNumeric.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numberOfColumnsNumeric.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numberOfColumnsNumeric.ForeColor = System.Drawing.Color.Gainsboro;
            this.numberOfColumnsNumeric.Location = new System.Drawing.Point(320, 105);
            this.numberOfColumnsNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numberOfColumnsNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberOfColumnsNumeric.Name = "numberOfColumnsNumeric";
            this.numberOfColumnsNumeric.Size = new System.Drawing.Size(97, 30);
            this.numberOfColumnsNumeric.TabIndex = 7;
            this.numberOfColumnsNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numberOfColumnsNumeric.Value = new decimal(new int[] {
            77,
            0,
            0,
            0});
            this.numberOfColumnsNumeric.ValueChanged += new System.EventHandler(this.numberOfColumnsNumeric_ValueChanged);
            // 
            // minTimeToChangeMsNumeric
            // 
            this.minTimeToChangeMsNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.minTimeToChangeMsNumeric.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.minTimeToChangeMsNumeric.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.minTimeToChangeMsNumeric.ForeColor = System.Drawing.Color.Gainsboro;
            this.minTimeToChangeMsNumeric.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.minTimeToChangeMsNumeric.Location = new System.Drawing.Point(320, 153);
            this.minTimeToChangeMsNumeric.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.minTimeToChangeMsNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.minTimeToChangeMsNumeric.Name = "minTimeToChangeMsNumeric";
            this.minTimeToChangeMsNumeric.Size = new System.Drawing.Size(97, 30);
            this.minTimeToChangeMsNumeric.TabIndex = 8;
            this.minTimeToChangeMsNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.minTimeToChangeMsNumeric.Value = new decimal(new int[] {
            5000,
            0,
            0,
            0});
            this.minTimeToChangeMsNumeric.ValueChanged += new System.EventHandler(this.minTimeToChangeMsNumeric_ValueChanged);
            // 
            // maxTimeToChangeMsNumeric
            // 
            this.maxTimeToChangeMsNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(55)))), ((int)(((byte)(55)))));
            this.maxTimeToChangeMsNumeric.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maxTimeToChangeMsNumeric.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maxTimeToChangeMsNumeric.ForeColor = System.Drawing.Color.Gainsboro;
            this.maxTimeToChangeMsNumeric.Increment = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.maxTimeToChangeMsNumeric.Location = new System.Drawing.Point(320, 201);
            this.maxTimeToChangeMsNumeric.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.maxTimeToChangeMsNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.maxTimeToChangeMsNumeric.Name = "maxTimeToChangeMsNumeric";
            this.maxTimeToChangeMsNumeric.Size = new System.Drawing.Size(97, 30);
            this.maxTimeToChangeMsNumeric.TabIndex = 9;
            this.maxTimeToChangeMsNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maxTimeToChangeMsNumeric.Value = new decimal(new int[] {
            15000,
            0,
            0,
            0});
            this.maxTimeToChangeMsNumeric.ValueChanged += new System.EventHandler(this.maxTimeToChangeMsNumeric_ValueChanged);
            // 
            // currentColumnLabel
            // 
            this.currentColumnLabel.AutoSize = true;
            this.currentColumnLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.currentColumnLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.currentColumnLabel.Location = new System.Drawing.Point(15, 387);
            this.currentColumnLabel.Margin = new System.Windows.Forms.Padding(10);
            this.currentColumnLabel.Name = "currentColumnLabel";
            this.currentColumnLabel.Size = new System.Drawing.Size(161, 28);
            this.currentColumnLabel.TabIndex = 10;
            this.currentColumnLabel.Text = "Current Column";
            // 
            // nextSwitchInLabel
            // 
            this.nextSwitchInLabel.AutoSize = true;
            this.nextSwitchInLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nextSwitchInLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.nextSwitchInLabel.Location = new System.Drawing.Point(17, 251);
            this.nextSwitchInLabel.Margin = new System.Windows.Forms.Padding(10);
            this.nextSwitchInLabel.Name = "nextSwitchInLabel";
            this.nextSwitchInLabel.Size = new System.Drawing.Size(154, 28);
            this.nextSwitchInLabel.TabIndex = 12;
            this.nextSwitchInLabel.Text = "Next switch in:";
            // 
            // nextSwitchMsTextBox
            // 
            this.nextSwitchMsTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.nextSwitchMsTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.nextSwitchMsTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nextSwitchMsTextBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.nextSwitchMsTextBox.Location = new System.Drawing.Point(179, 251);
            this.nextSwitchMsTextBox.Name = "nextSwitchMsTextBox";
            this.nextSwitchMsTextBox.Size = new System.Drawing.Size(91, 27);
            this.nextSwitchMsTextBox.TabIndex = 13;
            this.nextSwitchMsTextBox.Text = "0";
            this.nextSwitchMsTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // msUnitLabel
            // 
            this.msUnitLabel.AutoSize = true;
            this.msUnitLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.msUnitLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.msUnitLabel.Location = new System.Drawing.Point(269, 251);
            this.msUnitLabel.Margin = new System.Windows.Forms.Padding(10);
            this.msUnitLabel.Name = "msUnitLabel";
            this.msUnitLabel.Size = new System.Drawing.Size(39, 28);
            this.msUnitLabel.TabIndex = 14;
            this.msUnitLabel.Text = "ms";
            // 
            // currentColumnTextBox
            // 
            this.currentColumnTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.currentColumnTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.currentColumnTextBox.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.currentColumnTextBox.ForeColor = System.Drawing.Color.Gainsboro;
            this.currentColumnTextBox.Location = new System.Drawing.Point(179, 387);
            this.currentColumnTextBox.Name = "currentColumnTextBox";
            this.currentColumnTextBox.Size = new System.Drawing.Size(91, 27);
            this.currentColumnTextBox.TabIndex = 15;
            this.currentColumnTextBox.Text = "0";
            this.currentColumnTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // loadingPictureBox
            // 
            this.loadingPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.loadingPictureBox.Image = global::Automation.ResolumeCompositionSwitcher.WinForms.Properties.Resources.loading;
            this.loadingPictureBox.Location = new System.Drawing.Point(708, 360);
            this.loadingPictureBox.Margin = new System.Windows.Forms.Padding(30);
            this.loadingPictureBox.Name = "loadingPictureBox";
            this.loadingPictureBox.Size = new System.Drawing.Size(57, 55);
            this.loadingPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.loadingPictureBox.TabIndex = 16;
            this.loadingPictureBox.TabStop = false;
            this.loadingPictureBox.Visible = false;
            // 
            // playPauseButton
            // 
            this.playPauseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.playPauseButton.BackgroundImage = global::Automation.ResolumeCompositionSwitcher.WinForms.Properties.Resources.play_button_arrowhead1;
            this.playPauseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.playPauseButton.FlatAppearance.BorderSize = 0;
            this.playPauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playPauseButton.Location = new System.Drawing.Point(708, 360);
            this.playPauseButton.Margin = new System.Windows.Forms.Padding(30);
            this.playPauseButton.Name = "playPauseButton";
            this.playPauseButton.Play = false;
            this.playPauseButton.Size = new System.Drawing.Size(57, 55);
            this.playPauseButton.TabIndex = 3;
            this.playPauseButton.UseVisualStyleBackColor = false;
            this.playPauseButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.playPauseButton_MouseDown);
            // 
            // processStatusLabel
            // 
            this.processStatusLabel.AutoSize = true;
            this.processStatusLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.processStatusLabel.ForeColor = System.Drawing.Color.Gainsboro;
            this.processStatusLabel.Location = new System.Drawing.Point(552, 18);
            this.processStatusLabel.Name = "processStatusLabel";
            this.processStatusLabel.Size = new System.Drawing.Size(222, 23);
            this.processStatusLabel.TabIndex = 17;
            this.processStatusLabel.Text = "Process \'Arena\' is not found";
            // 
            // ResolumeCompositionSwitcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(45)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.processStatusLabel);
            this.Controls.Add(this.loadingPictureBox);
            this.Controls.Add(this.currentColumnTextBox);
            this.Controls.Add(this.msUnitLabel);
            this.Controls.Add(this.nextSwitchMsTextBox);
            this.Controls.Add(this.nextSwitchInLabel);
            this.Controls.Add(this.currentColumnLabel);
            this.Controls.Add(this.maxTimeToChangeMsNumeric);
            this.Controls.Add(this.minTimeToChangeMsNumeric);
            this.Controls.Add(this.numberOfColumnsNumeric);
            this.Controls.Add(this.maxTimeToChangeMsLabel);
            this.Controls.Add(this.minTimeToChangeMsLabel);
            this.Controls.Add(this.numberOfColumnsLabel);
            this.Controls.Add(this.playPauseButton);
            this.Controls.Add(this.connectionStatusLabel);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ResolumeCompositionSwitcher";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Resolume Composition Switicher";
            ((System.ComponentModel.ISupportInitialize)(this.numberOfColumnsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minTimeToChangeMsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxTimeToChangeMsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.loadingPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label connectionStatusLabel;
        private PlayPauseButton playPauseButton;
        private Label numberOfColumnsLabel;
        private Label minTimeToChangeMsLabel;
        private Label maxTimeToChangeMsLabel;
        private NumericUpDown numberOfColumnsNumeric;
        private NumericUpDown minTimeToChangeMsNumeric;
        private NumericUpDown maxTimeToChangeMsNumeric;
        private Label currentColumnLabel;
        private Label nextSwitchInLabel;
        private TextBox nextSwitchMsTextBox;
        private Label msUnitLabel;
        private TextBox currentColumnTextBox;
        private PictureBox loadingPictureBox;
        private Label processStatusLabel;
    }
}