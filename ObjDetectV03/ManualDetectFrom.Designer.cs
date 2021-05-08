
namespace ObjDetectV03
{
    partial class ManualDetectFrom
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
            this.output_box = new System.Windows.Forms.ListBox();
            this.btn_detect = new System.Windows.Forms.Button();
            this.btn_browse = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.BackColor = System.Drawing.SystemColors.ControlDark;
            this.picImage.Location = new System.Drawing.Point(12, 12);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(472, 426);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            // 
            // output_box
            // 
            this.output_box.FormattingEnabled = true;
            this.output_box.Location = new System.Drawing.Point(501, 12);
            this.output_box.Name = "output_box";
            this.output_box.Size = new System.Drawing.Size(206, 342);
            this.output_box.TabIndex = 1;
            // 
            // btn_detect
            // 
            this.btn_detect.Location = new System.Drawing.Point(567, 404);
            this.btn_detect.Name = "btn_detect";
            this.btn_detect.Size = new System.Drawing.Size(75, 23);
            this.btn_detect.TabIndex = 2;
            this.btn_detect.Text = "Detect";
            this.btn_detect.UseVisualStyleBackColor = true;
            this.btn_detect.Click += new System.EventHandler(this.btn_detect_Click);
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(567, 375);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(75, 23);
            this.btn_browse.TabIndex = 3;
            this.btn_browse.Text = "Browse";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // ManualDetectFrom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 450);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.btn_detect);
            this.Controls.Add(this.output_box);
            this.Controls.Add(this.picImage);
            this.Name = "ManualDetectFrom";
            this.Text = "ManualDetectFrom";
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.ListBox output_box;
        private System.Windows.Forms.Button btn_detect;
        private System.Windows.Forms.Button btn_browse;
    }
}