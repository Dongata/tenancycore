using Microsoft.AspNetCore.Http;
using System;
using System.Text.RegularExpressions;

namespace Core.Middlewares.Configuration
{
    public class RouteTenantCatchingStrategy : ITenantCatchingStrategy
    {
        private readonly Regex _guidDefinition = new Regex("(([0-9A-Fa-f]){8})-(([0-9A-Fa-f]{4}-){3})(([0-9A-Fa-f]){12})");
        private readonly Regex _startingPoint;

        public RouteTenantCatchingStrategy() : this("\\/Tenant\\/") { }

        public RouteTenantCatchingStrategy(string regexString)
        {
            _startingPoint = new Regex(regexString + _guidDefinition.ToString());
        }

        public Guid? GetTenantId(HttpContext context)
        {
            var uri = context.Request.Path.Value;

            var match = _startingPoint.Match(uri);

            if (match != null && match.Length > 0)
            {
                return new Guid(_guidDefinition.Match(match.Value).Value);
            }

            return null;
        }
    }
}
