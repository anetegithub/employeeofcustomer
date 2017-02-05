using DevOne.Security.Cryptography.BCrypt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Action()
        {
            return View();
        }

        [Authorize]
        public ActionResult Auth()
        {
            return View();
        }

        public ActionResult add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult add(User Model)
        {
            var userExist = Model.Linq(db => db.Where(x => x.Login == Model.Login).ToList())
                .Count != 0;
            if (userExist)
                return View(false);

            var pwd = BCryptHelper.HashPassword(Model.Pwd,
                BCryptHelper.GenerateSalt());
            Model.Pwd = pwd;
            
            var Result = Model.Create();
            return View(Result);
        }
    }
}