using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMSProject.Shared
{
    public class Item
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        //[Column(TypeName ="decimal(18,2")]  
        //public decimal Ammount { get; set; }    
        //[Column(TypeName = "decimal(18,2")]
        //public decimal Quantity { get; set;}
        public int SellingPrice { get; set; }
        public int Ammount { get; set; }
        public int Quantity { get; set; }
        public Category? Category { get; set; }
        public int CategoryId { get; set; }
        public Unit? Unit { get; set; }
        public int UnitId { get; set; }
    }
}
