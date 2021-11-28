using ASM2_CodeFirst.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ASM2_CodeFirst.Controllers
{
   
    public class RoleController : Controller
    {
        //private ApplicationDbContext db1 = new ApplicationDbContext();
        private ApplicationRoleManager _roleManager;

        public RoleController()
        {
        }

        public RoleController(ApplicationRoleManager userManager, ApplicationRoleManager roleManager)
        {
            RoleManager = roleManager;
           
        }

        public ApplicationRoleManager RoleManager
        {
            get
            {
                return _roleManager ?? HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
            }
            private set
            {
                _roleManager = value;
            }
        }

        // GET: Role
        public ActionResult Index()
        {
            List<RoleViewModel> List = new List<RoleViewModel>();
            foreach (var role in RoleManager.Roles)
            {
                List.Add(new RoleViewModel(role));
            }
            return View(List);
        }
        // GET: Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Role/Create
        [HttpPost]
        public async Task<ActionResult> Create(RoleViewModel model)
        {
            var role = new ApplicationRole() { Name = model.Name };
            await RoleManager.CreateAsync(role);
            return RedirectToAction("Index");


        }

        // GET: Role/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            return View(new RoleViewModel(role));
        }

        //Get:Role/Delete
        public async Task<ActionResult> Delete(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            return View(new RoleViewModel(role));
        }

        //Get: Role/delete còmirm
        public async Task<ActionResult> DeleteComfirm(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            await RoleManager.DeleteAsync(role);
            return RedirectToAction("Index");
        }
        //Role/get/edit

       
        public async Task<ActionResult> Edit(string id)
        {
            var role = await RoleManager.FindByIdAsync(id);
            await RoleManager.UpdateAsync(role);
            return RedirectToAction("Index");
        }

        // GET: Role/Edit/5
        /*
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Role role = db1.Roles.Find(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }
        // POST: CourseCategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] Role role)
        {
            if (ModelState.IsValid)
            {
                db1.Entry(role).State = EntityState.Modified;
                db1.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(role);
        }
        */
    }
}
