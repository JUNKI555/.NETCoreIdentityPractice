using System;
using System.Text;

namespace DotNETCoreIdentityPractice.Models.Core
{
    /// <summary>Aprication Base Congifurations</summary>
    public class AppConfiguration
    {
        public static AppConfiguration Current { get; private set; }

        public AppConfiguration()
        {
            Current = this;
        }

        // RDB Settings
        public string ProviderName { get; set; }
        public string ConnectionString { get; set; }

        // Redis Settings
        public string RedisConnectionString { get; set; }
        private readonly TimeSpan _defaultExpiry = TimeSpan.FromHours(12);
        public TimeSpan DefaultExpiry => _defaultExpiry;
    }
}
