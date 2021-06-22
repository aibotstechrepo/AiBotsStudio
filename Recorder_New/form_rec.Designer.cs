namespace Recorder_New
{
    partial class form_rec
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
            this.playBackMacroButton = new System.Windows.Forms.Button();
            this.recordStopButton = new System.Windows.Forms.Button();
            this.recordStartButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // playBackMacroButton
            // 
            this.playBackMacroButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playBackMacroButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.playBackMacroButton.Location = new System.Drawing.Point(212, 16);
            this.playBackMacroButton.Name = "playBackMacroButton";
            this.playBackMacroButton.Size = new System.Drawing.Size(75, 65);
            this.playBackMacroButton.TabIndex = 4;
            this.playBackMacroButton.UseVisualStyleBackColor = true;
            this.playBackMacroButton.Click += new System.EventHandler(this.playBackMacroButton_Click);
            // 
            // recordStopButton
            // 
            this.recordStopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.recordStopButton.Location = new System.Drawing.Point(114, 16);
            this.recordStopButton.Name = "recordStopButton";
            this.recordStopButton.Size = new System.Drawing.Size(75, 65);
            this.recordStopButton.TabIndex = 2;
            this.recordStopButton.UseVisualStyleBackColor = true;
            this.recordStopButton.Click += new System.EventHandler(this.recordStopButton_Click);
            // 
            // recordStartButton
            // 
            this.recordStartButton.BackColor = System.Drawing.Color.Transparent;
            this.recordStartButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.recordStartButton.Location = new System.Drawing.Point(21, 16);
            this.recordStartButton.Name = "recordStartButton";
            this.recordStartButton.Size = new System.Drawing.Size(75, 65);
            this.recordStartButton.TabIndex = 3;
            this.recordStartButton.UseVisualStyleBackColor = false;
            this.recordStartButton.Click += new System.EventHandler(this.recordStartButton_Click);
            // 
            // form_rec
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(308, 97);
            this.Controls.Add(this.playBackMacroButton);
            this.Controls.Add(this.recordStopButton);
            this.Controls.Add(this.recordStartButton);
            this.Name = "form_rec";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button playBackMacroButton;
        private System.Windows.Forms.Button recordStopButton;
        private System.Windows.Forms.Button recordStartButton;
    }
}

