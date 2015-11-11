using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Components.DataAccess;
using EM.Components.Entities;

namespace EM.Components.Business
{
    public class CampaignProvider
    {
        private CampaignDataAccess _da;
        public CampaignProvider()
        {
            _da = new CampaignDataAccess();
        }
        /// <summary>
        /// Get all campaign list
        /// </summary>
        /// <returns></returns>
        public List<EM_Campaigns> GetAll()
        {
            return _da.GetAll();
        }
        /// <summary>
        /// Get active campaign list
        /// </summary>
        /// <returns></returns>
        public List<EM_Campaigns> GetActive()
        {
            var all = GetAll();
            var active = from c in all
                         where c.Approved == true
                         orderby c.StartDate descending
                         select c;
            return active.ToList<EM_Campaigns>();
        }
        /// <summary>
        /// Get pending approval list.
        /// </summary>
        /// <returns></returns>
        public List<EM_Campaigns> GetPending()
        {
            var all = GetAll();
            var pending = from c in all
                          where c.Submitted == true && c.Approved != true
                          orderby c.StartDate descending
                          select c;
            return pending.ToList<EM_Campaigns>();
        }
        public List<EM_Campaigns> GetDraft()
        {
            var all = GetAll();
            var draft = from c in all
                        where c.Submitted != true
                        select c;
            return draft.ToList<EM_Campaigns>();
        }
        public EM_Campaigns Get(int entityId)
        {
            return _da.Get(entityId);
        }
        /// <summary>
        /// Add a new campaign.
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public EM_Campaigns Add(EM_Campaigns entity)
        {
            if (_da.Get(entity.CampaignName) != null)
            {
                throw new ApplicationException("Campaign Name must be unique. " +
                entity.CampaignName + " is already used.");
            }
            return _da.Add(entity);
        }
        public EM_Campaigns Update(EM_Campaigns entity)
        {
            return _da.Update(entity);
        }
        public void Submit(EM_Campaigns entity)
        {
            Submit(entity.CampaignID);
        }
        public void Submit(int entityId)
        {
            var entity = Get(entityId);
            entity.Submitted = true;
            Update(entity);
        }
        public void Approve(int entityId, string user)
        {
            // Update campaign status
            var entity = Get(entityId);
            entity.Approved = true;
            //entity.ApprovedBy = user;
            entity.ApprovedDate = DateTime.Now;
            Update(entity);
            // Populate campaign list
            // Create a task
            Task t = new Task(() =>
            {
                _da.CreateCamapignInstances(entity.EM_EmailInstances.FirstOrDefault<EM_EmailInstances>().EmailInstanceID);
            }
            );
            // run task in parallel
            t.Start();
        }
        public void Delete(EM_Campaigns entity)
        {
            Delete(entity.CampaignID);
        }
        public void Delete(int entityId)
        {
            _da.Delete(entityId);
        }

        public EM_CampaignInstances GetInstance(int instanceId)
        {
            return _da.GetInstance(instanceId);
        }
        public void SetIsSent(EM_CampaignInstances i)
        {
            _da.UpdateIsSent(i);
        }
        public List<EM_CampaignInstances> GetInstances(int emailInstanceID)
        {
            return _da.GetInstances(emailInstanceID);
        }
        /// <summary>
        /// Track campaign view for a given instance
        /// </summary>
        /// <param name="guid"></param>
        public void TrackCampaignView(string guid)
        {
            try
            {
                _da.UpdateCampaignInstanceEvent(guid, 1, "Y", DateTime.Now);
            }
            catch
            {
                // should keep application running.
            }
        }
    }
}
