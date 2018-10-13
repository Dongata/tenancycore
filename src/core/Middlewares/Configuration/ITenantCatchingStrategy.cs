using Microsoft.AspNetCore.Http;
using System;

namespace Core.Middlewares.Configuration
{
    /// <summary>
    /// Strategy for getting tenant's identifiers from a context
    /// </summary>
    public interface ITenantCatchingStrategy
    {
        /// <summary>
        /// Should return the guid if is encountered
        /// null if not :c
        /// </summary>
        /// <param name="context">scope's context</param>
        /// <returns>A Guid</returns>
        Guid? GetTenantId(HttpContext context);
    }
}
