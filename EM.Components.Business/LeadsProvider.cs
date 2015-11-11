using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Components.DataAccess;
using EM.Components.Entities;

namespace EM.Components.Business
{
    public class LeadsProvider
    {
        private LeadsDataAccess _da;
        public LeadsProvider()
        {
            _da = new LeadsDataAccess();
        }

        /// <summary>
        /// Add Leads
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public EM_Leads Add(EM_Leads entity)
        {
            EM_Leads result = null;
            var lead = _da.Get(entity.EmailAddress);
            if (lead != null)
            {
                throw new ArgumentException("Entity already exists. entity ID is " +
                entity.LeadID.ToString(), "entity");
            }
            else
            {
                result = _da.Add(entity);
            }
            return result;
        }
        public List<EM_Leads> GetAll()
        {
            return _da.GetAll();
        }
        public EM_Leads Get(int entityId)
        {
            return _da.Get(entityId);
        }
        public EM_Leads Update(EM_Leads entity)
        {
            EM_Leads result = null;
            var lead = Get(entity.LeadID);
            if (lead != null)
            {
                result = _da.Update(entity);
            }
            return result;
        }
        public void Delete(int entityId)
        {
            _da.Delete(entityId);
        }

    }
}
