namespace BatchImageWebOptimize
{
    partial class MainDialog
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
            this.label2 = new System.Windows.Forms.Label();
            this.sourceImageTextBox = new System.Windows.Forms.TextBox();
            this.sourceImageBrowseButton = new System.Windows.Forms.Button();
            this.outputImageBrowseButton = new System.Windows.Forms.Button();
            this.outputImageTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.qualityTrackBar = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            this.optimzeButton = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.qualityLabel = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressLabel = new System.Windows.Forms.Label();
            this.cancelButton = new System.Windows.Forms.Button();
            this.sourceFileTypesTextBox = new System.Windows.Forms.TextBox();
            this.sourceFileTypesLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.qualityTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Source Image Path:";
            // 
            // sourceImageTextBox
            // 
            this.sourceImageTextBox.Location = new System.Drawing.Point(116, 12);
            this.sourceImageTextBox.Name = "sourceImageTextBox";
            this.sourceImageTextBox.Size = new System.Drawing.Size(567, 20);
            this.sourceImageTextBox.TabIndex = 4;
            // 
            // sourceImageBrowseButton
            // 
            this.sourceImageBrowseButton.Location = new System.Drawing.Point(689, 9);
            this.sourceImageBrowseButton.Name = "sourceImageBrowseButton";
            this.sourceImageBrowseButton.Size = new System.Drawing.Size(84, 23);
            this.sourceImageBrowseButton.TabIndex = 5;
            this.sourceImageBrowseButton.Text = "Browse";
            this.sourceImageBrowseButton.UseVisualStyleBackColor = true;
            this.sourceImageBrowseButton.Click += new System.EventHandler(this.sourceImageBrowseButton_Click);
            // 
            // outputImageBrowseButton
            // 
            this.outputImageBrowseButton.Location = new System.Drawing.Point(689, 60);
            this.outputImageBrowseButton.Name = "outputImageBrowseButton";
            this.outputImageBrowseButton.Size = new System.Drawing.Size(84, 23);
            this.outputImageBrowseButton.TabIndex = 8;
            this.outputImageBrowseButton.Text = "Browse";
            this.outputImageBrowseButton.UseVisualStyleBackColor = true;
            this.outputImageBrowseButton.Click += new System.EventHandler(this.outputImageBrowseButton_Click);
            // 
            // outputImageTextBox
            // 
            this.outputImageTextBox.Location = new System.Drawing.Point(116, 63);
            this.outputImageTextBox.Name = "outputImageTextBox";
            this.outputImageTextBox.Size = new System.Drawing.Size(567, 20);
            this.outputImageTextBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(11, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Output Image Path:";
            // 
            // qualityTrackBar
            // 
            this.qualityTrackBar.Location = new System.Drawing.Point(116, 89);
            this.qualityTrackBar.Maximum = 100;
            this.qualityTrackBar.Minimum = 10;
            this.qualityTrackBar.Name = "qualityTrackBar";
            this.qualityTrackBar.Size = new System.Drawing.Size(567, 45);
            this.qualityTrackBar.TabIndex = 9;
            this.qualityTrackBar.TickFrequency = 5;
            this.qualityTrackBar.TickStyle = System.Windows.Forms.TickStyle.TopLeft;
            this.qualityTrackBar.Value = 75;
            this.qualityTrackBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(70, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Quality:";
            // 
            // optimzeButton
            // 
            this.optimzeButton.Location = new System.Drawing.Point(10, 127);
            this.optimzeButton.Name = "optimzeButton";
            this.optimzeButton.Size = new System.Drawing.Size(664, 102);
            this.optimzeButton.TabIndex = 11;
            this.optimzeButton.Text = "OPTIMIZE";
            this.optimzeButton.UseVisualStyleBackColor = true;
            this.optimzeButton.Click += new System.EventHandler(this.optimzeButton_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(11, 236);
            this.progressBar1.Maximum = 1000;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(663, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 12;
            // 
            // qualityLabel
            // 
            this.qualityLabel.AutoSize = true;
            this.qualityLabel.Location = new System.Drawing.Point(690, 98);
            this.qualityLabel.Name = "qualityLabel";
            this.qualityLabel.Size = new System.Drawing.Size(0, 13);
            this.qualityLabel.TabIndex = 13;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.WorkerSupportsCancellation = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressLabel
            // 
            this.progressLabel.BackColor = System.Drawing.SystemColors.Control;
            this.progressLabel.Location = new System.Drawing.Point(680, 236);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(96, 23);
            this.progressLabel.TabIndex = 14;
            this.progressLabel.Text = "0 / 0";
            this.progressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cancelButton
            // 
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(680, 127);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(93, 102);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // sourceFileTypesTextBox
            // 
            this.sourceFileTypesTextBox.Location = new System.Drawing.Point(116, 37);
            this.sourceFileTypesTextBox.Name = "sourceFileTypesTextBox";
            this.sourceFileTypesTextBox.Size = new System.Drawing.Size(567, 20);
            this.sourceFileTypesTextBox.TabIndex = 17;
            // 
            // sourceFileTypesLabel
            // 
            this.sourceFileTypesLabel.AutoSize = true;
            this.sourceFileTypesLabel.Location = new System.Drawing.Point(11, 40);
            this.sourceFileTypesLabel.Name = "sourceFileTypesLabel";
            this.sourceFileTypesLabel.Size = new System.Drawing.Size(95, 13);
            this.sourceFileTypesLabel.TabIndex = 16;
            this.sourceFileTypesLabel.Text = "Source File Types:";
            // 
            // MainDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 271);
            this.Controls.Add(this.sourceFileTypesTextBox);
            this.Controls.Add(this.sourceFileTypesLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.progressLabel);
            this.Controls.Add(this.qualityLabel);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.optimzeButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.qualityTrackBar);
            this.Controls.Add(this.outputImageBrowseButton);
            this.Controls.Add(this.outputImageTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.sourceImageBrowseButton);
            this.Controls.Add(this.sourceImageTextBox);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainDialog";
            this.Text = "Batch Image Web Optimizer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainDialog_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.qualityTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox sourceImageTextBox;
        private System.Windows.Forms.Button sourceImageBrowseButton;
        private System.Windows.Forms.Button outputImageBrowseButton;
        private System.Windows.Forms.TextBox outputImageTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar qualityTrackBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button optimzeButton;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label qualityLabel;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label progressLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox sourceFileTypesTextBox;
        private System.Windows.Forms.Label sourceFileTypesLabel;
    }
}

