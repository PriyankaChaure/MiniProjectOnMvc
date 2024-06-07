using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiniProjectMVC.Models
{
    [Table("Sales")]
    public class Sales
    {
        [Key]
        public Int64 SalesId { get; set; }
        public Int64 CustomerId { get; set; }
        public DateTime? SalesDate { get; set;}
        public Int64 BookId { get; set; }
        public decimal Price {  get; set; }
        public decimal Qty {  get; set; }
        public virtual Book Book { get; set; }
        public virtual Customer Customer { get; set; }
    }
}