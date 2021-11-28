using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASM2_CodeFirst.Models
{
    public class UserCourse
    {
        [Key]
        [Column(Order = 1)]
        public string UserID { get; set; }
        [Key]
        [Column(Order = 2)]
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}