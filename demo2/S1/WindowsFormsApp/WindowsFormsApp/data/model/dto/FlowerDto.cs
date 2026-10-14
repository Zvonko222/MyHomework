using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp.data.model.dto
{
    internal class FlowerDto
    {
        public string flowerName { get; set; }  
        public string category { get; set; }    
        public double price { get; set; }
        public Image image { get; set; }
        
    }
}
