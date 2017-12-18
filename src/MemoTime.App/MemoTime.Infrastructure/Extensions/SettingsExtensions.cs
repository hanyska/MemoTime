using System;
using Microsoft.Extensions.Configuration;

namespace MemoTime.Infrastructure.Extensions
{
    public static class SettingsExtensions
    {
        public static T GetSettings<T>(this IConfiguration configuration) where T: new()
        {
            var section = typeof(T).Name.Replace("Settings", String.Empty);
            var settings = new T();
            configuration.GetSection(section).Bind(settings);            
            
            return settings;
        }
    }
}