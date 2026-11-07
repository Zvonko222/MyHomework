namespace S2.ui
{
    partial class HsCodeSelectForm
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
            this.dgvHsCodes = new System.Windows.Forms.DataGridView();
            this.col_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.col_select = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHsCodes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHsCodes
            // 
            this.dgvHsCodes.AllowUserToAddRows = false;
            this.dgvHsCodes.AllowUserToDeleteRows = false;
            this.dgvHsCodes.AllowUserToResizeRows = false;
            this.dgvHsCodes.BackgroundColor = System.Drawing.Color.White;
            this.dgvHsCodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHsCodes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.col_code,
            this.col_desc,
            this.col_select});
            this.dgvHsCodes.Location = new System.Drawing.Point(20, 20);
            this.dgvHsCodes.MultiSelect = false;
            this.dgvHsCodes.Name = "dgvHsCodes";
            this.dgvHsCodes.ReadOnly = true;
            this.dgvHsCodes.RowHeadersVisible = false;
            this.dgvHsCodes.RowHeadersWidth = 51;
            this.dgvHsCodes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHsCodes.Size = new System.Drawing.Size(600, 340);
            this.dgvHsCodes.TabIndex = 0;
            this.dgvHsCodes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.SelectRow);
            // 
            // col_code
            // 
            this.col_code.HeaderText = "HS Code";
            this.col_code.MinimumWidth = 6;
            this.col_code.Name = "col_code";
            this.col_code.ReadOnly = true;
            this.col_code.Width = 150;
            // 
            // col_desc
            // 
            this.col_desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.col_desc.HeaderText = "Description";
            this.col_desc.MinimumWidth = 6;
            this.col_desc.Name = "col_desc";
            this.col_desc.ReadOnly = true;
            // 
            // col_select
            // 
            this.col_select.HeaderText = "Select";
            this.col_select.MinimumWidth = 6;
            this.col_select.Name = "col_select";
            this.col_select.ReadOnly = true;
            this.col_select.Text = "Select";
            this.col_select.UseColumnTextForLinkValue = true;
            this.col_select.Width = 80;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(525, 375);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 32);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // HsCodeSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(640, 420);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.dgvHsCodes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HsCodeSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select HS Code";
            ((System.ComponentModel.ISupportInitialize)(this.dgvHsCodes)).EndInit();
            this.ResumeLayout(false);

        }

        private System.Windows.Forms.DataGridView dgvHsCodes;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesc;
        private System.Windows.Forms.DataGridViewLinkColumn colSelect;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn col_desc;
        private System.Windows.Forms.DataGridViewLinkColumn col_select;
    }
}
