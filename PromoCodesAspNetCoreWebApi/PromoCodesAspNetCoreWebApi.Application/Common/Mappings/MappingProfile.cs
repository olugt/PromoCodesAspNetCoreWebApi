using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace PromoCodesAspNetCoreWebApi.Application.Common.Mappings
{
    /// <summary>
    /// Typical AutoMapper mapping profile that can be used to apply mappings for mapping profiles in this assembly.
    /// </summary>
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// Applies mapping for mappingg profiles in this assembly.
        /// </summary>
        /// <param name="assembly">The assembly.</param>
        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);
                var methodInfo = type.GetMethod(nameof(IMapFrom<object>.Mapping));
                methodInfo?.Invoke(instance, new object[] { this });
            }
        }
    }
}
