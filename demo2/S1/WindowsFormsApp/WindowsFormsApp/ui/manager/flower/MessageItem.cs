using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp.data.model.dto;

namespace WindowsFormsApp.ui.manager.flower
{
    internal class MessageItem : UserControl
    {
        private Label lb_flower_name;
        private Label lb_descript;
        private Label lb_fresh;
        private MaskedTextBox tb_number;
        private PictureBox pictureBox1;
        private Button button1;
  
        public MessageItem(Image image,string name,string category,double price)
        {
            InitializeComponent(); 
            init(image, name, category, price);

            this.Load += MessageItem_Load;
        }

        private void init(Image image, string name, string category,double price)
        {
            lb_flower_name.Text = name;
            lb_descript.Text = $"Category : {category} Price : {price}";
            pictureBox1.Image = image;
        }

        private void MessageItem_Load(object sender, EventArgs e)
        {
            
        }

        private void InitializeComponent()
        {
            this.lb_flower_name = new System.Windows.Forms.Label();
            this.lb_descript = new System.Windows.Forms.Label();
            this.lb_fresh = new System.Windows.Forms.Label();
            this.tb_number = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lb_flower_name
            // 
            this.lb_flower_name.AutoSize = true;
            this.lb_flower_name.Font = new System.Drawing.Font("SimSun", 15F);
            this.lb_flower_name.Location = new System.Drawing.Point(83, 12);
            this.lb_flower_name.Name = "lb_flower_name";
            this.lb_flower_name.Size = new System.Drawing.Size(155, 25);
            this.lb_flower_name.TabIndex = 0;
            this.lb_flower_name.Text = "Flower Name";
            // 
            // lb_descript
            // 
            this.lb_descript.AutoSize = true;
            this.lb_descript.Location = new System.Drawing.Point(83, 40);
            this.lb_descript.Name = "lb_descript";
            this.lb_descript.Size = new System.Drawing.Size(231, 15);
            this.lb_descript.TabIndex = 1;
            this.lb_descript.Text = "Category: Rose Price : 28.00";
            // 
            // lb_fresh
            // 
            this.lb_fresh.AutoSize = true;
            this.lb_fresh.Location = new System.Drawing.Point(83, 64);
            this.lb_fresh.Name = "lb_fresh";
            this.lb_fresh.Size = new System.Drawing.Size(175, 15);
            this.lb_fresh.TabIndex = 1;
            this.lb_fresh.Text = "Fresh seasonal flower";
            // 
            // tb_number
            // 
            this.tb_number.Location = new System.Drawing.Point(460, 37);
            this.tb_number.Name = "tb_number";
            this.tb_number.Size = new System.Drawing.Size(63, 25);
            this.tb_number.TabIndex = 2;
            this.tb_number.Text = "1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(529, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(116, 29);
            this.button1.TabIndex = 3;
            this.button1.Text = "Add to cart";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(74, 66);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // MessageItem
            // 
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tb_number);
            this.Controls.Add(this.lb_fresh);
            this.Controls.Add(this.lb_descript);
            this.Controls.Add(this.lb_flower_name);
            this.Name = "MessageItem";
            this.Size = new System.Drawing.Size(664, 105);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        // Add Cart

        // button 
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
