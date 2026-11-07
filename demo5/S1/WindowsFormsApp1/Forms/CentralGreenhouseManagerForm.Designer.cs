namespace WindowsFormsApp1.Forms
{
    partial class CentralGreenhouseManagerForm
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
            this.btn_purchase_histroy = new System.Windows.Forms.Button();
            this.btn_purchase_flowers = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_purchase_histroy
            // 
            this.btn_purchase_histroy.Font = new System.Drawing.Font("SimSun", 15F);
            this.btn_purchase_histroy.Location = new System.Drawing.Point(192, 163);
            this.btn_purchase_histroy.Name = "btn_purchase_histroy";
            this.btn_purchase_histroy.Size = new System.Drawing.Size(405, 79);
            this.btn_purchase_histroy.TabIndex = 1;
            this.btn_purchase_histroy.Text = "Flower Management";
            this.btn_purchase_histroy.UseVisualStyleBackColor = true;
            this.btn_purchase_histroy.Click += new System.EventHandler(this.btn_purchase_histroy_Click);
            // 
            // btn_purchase_flowers
            // 
            this.btn_purchase_flowers.Font = new System.Drawing.Font("SimSun", 15F);
            this.btn_purchase_flowers.Location = new System.Drawing.Point(192, 78);
            this.btn_purchase_flowers.Name = "btn_purchase_flowers";
            this.btn_purchase_flowers.Size = new System.Drawing.Size(405, 79);
            this.btn_purchase_flowers.TabIndex = 2;
            this.btn_purchase_flowers.Text = "Purchase Order Management";
            this.btn_purchase_flowers.UseVisualStyleBackColor = true;
            this.btn_purchase_flowers.Click += new System.EventHandler(this.btn_purchase_flowers_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("SimSun", 15F);
            this.button1.Location = new System.Drawing.Point(192, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(405, 79);
            this.button1.TabIndex = 1;
            this.button1.Text = "Material Management";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CentralGreenhouseManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_purchase_histroy);
            this.Controls.Add(this.btn_purchase_flowers);
            this.Name = "CentralGreenhouseManagerForm";
            this.Text = "CentralGreenhouseManagerForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_purchase_histroy;
        private System.Windows.Forms.Button btn_purchase_flowers;
        private System.Windows.Forms.Button button1;
    }
}