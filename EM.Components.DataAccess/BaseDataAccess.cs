using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using EM.Components.Entities;
namespace EM.Components.DataAccess
{
    public class BaseDataAccess
    {
        #region variables
        private EMEntities _ctx;
        protected EMEntities Ctx
        {
            get { return _ctx; }
            set { _ctx = value; }
        }
        #endregion
        public BaseDataAccess()
        {
            _ctx = CreateDataContext();
        }
        public EMEntities CreateDataContext()
        {
            var ctx = new EMEntities();
            return ctx;
        }
        /// <summary>
        /// Validate entity Id. Throw exception is entity Id is less than 1.
        /// </summary>
        /// <param name="entityId"></param>
        public void ValidateEntityId(int entityId)
        {
            if (entityId < 1)
                throw new ArgumentNullException("int entityId", "entity id must be greater than 0");
        }
        public void ValidateNull<T>(T entity)
        {
            if (entity == null)
                throw new ArgumentNullException(typeof(T).ToString() + " entity", "entity should not be null.");
        }
    }
}
