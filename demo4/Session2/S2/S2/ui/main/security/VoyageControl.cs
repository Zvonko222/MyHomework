using S2.controls;
using S2.data.db.model;
using S2.data.models;
using S2.util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace S2.ui.main.security
{
    public partial class VoyageControl : UserControl
    {
        private VoyageRow item;
        private SecurityCheckControl parent;

        public VoyageControl(SecurityCheckControl parent, VoyageRow item)
        {
            InitializeComponent();
            this.parent = parent;
            this.item = item;
            label1.Text = "Voyage Number: " + item.number;
            lb_container_count_x.Text = "Container Count:" + item.containerCount;
            lb_date_of_arrival_xxxx_xx_xx.Text = "Date of arrival:" + item.arrivalTime.ToString("yyyy-MM-dd");
            setSelectedCard(false);


            Click += (s, e) => echoParent(); 
            
        }

        private void echoParent()
        {
            string number = item.number;
            parent.echoParentVoyage(this,number);
        }

        public void setSelectedCard(bool selected)
        {

            BackColor = selected ? Color.Teal : SystemColors.Control;
            label1.ForeColor = selected ? Color.White : SystemColors.ControlText;
            lb_container_count_x.ForeColor = selected ? Color.White : SystemColors.ControlText;
            lb_date_of_arrival_xxxx_xx_xx.ForeColor = selected ? Color.White : SystemColors.ControlText;
        }
    }
}
