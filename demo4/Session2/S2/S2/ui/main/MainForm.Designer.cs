namespace S2.ui
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed</param>
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tc_declaration = new S2.controls.DeclarationControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tc_security_check = new S2.controls.SecurityCheckControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tc_exception = new S2.controls.ExceptionControl();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl.Location = new System.Drawing.Point(12, 18);
            this.tabControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1298, 1035);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tc_declaration);
            this.tabPage1.Location = new System.Drawing.Point(4, 31);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(1290, 1000);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Declaration Management";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tc_declaration
            // 
            this.tc_declaration.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_declaration.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tc_declaration.Location = new System.Drawing.Point(3, 4);
            this.tc_declaration.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tc_declaration.Name = "tc_declaration";
            this.tc_declaration.Size = new System.Drawing.Size(1284, 992);
            this.tc_declaration.TabIndex = 0;
            this.tc_declaration.Load += new System.EventHandler(this.declarationControl1_Load);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tc_security_check);
            this.tabPage2.Location = new System.Drawing.Point(4, 31);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(1290, 998);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Security Check Management";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tc_security_check
            // 
            this.tc_security_check.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_security_check.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tc_security_check.Location = new System.Drawing.Point(3, 4);
            this.tc_security_check.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tc_security_check.Name = "tc_security_check";
            this.tc_security_check.Size = new System.Drawing.Size(1284, 990);
            this.tc_security_check.TabIndex = 0;
            this.tc_security_check.Load += new System.EventHandler(this.securityCheckControl1_Load);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tc_exception);
            this.tabPage3.Location = new System.Drawing.Point(4, 31);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage3.Size = new System.Drawing.Size(1290, 998);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Exception Management";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tc_exception
            // 
            this.tc_exception.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_exception.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tc_exception.Location = new System.Drawing.Point(3, 4);
            this.tc_exception.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tc_exception.Name = "tc_exception";
            this.tc_exception.Size = new System.Drawing.Size(1284, 990);
            this.tc_exception.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1321, 869);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XM Port Customs-Main Page(Firstname Lastname-Role)";
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private S2.controls.DeclarationControl tc_declaration;
        private S2.controls.SecurityCheckControl tc_security_check;
        private S2.controls.ExceptionControl tc_exception;
    }
}
