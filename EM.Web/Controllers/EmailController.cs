using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Security.Principal;
using EM.Components.Entities;
using EM.Components.Business;
using EM.Web.Code;

namespace EM.Web.Controllers
{
    public class EmailController : Controller
    {

        private EmailProvider _emailService;
        private CampaignProvider _campaignService;
        public EmailController()
        {
            _emailService = new EmailProvider();
            _campaignService = new CampaignProvider();
        }

        // GET: /Email/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Edit/Details
        public ActionResult Details(int id)
        {
            return View();
        }
        //
        // GET: /Edit/Create
        public ActionResult Create()
        {
            return View();
        }
        //
        // POST: /Edit/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        //
        // GET: /Edit/Edit/5
        /// <summary>
        /// Campaign ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Edit(int id)
        {
            EM_EmailInstances currentEmail;
            int campaignId = id;
            var campaign = _campaignService.Get(campaignId);
            ViewData[WebHelper.ViewDataCampaignName] = campaign == null ?
            string.Empty : campaign.CampaignName;
            currentEmail =
            _emailService.GetByCampaignId(campaignId).FirstOrDefault<EM_EmailInstances>();
            return View(currentEmail);
        }
        //
        // POST: /Edit/Edit
        [HttpPost, ValidateInput(false)]
        public ActionResult Edit(int id, EM_EmailInstances email, string button, string
        content)
        {
            // Back
            if (button == "Back")
            {
                return RedirectToAction("Edit", "Campaign", new { id = id });
            }
            // Save and Next
            email.EmailBody = content;
            try
            {
                if (email.EmailInstanceID < 1)
                {
                    // New Email
                    email.CampaignID = id;
                    email.CreatedBy = WindowsIdentity.GetCurrent().Name;
                    email.CreatedDate = DateTime.Now;
                    _emailService.Add(email);
                }
                else
                {
                    //update
                    email.UpdatedBy = WindowsIdentity.GetCurrent().Name;
                    email.UpdatedDate = DateTime.Now;
                    _emailService.Update(email);
                }
                return RedirectToAction("Summary", "Campaign", new { id = id });
            }
            catch
            {
                return View(email);
            }
        }
        //
        // GET: /Edit/Delete
        public ActionResult Delete(int id)
        {
            return View();
        }
        //
        // POST: /Edit/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
