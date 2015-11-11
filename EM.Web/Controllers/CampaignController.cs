using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Principal;
using EM.Components.Business;
using EM.Components.Entities;

namespace EM.Web.Controllers
{
    public class CampaignController : Controller
    {
        CampaignProvider _service;
        public CampaignController()
        {
            _service = new CampaignProvider();
        }

        // GET: /Campaign/
        [HttpGet]
        public ActionResult Edit(int id)
        {
            EM_Campaigns entity = _service.Get(id);
            return View(entity);
        }
        // POST: /Campaign/Edit/
        [HttpPost]
        public ActionResult Edit(EM_Campaigns entityToChange)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    entityToChange.UpdatedBy = WindowsIdentity.GetCurrent().Name;
                    entityToChange.UpdatedDate = DateTime.Now;
                    _service.Update(entityToChange);
                    return RedirectToAction("Edit", "Email", new
                    {
                        id = entityToChange.CampaignID
                    });
                }
            }
            catch
            {
                return View(entityToChange);
            }
            return View(entityToChange);
        }

        // GET: /Campaign/Create
        public ActionResult Create()
        {
            return View("Edit");
        }

        public ActionResult Index()
        {
            var list = new List<EM_Campaigns>();
            // check querystring
            if (Request.QueryString.AllKeys.Contains("status"))
            {
                string status = Request.QueryString["status"];
                switch (status.ToLower())
                {
                    case "active":
                        list = _service.GetActive();
                        break;
                    case "draft":
                        list = _service.GetDraft();
                        break;
                    default:
                        list = _service.GetAll();
                        break;
                }
            }
            else
            {
                list = _service.GetAll();
            }
            return View(list);
        }

        // POST: /Campaign/Create/
        [HttpPost]

        public ActionResult Create(EM_Campaigns campaign)
        {
            try
            {
                // validation
                if (ModelState.IsValid)
                {
                    campaign.Owner = WindowsIdentity.GetCurrent().Name;
                    campaign.CreatedBy = campaign.Owner;
                    campaign.CreatedDate = DateTime.Now;
                    campaign.Guid = Guid.NewGuid();
                    _service.Add(campaign);
                    // redirec to email create/edit page
                    return RedirectToAction("Edit", "Email", new
                    {
                        id = campaign.CampaignID
                    });
                }
            }
            catch { }
            return View("Edit", campaign);
        }

        // GET: /Campaign/Approve/
        public ActionResult Approve()
        {
            var list = _service.GetPending();
            return View(list);
        }
        [HttpPost]
        public ActionResult Approve(string[] SelectedObjectIds)
        {
            if (SelectedObjectIds != null)
            {
                foreach (var id in SelectedObjectIds)
                {
                    _service.Approve(int.Parse(id), User.Identity.Name);
                }
            }
            // redisplay approve page
            var list = _service.GetPending();
            return View(list);
        }

        // GET: /Campaign/Summary
        [HttpGet]
        public ActionResult Summary(int id)
        {
            EM_Campaigns entity = _service.Get(id);
            return View(entity);
        }
        [HttpPost]
        public ActionResult Summary(string button)
        {
            // submit for approval
            int id = int.Parse(button);
            EM_Campaigns entity = _service.Get(id);
            entity.Submitted = true;
            _service.Update(entity);
            return RedirectToAction("Index");
        }
    }
}
