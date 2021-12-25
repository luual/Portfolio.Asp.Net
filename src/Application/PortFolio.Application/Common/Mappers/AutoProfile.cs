using System;
using System.Linq;
using System.Reflection;
using AutoMapper;

namespace PortFolio.Application.Common.Mappers;

public class AutoProfile : Profile
{
    public AutoProfile()
    {
        ScanAssembly(Assembly.GetExecutingAssembly());
    }

    private void ScanAssembly(Assembly assembly)
    {
        var types = assembly.GetExportedTypes()
            .Where(x => x.GetInterfaces()
                .Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapFrom<>)))
            .ToList();

        foreach (var type in types)
        {
            var instance = Activator.CreateInstance(type);

            var methodInfo = type.GetMethod("Mapping")
                             ?? type.GetInterface("IMapFrom`1")!.GetMethod("Mapping");

            methodInfo?.Invoke(instance, new object[] { this });
        }
    }
}