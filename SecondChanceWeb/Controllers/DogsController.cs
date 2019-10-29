using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace SecondChanceWeb.Controllers
{
    public class DogsController : Controller
    {
        public ActionResult Page(int PageNumber, int PageSize)
        {
            ViewBag.PageNumber = PageNumber;
            ViewBag.PageSize = PageSize;
            List<DogBLL> Model = new List<DogBLL>();
            try
            {
                using (ContextBLL ctx = new ContextBLL())
                {
                    ViewBag.TotalCount = ctx.DogObtainCount(0, 25);
                    Model = ctx.DogsGetAll(PageNumber * PageSize, PageSize);
                }
                return View("Index", Model);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error");
            }
        }
        // GET: Dogs
        public ActionResult Index()
        {
            try
            {
                List<DogBLL> items = null;
                using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
                {
                    items = ctx.DogsGetAll(0, 25);
                }
                return View(items);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error");
            }
        }

        // GET: Dogs/Details/5
        public ActionResult Details(int id)
        {
            try
            {
                DogBLL it = null;
                using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
                {
                    it = ctx.DogFindByID(id);
                }
                return View(it);
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error");
            }
        }

        // GET: Dogs/Create
        public ActionResult Create()
        {
            try
            {
                DogBLL data = new DogBLL();
                return View(data);
            }
            catch(Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error");
            }
        }

        // POST: Dogs/Create
        [HttpPost]
        public ActionResult Create(DogBLL dog)
        {
            try
            {
                // TODO: Add insert logic here
                using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
                {
                    ctx.DogCreate(dog.Name, dog.BreedID, dog.IsSmallBreed, dog.IsDogHairless, dog.Medical, dog.AdoptDate, dog.SurrenderDate);
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error", ex);
            }
        }

        // GET: Dogs/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                DogBLL it = null;
                using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
                {
                    it = ctx.DogFindByID(id);
                }
                return View("Edit");
            }
            catch(Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error");
            }
        }

        // POST: Dogs/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, DogBLL edit)
        {
            try
            {
                // TODO: Add update logic here
                using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
                    ctx.DogUpdateJust(id, edit.Name, edit.IsSmallBreed, edit.IsDogHairless, edit.Medical, edit.AdoptDate, edit.SurrenderDate);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error");
            }
        }

        // GET: Dogs/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())
                {
                    ctx.DogFindByID(id);
                }
                return View();
            }
            catch(Exception ex)
            {
                Logger.Logger.Log(ex);
                return View("Error");
            }
        }

        // POST: Dogs/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, DogBLL delete)
        {
            try
            {
                // TODO: Add delete logic here
                using (BusinessLogicLayer.ContextBLL ctx = new BusinessLogicLayer.ContextBLL())

                    ctx.DogDelete(id);

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
