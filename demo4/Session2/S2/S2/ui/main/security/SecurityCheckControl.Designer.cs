namespace S2.controls
{
    public partial class SecurityCheckControl
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dtp_from = new System.Windows.Forms.DateTimePicker();
            this.lbl_to = new System.Windows.Forms.Label();
            this.dtp_to = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_start = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_security_check_status = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cb_hs_code = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cb_cargo_owner_rating = new System.Windows.Forms.ComboBox();
            this.btn_batch_unseal = new System.Windows.Forms.Button();
            this.btn_batch_release = new System.Windows.Forms.Button();
            this.btn_from = new System.Windows.Forms.Button();
            this.btn_to = new System.Windows.Forms.Button();
            this.tb_veyage_number = new System.Windows.Forms.TextBox();
            this.flowpanel = new System.Windows.Forms.FlowLayoutPanel();
            this.datagridview = new System.Windows.Forms.DataGridView();
            this.cb_container_number = new System.Windows.Forms.ComboBox();
            this.lb_voyage_number_xxx = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.datagridview)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Date of arrival:";
            // 
            // dtp_from
            // 
            this.dtp_from.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_from.Location = new System.Drawing.Point(136, 10);
            this.dtp_from.Name = "dtp_from";
            this.dtp_from.Size = new System.Drawing.Size(105, 25);
            this.dtp_from.TabIndex = 2;
            // 
            // lbl_to
            // 
            this.lbl_to.AutoSize = true;
            this.lbl_to.Location = new System.Drawing.Point(265, 20);
            this.lbl_to.Name = "lbl_to";
            this.lbl_to.Size = new System.Drawing.Size(15, 15);
            this.lbl_to.TabIndex = 3;
            this.lbl_to.Text = "~";
            // 
            // dtp_to
            // 
            this.dtp_to.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_to.Location = new System.Drawing.Point(283, 10);
            this.dtp_to.Name = "dtp_to";
            this.dtp_to.Size = new System.Drawing.Size(105, 25);
            this.dtp_to.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(446, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "Voyage Number: ";
            // 
            // btn_start
            // 
            this.btn_start.BackColor = System.Drawing.Color.Chartreuse;
            this.btn_start.Location = new System.Drawing.Point(794, 31);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(160, 26);
            this.btn_start.TabIndex = 10;
            this.btn_start.Text = "Start Security Check";
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-1, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(183, 15);
            this.label3.TabIndex = 11;
            this.label3.Text = "Security Check Status:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(279, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "HS Code:";
            // 
            // cb_security_check_status
            // 
            this.cb_security_check_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_security_check_status.FormattingEnabled = true;
            this.cb_security_check_status.Location = new System.Drawing.Point(183, 63);
            this.cb_security_check_status.Name = "cb_security_check_status";
            this.cb_security_check_status.Size = new System.Drawing.Size(90, 23);
            this.cb_security_check_status.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(472, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 15);
            this.label5.TabIndex = 15;
            this.label5.Text = "Cargo Owner Rating:";
            // 
            // cb_hs_code
            // 
            this.cb_hs_code.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_hs_code.FormattingEnabled = true;
            this.cb_hs_code.Location = new System.Drawing.Point(356, 63);
            this.cb_hs_code.Name = "cb_hs_code";
            this.cb_hs_code.Size = new System.Drawing.Size(110, 23);
            this.cb_hs_code.TabIndex = 16;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(736, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(143, 15);
            this.label6.TabIndex = 17;
            this.label6.Text = "Container Number:";
            // 
            // cb_cargo_owner_rating
            // 
            this.cb_cargo_owner_rating.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_cargo_owner_rating.FormattingEnabled = true;
            this.cb_cargo_owner_rating.Location = new System.Drawing.Point(625, 65);
            this.cb_cargo_owner_rating.Name = "cb_cargo_owner_rating";
            this.cb_cargo_owner_rating.Size = new System.Drawing.Size(105, 23);
            this.cb_cargo_owner_rating.TabIndex = 18;
            // 
            // btn_batch_unseal
            // 
            this.btn_batch_unseal.BackColor = System.Drawing.Color.GreenYellow;
            this.btn_batch_unseal.Location = new System.Drawing.Point(528, 593);
            this.btn_batch_unseal.Name = "btn_batch_unseal";
            this.btn_batch_unseal.Size = new System.Drawing.Size(228, 28);
            this.btn_batch_unseal.TabIndex = 21;
            this.btn_batch_unseal.Text = "Batch Unseal Inspect";
            this.btn_batch_unseal.UseVisualStyleBackColor = false;
            this.btn_batch_unseal.Click += new System.EventHandler(this.btn_batch_unseal_Click);
            // 
            // btn_batch_release
            // 
            this.btn_batch_release.BackColor = System.Drawing.Color.GreenYellow;
            this.btn_batch_release.Location = new System.Drawing.Point(837, 593);
            this.btn_batch_release.Name = "btn_batch_release";
            this.btn_batch_release.Size = new System.Drawing.Size(120, 28);
            this.btn_batch_release.TabIndex = 22;
            this.btn_batch_release.Text = "Batch Release";
            this.btn_batch_release.UseVisualStyleBackColor = false;
            this.btn_batch_release.Click += new System.EventHandler(this.btn_batch_release_Click);
            // 
            // btn_from
            // 
            this.btn_from.Location = new System.Drawing.Point(239, 10);
            this.btn_from.Name = "btn_from";
            this.btn_from.Size = new System.Drawing.Size(27, 23);
            this.btn_from.TabIndex = 23;
            this.btn_from.UseVisualStyleBackColor = true;
            // 
            // btn_to
            // 
            this.btn_to.Location = new System.Drawing.Point(392, 10);
            this.btn_to.Name = "btn_to";
            this.btn_to.Size = new System.Drawing.Size(27, 23);
            this.btn_to.TabIndex = 23;
            this.btn_to.UseVisualStyleBackColor = true;
            // 
            // tb_veyage_number
            // 
            this.tb_veyage_number.Location = new System.Drawing.Point(580, 11);
            this.tb_veyage_number.Name = "tb_veyage_number";
            this.tb_veyage_number.Size = new System.Drawing.Size(152, 25);
            this.tb_veyage_number.TabIndex = 24;
            // 
            // flowpanel
            // 
            this.flowpanel.AutoScroll = true;
            this.flowpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowpanel.Location = new System.Drawing.Point(3, 56);
            this.flowpanel.Name = "flowpanel";
            this.flowpanel.Size = new System.Drawing.Size(301, 629);
            this.flowpanel.TabIndex = 25;
            // 
            // datagridview
            // 
            this.datagridview.AllowUserToAddRows = false;
            this.datagridview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.datagridview.Location = new System.Drawing.Point(24, 92);
            this.datagridview.Name = "datagridview";
            this.datagridview.RowHeadersVisible = false;
            this.datagridview.RowHeadersWidth = 51;
            this.datagridview.Size = new System.Drawing.Size(933, 488);
            this.datagridview.TabIndex = 20;
            // 
            // cb_container_number
            // 
            this.cb_container_number.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_container_number.FormattingEnabled = true;
            this.cb_container_number.Location = new System.Drawing.Point(885, 68);
            this.cb_container_number.Name = "cb_container_number";
            this.cb_container_number.Size = new System.Drawing.Size(69, 23);
            this.cb_container_number.TabIndex = 18;
            // 
            // lb_voyage_number_xxx
            // 
            this.lb_voyage_number_xxx.AutoSize = true;
            this.lb_voyage_number_xxx.Font = new System.Drawing.Font("SimSun", 20F);
            this.lb_voyage_number_xxx.Location = new System.Drawing.Point(35, 23);
            this.lb_voyage_number_xxx.Name = "lb_voyage_number_xxx";
            this.lb_voyage_number_xxx.Size = new System.Drawing.Size(338, 34);
            this.lb_voyage_number_xxx.TabIndex = 11;
            this.lb_voyage_number_xxx.Text = "Voyage Number:xxxxx";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.datagridview);
            this.panel1.Controls.Add(this.btn_start);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.lb_voyage_number_xxx);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.btn_batch_release);
            this.panel1.Controls.Add(this.cb_security_check_status);
            this.panel1.Controls.Add(this.btn_batch_unseal);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.cb_hs_code);
            this.panel1.Controls.Add(this.cb_container_number);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cb_cargo_owner_rating);
            this.panel1.Location = new System.Drawing.Point(310, 56);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(982, 629);
            this.panel1.TabIndex = 26;
            // 
            // SecurityCheckControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowpanel);
            this.Controls.Add(this.tb_veyage_number);
            this.Controls.Add(this.btn_to);
            this.Controls.Add(this.btn_from);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtp_to);
            this.Controls.Add(this.lbl_to);
            this.Controls.Add(this.dtp_from);
            this.Controls.Add(this.label1);
            this.Name = "SecurityCheckControl";
            this.Size = new System.Drawing.Size(1309, 732);
            ((System.ComponentModel.ISupportInitialize)(this.datagridview)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtp_from;
        private System.Windows.Forms.Label lbl_to;
        private System.Windows.Forms.DateTimePicker dtp_to;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_security_check_status;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_hs_code;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cb_cargo_owner_rating;
        private System.Windows.Forms.Button btn_batch_unseal;
        private System.Windows.Forms.Button btn_batch_release;
        private System.Windows.Forms.Button btn_from;
        private System.Windows.Forms.Button btn_to;
        private System.Windows.Forms.TextBox tb_veyage_number;
        private System.Windows.Forms.FlowLayoutPanel flowpanel;
        private System.Windows.Forms.DataGridView datagridview;
        private System.Windows.Forms.ComboBox cb_container_number;
        private System.Windows.Forms.Label lb_voyage_number_xxx;
        private System.Windows.Forms.Panel panel1;
    }
}
