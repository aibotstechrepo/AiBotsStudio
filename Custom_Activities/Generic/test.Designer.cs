namespace GlobalMacroRecorder
{
    partial class test
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
            this.BtnPlayBack = new System.Windows.Forms.Button();
            this.BtnStop = new System.Windows.Forms.Button();
            this.BtnStart = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnPlayBack
            // 
            this.BtnPlayBack.BackgroundImage = global::GlobalMacroRecorder.Properties.Resources.REPLAY;
            this.BtnPlayBack.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnPlayBack.Location = new System.Drawing.Point(263, 12);
            this.BtnPlayBack.Name = "BtnPlayBack";
            this.BtnPlayBack.Size = new System.Drawing.Size(98, 84);
            this.BtnPlayBack.TabIndex = 2;
            this.BtnPlayBack.UseVisualStyleBackColor = true;
            // 
            // BtnStop
            // 
            this.BtnStop.BackgroundImage = global::GlobalMacroRecorder.Properties.Resources.STOP;
            this.BtnStop.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnStop.Location = new System.Drawing.Point(135, 12);
            this.BtnStop.Name = "BtnStop";
            this.BtnStop.Size = new System.Drawing.Size(99, 84);
            this.BtnStop.TabIndex = 1;
            this.BtnStop.UseVisualStyleBackColor = true;
            // 
            // BtnStart
            // 
            this.BtnStart.BackgroundImage = global::GlobalMacroRecorder.Properties.Resources.PLAY;
            this.BtnStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BtnStart.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.BtnStart.FlatAppearance.BorderSize = 2;
            this.BtnStart.Location = new System.Drawing.Point(12, 12);
            this.BtnStart.Name = "BtnStart";
            this.BtnStart.Size = new System.Drawing.Size(99, 84);
            this.BtnStart.TabIndex = 0;
            this.BtnStart.UseVisualStyleBackColor = true;
            // 
            // test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(380, 105);
            this.Controls.Add(this.BtnPlayBack);
            this.Controls.Add(this.BtnStop);
            this.Controls.Add(this.BtnStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "test";
            this.Text = "Phoenix Recorder";
            this.Load += new System.EventHandler(this.test_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnStart;
        private System.Windows.Forms.Button BtnStop;
        private System.Windows.Forms.Button BtnPlayBack;
    }
}