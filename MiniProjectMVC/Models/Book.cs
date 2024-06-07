using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiniProjectMVC.Models
{
    [Table("Book")]
    public class Book
    {
        [Key]
        public Int64 BookId { get; set; }
        public string BookName { get; set; }
        public string BookDesc { get; set; }
        public Int64 AuthorId { get; set; }
        public Int64 SubjectId { get; set; }
        public decimal Price { get; set; }
        public virtual Author Author { get; set; }
        public virtual Subject Subject { get; set; }
        public virtual List<Sales> Sales { get; set; }
    }
}