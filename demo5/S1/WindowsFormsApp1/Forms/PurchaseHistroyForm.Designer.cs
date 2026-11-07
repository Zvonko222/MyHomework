namespace WindowsFormsApp1.Forms
{
    partial class PurchaseHistroyForm
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.cb_serach_by = new System.Windows.Forms.ComboBox();
            this.tb_date_start = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_date_end = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_status = new System.Windows.Forms.ComboBox();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(17, 146);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(1083, 499);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("SimSun", 15F);
            this.button1.Location = new System.Drawing.Point(961, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(139, 35);
            this.button1.TabIndex = 7;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cb_serach_by
            // 
            this.cb_serach_by.FormattingEnabled = true;
            this.cb_serach_by.Items.AddRange(new object[] {
            "OrderDate",
            "DeliveryDate"});
            this.cb_serach_by.Location = new System.Drawing.Point(578, 37);
            this.cb_serach_by.Name = "cb_serach_by";
            this.cb_serach_by.Size = new System.Drawing.Size(114, 26);
            this.cb_serach_by.TabIndex = 6;
            // 
            // tb_date_start
            // 
            this.tb_date_start.Location = new System.Drawing.Point(196, 33);
            this.tb_date_start.Name = "tb_date_start";
            this.tb_date_start.Size = new System.Drawing.Size(114, 28);
            this.tb_date_start.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 15F);
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "Date Range:";
            // 
            // tb_date_end
            // 
            this.tb_date_end.Location = new System.Drawing.Point(316, 33);
            this.tb_date_end.Name = "tb_date_end";
            this.tb_date_end.Size = new System.Drawing.Size(114, 28);
            this.tb_date_end.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("SimSun", 15F);
            this.label2.Location = new System.Drawing.Point(436, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "Search By";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 15F);
            this.label3.Location = new System.Drawing.Point(704, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 30);
            this.label3.TabIndex = 4;
            this.label3.Text = "Status:";
            // 
            // cb_status
            // 
            this.cb_status.FormattingEnabled = true;
            this.cb_status.Items.AddRange(new object[] {
            "All",
            "Prepare",
            "Pending"});
            this.cb_status.Location = new System.Drawing.Point(828, 37);
            this.cb_status.Name = "cb_status";
            this.cb_status.Size = new System.Drawing.Size(114, 26);
            this.cb_status.TabIndex = 6;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Action";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column1.ToolTipText = "ViewDetail";
            this.Column1.Width = 150;
            // 
            // PurchaseHistroyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1112, 657);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cb_status);
            this.Controls.Add(this.cb_serach_by);
            this.Controls.Add(this.tb_date_end);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_date_start);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "PurchaseHistroyForm";
            this.Text = "PurchaseHistroyForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PurchaseHistroyForm_FormClosed);
            this.Load += new System.EventHandler(this.PurchaseHistroyForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cb_serach_by;
        private System.Windows.Forms.TextBox tb_date_start;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_date_end;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}