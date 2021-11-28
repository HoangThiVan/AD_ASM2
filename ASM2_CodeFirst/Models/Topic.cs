using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASM2_CodeFirst.Models
{
    public class Topic
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        public DateTime BeginDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime FinishDate { get; set; }

        [ForeignKey("Course")]
        public int CourseID { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<UserTopic> UserTopics { get; set; }
    }
}