using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryControlSystem.Models
{
    public class Product
    {
        [Key]
         public int ProductId { get; set; }

         [Column(TypeName = "nvarchar(100)")]
         public string ProductName { get; set; }

       
         public int ProductCategory { get; set; }

         [Column(TypeName = "nvarchar(100)")]
         public string ProductDiscription { get; set; }

         [Column(TypeName = "nvarchar(100)")]
         public string ProductPrice { get; set; }

         [Column(TypeName = "nvarchar(100)")]
         public string ProductQuantity { get; set; }
    }
}
