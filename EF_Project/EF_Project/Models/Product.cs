using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Project.Models
{
    public class Product
    {
        [Key]
        public int ProductID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; } = 0;
        [Required]
        [ForeignKey("Category")]
        public int CategoryID { get; set; }


        public Product Category { get; set; }
    }
}
