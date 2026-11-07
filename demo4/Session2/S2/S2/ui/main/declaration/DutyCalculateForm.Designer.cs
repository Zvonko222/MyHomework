namespace S2.ui
{
    partial class DutyCalculateForm
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
            this.lblQuantity = new System.Windows.Forms.Label();
            this.lb_hs_code = new System.Windows.Forms.Label();
            this.llb_select_hs_code = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbTrade = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.linkRecalc = new System.Windows.Forms.LinkLabel();
            this.lb_duty_payable_xxxx_xx = new System.Windows.Forms.Label();
            this.lblDuty = new System.Windows.Forms.Label();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lb_cargo_unit_xxx = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblQuantity
            // 
            this.lblQuantity.AutoSize = true;
            this.lblQuantity.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuantity.Location = new System.Drawing.Point(94, 49);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(71, 22);
            this.lblQuantity.TabIndex = 0;
            this.lblQuantity.Text = "Quantity:";
            // 
            // lb_hs_code
            // 
            this.lb_hs_code.AutoSize = true;
            this.lb_hs_code.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_hs_code.Location = new System.Drawing.Point(102, 82);
            this.lb_hs_code.Name = "lb_hs_code";
            this.lb_hs_code.Size = new System.Drawing.Size(72, 22);
            this.lb_hs_code.TabIndex = 1;
            this.lb_hs_code.Text = "HS Code:";
            // 
            // llb_select_hs_code
            // 
            this.llb_select_hs_code.AutoSize = true;
            this.llb_select_hs_code.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.llb_select_hs_code.Location = new System.Drawing.Point(312, 82);
            this.llb_select_hs_code.Name = "llb_select_hs_code";
            this.llb_select_hs_code.Size = new System.Drawing.Size(50, 22);
            this.llb_select_hs_code.TabIndex = 3;
            this.llb_select_hs_code.TabStop = true;
            this.llb_select_hs_code.Text = "Select";
            this.llb_select_hs_code.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkHs_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 22);
            this.label1.TabIndex = 4;
            this.label1.Text = "Country of Origin:";
            // 
            // cbCountry
            // 
            this.cbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCountry.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCountry.FormattingEnabled = true;
            this.cbCountry.Location = new System.Drawing.Point(179, 114);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(180, 30);
            this.cbCountry.TabIndex = 5;
            this.cbCountry.SelectedIndexChanged += new System.EventHandler(this.cbCountry_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(78, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "Trade Mode:";
            // 
            // cbTrade
            // 
            this.cbTrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTrade.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTrade.FormattingEnabled = true;
            this.cbTrade.Location = new System.Drawing.Point(179, 149);
            this.cbTrade.Name = "cbTrade";
            this.cbTrade.Size = new System.Drawing.Size(180, 30);
            this.cbTrade.TabIndex = 7;
            this.cbTrade.SelectedIndexChanged += new System.EventHandler(this.cbTrade_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(62, 187);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 22);
            this.label3.TabIndex = 8;
            this.label3.Text = "Cargo Amount:";
            // 
            // tbAmount
            // 
            this.tbAmount.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAmount.Location = new System.Drawing.Point(179, 187);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(180, 28);
            this.tbAmount.TabIndex = 9;
            this.tbAmount.TextChanged += new System.EventHandler(this.tbAmount_TextChanged);
            // 
            // linkRecalc
            // 
            this.linkRecalc.AutoSize = true;
            this.linkRecalc.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkRecalc.Location = new System.Drawing.Point(369, 190);
            this.linkRecalc.Name = "linkRecalc";
            this.linkRecalc.Size = new System.Drawing.Size(87, 22);
            this.linkRecalc.TabIndex = 10;
            this.linkRecalc.TabStop = true;
            this.linkRecalc.Text = "Recalculate";
            this.linkRecalc.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkRecalc_LinkClicked);
            // 
            // lb_duty_payable_xxxx_xx
            // 
            this.lb_duty_payable_xxxx_xx.AutoSize = true;
            this.lb_duty_payable_xxxx_xx.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_duty_payable_xxxx_xx.Location = new System.Drawing.Point(78, 222);
            this.lb_duty_payable_xxxx_xx.Name = "lb_duty_payable_xxxx_xx";
            this.lb_duty_payable_xxxx_xx.Size = new System.Drawing.Size(148, 22);
            this.lb_duty_payable_xxxx_xx.TabIndex = 11;
            this.lb_duty_payable_xxxx_xx.Text = "Duty Payable:xxxx.xx";
            // 
            // lblDuty
            // 
            this.lblDuty.AutoSize = true;
            this.lblDuty.Location = new System.Drawing.Point(122, 222);
            this.lblDuty.Name = "lblDuty";
            this.lblDuty.Size = new System.Drawing.Size(15, 15);
            this.lblDuty.TabIndex = 12;
            this.lblDuty.Text = "-";
            // 
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Lime;
            this.btnSubmit.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSubmit.Location = new System.Drawing.Point(158, 247);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(90, 32);
            this.btnSubmit.TabIndex = 13;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(254, 247);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 32);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lb_cargo_unit_xxx
            // 
            this.lb_cargo_unit_xxx.AutoSize = true;
            this.lb_cargo_unit_xxx.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_cargo_unit_xxx.Location = new System.Drawing.Point(78, 20);
            this.lb_cargo_unit_xxx.Name = "lb_cargo_unit_xxx";
            this.lb_cargo_unit_xxx.Size = new System.Drawing.Size(107, 22);
            this.lb_cargo_unit_xxx.TabIndex = 0;
            this.lb_cargo_unit_xxx.Text = "Cargo Unit:xxx";
            // 
            // DutyCalculateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 309);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.lblDuty);
            this.Controls.Add(this.lb_duty_payable_xxxx_xx);
            this.Controls.Add(this.linkRecalc);
            this.Controls.Add(this.tbAmount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbTrade);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbCountry);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.llb_select_hs_code);
            this.Controls.Add(this.lb_hs_code);
            this.Controls.Add(this.lb_cargo_unit_xxx);
            this.Controls.Add(this.lblQuantity);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DutyCalculateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Automatic duty calculation-Container Number";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblQuantity;
        private System.Windows.Forms.Label lb_hs_code;
        private System.Windows.Forms.LinkLabel llb_select_hs_code;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbCountry;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbTrade;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.LinkLabel linkRecalc;
        private System.Windows.Forms.Label lb_duty_payable_xxxx_xx;
        private System.Windows.Forms.Label lblDuty;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lb_cargo_unit_xxx;
    }
}
