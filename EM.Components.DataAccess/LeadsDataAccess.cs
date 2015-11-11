using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Components.Entities;

namespace EM.Components.DataAccess
{
    public class LeadsDataAccess : BaseDataAccess, IEntityDataService<EM_Leads>
    {
        public LeadsDataAccess() : base() { }


        public List<EM_Leads> GetAll()
        {
            var leads = from l in base.Ctx.EM_Leads
                        orderby l.LastName
                        select l;
            return leads.ToList<EM_Leads>();
        }

        public EM_Leads Get(int entityId)
        {
            ValidateEntityId(entityId);
            EM_Leads lead = null;
            try
            {
                lead = base.Ctx.EM_Leads.First<EM_Leads>(l => l.LeadID == entityId);
            }
            catch
            {
                // ignore
            }
            return lead;
        }

        public EM_Leads Update(EM_Leads entity)
        {
            ValidateNull<EM_Leads>(entity);
            ValidateEntityId(entity.LeadID);
            var lead = Get(entity.LeadID);
            lead.FirstName = entity.FirstName;
            lead.LastName = entity.LastName;
            lead.EmailAddress = entity.EmailAddress;
            lead.IsValid = entity.IsValid;
            lead.Unsubscribed = entity.Unsubscribed;
            base.Ctx.SaveChanges();
            return Get(entity.LeadID);
        }

        public EM_Leads Add(EM_Leads entity)
        {
            ValidateNull<EM_Leads>(entity);
            entity.LeadID = 0;
            base.Ctx.EM_Leads.Add(entity);
            base.Ctx.SaveChanges();
            var lead = (from l in base.Ctx.EM_Leads
                        where l.EmailAddress == entity.EmailAddress
                        select l).First<EM_Leads>();
            return lead;
        }

        public void Delete(EM_Leads entity)
        {
            ValidateNull<EM_Leads>(entity);
            ValidateEntityId(entity.LeadID);
            Delete(entity.LeadID);
        }

        public void Delete(int entityId)
        {
            ValidateEntityId(entityId);
            var entity = Get(entityId);
            if (entity == null)
            {
                throw new ArgumentException("Entity Doesn't exist",
                entity.GetType().ToString() + " entity Id " + entity.LeadID);
            }
            else
            {
                base.Ctx.EM_Leads.Remove(entity);
                base.Ctx.SaveChanges();
            }
        }

        #region public methods
        public EM_Leads Get(string email)
        {
            EM_Leads lead = null;
            try
            {
                lead = (from l in base.Ctx.EM_Leads
                        where l.EmailAddress == email
                        select l).First<EM_Leads>();
            }
            catch (Exception ex)
            {
                //handle exception
            }
            return lead;
        }
        #endregion
    }
}
