using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Components.Entities;

namespace EM.Components.DataAccess
{
    public class CampaignDataAccess : BaseDataAccess, IEntityDataService<EM_Campaigns>
    {
        public CampaignDataAccess()
            : base()
        {
        }
        public EM_Campaigns Get(string name)
        {
            var cc = from c in base.Ctx.EM_Campaigns
                     where c.CampaignName.ToLower() == name.ToLower()
                     select c;
            EM_Campaigns result = null;
            try
            {
                result = cc.FirstOrDefault<EM_Campaigns>();
            }
            catch (Exception ex)
            {

            }
            return result;
        }
        public EM_Campaigns Get(Guid guid)
        {
            var cc = from c in base.Ctx.EM_Campaigns
                     where c.Guid == guid
                     select c;
            EM_Campaigns result = null;
            try
            {
                result = cc.FirstOrDefault<EM_Campaigns>();
            }
            catch (Exception ex)
            {
                // Log exeception
            }
            return result;
        }
        /// <summary>
        /// Create Campaign instances.
        /// </summary>
        /// <param name="emailInstanceID"></param>
        public void CreateCamapignInstances(int emailInstanceID)
        {
            Ctx.EM_CampaignInstances_INSERT(emailInstanceID);
        }
        #region Implement interface
        public List<EM_Campaigns> GetAll()
        {
            var all = from c in base.Ctx.EM_Campaigns
                      orderby c.StartDate descending
                      select c;
            return all.ToList<EM_Campaigns>();
        }
        public EM_Campaigns Get(int entityId)
        {
            ValidateEntityId(entityId);
            var entity = (from c in base.Ctx.EM_Campaigns
                          where c.CampaignID == entityId
                          select c).FirstOrDefault<EM_Campaigns>();
            return entity;
        }
        public EM_Campaigns Update(EM_Campaigns entity)
        {
            ValidateNull<EM_Campaigns>(entity);
            ValidateEntityId(entity.CampaignID);
            var existing = Get(entity.CampaignID);
            existing.CampaignName = entity.CampaignName;
            existing.CampaignDesc = entity.CampaignDesc;
            existing.StartDate = entity.StartDate;
            existing.EndDate = entity.EndDate;
            existing.Submitted = entity.Submitted;
            existing.Approved = entity.Approved;
            //existing.ApprovalRequest = entity.ApprovalRequest;
            existing.Owner = entity.Owner;
            existing.ApprovedBy = entity.ApprovedBy;
            existing.ApprovedDate = entity.ApprovedDate;
            existing.UpdatedBy = entity.UpdatedBy;
            existing.UpdatedDate = entity.UpdatedDate;
            base.Ctx.SaveChanges();
            return entity;
        }
        public EM_Campaigns Add(EM_Campaigns entity)
        {
            ValidateNull<EM_Campaigns>(entity);
            base.Ctx.EM_Campaigns.Add(entity);
            base.Ctx.SaveChanges();
            return entity;
        }
        public void Delete(EM_Campaigns entity)
        {
            ValidateNull<EM_Campaigns>(entity);
            ValidateEntityId(entity.CampaignID);
            Delete(entity.CampaignID);
        }
        public void Delete(int entityId)
        {
            ValidateEntityId(entityId);
            var entity = Get(entityId);
            if (entity == null)
            {
                throw new ArgumentException("Entity Doesn't exist",
                entity.GetType().ToString() + " entity Id " + entity.CampaignID);
            }
            else
            {
                base.Ctx.EM_Campaigns.Remove(entity);
                base.Ctx.SaveChanges();
            }
        }
        #endregion
        /// <summary>
        /// Get all instances for a campaign email
        /// </summary>
        /// <param name="emailInstanceID"></param>
        /// <returns></returns>
        public List<EM_CampaignInstances> GetInstances(int emailInstanceID)
        {
            var query = from i in Ctx.EM_CampaignInstances
                        where i.EmailInstanceID == emailInstanceID
                        select i;
            return query.ToList<EM_CampaignInstances>();
        }
        /// <summary>
        /// Get EM_Campaign instance
        /// </summary>
        /// <param name="instanceID"></param>
        /// <returns></returns>
        public EM_CampaignInstances GetInstance(int instanceID)
        {
            var instance = (from i in Ctx.EM_CampaignInstances
                            where i.CampaignInstanceID == instanceID
                            select i).FirstOrDefault<EM_CampaignInstances>();
            return instance;
        }
        /// <summary>
        /// Mark email as sent
        /// </summary>
        /// <param name="instance"></param>
        public void UpdateIsSent(EM_CampaignInstances instance)
        {
            var i = GetInstance(instance.CampaignInstanceID);
            i.IsSent = true;
            i.UpdatedDate = DateTime.Now;
            Ctx.SaveChanges();
        }
        /// <summary>
        /// Update campaign instance event status
        /// </summary>
        /// <param name="guid"></param>
        public void UpdateCampaignInstanceEvent(string guid, int eventId, string
        eventStatus, DateTime eventDate)
        {
            var query = from i in Ctx.EM_CampaignInstances
                        where i.Guid == new Guid(guid)
                        select i;
            if (query.Count<EM_CampaignInstances>() > 0)
            {
                var i = query.First<EM_CampaignInstances>();
                i.EventID = eventId;
                i.EventStatus = eventStatus;
                i.EventDate = eventDate;
                Ctx.SaveChanges();
            }
        }
    }
}
