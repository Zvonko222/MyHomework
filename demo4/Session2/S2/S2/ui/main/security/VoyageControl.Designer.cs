namespace S2.ui.main.security
{
    partial class VoyageControl
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
            this.lb_container_count_x = new System.Windows.Forms.Label();
            this.lb_date_of_arrival_xxxx_xx_xx = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Voyage Number";
            // 
            // lb_container_count_x
            // 
            this.lb_container_count_x.AutoSize = true;
            this.lb_container_count_x.Location = new System.Drawing.Point(24, 47);
            this.lb_container_count_x.Name = "lb_container_count_x";
            this.lb_container_count_x.Size = new System.Drawing.Size(151, 15);
            this.lb_container_count_x.TabIndex = 0;
            this.lb_container_count_x.Text = "Container Count:xx";
            // 
            // lb_date_of_arrival_xxxx_xx_xx
            // 
            this.lb_date_of_arrival_xxxx_xx_xx.AutoSize = true;
            this.lb_date_of_arrival_xxxx_xx_xx.Location = new System.Drawing.Point(24, 77);
            this.lb_date_of_arrival_xxxx_xx_xx.Name = "lb_date_of_arrival_xxxx_xx_xx";
            this.lb_date_of_arrival_xxxx_xx_xx.Size = new System.Drawing.Size(215, 15);
            this.lb_date_of_arrival_xxxx_xx_xx.TabIndex = 0;
            this.lb_date_of_arrival_xxxx_xx_xx.Text = "Date of arrival:xxxx-xx-xx";
            // 
            // VoyageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lb_date_of_arrival_xxxx_xx_xx);
            this.Controls.Add(this.lb_container_count_x);
            this.Controls.Add(this.label1);
            this.Name = "VoyageControl";
            this.Size = new System.Drawing.Size(275, 107);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lb_container_count_x;
        private System.Windows.Forms.Label lb_date_of_arrival_xxxx_xx_xx;
    }
}
