using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ASM2_CodeFirst.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Desscription { get; set; }
        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }
        [ForeignKey("CourseCategory")]
        public int CatID { get; set; }

        public virtual CourseCategory CourseCategory { get; set; }
        //topic truy van
        public virtual ICollection<Topic> Topicss { get; set; }
        public virtual ICollection<UserCourse> UserCourses { get; set; }
    }
}