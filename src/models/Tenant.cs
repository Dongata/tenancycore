using System;

namespace Models
{
    public class Tenant
    {
        #region Consturtor
        public Tenant(Guid id, TenantConfiguration configuration)
        {
            Id = id;
            Configuration = configuration;
        }

        #endregion

        #region Properties

        public Guid Id { get; set; }

        public TenantConfiguration Configuration {get}

        #endregion
    }
}
