namespace WindowsFormsApp1.Forms
{
    partial class PurchaseOder
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
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.cb_serach = new System.Windows.Forms.ComboBox();
            this.tb_flower_name = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_serach_by = new System.Windows.Forms.ComboBox();
            this.tb_date_end = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1});
            this.dataGridView1.Location = new System.Drawing.Point(50, 168);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.Size = new System.Drawing.Size(898, 418);
            this.dataGridView1.TabIndex = 10;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Add to cart";
            this.Column1.MinimumWidth = 8;
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(709, -79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 35);
            this.button1.TabIndex = 9;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // cb_serach
            // 
            this.cb_serach.FormattingEnabled = true;
            this.cb_serach.Items.AddRange(new object[] {
            "ALL"});
            this.cb_serach.Location = new System.Drawing.Point(429, -74);
            this.cb_serach.Name = "cb_serach";
            this.cb_serach.Size = new System.Drawing.Size(202, 26);
            this.cb_serach.TabIndex = 8;
            // 
            // tb_flower_name
            // 
            this.tb_flower_name.Location = new System.Drawing.Point(127, -80);
            this.tb_flower_name.Name = "tb_flower_name";
            this.tb_flower_name.Size = new System.Drawing.Size(189, 28);
            this.tb_flower_name.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("SimSun", 15F);
            this.label1.Location = new System.Drawing.Point(-72, -82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 30);
            this.label1.TabIndex = 6;
            this.label1.Text = "Flower Name:";
            // 
            // cb_serach_by
            // 
            this.cb_serach_by.FormattingEnabled = true;
            this.cb_serach_by.Items.AddRange(new object[] {
            "OrderDate",
            "DeliveryDate"});
            this.cb_serach_by.Location = new System.Drawing.Point(136, 38);
            this.cb_serach_by.Name = "cb_serach_by";
            this.cb_serach_by.Size = new System.Drawing.Size(114, 26);
            this.cb_serach_by.TabIndex = 16;
            // 
            // tb_date_end
            // 
            this.tb_date_end.Location = new System.Drawing.Point(442, 40);
            this.tb_date_end.Name = "tb_date_end";
            this.tb_date_end.Size = new System.Drawing.Size(114, 28);
            this.tb_date_end.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("SimSun", 15F);
            this.label3.Location = new System.Drawing.Point(12, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(118, 30);
            this.label3.TabIndex = 11;
            this.label3.Text = "Status:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("SimSun", 15F);
            this.label4.Location = new System.Drawing.Point(256, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(163, 30);
            this.label4.TabIndex = 13;
            this.label4.Text = "Order Date";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(579, 45);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(88, 22);
            this.checkBox1.TabIndex = 17;
            this.checkBox1.Text = "Enable";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(741, 44);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 18;
            this.button2.Text = "Search";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // PurchaseOder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 619);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.cb_serach_by);
            this.Controls.Add(this.tb_date_end);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cb_serach);
            this.Controls.Add(this.tb_flower_name);
            this.Controls.Add(this.label1);
            this.Name = "PurchaseOder";
            this.Text = "PurchaseOder";
            this.Load += new System.EventHandler(this.PurchaseOder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cb_serach;
        private System.Windows.Forms.TextBox tb_flower_name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_serach_by;
        private System.Windows.Forms.TextBox tb_date_end;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button2;
    }
}