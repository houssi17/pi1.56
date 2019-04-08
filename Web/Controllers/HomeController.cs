using Domain.Entities;
using Microsoft.AspNet.Identity;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        UserService us = new UserService();



        public PartialViewResult Userco()
        {

            int currentUserId = 0;
            if (User.Identity.GetUserId() != "")
            {
                currentUserId = Int32.Parse(User.Identity.GetUserId());

            }

            var cuser = new User();
            if (us.GetById(currentUserId) != null)
            {
                cuser = us.GetById(currentUserId);

            }

            User u = new User();
            u.Id = cuser.Id;
            u.img = cuser.img;
            u.firstname = cuser.firstname;
            List<User> listuser = new List<User>();
            listuser.Add(u);
            return PartialView(listuser);




        }
        public ActionResult Index()
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            if (User.IsInRole("Team Leader"))
            {
                return RedirectToAction("DisplayTeamLeader", "Home");
            }
            else if (User.IsInRole("Team Member"))
            {
                return RedirectToAction("DisplayTeamLeader","Home");
            }
            else if (User.IsInRole("Admin"))
            {


                return RedirectToAction("Users", "Home");
            }
          
            return View();
        }



        //profil de l'utilisateur
        //Get: /User/id
        public ActionResult Profil(int id)
        {
            var req = us.GetById(id);
           

            return View(req);
        }



        //liste des utilisateur(admin)
        //get: /Home/Users


        public ActionResult Users()
        {

            //redirect to login if not connected
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            //redirect to nowhere if not admin
            if (!(User.IsInRole("Admin")))
            {
                return RedirectToAction("Nowhere", "Account");


            }
           

            return View(us.noadmin().ToList());
        }


        //delete User 
        public ActionResult Delete(int id)
        {
            //redirect to login
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            //redirect to nowhere if not admin
            if (!(User.IsInRole("Admin")))
            {
                return RedirectToAction("Nowhere", "Account");


            }
            User user = us.GetById(id);
            us.Delete(user);
            us.Commit();
            return RedirectToAction("Index");
        }


        //Update a User View

        public ActionResult Edit(int id )
        {
            if (!Request.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            //redirect to nowhere if not admin
            if (!(User.IsInRole("Admin")))
            {
                return RedirectToAction("Nowhere", "Account");


            }

            User user = us.GetById(id);
            RegisterViewModel rvm = new RegisterViewModel();
            rvm.PhoneNumber = user.PhoneNumber;
            rvm.firstname = user.firstname;
            rvm.Email = user.Email;
            rvm.lastname = user.lastname;
            rvm.Password = user.PasswordHash;

            return View(rvm);


        }


        //update User for real 
        [HttpPost]
        public ActionResult Edit(int id, RegisterViewModel rvm)
        {

            User user = us.GetById(id);

            user.PhoneNumber = rvm.PhoneNumber;
            user.firstname = rvm.firstname;
            user.Email = rvm.Email;
            user.UserName=rvm.Email;
            user.lastname = rvm.lastname;
            user.PasswordHash = rvm.Password;

            us.Update(user);
            us.Commit();
            return RedirectToAction("Users");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult DisplayManager()
        {
            ProjectServices ps = new ProjectServices();
            var getAll = ps.GetAll();
            return View(getAll);
        }


        public ActionResult DisplayTeamLeader()
        {

            return View();
        }
        //public ActionResult CreateTeam()
        //{ TeamService tm = new TeamService();
        //    List<TeamViewModel> lTVM = new List<TeamViewModel>();
        //    var pip = tm.GetAll();
        //        foreach (var item in pip)
        //    {
        //        TeamViewModel Tvm = new TeamViewModel();
        //        Tvm.TeamName = item.TeamName;
                
        //        Tvm.TeamLeaderFK = item.TeamLeaderFK;
        //    }
        //}
    }
}