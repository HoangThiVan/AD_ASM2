using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASM2_CodeFirst.Models
{
    public class Class
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<UserClass> UserClasses { get; set; }
    }
}