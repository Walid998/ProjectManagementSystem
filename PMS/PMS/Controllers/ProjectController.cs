using PMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PMS.Controllers
{
    public class ProjectController : Controller
    {
        pmsEcommerceEntities1 db = pmsEcommerceEntities1.getInstance();
        // GET: Project

        [Authorize(Roles ="customer")]
        public ActionResult ListProjects()
        {
            var pros = getProjects().Where(x => x.usrname.Equals(User.Identity.Name) && x.stat == "to do");
            var md = getDm().Where(x => x.Role == "MD");
            var Asgn = db.projectAssigns.ToList();
            ProjectAssignment PA = new ProjectAssignment
            {
                mds = md,
                projects = pros,
                projectAsinss = Asgn

            };
            return View(PA);
        }
        public IEnumerable<project> getProjects()
        {
            var pros = db.projects.ToList();
            return pros;
        }

        [HttpGet]
        [Authorize(Roles = "customer")]
        public ActionResult AddProject()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddProject(project pro)
        {
            pro.stat = "to do";
            db.projects.Add(pro);
            db.SaveChanges();
            // this noti for test
            tbl_Notification no = new tbl_Notification
            {
                ExtraColumn = "Y",
                Status = "yes",
                Message = "Customer " + User.Identity.Name + " have been add post"
            };
            db.tbl_Notification.Add(no);
            db.SaveChanges();
            return RedirectToAction("ListProjects");
        }
        [HttpGet]
        public ActionResult DetailsProCust(int id)
        {
            var pro = getProjects().SingleOrDefault(y => y.id == id);
            var mds = db.projectAssigns.ToList().Where(x => x.proId == id);
            ProjectAssignment PA = new ProjectAssignment {
                project = pro,
                projectAsinss = mds
                
            };
            return View(PA);
        }

        [HttpGet]
        public ActionResult DeleteProjectCust(int id)
        {
            var pro = getProjects().SingleOrDefault(y => y.id == id);
            var mds = db.projectAssigns.ToList().Where(x => x.proId == id);
            ProjectAssignment PA = new ProjectAssignment {
                project = pro,
                projectAsinss =mds
            };
            return View(PA);
        }
        [HttpPost]
        public ActionResult DeleteProjectCust(project pro)
        {
            var pros = getProjects().SingleOrDefault(y => y.id == pro.id);
            db.projects.Remove(pros);
            db.SaveChanges();
            return RedirectToAction("ListProjects");
        }
        [HttpGet]
        public ActionResult EditProjectCust(int id)
        {
            var pr = db.projects.Find(id);
            var mds = db.projectAssigns.ToList().Where(x => x.proId == id);
            ProjectAssignment PA = new ProjectAssignment
            {
                project = pr,
                projectAsinss = mds
            };
            return View(PA);
        }
        [HttpPost]
        public ActionResult EditProjectCust(project pro)
        {
            var p = db.projects.SingleOrDefault(x => x.id == pro.id);
            p.name = pro.name;
            p.descrption = pro.descrption;
            db.SaveChanges();
            return RedirectToAction("ListProjects");
        }
        /*********************************************/
        /*************Manage_project_to_create*************/
        public ActionResult manage_project()
        {
            var pros = getProjects().Where(x => x.stat == "to do");
            var mtls = getDm().Where(x=>x.Role == "MTL");
            var mts = getDm().Where(x=>x.Role == "MT");
            CreateProject PA = new CreateProject {
                mtl = mtls,
                mt = mts ,
                projectss = pros
            
            };
            return View(PA);
        }
        [HttpPost]
        public ActionResult manage_project(CreateProject c)
        {
            if (ModelState.IsValid)
            {
                db.CreateProjects.Add(c);
                db.SaveChanges();
                
            }
            return RedirectToAction("ListManageProject");
        }
        public ActionResult ListManageProject()
        {
            var M = getManageProjects();
            return View(M);
        }
        public IEnumerable<CreateProject> getManageProjects()
        {
            var M = db.CreateProjects.ToList();
            return M;
        }
        [HttpGet]
        public ActionResult Details_project(int id)
        {
            var M = getManageProjects().SingleOrDefault(y => y.id == id);
            return View(M);
        }

        [HttpGet]
        public ActionResult DeleteManageProject(int id)
        {
            var M = db.CreateProjects.SingleOrDefault(y => y.id == id);
            return View(M);
        }
        [HttpPost]
        public ActionResult DeleteManageProject(CreateProject pro)
        {
            var M = db.CreateProjects.SingleOrDefault(y => y.id == pro.id);
            db.CreateProjects.Remove(M);
            db.SaveChanges();
            return RedirectToAction("ListManageProject");
        }
        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateProject pro = db.CreateProjects.Find(id);
            if (pro == null)
            {
                return HttpNotFound();
            }
            return View(pro);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public ActionResult EditPost(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var Update = db.CreateProjects.Find(id);
            if (TryUpdateModel(Update, "",
               new string[] { "pro_name", "strt_date", "end_date","stat","price","leader_name" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("ListManageProject");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(Update);
        }

        /*================================== YOUNIS WORK ================================ */
        public ActionResult List_dm()
        {
            var md = getDm().Where(x => x.Role == "MD");
            var pros = db.projects.ToList();
            var Asgn = db.projectAssigns.ToList();
            ProjectAssignment PA = new ProjectAssignment {
                mds = md,
                projects =pros,
                projectAsinss =Asgn

            };
            return View(PA);
        }
        public IEnumerable<user> getDm()
        {
            var usr = db.users.ToList();
            return usr;
        }
        [HttpGet]
        public PartialViewResult Mdir(int id)
        {
            var mds =  db.projectAssigns.ToList().Where(x=>x.proId==id);

            return PartialView("Mdir",mds);
        }
        [HttpPost]
        public ActionResult AssignMD(projectAssign pa)
        {
            if (pa.name_dm == null || pa.name_dm.Equals("Assign MD"))
            {
                return Content("<script language='javascript' type='text/javascript'>alert('MD has not determined !!');window.location.replace('ListProjects');</script>");
            }
            else
            {
                db.projectAssigns.Add(pa);
                db.SaveChanges();
                return RedirectToAction("ListProjects");
            }
        }

        [HttpPost]
        public ActionResult DeleteMDAssign(projectAssign PA)
        {
            var md = db.projectAssigns.SingleOrDefault(x => x.id == PA.id);
            db.projectAssigns.Remove(md);
            db.SaveChanges();
            return RedirectToAction("ListProjects");
        }


        /*-----------------------------------(Nourhan)----------------------------------*/
        /**********************************List project for MTL**********************************/
        public ActionResult layout()  /*******************just for show layout*************/
        {
            return View();
        }

        /*.............................List MTL's Current projects..........................*/
        [HttpGet]
        [Authorize(Roles = "MTL")]
        public ActionResult ListCurrentPMTL()
        {
            var projects = getcurrentProjects().Where(y => y.leader_name.Equals(User.Identity.Name));
            //CurrentPMTL C = new CurrentPMTL {
            //    createProjects = projects
            //};
            return View(projects);
        }

        public IEnumerable<CreateProject> getcurrentProjects()
        {
            var p = db.CreateProjects.ToList().Where(y => y.state == "doing");
            return p;
        }

        public ActionResult Leave(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateProject cp = db.CreateProjects.Find(id);
            if (cp == null)
            {
                return HttpNotFound();
            }

            return View(cp);
        }

        [HttpPost, ActionName("Leave")]
        public ActionResult Confirm(int? id)
        {
            CreateProject cp = db.CreateProjects.Find(id);
            cp.leader_name = "noleader";
            db.Entry(cp).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("ListCurrentPMTL");
        }

        /*.............................List MTL's Pervious projects..........................*/
        [HttpGet]
        [Authorize(Roles = "MTL")]
        public ActionResult ListPerviousPMTL()
        {
            var project = getpervoiusProjects().Where(x => x.leader_name.Equals(User.Identity.Name));
            return View(project);
        }

        public IEnumerable<CreateProject> getpervoiusProjects()
        {
            var p = db.CreateProjects.ToList().Where(y => y.state == "done");
            return p;
        }


        /**********************************List project for MT**********************************/
        public ActionResult layout2()  /*******************just for show layout*************/
        {
            return View();
        }

        /*.............................List MT's Current projects..........................*/
        [HttpGet]
        [Authorize(Roles = "MT")]
        public ActionResult ListCurrentPMT()
        {
            var pro = db.CreateProjects.ToList();
            var tm = db.teams.ToList();


            CurrentPMTL C = new CurrentPMTL
            {
                tms = tm,
                CurPros =pro
            };
            return View(C);
        }

        public IEnumerable<team> getcurrentProject()
        {
            var p = db.teams.ToList().Where(y => y.state == "doing");
            return p;
        }


        /*.............................List MT's Pervious projects..........................*/
        [HttpGet]
        [Authorize(Roles = "MT")]
        public ActionResult ListPerviousPMT()
        {
            var projects = getpervoiusProject().Where(x => x.memUname.Equals(User.Identity.Name));
            return View(projects);
        }

        public IEnumerable<team> getpervoiusProject()
        {
            var p = db.teams.ToList().Where(y => y.state == "done");
            return p;
        }


        /*===============================List project for MD ============================*/
        [HttpGet]
        [Authorize(Roles = "MD")]
        public ActionResult ListMTLProject()
        {
            var cp = db.CreateProjects.ToList();
            return View(cp);
        }



    }

   
}