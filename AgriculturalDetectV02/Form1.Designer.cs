
namespace ObjDetectV02
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
            this.picImage = new System.Windows.Forms.PictureBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnDetect = new System.Windows.Forms.Button();
            this.output_box = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.BackColor = System.Drawing.SystemColors.Control;
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picImage.Location = new System.Drawing.Point(22, 23);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(812, 521);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(888, 23);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnDetect
            // 
            this.btnDetect.Location = new System.Drawing.Point(888, 52);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.Size = new System.Drawing.Size(75, 23);
            this.btnDetect.TabIndex = 2;
            this.btnDetect.Text = "Detect";
            this.btnDetect.UseVisualStyleBackColor = true;
            this.btnDetect.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // output_box
            // 
            this.output_box.FormattingEnabled = true;
            this.output_box.Location = new System.Drawing.Point(851, 98);
            this.output_box.Name = "output_box";
            this.output_box.Size = new System.Drawing.Size(152, 160);
            this.output_box.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(1015, 568);
            this.Controls.Add(this.output_box);
            this.Controls.Add(this.btnDetect);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.picImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnDetect;
        private System.Windows.Forms.ListBox output_box;
    }
}

