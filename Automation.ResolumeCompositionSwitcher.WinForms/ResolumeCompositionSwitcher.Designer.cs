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
            // ResolumeCompositionSwitcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.playPauseButton);
            this.Controls.Add(this.isAppInForegroundLabel);
            this.Controls.Add(this.connectionStatusLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ResolumeCompositionSwitcher";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.Text = "Resolume Composition Switicher";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label connectionStatusLabel;
        private Label isAppInForegroundLabel;
        private PlayPauseButton playPauseButton;
    }
}