namespace S2.ui
{
    partial class DeclarationDetailForm
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
            this.lblVoyageNumber = new System.Windows.Forms.Label();
            this.lblContainerNumber = new System.Windows.Forms.Label();
            this.lblCountry = new System.Windows.Forms.Label();
            this.lblTradeMode = new System.Windows.Forms.Label();
            this.lblCargoAmount = new System.Windows.Forms.Label();
            this.lblDutyPayable = new System.Windows.Forms.Label();
            this.lblHsCode = new System.Windows.Forms.Label();
            this.lblDescTitle = new System.Windows.Forms.Label();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.btnAutoDuty = new System.Windows.Forms.Button();
            this.btnApprove = new System.Windows.Forms.Button();
            this.btnReject = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblVoyageNumber
            // 
            this.lblVoyageNumber.AutoSize = true;
            this.lblVoyageNumber.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVoyageNumber.Location = new System.Drawing.Point(30, 20);
            this.lblVoyageNumber.Name = "lblVoyageNumber";
            this.lblVoyageNumber.Size = new System.Drawing.Size(125, 22);
            this.lblVoyageNumber.TabIndex = 0;
            this.lblVoyageNumber.Text = "Voyage Number:";
            // 
            // lblContainerNumber
            // 
            this.lblContainerNumber.AutoSize = true;
            this.lblContainerNumber.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContainerNumber.Location = new System.Drawing.Point(290, 20);
            this.lblContainerNumber.Name = "lblContainerNumber";
            this.lblContainerNumber.Size = new System.Drawing.Size(142, 22);
            this.lblContainerNumber.TabIndex = 1;
            this.lblContainerNumber.Text = "Container Number:";
            // 
            // lblCountry
            // 
            this.lblCountry.AutoSize = true;
            this.lblCountry.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountry.Location = new System.Drawing.Point(30, 76);
            this.lblCountry.Name = "lblCountry";
            this.lblCountry.Size = new System.Drawing.Size(134, 22);
            this.lblCountry.TabIndex = 2;
            this.lblCountry.Text = "Country of Origin:";
            // 
            // lblTradeMode
            // 
            this.lblTradeMode.AutoSize = true;
            this.lblTradeMode.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTradeMode.Location = new System.Drawing.Point(290, 76);
            this.lblTradeMode.Name = "lblTradeMode";
            this.lblTradeMode.Size = new System.Drawing.Size(96, 22);
            this.lblTradeMode.TabIndex = 3;
            this.lblTradeMode.Text = "Trade Mode:";
            // 
            // lblCargoAmount
            // 
            this.lblCargoAmount.AutoSize = true;
            this.lblCargoAmount.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCargoAmount.Location = new System.Drawing.Point(30, 132);
            this.lblCargoAmount.Name = "lblCargoAmount";
            this.lblCargoAmount.Size = new System.Drawing.Size(113, 22);
            this.lblCargoAmount.TabIndex = 4;
            this.lblCargoAmount.Text = "Cargo Amount:";
            // 
            // lblDutyPayable
            // 
            this.lblDutyPayable.AutoSize = true;
            this.lblDutyPayable.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDutyPayable.Location = new System.Drawing.Point(293, 132);
            this.lblDutyPayable.Name = "lblDutyPayable";
            this.lblDutyPayable.Size = new System.Drawing.Size(105, 22);
            this.lblDutyPayable.TabIndex = 5;
            this.lblDutyPayable.Text = "Duty Payable:";
            // 
            // lblHsCode
            // 
            this.lblHsCode.AutoSize = true;
            this.lblHsCode.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHsCode.Location = new System.Drawing.Point(30, 188);
            this.lblHsCode.Name = "lblHsCode";
            this.lblHsCode.Size = new System.Drawing.Size(72, 22);
            this.lblHsCode.TabIndex = 6;
            this.lblHsCode.Text = "HS Code:";
            // 
            // lblDescTitle
            // 
            this.lblDescTitle.AutoSize = true;
            this.lblDescTitle.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescTitle.Location = new System.Drawing.Point(30, 248);
            this.lblDescTitle.Name = "lblDescTitle";
            this.lblDescTitle.Size = new System.Drawing.Size(93, 22);
            this.lblDescTitle.TabIndex = 8;
            this.lblDescTitle.Text = "Description:";
            // 
            // tbDesc
            // 
            this.tbDesc.Location = new System.Drawing.Point(158, 248);
            this.tbDesc.Multiline = true;
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.ReadOnly = true;
            this.tbDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDesc.Size = new System.Drawing.Size(580, 210);
            this.tbDesc.TabIndex = 9;
            // 
            // btnAutoDuty
            // 
            this.btnAutoDuty.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAutoDuty.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAutoDuty.Location = new System.Drawing.Point(351, 476);
            this.btnAutoDuty.Name = "btnAutoDuty";
            this.btnAutoDuty.Size = new System.Drawing.Size(195, 32);
            this.btnAutoDuty.TabIndex = 11;
            this.btnAutoDuty.Text = "Auto Duty Calculate";
            this.btnAutoDuty.UseVisualStyleBackColor = false;
            this.btnAutoDuty.Visible = false;
            this.btnAutoDuty.Click += new System.EventHandler(this.btnAutoDuty_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.BackColor = System.Drawing.Color.Lime;
            this.btnApprove.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApprove.Location = new System.Drawing.Point(552, 476);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(90, 32);
            this.btnApprove.TabIndex = 12;
            this.btnApprove.Text = "Approve";
            this.btnApprove.UseVisualStyleBackColor = false;
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // btnReject
            // 
            this.btnReject.BackColor = System.Drawing.Color.Red;
            this.btnReject.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReject.Location = new System.Drawing.Point(648, 476);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(90, 32);
            this.btnReject.TabIndex = 13;
            this.btnReject.Text = "Reject";
            this.btnReject.UseVisualStyleBackColor = false;
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // DeclarationDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 520);
            this.Controls.Add(this.btnReject);
            this.Controls.Add(this.btnApprove);
            this.Controls.Add(this.btnAutoDuty);
            this.Controls.Add(this.tbDesc);
            this.Controls.Add(this.lblDescTitle);
            this.Controls.Add(this.lblHsCode);
            this.Controls.Add(this.lblDutyPayable);
            this.Controls.Add(this.lblCargoAmount);
            this.Controls.Add(this.lblTradeMode);
            this.Controls.Add(this.lblCountry);
            this.Controls.Add(this.lblContainerNumber);
            this.Controls.Add(this.lblVoyageNumber);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DeclarationDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Declaration Detail";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Label lblVoyageNumber;
        private System.Windows.Forms.Label lblContainerNumber;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.Label lblTradeMode;
        private System.Windows.Forms.Label lblCargoAmount;
        private System.Windows.Forms.Label lblDutyPayable;
        private System.Windows.Forms.Label lblHsCode;
        private System.Windows.Forms.Label lblDescTitle;
        private System.Windows.Forms.TextBox tbDesc;
        private System.Windows.Forms.Button btnAutoDuty;
        private System.Windows.Forms.Button btnApprove;
        private System.Windows.Forms.Button btnReject;
    }
}
