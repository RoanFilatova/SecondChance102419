using BusinessLogicLayer;
using SecondChanceWeb.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;


namespace SecondChanceWeb.Controllers
{
    [Models.MustBeInRole(Roles = MuhConstants.AdminRoleName)]
    public class RolesController : Controller
    {
        public ActionResult Page(int PageNumber, int PageSize)
        {
            ViewBag.PageNumber = PageNumber;
            ViewBag.PageSize = PageSize;
            List<RoleBLL> Model = new List<RoleBLL>();
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    ViewBag.TotalCount = ctx.RoleObtainCount();
                    Model = ctx.RoleGetAll(PageNumber * PageSize, PageSize);
                }
                return View("Index", Model);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error");
            }
        }
        // GET: Roles
        public ActionResult Index()
        {
            try
            {
                List<RoleBLL> items = null;
                using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
                {
                    items = ctx.RoleGetAll(0, 25);
                }
                return View(items);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error");
            }
        }

        // GET: Roles/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                RoleBLL it = null;
                using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
                {
                    it = ctx.RoleFindByID(id);
                }
                return View(it);
            }catch(Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error");
            }
        }

        // GET: Roles/Create
        public ActionResult Create()
        {
            try
            {
                RoleBLL data = new RoleBLL();
                return View(data);
            }
            catch(Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error");
            }
        }

        // POST: Roles/Create
        [HttpPost]
        public ActionResult Create(RoleBLL Roles)
        {
            try
            {
                // TODO: Add insert logic here
               using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
                {
                    ctx.RoleCreate(Roles.RoleName);
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Index");
            }
        }

        // GET: Roles/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                RoleBLL it = null;
                using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
                {
                    it = ctx.RoleFindByID(id);
                }
                return View("Edit");
            }
            catch(Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error");
            }
        }

        // POST: Roles/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RoleBLL edit)
        {
            try
            {
                using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
                    ctx.RoleUpdateJust(edit.RoleID, edit.RoleName);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Edit");
            }
        }

        // GET: Roles/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                UserBLL it = null;
                using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
                {
                    ctx.RoleFindByID(id);
                }
                return View(it);
            }
            catch(Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error");
            }
        }

        // POST: Roles/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, RoleBLL delete)
        {
            try
            {
                // TODO: Add delete logic here
                using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
                {
                    ctx.RoleDelete(id);
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error");
            }
        }
    }
}
