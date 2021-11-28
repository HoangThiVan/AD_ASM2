using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASM2_CodeFirst.Models
{
    public class UserTopic
    {
        [Key]
        [Column(Order = 1)]
        public string UserID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ID { get; set; }
        public virtual Topic Topic { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}