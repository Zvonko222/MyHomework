namespace WindowsFormsApp1.Forms
{
    partial class ManagerForm
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
            this.btn_purchase_flowers = new System.Windows.Forms.Button();
            this.btn_purchase_histroy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_purchase_flowers
            // 
            this.btn_purchase_flowers.Font = new System.Drawing.Font("SimSun", 15F);
            this.btn_purchase_flowers.Location = new System.Drawing.Point(192, 106);
            this.btn_purchase_flowers.Name = "btn_purchase_flowers";
            this.btn_purchase_flowers.Size = new System.Drawing.Size(405, 79);
            this.btn_purchase_flowers.TabIndex = 0;
            this.btn_purchase_flowers.Text = "Purchase Flowers";
            this.btn_purchase_flowers.UseVisualStyleBackColor = true;
            this.btn_purchase_flowers.Click += new System.EventHandler(this.btn_purchase_flowers_Click);
            // 
            // btn_purchase_histroy
            // 
            this.btn_purchase_histroy.Font = new System.Drawing.Font("SimSun", 15F);
            this.btn_purchase_histroy.Location = new System.Drawing.Point(192, 225);
            this.btn_purchase_histroy.Name = "btn_purchase_histroy";
            this.btn_purchase_histroy.Size = new System.Drawing.Size(405, 79);
            this.btn_purchase_histroy.TabIndex = 0;
            this.btn_purchase_histroy.Text = "Purchase Histroy";
            this.btn_purchase_histroy.UseVisualStyleBackColor = true;
            this.btn_purchase_histroy.Click += new System.EventHandler(this.btn_purchase_histroy_Click);
            // 
            // ManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_purchase_histroy);
            this.Controls.Add(this.btn_purchase_flowers);
            this.Name = "ManagerForm";
            this.Text = "Store Manager HomePage";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ManagerForm_FormClosed);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_purchase_flowers;
        private System.Windows.Forms.Button btn_purchase_histroy;
    }
}