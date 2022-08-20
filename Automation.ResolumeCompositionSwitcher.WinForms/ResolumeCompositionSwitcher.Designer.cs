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
            this.isAppInForegroundLabel = new System.Windows.Forms.Label();
            this.playPauseButton = new Automation.ResolumeCompositionSwitcher.WinForms.Controls.PlayPauseButton();
            this.numberOfColumnsLabel = new System.Windows.Forms.Label();
            this.minTimeToChangeMsLabel = new System.Windows.Forms.Label();
            this.maxTimeToChangeMsLabel = new System.Windows.Forms.Label();
            this.numberOfColumnsNumeric = new System.Windows.Forms.NumericUpDown();
            this.minTimeToChangeMsNumeric = new System.Windows.Forms.NumericUpDown();
            this.maxTimeToChangeMsNumeric = new System.Windows.Forms.NumericUpDown();
            this.currentColumnLabel = new System.Windows.Forms.Label();
            this.currentColumnNumeric = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfColumnsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minTimeToChangeMsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxTimeToChangeMsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentColumnNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // connectionStatusLabel
            // 
            this.connectionStatusLabel.AutoSize = true;
            this.connectionStatusLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.connectionStatusLabel.Location = new System.Drawing.Point(17, 14);
            this.connectionStatusLabel.Name = "connectionStatusLabel";
            this.connectionStatusLabel.Size = new System.Drawing.Size(186, 23);
            this.connectionStatusLabel.TabIndex = 0;
            this.connectionStatusLabel.Text = "connection status label";
            // 
            // isAppInForegroundLabel
            // 
            this.isAppInForegroundLabel.AutoSize = true;
            this.isAppInForegroundLabel.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.isAppInForegroundLabel.Location = new System.Drawing.Point(559, 18);
            this.isAppInForegroundLabel.Name = "isAppInForegroundLabel";
            this.isAppInForegroundLabel.Size = new System.Drawing.Size(0, 19);
            this.isAppInForegroundLabel.TabIndex = 1;
            // 
            // playPauseButton
            // 
            this.playPauseButton.BackColor = System.Drawing.Color.DimGray;
            this.playPauseButton.BackgroundImage = global::Automation.ResolumeCompositionSwitcher.WinForms.Properties.Resources.play_button_arrowhead1;
            this.playPauseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.playPauseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playPauseButton.Location = new System.Drawing.Point(708, 360);
            this.playPauseButton.Margin = new System.Windows.Forms.Padding(30);
            this.playPauseButton.Name = "playPauseButton";
            this.playPauseButton.Play = false;
            this.playPauseButton.Size = new System.Drawing.Size(57, 55);
            this.playPauseButton.TabIndex = 3;
            this.playPauseButton.UseVisualStyleBackColor = false;
            this.playPauseButton.Click += new System.EventHandler(this.playPauseButton_Click);
            // 
            // numberOfColumnsLabel
            // 
            this.numberOfColumnsLabel.AutoSize = true;
            this.numberOfColumnsLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
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
            this.maxTimeToChangeMsLabel.Location = new System.Drawing.Point(17, 203);
            this.maxTimeToChangeMsLabel.Margin = new System.Windows.Forms.Padding(10);
            this.maxTimeToChangeMsLabel.Name = "maxTimeToChangeMsLabel";
            this.maxTimeToChangeMsLabel.Size = new System.Drawing.Size(257, 28);
            this.maxTimeToChangeMsLabel.TabIndex = 6;
            this.maxTimeToChangeMsLabel.Text = "Max Time To Change [ms]";
            // 
            // numberOfColumnsNumeric
            // 
            this.numberOfColumnsNumeric.BackColor = System.Drawing.Color.DarkGray;
            this.numberOfColumnsNumeric.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.numberOfColumnsNumeric.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numberOfColumnsNumeric.Location = new System.Drawing.Point(320, 105);
            this.numberOfColumnsNumeric.Maximum = new decimal(new int[] {
            10000,
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
            this.minTimeToChangeMsNumeric.BackColor = System.Drawing.Color.DarkGray;
            this.minTimeToChangeMsNumeric.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.minTimeToChangeMsNumeric.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.minTimeToChangeMsNumeric.Location = new System.Drawing.Point(320, 153);
            this.minTimeToChangeMsNumeric.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.minTimeToChangeMsNumeric.Name = "minTimeToChangeMsNumeric";
            this.minTimeToChangeMsNumeric.Size = new System.Drawing.Size(97, 30);
            this.minTimeToChangeMsNumeric.TabIndex = 8;
            this.minTimeToChangeMsNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.minTimeToChangeMsNumeric.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.minTimeToChangeMsNumeric.ValueChanged += new System.EventHandler(this.minTimeToChangeMsNumeric_ValueChanged);
            // 
            // maxTimeToChangeMsNumeric
            // 
            this.maxTimeToChangeMsNumeric.BackColor = System.Drawing.Color.DarkGray;
            this.maxTimeToChangeMsNumeric.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.maxTimeToChangeMsNumeric.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.maxTimeToChangeMsNumeric.Location = new System.Drawing.Point(320, 201);
            this.maxTimeToChangeMsNumeric.Maximum = new decimal(new int[] {
            30000,
            0,
            0,
            0});
            this.maxTimeToChangeMsNumeric.Name = "maxTimeToChangeMsNumeric";
            this.maxTimeToChangeMsNumeric.Size = new System.Drawing.Size(97, 30);
            this.maxTimeToChangeMsNumeric.TabIndex = 9;
            this.maxTimeToChangeMsNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.maxTimeToChangeMsNumeric.Value = new decimal(new int[] {
            3000,
            0,
            0,
            0});
            this.maxTimeToChangeMsNumeric.ValueChanged += new System.EventHandler(this.maxTimeToChangeMsNumeric_ValueChanged);
            // 
            // currentColumnLabel
            // 
            this.currentColumnLabel.AutoSize = true;
            this.currentColumnLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.currentColumnLabel.Location = new System.Drawing.Point(17, 387);
            this.currentColumnLabel.Margin = new System.Windows.Forms.Padding(10);
            this.currentColumnLabel.Name = "currentColumnLabel";
            this.currentColumnLabel.Size = new System.Drawing.Size(161, 28);
            this.currentColumnLabel.TabIndex = 10;
            this.currentColumnLabel.Text = "Current Column";
            // 
            // currentColumnNumeric
            // 
            this.currentColumnNumeric.BackColor = System.Drawing.Color.DarkGray;
            this.currentColumnNumeric.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.currentColumnNumeric.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.currentColumnNumeric.Location = new System.Drawing.Point(232, 385);
            this.currentColumnNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.currentColumnNumeric.Name = "currentColumnNumeric";
            this.currentColumnNumeric.Size = new System.Drawing.Size(97, 30);
            this.currentColumnNumeric.TabIndex = 11;
            this.currentColumnNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.currentColumnNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.currentColumnNumeric.ValueChanged += new System.EventHandler(this.currentColumnNumeric_ValueChanged);
            // 
            // ResolumeCompositionSwitcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.currentColumnNumeric);
            this.Controls.Add(this.currentColumnLabel);
            this.Controls.Add(this.maxTimeToChangeMsNumeric);
            this.Controls.Add(this.minTimeToChangeMsNumeric);
            this.Controls.Add(this.numberOfColumnsNumeric);
            this.Controls.Add(this.maxTimeToChangeMsLabel);
            this.Controls.Add(this.minTimeToChangeMsLabel);
            this.Controls.Add(this.numberOfColumnsLabel);
            this.Controls.Add(this.playPauseButton);
            this.Controls.Add(this.isAppInForegroundLabel);
            this.Controls.Add(this.connectionStatusLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ResolumeCompositionSwitcher";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Resolume Composition Switicher";
            ((System.ComponentModel.ISupportInitialize)(this.numberOfColumnsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minTimeToChangeMsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxTimeToChangeMsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.currentColumnNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label connectionStatusLabel;
        private Label isAppInForegroundLabel;
        private PlayPauseButton playPauseButton;
        private Label numberOfColumnsLabel;
        private Label minTimeToChangeMsLabel;
        private Label maxTimeToChangeMsLabel;
        private NumericUpDown numberOfColumnsNumeric;
        private NumericUpDown minTimeToChangeMsNumeric;
        private NumericUpDown maxTimeToChangeMsNumeric;
        private Label currentColumnLabel;
        private NumericUpDown currentColumnNumeric;
    }
}