using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace messManagementSystem.Models
{
    [Table("DailyMess")]
    public class DailyMess
    {

        [Key]
        public int dailyMessID { get; set; }

        [ForeignKey("customer")]
        public long custId { get; set; }
        public virtual Customer customer { get; set; }

        [Required(ErrorMessage="Mess custmer Name is Required")]
        public string custMessName { get; set; }

        public DateTime lunchDateTime { get; set; }

        public byte status { get; set; }

        public DateTime lastUpdateDate { get; set; }

       public string abc { get; set; }


    }
}