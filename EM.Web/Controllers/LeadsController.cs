using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EM.Components.Entities;
using EM.Web.Models;



namespace EM.Web.Controllers
{
    public class LeadsController : Controller
    {

        private LeadsService _model;
        public LeadsController()
        {
            _model = new LeadsService();
        }
        //
        // GET: /Leads/

        public ActionResult Index()
        {
            return View("index",_model.GetAll());
        }

        // GET: /Leads/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        //
        // POST: /Leads/Create
        [HttpPost]
        public ActionResult Create(EM_Leads lead)
        {
            if (!ModelState.IsValid) return View(lead);
            try
            {
                _model.Add(lead);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(lead);
            }
        }

        //
        // GET: /Leads/Delete/{id}
        //[HttpGet]
        //public ActionResult Delete(int id)
        //{
        //    _model.Delete(id);
        //    return RedirectToAction("Index");
        //}

        public ActionResult Edit(int id)
        {
            EM_Leads leads = _model.Get(id);
            return View(leads);
        }

        [HttpPost]
        public ActionResult Edit(EM_Leads entityToChange)
        {
            try
            {
                // TODO: Add update logic here
                _model.Update(entityToChange);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                
                _model.Delete(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
