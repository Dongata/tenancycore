using Microsoft.AspNetCore.Http;
using System;

namespace Core.Middlewares.TenantCatching
{
    /// <summary>
    /// Gets the tenant id from a user claim
    /// </summary>
    public class ClaimTenantCatchingStrategy : ITenantCatchingStrategy
    {
        private readonly string _claimType;

        public ClaimTenantCatchingStrategy(string claimType)
        {
            _claimType = claimType;
        }

        /// <summary>
        /// Gets the tenant id from the specified claimtype
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public Guid? GetTenantId(HttpContext context)
        {
            var stringId = context.User.FindFirst(a => a.Type == _claimType)?.Value;

            if (!string.IsNullOrEmpty(stringId))
            {

                if (Guid.TryParse(stringId, out var guid))
                {
                    return guid;
                }
            }

            return null;
        }
    }
}
