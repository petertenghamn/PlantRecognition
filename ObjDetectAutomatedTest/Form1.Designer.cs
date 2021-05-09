
namespace ObjDetectAutomatedTest
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
            this.lb_current_output = new System.Windows.Forms.ListBox();
            this.label_title = new System.Windows.Forms.Label();
            this.label_final = new System.Windows.Forms.Label();
            this.lb_final_output = new System.Windows.Forms.ListBox();
            this.label_accuracy = new System.Windows.Forms.Label();
            this.label_confidence = new System.Windows.Forms.Label();
            this.tb_confidence = new System.Windows.Forms.TextBox();
            this.tb_accuracy = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).BeginInit();
            this.SuspendLayout();
            // 
            // picImage
            // 
            this.picImage.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.picImage.Location = new System.Drawing.Point(12, 12);
            this.picImage.Name = "picImage";
            this.picImage.Size = new System.Drawing.Size(416, 416);
            this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImage.TabIndex = 0;
            this.picImage.TabStop = false;
            // 
            // lb_current_output
            // 
            this.lb_current_output.FormattingEnabled = true;
            this.lb_current_output.Location = new System.Drawing.Point(444, 33);
            this.lb_current_output.Name = "lb_current_output";
            this.lb_current_output.Size = new System.Drawing.Size(425, 147);
            this.lb_current_output.TabIndex = 1;
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Location = new System.Drawing.Point(589, 12);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(137, 13);
            this.label_title.TabIndex = 2;
            this.label_title.Text = "Automated Tensorflow Test";
            // 
            // label_final
            // 
            this.label_final.AutoSize = true;
            this.label_final.Location = new System.Drawing.Point(626, 259);
            this.label_final.Name = "label_final";
            this.label_final.Size = new System.Drawing.Size(62, 13);
            this.label_final.TabIndex = 3;
            this.label_final.Text = "Final results";
            // 
            // lb_final_output
            // 
            this.lb_final_output.FormattingEnabled = true;
            this.lb_final_output.Location = new System.Drawing.Point(444, 281);
            this.lb_final_output.Name = "lb_final_output";
            this.lb_final_output.Size = new System.Drawing.Size(425, 147);
            this.lb_final_output.TabIndex = 4;
            // 
            // label_accuracy
            // 
            this.label_accuracy.AutoSize = true;
            this.label_accuracy.Location = new System.Drawing.Point(450, 195);
            this.label_accuracy.Name = "label_accuracy";
            this.label_accuracy.Size = new System.Drawing.Size(98, 13);
            this.label_accuracy.TabIndex = 5;
            this.label_accuracy.Text = "Average Accuracy:";
            // 
            // label_confidence
            // 
            this.label_confidence.AutoSize = true;
            this.label_confidence.Location = new System.Drawing.Point(447, 228);
            this.label_confidence.Name = "label_confidence";
            this.label_confidence.Size = new System.Drawing.Size(101, 13);
            this.label_confidence.TabIndex = 6;
            this.label_confidence.Text = "Current Confidence:";
            // 
            // tb_confidence
            // 
            this.tb_confidence.Location = new System.Drawing.Point(551, 225);
            this.tb_confidence.Name = "tb_confidence";
            this.tb_confidence.Size = new System.Drawing.Size(318, 20);
            this.tb_confidence.TabIndex = 7;
            // 
            // tb_accuracy
            // 
            this.tb_accuracy.Location = new System.Drawing.Point(551, 192);
            this.tb_accuracy.Name = "tb_accuracy";
            this.tb_accuracy.Size = new System.Drawing.Size(318, 20);
            this.tb_accuracy.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 438);
            this.Controls.Add(this.tb_accuracy);
            this.Controls.Add(this.tb_confidence);
            this.Controls.Add(this.label_confidence);
            this.Controls.Add(this.label_accuracy);
            this.Controls.Add(this.lb_final_output);
            this.Controls.Add(this.label_final);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.lb_current_output);
            this.Controls.Add(this.picImage);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.picImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picImage;
        private System.Windows.Forms.ListBox lb_current_output;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_final;
        private System.Windows.Forms.ListBox lb_final_output;
        private System.Windows.Forms.Label label_accuracy;
        private System.Windows.Forms.Label label_confidence;
        private System.Windows.Forms.TextBox tb_confidence;
        private System.Windows.Forms.TextBox tb_accuracy;
    }
}

