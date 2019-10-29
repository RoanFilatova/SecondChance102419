using BusinessLogicLayer;
using SecondChanceWeb.Models;
using System;
using System.Web.Mvc;


namespace SecondChanceWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Us";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact us! The dogs are already wagging their tails in anticipation!";

            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            //empty login screen
            LoginModel m = new LoginModel();
            m.message = TempData["message"]?.ToString() ?? "";
            m.ReturnURL = TempData["ReturnURL"]?.ToString() ?? @"~/Home";
            m.Email = "";
            m.Password = "";
            return View(m);
        }
        [HttpPost]
        public ActionResult Login(LoginModel info)
        {
            //authentication logic
            using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
            {
                BusinessLogicLayer.UserBLL user = ctx.UserFindByEMail(info.Email);
                if (user == null)
                {
                    info.message = $"The username '{info.Email}'is not in the database";
                    return View(info);
                }
                string actual = user.Hash;
                //string potential = info.Password + user.Salt;
                //bool validated user = System.Web.Helpers.Crypto.VerifyHashedPasswords(actual, potential);
                string potential = info.Password;
                string ValidationType = "$ClearText:({user.UserID})";
                bool validateduser = actual == potential;
                {
                    potential = info.Password + user.Salt;
                    try
                    {
                        validateduser = System.Web.Helpers.Crypto.VerifyHashedPassword(actual, potential);
                        ValidationType = $"HASHED:({user.UserID})";
                    }
                    catch (Exception ex)
                    {
                        Logger.Logger.Log(ex);
                        validateduser = false;
                    }
                }
                if (validateduser)
                {
                    Session["AUTHUsername"] = user.Email;
                    Session["AUTHRoles"] = user.RoleID;
                    Session["AUTHTYPE"] = ValidationType;
                    return Redirect(info.ReturnURL);
                }
                info.message = "The username or password was incorrect. Please try again.";
                return View(info);
            }

        }

        [HttpGet]
        public ActionResult Register()
        {
            if (ModelState.IsValid)
                try
                {
                    {
                        RegistrationModel r = new RegistrationModel();
                        r.UserName = "";
                        r.Name = "";
                        r.Address = "";
                        r.Password = "";
                        r.PasswordAgain = "";
                        r.Email = "";
                    }
                }
                catch (Exception ex)
                {
                    Logger.Logger.Log(ex);
                }
            return View();
        }
        [HttpPost]
        public ActionResult Register(RegistrationModel register)
        {
            using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
            {
                BusinessLogicLayer.UserBLL user = ctx.UserFindByEMail(register.Email);
                if (user != null)
                {
                    register.Message = $"The Email address '{register.Email}' has already been registered.";
                    return View(register);
                }
                user = new UserBLL();
                user.UserName = register.UserName;
                user.Name = register.Name;
                user.Address = register.Address;
                user.Email = register.Email;
                user.Salt = System.Web.Helpers.Crypto.GenerateSalt(MuhConstants.SaltSize);
                user.Hash = System.Web.Helpers.Crypto.HashPassword(register.Password + user.Salt);
                user.RoleID = 3;

                ctx.UserCreate(user);
                Session["AUTHUserName"] = user.Email;
                Session["AUTHRoles"] = user.RoleID;
                Session["AUTHTYPE"] = "HASHED";
                return RedirectToAction("Index");
            }
        }
        public ActionResult Hash()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View("NotLoggedIn");
            }
            if (User.Identity.AuthenticationType.StartsWith("HASHED"))
            {
                return View("AlreadyHashed");
            }
            using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
            {
                try
                {
                    BusinessLogicLayer.UserBLL user = ctx.UserFindByEMail(User.Identity.Name);
                    if (user == null)
                    {
                        Exception Message = new Exception($"The UserName '{User.Identity.Name}' doesn't exist in the database.");
                        ViewBag.Exception = Message;
                        return View("Error");
                    }
                    user.Salt = System.Web.Helpers.Crypto.GenerateSalt(MuhConstants.SaltSize);
                    user.Hash = System.Web.Helpers.Crypto.HashPassword(user.Hash + user.Salt);
                    ctx.UserUpdateJust(user);

                    string ValidationType = $"HASHED:({user.UserID})";
                    Session["AUTHUserName"] = user.Email;
                    Session["AUTHRoles"] = user.RoleID;
                    Session["AUTHTYPE"] = ValidationType;
                }
                catch (Exception ex)
                {
                    Logger.Logger.Log(ex);
                }
                return RedirectToAction("Index", "Home");
            }
        }

        public ActionResult Logout()
        {
            try
            {
                Session.Remove("AUTHUserName");
                Session.Remove("AUTHRoles");
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
            }
            return RedirectToAction("Index");
        }
    }
}