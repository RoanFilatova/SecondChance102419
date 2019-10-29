using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Web.Mvc;


namespace SecondChanceWeb.Controllers
{
    //[SecondChanceWeb.Models.MustBeInRole(Roles = MuhConstants.AdminRoleName)]
    public class UsersController : Controller
    {
        List<SelectListItem> GetRoleItems()
        {
            List<SelectListItem> proposedReturnValue = new List<SelectListItem>();
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    List<RoleBLL> roles = ctx.RoleGetAll(0, 25);
                    foreach (RoleBLL r in roles)
                    {
                        SelectListItem i = new SelectListItem();
                        i.Value = r.RoleID.ToString();
                        i.Text = r.RoleName;
                        proposedReturnValue.Add(i);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
            }
            return proposedReturnValue;
        }
        public ActionResult Page(int PageNumber, int PageSize)
        {
            ViewBag.PageNumber = PageNumber;
            ViewBag.PageSize = PageSize;
            List<UserBLL> Model = new List<UserBLL>();

            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    ViewBag.TotalCount = ctx.UserObtainCount();
                    Model = ctx.UserGetAll(PageNumber * PageSize, PageSize);
                }
                return View("Index", Model);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error");
            }
        }
        // GET: Users
        public ActionResult Index()
        {
            List<UserBLL> items = null;
            try
            {
                using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
                {
                    items = ctx.UserGetAll(0, 25);
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
            }
            return View(items);
        }

        // GET: Users/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                UserBLL it = null;
                using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
                {
                    it = ctx.UserFindByID(id);
                    return View(it);
                }
            }
            catch(Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error");
            }
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            try
            {
                UserBLL data = new UserBLL();
                return View(data);
            }
            catch(Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error");
            }
        }

        // POST: Users/Create
        [HttpPost]
        public ActionResult Create(UserBLL user)
        {
            try
            {
                // TODO: Add insert logic here
                using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
                {
                    ctx.UserCreate(user.UserName, user.Name, user.Address, user.Email, user.Hash, user.Salt, user.RoleID);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error");
            }
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int id)
        {
            UserBLL user;
            try
            {
                using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
                {
                    user = ctx.UserFindByID(id);
                    if (null == user)
                    {
                        return View("Error");
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error");
            }
            ViewBag.Roles = GetRoleItems();
            return View(user);

        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, UserBLL edit)
        {
            try
            {
                using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
                    ctx.UserUpdateJust(id, edit.UserName, edit.Email, edit.Address, edit.Hash, edit.Salt, edit.RoleID);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error");
            }
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
                {
                    ctx.UserFindByID(id);
                }
                return View();
            }
            catch(Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error");
            }
        }

        // POST: Users/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, UserBLL delete)
        {
            try
            {
                using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
                    ctx.UserDelete(id);
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error");
            }
        }
    }
}
