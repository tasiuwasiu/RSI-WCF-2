namespace Client
{
    partial class DescriptionInputForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.tb_description = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lab_imageName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(225, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Enter the description of image:";
            // 
            // tb_description
            // 
            this.tb_description.Location = new System.Drawing.Point(12, 83);
            this.tb_description.Name = "tb_description";
            this.tb_description.Size = new System.Drawing.Size(387, 20);
            this.tb_description.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(158, 123);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Send";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lab_imageName
            // 
            this.lab_imageName.AutoSize = true;
            this.lab_imageName.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lab_imageName.Location = new System.Drawing.Point(13, 42);
            this.lab_imageName.Name = "lab_imageName";
            this.lab_imageName.Size = new System.Drawing.Size(101, 17);
            this.lab_imageName.TabIndex = 3;
            this.lab_imageName.Text = "<image name>";
            // 
            // DescriptionInputForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 167);
            this.Controls.Add(this.lab_imageName);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_description);
            this.Controls.Add(this.label1);
            this.Name = "DescriptionInputForm";
            this.Text = "Description";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_description;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lab_imageName;
    }
}