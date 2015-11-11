using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EM.Components.Entities;

namespace EM.Components.DataAccess
{
    public class EmailDataAccess : BaseDataAccess, IEntityDataService<EM_EmailInstances>
    {
        public EmailDataAccess()
            : base()
        {}

        public List<EM_EmailInstances> GetAll()
        {
            var all = from e in base.Ctx.EM_EmailInstances
                      orderby e.CampaignID, e.CreatedDate
                      select e;
            return all.ToList<EM_EmailInstances>();
        }

        public EM_EmailInstances Get(int entityId)
        {
            var all = from e in base.Ctx.EM_EmailInstances
                      orderby e.CampaignID, e.CreatedDate
                      where e.EmailInstanceID == entityId
                      select e;
            return all.FirstOrDefault<EM_EmailInstances>();
        }

        public EM_EmailInstances Update(EM_EmailInstances entity)
        {
            ValidateNull<EM_EmailInstances>(entity);
            ValidateEntityId(entity.EmailInstanceID);
            var e = Get(entity.EmailInstanceID);
            e.EmailBody = entity.EmailBody;
            e.SubjectLine = entity.SubjectLine;
            //e.CreatedBy = entity.CreatedBy;
            //e.CreatedDate = entity.CreatedDate;
            e.EnableTracking = entity.EnableTracking;
            e.IsDraft = entity.IsDraft;
            e.PreviousStep = entity.PreviousStep;
            e.Step = entity.Step;
            e.UpdatedBy = entity.UpdatedBy;
            e.UpdatedDate = entity.UpdatedDate;
            base.Ctx.SaveChanges();
            return entity;
        }

        public EM_EmailInstances Add(EM_EmailInstances entity)
        {
            base.Ctx.EM_EmailInstances.Add(entity);
            base.Ctx.SaveChanges();
            return entity;
        }

        public void Delete(EM_EmailInstances entity)
        {
            Delete(entity.EmailInstanceID);
        }

        public void Delete(int entityId)
        {
           var d = (from e in base.Ctx.EM_EmailInstances
                    where e.EmailInstanceID == entityId
                    select e).FirstOrDefault<EM_EmailInstances>();
           base.Ctx.EM_EmailInstances.Remove(d);
        }

        public List<EM_EmailInstances> GetByCampaign(int campaignId)
        {
            var all = from e in base.Ctx.EM_EmailInstances
                      orderby e.CampaignID, e.CreatedDate
                      where e.CampaignID == campaignId
                      select e;
            return all.ToList<EM_EmailInstances>();
        }
    }
}
