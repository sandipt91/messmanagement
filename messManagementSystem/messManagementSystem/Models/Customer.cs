using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace messManagementSystem.Models
{
    [Table("Customer")]
  [DataContract]
    public class Customer
    {
        [Key]
        [DataMember(IsRequired = true)]
        public long custId { get; set; }

        [Required(ErrorMessage = "First Name Required")]
        [DataMember(IsRequired = true)]
        public string custFirstName { get; set; }

        [Required(ErrorMessage = "Last Name Required")]
        [DataMember(IsRequired = true)]
        public string custLastName { get; set; }

        [Required(ErrorMessage = " Contact No Required")]
        [DataMember(IsRequired = true)]
        public long custContactNo { get; set; }

         [DataMember(IsRequired = true)]
        public string custAddress { get; set; }

        [Required(ErrorMessage = "Email Required")]
        [DataMember(IsRequired = true)]
        public string custEmail { get; set; }

         [DataMember(IsRequired = true)]
        public DateTime joinDate { get; set; }

         [DataMember(IsRequired = true)]
        public DateTime releasedate { get; set; }

         [DataMember(IsRequired = true)]
        public DateTime lastUpdateDate { get; set; }

         [DataMember(IsRequired = true)]
        public byte status { get; set; }

    }
}