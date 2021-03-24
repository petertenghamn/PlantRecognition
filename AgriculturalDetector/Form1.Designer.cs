
namespace ObjDetectV01
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
            this.tb_prediction = new System.Windows.Forms.TextBox();
            this.label_prediction = new System.Windows.Forms.Label();
            this.label_accuracy = new System.Windows.Forms.Label();
            this.tb_accuracy = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.BackColor = System.Drawing.SystemColors.Control;
            this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picImage.Location = new System.Drawing.Point(18, 20);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(532, 417);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(38, 451);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnDetect
            // 
            this.btnDetect.Location = new System.Drawing.Point(119, 451);
            this.btnDetect.Name = "btnDetect";
            this.btnDetect.Size = new System.Drawing.Size(75, 23);
            this.btnDetect.TabIndex = 2;
            this.btnDetect.Text = "Detect";
            this.btnDetect.UseVisualStyleBackColor = true;
            this.btnDetect.Click += new System.EventHandler(this.btnDisplay_Click);
            // 
            // tb_prediction
            // 
            this.tb_prediction.Location = new System.Drawing.Point(267, 454);
            this.tb_prediction.Name = "tb_prediction";
            this.tb_prediction.Size = new System.Drawing.Size(100, 20);
            this.tb_prediction.TabIndex = 3;
            // 
            // label_prediction
            // 
            this.label_prediction.AutoSize = true;
            this.label_prediction.Location = new System.Drawing.Point(209, 457);
            this.label_prediction.Name = "label_prediction";
            this.label_prediction.Size = new System.Drawing.Size(57, 13);
            this.label_prediction.TabIndex = 4;
            this.label_prediction.Text = "Prediction:";
            // 
            // label_accuracy
            // 
            this.label_accuracy.AutoSize = true;
            this.label_accuracy.Location = new System.Drawing.Point(381, 456);
            this.label_accuracy.Name = "label_accuracy";
            this.label_accuracy.Size = new System.Drawing.Size(55, 13);
            this.label_accuracy.TabIndex = 6;
            this.label_accuracy.Text = "Accuracy:";
            // 
            // tb_accuracy
            // 
            this.tb_accuracy.Location = new System.Drawing.Point(436, 454);
            this.tb_accuracy.Name = "tb_accuracy";
            this.tb_accuracy.Size = new System.Drawing.Size(100, 20);
            this.tb_accuracy.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(571, 486);
            this.Controls.Add(this.label_accuracy);
            this.Controls.Add(this.tb_accuracy);
            this.Controls.Add(this.label_prediction);
            this.Controls.Add(this.tb_prediction);
            this.Controls.Add(this.btnDetect);
            this.Controls.Add(this.btnBrowse);
            this.Controls.Add(this.picImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnDetect;
        private System.Windows.Forms.TextBox tb_prediction;
        private System.Windows.Forms.Label label_prediction;
        private System.Windows.Forms.Label label_accuracy;
        private System.Windows.Forms.TextBox tb_accuracy;
    }
}

