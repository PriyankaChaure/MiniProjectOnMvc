﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MiniProjectMVC.Models
{
    [Table("Customer")]
    public class Customer
    {
        [Key]
        public Int64 CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerEmail { get; set; }
         public string CustomerPhone { get; set; }
        public virtual List<Sales> Sales { get; set; }

    }
}