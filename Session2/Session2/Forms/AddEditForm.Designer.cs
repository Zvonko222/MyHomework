namespace Session2.Forms
{
    partial class AddEditForm
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.nud_number_of_bathrooms = new System.Windows.Forms.NumericUpDown();
            this.nud_number_of_bedrooms = new System.Windows.Forms.NumericUpDown();
            this.nud_number_of_beds = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.nud_capacity = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tb_title = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_type = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.column_amenity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.column_is = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.label14 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label15 = new System.Windows.Forms.Label();
            this.btn_close_finish = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_number_of_bathrooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_number_of_bedrooms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_number_of_beds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_capacity)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(887, 459);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.nud_number_of_bathrooms);
            this.tabPage1.Controls.Add(this.nud_number_of_bedrooms);
            this.tabPage1.Controls.Add(this.nud_number_of_beds);
            this.tabPage1.Controls.Add(this.numericUpDown2);
            this.tabPage1.Controls.Add(this.numericUpDown1);
            this.tabPage1.Controls.Add(this.nud_capacity);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.textBox4);
            this.tabPage1.Controls.Add(this.textBox3);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.tb_title);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.cb_type);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label13);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(879, 430);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Listing Details";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // nud_number_of_bathrooms
            // 
            this.nud_number_of_bathrooms.Location = new System.Drawing.Point(803, 68);
            this.nud_number_of_bathrooms.Name = "nud_number_of_bathrooms";
            this.nud_number_of_bathrooms.Size = new System.Drawing.Size(38, 25);
            this.nud_number_of_bathrooms.TabIndex = 3;
            // 
            // nud_number_of_bedrooms
            // 
            this.nud_number_of_bedrooms.Location = new System.Drawing.Point(585, 68);
            this.nud_number_of_bedrooms.Name = "nud_number_of_bedrooms";
            this.nud_number_of_bedrooms.Size = new System.Drawing.Size(38, 25);
            this.nud_number_of_bedrooms.TabIndex = 3;
            // 
            // nud_number_of_beds
            // 
            this.nud_number_of_beds.Location = new System.Drawing.Point(336, 62);
            this.nud_number_of_beds.Name = "nud_number_of_beds";
            this.nud_number_of_beds.Size = new System.Drawing.Size(38, 25);
            this.nud_number_of_beds.TabIndex = 3;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Location = new System.Drawing.Point(513, 370);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(38, 25);
            this.numericUpDown2.TabIndex = 3;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(336, 370);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(38, 25);
            this.numericUpDown1.TabIndex = 3;
            // 
            // nud_capacity
            // 
            this.nud_capacity.Location = new System.Drawing.Point(101, 60);
            this.nud_capacity.Name = "nud_capacity";
            this.nud_capacity.Size = new System.Drawing.Size(38, 25);
            this.nud_capacity.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(640, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(167, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "Number of Bathrooms:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(168, 277);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(711, 68);
            this.textBox4.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(168, 203);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(711, 68);
            this.textBox3.TabIndex = 2;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(168, 129);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(711, 68);
            this.textBox2.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(168, 98);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(711, 25);
            this.textBox1.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(20, 372);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(199, 15);
            this.label11.TabIndex = 0;
            this.label11.Text = "Reservation Time(Night):";
            this.label11.Click += new System.EventHandler(this.label10_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 277);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(95, 15);
            this.label10.TabIndex = 0;
            this.label10.Text = "Host Rules:";
            this.label10.Click += new System.EventHandler(this.label10_Click);
            // 
            // tb_title
            // 
            this.tb_title.Location = new System.Drawing.Point(549, 21);
            this.tb_title.Name = "tb_title";
            this.tb_title.Size = new System.Drawing.Size(265, 25);
            this.tb_title.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 203);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(95, 15);
            this.label9.TabIndex = 0;
            this.label9.Text = "Desciption:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(420, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "Number of Bedrooms:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(20, 129);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(119, 15);
            this.label8.TabIndex = 0;
            this.label8.Text = "Exact Address:";
            // 
            // cb_type
            // 
            this.cb_type.FormattingEnabled = true;
            this.cb_type.Location = new System.Drawing.Point(85, 24);
            this.cb_type.Name = "cb_type";
            this.cb_type.Size = new System.Drawing.Size(269, 23);
            this.cb_type.TabIndex = 1;
            this.cb_type.SelectedIndexChanged += new System.EventHandler(this.cb_type_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(-3, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(175, 15);
            this.label7.TabIndex = 0;
            this.label7.Text = "Approxinmate Address:";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(428, 372);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 15);
            this.label13.TabIndex = 0;
            this.label13.Text = "Maximum:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(203, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "Number of Beds:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(251, 372);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 15);
            this.label12.TabIndex = 0;
            this.label12.Text = "Minimum:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(484, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Title:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Capacity:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dataGridView1);
            this.tabPage2.Controls.Add(this.label14);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(879, 430);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Amenities";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.column_amenity,
            this.column_is});
            this.dataGridView1.Location = new System.Drawing.Point(57, 82);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(414, 256);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // column_amenity
            // 
            this.column_amenity.HeaderText = "Amenity";
            this.column_amenity.MinimumWidth = 6;
            this.column_amenity.Name = "column_amenity";
            this.column_amenity.Width = 125;
            // 
            // column_is
            // 
            this.column_is.HeaderText = "";
            this.column_is.MinimumWidth = 6;
            this.column_is.Name = "column_is";
            this.column_is.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.column_is.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.column_is.Width = 125;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(15, 28);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(215, 15);
            this.label14.TabIndex = 0;
            this.label14.Text = "Choose Acaliable Amenties:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.dataGridView2);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(879, 430);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Distance to Attraction";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(3, 73);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 27;
            this.dataGridView2.Size = new System.Drawing.Size(870, 351);
            this.dataGridView2.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(64, 27);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(711, 15);
            this.label15.TabIndex = 0;
            this.label15.Text = "Specify the distance from each close by attraction and the time it takes to get t" +
    "o them:";
            // 
            // btn_close_finish
            // 
            this.btn_close_finish.Location = new System.Drawing.Point(762, 477);
            this.btn_close_finish.Name = "btn_close_finish";
            this.btn_close_finish.Size = new System.Drawing.Size(137, 36);
            this.btn_close_finish.TabIndex = 4;
            this.btn_close_finish.Text = "Close / Finish";
            this.btn_close_finish.UseVisualStyleBackColor = true;
            this.btn_close_finish.Click += new System.EventHandler(this.btn_close_finish_Click);
            // 
            // btn_next
            // 
            this.btn_next.Location = new System.Drawing.Point(659, 477);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(97, 36);
            this.btn_next.TabIndex = 5;
            this.btn_next.Text = "Next";
            this.btn_next.UseVisualStyleBackColor = true;
            // 
            // AddEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(911, 525);
            this.Controls.Add(this.btn_close_finish);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.tabControl1);
            this.Name = "AddEditForm";
            this.Text = "Seoul Stay - Add / Edit Listing";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AddEditForm_FormClosed);
            this.Load += new System.EventHandler(this.AddEditForm_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nud_number_of_bathrooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_number_of_bedrooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_number_of_beds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_capacity)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btn_close_finish;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nud_number_of_bathrooms;
        private System.Windows.Forms.NumericUpDown nud_number_of_bedrooms;
        private System.Windows.Forms.NumericUpDown nud_number_of_beds;
        private System.Windows.Forms.NumericUpDown nud_capacity;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_title;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cb_type;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn column_amenity;
        private System.Windows.Forms.DataGridViewCheckBoxColumn column_is;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label15;
    }
}