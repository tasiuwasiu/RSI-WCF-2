namespace Client
{
    partial class Form1
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.but_upload = new System.Windows.Forms.Button();
            this.but_download = new System.Windows.Forms.Button();
            this.but_refresh = new System.Windows.Forms.Button();
            this.but_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(271, 303);
            this.listBox1.TabIndex = 0;
            this.listBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.listbox1_MouseMove);
            // 
            // but_upload
            // 
            this.but_upload.Location = new System.Drawing.Point(12, 330);
            this.but_upload.Name = "but_upload";
            this.but_upload.Size = new System.Drawing.Size(119, 32);
            this.but_upload.TabIndex = 1;
            this.but_upload.Text = "Upload";
            this.but_upload.UseVisualStyleBackColor = true;
            this.but_upload.Click += new System.EventHandler(this.but_upload_Click);
            // 
            // but_download
            // 
            this.but_download.Location = new System.Drawing.Point(159, 330);
            this.but_download.Name = "but_download";
            this.but_download.Size = new System.Drawing.Size(124, 32);
            this.but_download.TabIndex = 2;
            this.but_download.Text = "Download";
            this.but_download.UseVisualStyleBackColor = true;
            this.but_download.Click += new System.EventHandler(this.but_download_Click);
            // 
            // but_refresh
            // 
            this.but_refresh.Location = new System.Drawing.Point(12, 380);
            this.but_refresh.Name = "but_refresh";
            this.but_refresh.Size = new System.Drawing.Size(119, 32);
            this.but_refresh.TabIndex = 3;
            this.but_refresh.Text = "Refresh";
            this.but_refresh.UseVisualStyleBackColor = true;
            this.but_refresh.Click += new System.EventHandler(this.but_refresh_Click);
            // 
            // but_exit
            // 
            this.but_exit.Location = new System.Drawing.Point(159, 380);
            this.but_exit.Name = "but_exit";
            this.but_exit.Size = new System.Drawing.Size(124, 32);
            this.but_exit.TabIndex = 4;
            this.but_exit.Text = "Exit";
            this.but_exit.UseVisualStyleBackColor = true;
            this.but_exit.Click += new System.EventHandler(this.but_exit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 434);
            this.Controls.Add(this.but_exit);
            this.Controls.Add(this.but_refresh);
            this.Controls.Add(this.but_download);
            this.Controls.Add(this.but_upload);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.Text = "Image Client";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button but_upload;
        private System.Windows.Forms.Button but_download;
        private System.Windows.Forms.Button but_refresh;
        private System.Windows.Forms.Button but_exit;
    }
}

