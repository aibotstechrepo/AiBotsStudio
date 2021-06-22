namespace Generic_Record
{
    partial class Record
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Record));
            this.recordStartButton = new System.Windows.Forms.Button();
            this.recordStopButton = new System.Windows.Forms.Button();
            this.playBackMacroButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // recordStartButton
            // 
            this.recordStartButton.BackColor = System.Drawing.Color.Transparent;
            this.recordStartButton.BackgroundImage = global::GlobalMacroRecorder.Properties.Resources.PLAY;
            this.recordStartButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.recordStartButton.Location = new System.Drawing.Point(27, 23);
            this.recordStartButton.Name = "recordStartButton";
            this.recordStartButton.Size = new System.Drawing.Size(75, 65);
            this.recordStartButton.TabIndex = 0;
            this.recordStartButton.UseVisualStyleBackColor = false;
            this.recordStartButton.Click += new System.EventHandler(this.recordStartButton_Click);
            // 
            // recordStopButton
            // 
            this.recordStopButton.BackgroundImage = global::GlobalMacroRecorder.Properties.Resources.STOP;
            this.recordStopButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.recordStopButton.Location = new System.Drawing.Point(120, 23);
            this.recordStopButton.Name = "recordStopButton";
            this.recordStopButton.Size = new System.Drawing.Size(75, 65);
            this.recordStopButton.TabIndex = 0;
            this.recordStopButton.UseVisualStyleBackColor = true;
            this.recordStopButton.Click += new System.EventHandler(this.recordStopButton_Click);
            // 
            // playBackMacroButton
            // 
            this.playBackMacroButton.BackgroundImage = global::GlobalMacroRecorder.Properties.Resources.REPLAY;
            this.playBackMacroButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.playBackMacroButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.playBackMacroButton.Location = new System.Drawing.Point(218, 23);
            this.playBackMacroButton.Name = "playBackMacroButton";
            this.playBackMacroButton.Size = new System.Drawing.Size(75, 65);
            this.playBackMacroButton.TabIndex = 1;
            this.playBackMacroButton.UseVisualStyleBackColor = true;
            this.playBackMacroButton.Click += new System.EventHandler(this.playBackMacroButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 2;
            // 
            // Record
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::GlobalMacroRecorder.Properties.Resources._459754;
            this.ClientSize = new System.Drawing.Size(317, 110);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.playBackMacroButton);
            this.Controls.Add(this.recordStopButton);
            this.Controls.Add(this.recordStartButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Record";
            this.Text = "Phoenix Recorder";
            this.Load += new System.EventHandler(this.MacroForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button recordStartButton;
        private System.Windows.Forms.Button recordStopButton;
        private System.Windows.Forms.Button playBackMacroButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

