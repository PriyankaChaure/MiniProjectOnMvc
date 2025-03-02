﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiniProjectMVC.Models
{
    [Table("Subject")]
    public class Subject
    {
        [Key]
        public Int64 SubjectId { get; set; }
        public string SubjectName { get; set; }
        public virtual List<Book> Books { get; set; }

    }
}