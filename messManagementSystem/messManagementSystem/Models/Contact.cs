using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace messManagementSystem.Models
{
    [Table("Contats")]
    public class Contact
    {
        [Key]
        public long CommentId { get; set; }

        public string Email { get; set; }

        public string Comment { get; set; }

        public byte status { get; set; }

        public DateTime lastUpdatedDate { get; set; }

    }
}