﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace messManagementSystem.Models
{
    [Table("Temp")]
   public class temp
    {
        [Key]
       public int id { get; set;}
       public string Name { get; set; }

    }
}