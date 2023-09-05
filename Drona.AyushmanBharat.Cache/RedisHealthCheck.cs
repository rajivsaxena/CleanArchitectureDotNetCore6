using Drona.AyushmanBharat.Cache.Interface;
using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Drona.AyushmanBharat.Cache
{
    public class RedisHealthCheck : IHealthCheck
    {
        private IRedisCacheProvider _cacheProvider;
        public RedisHealthCheck(IRedisCacheProvider cacheProvider)
        {
            _cacheProvider = cacheProvider;
        }
        public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
        {
            return _cacheProvider.IsAlive()
                ? Task.FromResult(HealthCheckResult.Healthy("Redis cache Healthy"))
                : Task.FromResult(HealthCheckResult.Degraded("Redis cache Degraded"));
        }
    }
}
