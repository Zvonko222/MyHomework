namespace S2.ui
{
    partial class ReportExceptionForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lb_voyage_number_xxx = new System.Windows.Forms.Label();
            this.lb_container_number_xxx = new System.Windows.Forms.Label();
            this.lb_cargo_onwer_xxx = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_exception_type = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbDetail = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lb_voyage_number_xxx
            // 
            this.lb_voyage_number_xxx.AutoSize = true;
            this.lb_voyage_number_xxx.Location = new System.Drawing.Point(44, 13);
            this.lb_voyage_number_xxx.Name = "lb_voyage_number_xxx";
            this.lb_voyage_number_xxx.Size = new System.Drawing.Size(123, 22);
            this.lb_voyage_number_xxx.TabIndex = 0;
            this.lb_voyage_number_xxx.Text = "Voyage Number:";
            // 
            // lb_container_number_xxx
            // 
            this.lb_container_number_xxx.AutoSize = true;
            this.lb_container_number_xxx.Location = new System.Drawing.Point(20, 59);
            this.lb_container_number_xxx.Name = "lb_container_number_xxx";
            this.lb_container_number_xxx.Size = new System.Drawing.Size(140, 22);
            this.lb_container_number_xxx.TabIndex = 1;
            this.lb_container_number_xxx.Text = "Container Number:";
            // 
            // lb_cargo_onwer_xxx
            // 
            this.lb_cargo_onwer_xxx.AutoSize = true;
            this.lb_cargo_onwer_xxx.Location = new System.Drawing.Point(20, 95);
            this.lb_cargo_onwer_xxx.Name = "lb_cargo_onwer_xxx";
            this.lb_cargo_onwer_xxx.Size = new System.Drawing.Size(103, 22);
            this.lb_cargo_onwer_xxx.TabIndex = 2;
            this.lb_cargo_onwer_xxx.Text = "Cargo Owner:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "Exception Type:";
            // 
            // cb_exception_type
            // 
            this.cb_exception_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_exception_type.FormattingEnabled = true;
            this.cb_exception_type.Location = new System.Drawing.Point(167, 135);
            this.cb_exception_type.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cb_exception_type.Name = "cb_exception_type";
            this.cb_exception_type.Size = new System.Drawing.Size(260, 30);
            this.cb_exception_type.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 22);
            this.label2.TabIndex = 5;
            this.label2.Text = "Exception Detail:";
            // 
            // tbDetail
            // 
            this.tbDetail.Location = new System.Drawing.Point(169, 191);
            this.tbDetail.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbDetail.Multiline = true;
            this.tbDetail.Name = "tbDetail";
            this.tbDetail.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDetail.Size = new System.Drawing.Size(390, 177);
            this.tbDetail.TabIndex = 6;
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Lime;
            this.btnSubmit.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.Location = new System.Drawing.Point(167, 392);
            this.btnSubmit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(80, 44);
            this.btnSubmit.TabIndex = 7;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(253, 392);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 44);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ReportExceptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(572, 453);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.tbDetail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_exception_type);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lb_cargo_onwer_xxx);
            this.Controls.Add(this.lb_container_number_xxx);
            this.Controls.Add(this.lb_voyage_number_xxx);
            this.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportExceptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Exception";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lb_voyage_number_xxx;
        private System.Windows.Forms.Label lb_container_number_xxx;
        private System.Windows.Forms.Label lb_cargo_onwer_xxx;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_exception_type;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDetail;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
    }
}
