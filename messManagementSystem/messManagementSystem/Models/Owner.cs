using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace messManagementSystem.Models
{
    [Table("Owner")]
    public class Owner
    {
        [Key]
        public long ownerId { get; set; }

        public string ownerFirstName { get; set; }

        public string ownerLastNeame { get; set; }

        public string ownerAddress { get; set;} 
        
        public long ownerContactNo { get; set; }

        public string ownerEmail { get; set; }

        //[DisplayName("Upload Image: ")]
        //public HttpPostedFileBase Photo { get; set; }

        public DateTime lastUpdatedDate { get; set; }

        public byte status { get; set; }

      // public string Name { get; set; }

    }
}