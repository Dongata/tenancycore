using Models.Abstractions;
using System;

namespace Models
{
    public class Tenant : BaseDomainEntity
    {
        #region Consturtor

        /// <summary>
        /// Ef pruposes only
        /// </summary>
        protected Tenant() { }

        public Tenant(Guid id, string createdBy) : base(id, createdBy)
        {
        }

        
        public Tenant(Guid id, string createdBy, TenantConfiguration configuration) : this(id, createdBy)
        {
            Configuration = configuration;
        }

        #endregion

        #region Properties

        public TenantConfiguration Configuration { get; }

        #endregion
    }
}
