namespace S2.controls
{
    public partial class DeclarationControl
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
            this.label = new System.Windows.Forms.Label();
            this.cb_voyage_number = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_container_number = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_declaration_status = new System.Windows.Forms.ComboBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.lb_x_records_found = new System.Windows.Forms.Label();
            this.btn_first = new System.Windows.Forms.Button();
            this.btn_prev = new System.Windows.Forms.Button();
            this.tb_page = new System.Windows.Forms.TextBox();
            this.btn_next = new System.Windows.Forms.Button();
            this.btn_last = new System.Windows.Forms.Button();
            this.lb_page_x_x = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tb_declaration_id = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(58, 27);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(123, 22);
            this.label.TabIndex = 4;
            this.label.Text = "Voyage Number:";
            // 
            // cb_voyage_number
            // 
            this.cb_voyage_number.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_voyage_number.FormattingEnabled = true;
            this.cb_voyage_number.Location = new System.Drawing.Point(183, 24);
            this.cb_voyage_number.Name = "cb_voyage_number";
            this.cb_voyage_number.Size = new System.Drawing.Size(143, 30);
            this.cb_voyage_number.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(410, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 22);
            this.label1.TabIndex = 6;
            this.label1.Text = "Container Number:";
            // 
            // cb_container_number
            // 
            this.cb_container_number.FormattingEnabled = true;
            this.cb_container_number.Location = new System.Drawing.Point(549, 24);
            this.cb_container_number.Name = "cb_container_number";
            this.cb_container_number.Size = new System.Drawing.Size(143, 23);
            this.cb_container_number.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(804, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 22);
            this.label2.TabIndex = 8;
            this.label2.Text = "Declaration Id:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(18, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 22);
            this.label3.TabIndex = 10;
            this.label3.Text = "Declaration Status:";
            // 
            // cb_declaration_status
            // 
            this.cb_declaration_status.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_declaration_status.FormattingEnabled = true;
            this.cb_declaration_status.Location = new System.Drawing.Point(183, 74);
            this.cb_declaration_status.Name = "cb_declaration_status";
            this.cb_declaration_status.Size = new System.Drawing.Size(143, 30);
            this.cb_declaration_status.TabIndex = 11;
            // 
            // btn_search
            // 
            this.btn_search.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_search.Location = new System.Drawing.Point(1006, 66);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(80, 26);
            this.btn_search.TabIndex = 12;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // lb_x_records_found
            // 
            this.lb_x_records_found.AutoSize = true;
            this.lb_x_records_found.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_x_records_found.Location = new System.Drawing.Point(18, 107);
            this.lb_x_records_found.Name = "lb_x_records_found";
            this.lb_x_records_found.Size = new System.Drawing.Size(126, 22);
            this.lb_x_records_found.TabIndex = 13;
            this.lb_x_records_found.Text = "0 Records Found";
            // 
            // btn_first
            // 
            this.btn_first.Location = new System.Drawing.Point(21, 654);
            this.btn_first.Name = "btn_first";
            this.btn_first.Size = new System.Drawing.Size(35, 23);
            this.btn_first.TabIndex = 15;
            this.btn_first.Text = "<<";
            this.btn_first.UseVisualStyleBackColor = true;
            this.btn_first.Click += new System.EventHandler(this.btn_first_Click);
            // 
            // btn_prev
            // 
            this.btn_prev.Location = new System.Drawing.Point(62, 654);
            this.btn_prev.Name = "btn_prev";
            this.btn_prev.Size = new System.Drawing.Size(35, 23);
            this.btn_prev.TabIndex = 16;
            this.btn_prev.Text = "<";
            this.btn_prev.UseVisualStyleBackColor = true;
            this.btn_prev.Click += new System.EventHandler(this.btn_prev_Click);
            // 
            // tb_page
            // 
            this.tb_page.Location = new System.Drawing.Point(103, 656);
            this.tb_page.Name = "tb_page";
            this.tb_page.Size = new System.Drawing.Size(35, 25);
            this.tb_page.TabIndex = 17;
            this.tb_page.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btn_next
            // 
            this.btn_next.Location = new System.Drawing.Point(142, 654);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(35, 23);
            this.btn_next.TabIndex = 18;
            this.btn_next.Text = ">";
            this.btn_next.UseVisualStyleBackColor = true;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // btn_last
            // 
            this.btn_last.Location = new System.Drawing.Point(183, 654);
            this.btn_last.Name = "btn_last";
            this.btn_last.Size = new System.Drawing.Size(35, 23);
            this.btn_last.TabIndex = 19;
            this.btn_last.Text = ">>";
            this.btn_last.UseVisualStyleBackColor = true;
            this.btn_last.Click += new System.EventHandler(this.btn_last_Click);
            // 
            // lb_page_x_x
            // 
            this.lb_page_x_x.AutoSize = true;
            this.lb_page_x_x.Font = new System.Drawing.Font("Open Sans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_page_x_x.Location = new System.Drawing.Point(233, 654);
            this.lb_page_x_x.Name = "lb_page_x_x";
            this.lb_page_x_x.Size = new System.Drawing.Size(71, 22);
            this.lb_page_x_x.TabIndex = 20;
            this.lb_page_x_x.Text = "Page:1/1";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(36, 143);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(1068, 466);
            this.flowLayoutPanel1.TabIndex = 21;
            // 
            // tb_declaration_id
            // 
            this.tb_declaration_id.Location = new System.Drawing.Point(918, 28);
            this.tb_declaration_id.Name = "tb_declaration_id";
            this.tb_declaration_id.Size = new System.Drawing.Size(168, 25);
            this.tb_declaration_id.TabIndex = 22;
            // 
            // DeclarationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tb_declaration_id);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btn_last);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.lb_page_x_x);
            this.Controls.Add(this.tb_page);
            this.Controls.Add(this.btn_prev);
            this.Controls.Add(this.btn_first);
            this.Controls.Add(this.lb_x_records_found);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.cb_declaration_status);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_container_number);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_voyage_number);
            this.Controls.Add(this.label);
            this.Name = "DeclarationControl";
            this.Size = new System.Drawing.Size(1152, 686);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.ComboBox cb_voyage_number;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_container_number;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_declaration_status;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.Label lb_x_records_found;
        private System.Windows.Forms.Button btn_first;
        private System.Windows.Forms.Button btn_prev;
        private System.Windows.Forms.TextBox tb_page;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Button btn_last;
        private System.Windows.Forms.Label lb_page_x_x;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.TextBox tb_declaration_id;
    }
}
