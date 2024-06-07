using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiniProjectMVC.Models
{
    [Table("Author")]
    public class Author
    {
        [Key]
        public Int64 AuthorId { get; set; }
        public string AuthorName { get; set; }
        public virtual List<Book> Books { get; set; }


    }
}