using HitExercise.DataAccess.Core.Entities;
using HitExercise.DataAccess.Core.Interfaces;
using HitExercise.MVC.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HitExercise.MVC.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly IDataAccess _dataAccess;

        public AccountController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        
        public ActionResult Login()
        {
            //Return the Login view for log in
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserViewModel userViewModel)
        {
            if (ModelState.IsValid)
            {
                bool IsValidUser = _dataAccess.Users.GetAll().Any(u=>u.UserName == userViewModel.UserName && u.Password==userViewModel.Password);
            
                if (IsValidUser)
                {
                    //if the user credentials matches a user in DB then we log him in
                    FormsAuthentication.SetAuthCookie(userViewModel.UserName, false);
                    return RedirectToAction("Index","Suppliers");
                }
                else
                {
                    
                    userViewModel.ErrorMessage="Invalid User Name or Password";
                    return View(userViewModel);
                }
            }
            else
            {
                return View();
            }
        }

        
        public ActionResult Logout()
        {
            //action for the user to log out
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }

    }
}