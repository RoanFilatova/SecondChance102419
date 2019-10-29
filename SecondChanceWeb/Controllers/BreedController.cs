using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessLogicLayer;

namespace SecondChanceWeb.Controllers
{
    public class BreedController : Controller
    {
        public ActionResult Page(int PageNumber, int PageSize)
        {
            ViewBag.PageNumber = PageNumber;
            ViewBag.PageSize = PageSize;
            List<BreedBLL> Model = new List<BreedBLL>();
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    ViewBag.TotalCount = ctx.BreedObtainCount(0,25);
                    Model = ctx.BreedGetAll(PageNumber * PageSize, PageSize);
                }return View("Index", Model);
            }catch(Exception ex)
            {
                Logger.Logger.Log(ex);
                    return View("Error");
            }
        }
        // GET: Breed
        public ActionResult Index()
        {
            try
            {
                List<BreedBLL> items = null;
                using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
                {
                    items = ctx.BreedGetAll(0, 25);
                }

                return View(items);
            }catch(Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error");
            }
        }

        // GET: Breed/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                BreedBLL it = null;
                using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
                {
                    it = ctx.BreedFindByID(id);
                }
                return View(it);
            }catch(Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error");
            }
        }

        // GET: Breed/Create
        public ActionResult Create()
        {
            try
            {
                BreedBLL data = new BreedBLL();
                return View(data);
            }catch(Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error");
            }
        }

        // POST: Breed/Create
        [HttpPost]
        public ActionResult Create(BreedBLL breed)
        {
            try
            {
                // TODO: Add insert logic here
                using(BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
                {
                    ctx.BreedCreate(breed.BreedName);
                }
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error");
            }
        }

        // GET: Breed/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                BreedBLL it = null;
                using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
                {
                    it = ctx.BreedFindByID(id);
                }
                return View("Edit");
            }catch(Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error");
            }
        }

        // POST: Breed/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BreedBLL edit)
        {
            try
            {using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
                    ctx.BreedUpdateJust(id, edit.BreedName);
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error");
            }
        }

        // GET: Breed/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
                {
                    ctx.BreedFindByID(id);
                }
                return View();
            }catch(Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error");
            }
        }

        // POST: Breed/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, BreedBLL delete)
        {
            try
            {
                // TODO: Add delete logic here
                using(BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
                {
                    ctx.BreedDelete(id);
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
