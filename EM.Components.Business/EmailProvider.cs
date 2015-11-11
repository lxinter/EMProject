using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Components.Entities;
using EM.Components.DataAccess;

namespace EM.Components.Business
{
    public class EmailProvider
    {
        private EmailDataAccess _da;
        public EmailProvider()
        {
            _da = new EmailDataAccess();
        }
        public List<EM_EmailInstances> GetByCampaignId(int campaignId)
        {
            return _da.GetByCampaign(campaignId);
        }
        public EM_EmailInstances Get(int entityId)
        {
            return _da.Get(entityId);
        }
        public EM_EmailInstances Add(EM_EmailInstances entity)
        {
            return _da.Add(entity);
        }
        public EM_EmailInstances Update(EM_EmailInstances entity)
        {
            return _da.Update(entity);
        }
        public void Delete(EM_EmailInstances entity)
        {
            Delete(entity.EmailInstanceID);
        }
        public void Delete(int entityId)
        {
            _da.Delete(entityId);
        }
    }
}
