
namespace ObjDetectV03
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
            this.title = new System.Windows.Forms.Label();
            this.cb_method_select = new System.Windows.Forms.ComboBox();
            this.cb_automated = new System.Windows.Forms.CheckBox();
            this.btn_run = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Location = new System.Drawing.Point(104, 25);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(149, 13);
            this.title.TabIndex = 0;
            this.title.Text = "Object Detection Run Options";
            // 
            // cb_method_select
            // 
            this.cb_method_select.FormattingEnabled = true;
            this.cb_method_select.Items.AddRange(new object[] {
            "Control Test (colored - colored)",
            "Grey Test (colored - grey)",
            "Grey Trained Only (grey - colored)",
            "Grey Trained Test (grey - grey)"});
            this.cb_method_select.Location = new System.Drawing.Point(42, 55);
            this.cb_method_select.Name = "cb_method_select";
            this.cb_method_select.Size = new System.Drawing.Size(268, 21);
            this.cb_method_select.TabIndex = 1;
            this.cb_method_select.SelectedIndexChanged += new System.EventHandler(this.cb_method_select_SelectedIndexChanged);
            // 
            // cb_automated
            // 
            this.cb_automated.AutoSize = true;
            this.cb_automated.Location = new System.Drawing.Point(121, 100);
            this.cb_automated.Name = "cb_automated";
            this.cb_automated.Size = new System.Drawing.Size(101, 17);
            this.cb_automated.TabIndex = 2;
            this.cb_automated.Text = "Automated Test";
            this.cb_automated.UseVisualStyleBackColor = true;
            this.cb_automated.CheckedChanged += new System.EventHandler(this.cb_automated_CheckedChanged);
            // 
            // btn_run
            // 
            this.btn_run.Location = new System.Drawing.Point(132, 136);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(75, 23);
            this.btn_run.TabIndex = 3;
            this.btn_run.Text = "Run";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.cb_automated);
            this.Controls.Add(this.cb_method_select);
            this.Controls.Add(this.title);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label title;
        private System.Windows.Forms.ComboBox cb_method_select;
        private System.Windows.Forms.CheckBox cb_automated;
        private System.Windows.Forms.Button btn_run;
    }
}

