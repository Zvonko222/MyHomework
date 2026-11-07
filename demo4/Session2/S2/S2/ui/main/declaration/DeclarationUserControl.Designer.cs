namespace S2.ui.main.control
{
    partial class DeclarationUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_status = new System.Windows.Forms.Button();
            this.btn_view_reason = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(191, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Conatiner Number: XXXXX";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Country of Origin: XXXXX";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 96);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(159, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Duty Payable: XXXXX";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(151, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Cargo Owner: XXXXX";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(262, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Trade Mode: XXXXX";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(262, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Declared Time: XXXXX";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(472, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(119, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "HS Code: XXXXX";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(472, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Cargo Amount: XXXXX";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(472, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(175, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Declaration Id: XXXXX";
            // 
            // btn_status
            // 
            this.btn_status.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btn_status.Location = new System.Drawing.Point(684, 3);
            this.btn_status.Name = "btn_status";
            this.btn_status.Size = new System.Drawing.Size(75, 23);
            this.btn_status.TabIndex = 1;
            this.btn_status.Text = "Pending";
            this.btn_status.UseVisualStyleBackColor = false;
            // 
            // btn_view_reason
            // 
            this.btn_view_reason.Location = new System.Drawing.Point(621, 114);
            this.btn_view_reason.Name = "btn_view_reason";
            this.btn_view_reason.Size = new System.Drawing.Size(127, 33);
            this.btn_view_reason.TabIndex = 1;
            this.btn_view_reason.Text = "View Reason";
            this.btn_view_reason.UseVisualStyleBackColor = true;
            this.btn_view_reason.Click += new System.EventHandler(this.btn_view_reason_Click);
            // 
            // DeclarationUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.btn_view_reason);
            this.Controls.Add(this.btn_status);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "DeclarationUserControl";
            this.Size = new System.Drawing.Size(760, 148);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_status;
        private System.Windows.Forms.Button btn_view_reason;
    }
}
