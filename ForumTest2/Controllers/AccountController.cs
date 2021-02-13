using ForumTest2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ForumTest2.Controllers
{
    public class AccountController : Controller
    {
        /// <param name="returnURL"></param>
        /// <returns></returns>
        public ActionResult Login(string returnURL)
        {
            ViewBag.ReturnUrl = returnURL;
            return View(new ApplicationUser());
        }

        /// <param name="login"></param>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(ApplicationUser login, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                using (ManagerContext db = new ManagerContext())
                {
                    var vLogin = db.ApplicationUsers.Where(p => p.Email.Equals(login.Email)).FirstOrDefault();
                    if (vLogin != null)
                    {
                        if (Equals(vLogin.Active, 1))
                        {
                            if (Equals(vLogin.Pass, login.Pass))
                            {
                                FormsAuthentication.SetAuthCookie(vLogin.Email, false);
                                if (Url.IsLocalUrl(returnUrl)
                                && returnUrl.Length > 1
                                && returnUrl.StartsWith("/")
                                && !returnUrl.StartsWith("//")
                                && returnUrl.StartsWith("/\\"))
                                {
                                    return Redirect(returnUrl);
                                }
                                Session["FirstName"] = vLogin.FirstName;
                                Session["LastName"] = vLogin.LastName;
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                ModelState.AddModelError("", "Password wrong!");
                                return View(new ApplicationUser());
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("", "User not found!");
                            return View(new ApplicationUser());
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "Email not found!");
                        return View(new ApplicationUser());
                    }
                }
            }
            return View(login);
        }
    }
}