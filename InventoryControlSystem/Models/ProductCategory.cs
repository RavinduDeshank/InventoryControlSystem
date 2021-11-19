using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace InventoryControlSystem.Models
{
    public class ProductCategory
    {
        [Key]
        public int CategoryId { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string CategoryName { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string CategoryDiscription { get; set; }
    }
}
