using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASM2_CodeFirst.Models
{
    public class UserClass
    {
        [Key]
        [Column(Order = 1)]
        public string UserID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ClassID { get; set; }
        public virtual Class Class { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}