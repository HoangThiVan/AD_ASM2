using ASM2_CodeFirst.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASM2_CodeFirst.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        public ActionResult Index()
        {
            return View();
        }

        //hieenr thij usercourse
        [CustomAuthorize(Roles ="Trainee")]
        public ActionResult YourCouse()
        {

            //laays user ddawng nhaapj
            var userID = User.Identity.GetUserId();
            var usercourse = context.UserCourses.Where(x => x.UserID == userID).ToList();

            // IEnumerable<Enrollment> enrollment = context.Enrollments
            //   .Where(c => c.UserId == userID).ToList();
            return View(usercourse);

            // return View();
        }

        //hien thi usertopic
        [CustomAuthorize(Roles ="Trainer")]
        public ActionResult YourTopic()
        {

            //laays user ddawng nhaapj
            var userID = User.Identity.GetUserId();
            var usertopic = context.UserTopics.Where(x => x.UserID == userID).ToList();

            // IEnumerable<Enrollment> enrollment = context.Enrollments
            //   .Where(c => c.UserId == userID).ToList();
            return View(usertopic);

            // return View();
        }

        //hien thi userclass
        public ActionResult YourClass()
        {

            //laays user ddawng nhaapj
            var userID = User.Identity.GetUserId();
            var userclass = context.UserClasses.Where(x => x.UserID == userID).ToList();

            // IEnumerable<Enrollment> enrollment = context.Enrollments
            //   .Where(c => c.UserId == userID).ToList();
            return View(userclass);

            // return View();
        }

        [CustomAuthorize(Roles ="Admin")]
        public ActionResult ListUser(string id, string searchString, string sortOrder, string currentFilter)
        {

            ViewBag.FullNameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var users = from s in context.Users
                        select s;
            switch (sortOrder)
            {
                case "name_desc":
                    users = users.OrderByDescending(s => s.FullName);
                    break;

                default:
                    users = users.OrderBy(s => s.FullName);
                    break;
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                users = users.Where(s => s.FullName.Contains(searchString));

            }

            ViewBag.CurrentFilter = searchString;
            return View(users);

        }



        [CustomAuthorize(Roles ="Admin,Training Staff")]
        public ActionResult ListCourse(string id, string searchString, string sortOrder, string currentFilter)
        {

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var courses = from s in context.Courses
                          select s;
            switch (sortOrder)
            {
                case "name_desc":
                    courses = courses.OrderByDescending(s => s.Name);
                    break;

                default:
                    courses = courses.OrderBy(s => s.Name);
                    break;
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                courses = courses.Where(s => s.Name.Contains(searchString));

            }

            ViewBag.CurrentFilter = searchString;
            return View(courses);

        }
        [CustomAuthorize(Roles ="Admin, Training Staff")]
        public ActionResult ListTopic(string id, string searchString, string sortOrder, string currentFilter)
        {

            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";

            var topics = from s in context.Topics
                         select s;
            switch (sortOrder)
            {
                case "name_desc":
                    topics = topics.OrderByDescending(s => s.Name);
                    break;

                default:
                    topics = topics.OrderBy(s => s.Name);
                    break;
            }
            if (!String.IsNullOrEmpty(searchString))
            {
                topics = topics.Where(s => s.Name.Contains(searchString));

            }

            ViewBag.CurrentFilter = searchString;
            return View(topics);

        }

       

    }

}