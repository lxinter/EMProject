using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EM.Components.Business;
using EM.Components.Entities;

namespace EM.Web.Models
{
    public class LeadsService
    {
        private LeadsProvider _service;
        public LeadsService()
        {
            _service = new LeadsProvider();
        }
        public List<EM_Leads> GetAll()
        {
            return _service.GetAll();
        }
        public EM_Leads Add(EM_Leads entity)
        {
            return _service.Add(entity);
        }
        public EM_Leads Get(int entityId)
        {
            return _service.Get(entityId);
        }
        public EM_Leads Update(EM_Leads entity)
        {
            return _service.Update(entity);
        }
        public void Delete(int entityId)
        {
            _service.Delete(entityId);
        }

    }
}