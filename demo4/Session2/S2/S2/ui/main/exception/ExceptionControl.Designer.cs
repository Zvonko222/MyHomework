namespace S2.controls
{
    public partial class ExceptionControl
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
            this.tb_voyage_number = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_conatiner_number = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_cargo_owner = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_exception_type = new System.Windows.Forms.ComboBox();
            this.btn_search = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Voyage Number:";
            // 
            // tb_voyage_number
            // 
            this.tb_voyage_number.Location = new System.Drawing.Point(163, 12);
            this.tb_voyage_number.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_voyage_number.Name = "tb_voyage_number";
            this.tb_voyage_number.Size = new System.Drawing.Size(110, 28);
            this.tb_voyage_number.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(347, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 22);
            this.label2.TabIndex = 3;
            this.label2.Text = "Container Number:";
            // 
            // tb_conatiner_number
            // 
            this.tb_conatiner_number.Location = new System.Drawing.Point(496, 12);
            this.tb_conatiner_number.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_conatiner_number.Name = "tb_conatiner_number";
            this.tb_conatiner_number.Size = new System.Drawing.Size(110, 28);
            this.tb_conatiner_number.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(724, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 22);
            this.label3.TabIndex = 5;
            this.label3.Text = "Cargo Owner:";
            // 
            // tb_cargo_owner
            // 
            this.tb_cargo_owner.Location = new System.Drawing.Point(833, 12);
            this.tb_cargo_owner.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tb_cargo_owner.Name = "tb_cargo_owner";
            this.tb_cargo_owner.Size = new System.Drawing.Size(160, 28);
            this.tb_cargo_owner.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 22);
            this.label4.TabIndex = 7;
            this.label4.Text = "Exception Type:";
            // 
            // cb_exception_type
            // 
            this.cb_exception_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_exception_type.FormattingEnabled = true;
            this.cb_exception_type.Location = new System.Drawing.Point(157, 69);
            this.cb_exception_type.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cb_exception_type.Name = "cb_exception_type";
            this.cb_exception_type.Size = new System.Drawing.Size(150, 30);
            this.cb_exception_type.TabIndex = 8;
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(913, 57);
            this.btn_search.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(80, 38);
            this.btn_search.TabIndex = 9;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_ex_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(10, 142);
            this.dataGridView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidth = 51;
            this.dataGridView.Size = new System.Drawing.Size(1040, 723);
            this.dataGridView.TabIndex = 10;
            this.dataGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_exception_CellContentClick);
            // 
            // ExceptionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.btn_search);
            this.Controls.Add(this.cb_exception_type);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_cargo_owner);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tb_conatiner_number);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_voyage_number);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Open Sans Light", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ExceptionControl";
            this.Size = new System.Drawing.Size(1059, 896);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_voyage_number;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_conatiner_number;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_cargo_owner;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_exception_type;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.DataGridView dataGridView;
    }
}
