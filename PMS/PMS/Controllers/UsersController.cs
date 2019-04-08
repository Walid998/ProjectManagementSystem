using PMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class UsersController : Controller
    {
        pmsEcommerceEntities db = new pmsEcommerceEntities();
        // GET: Users
        
        public ActionResult ListAllUsers()
        {
            var usr = getUsers();
            return View(usr);
        }

        public IEnumerable<user> getUsers()
        {
            var usrs = db.users.ToList();
            return usrs;
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            var usrTyps = db.userTypes.ToList();
            UserTypes ut = new UserTypes
            {
                UsrTypes = usrTyps
            };
            return View(ut);
        }
        [HttpPost]
        public ActionResult AddUser(UserTypes uts)
        {
            db.users.Add(uts.users);
            db.SaveChanges();
            return RedirectToAction("ListAllUsers");
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var usr = db.users.SingleOrDefault(x => x.id == id);
            return View(usr);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            var usr = db.users.SingleOrDefault(x => x.id == id);
            return View(usr);
        }

        [HttpPost]
        public ActionResult Delete(user usr)
        {
            var us = db.users.SingleOrDefault(x => x.id == usr.id);
            db.users.Remove(us);
            db.SaveChanges();
            return RedirectToAction("ListAllUsers");
        }

    }
}