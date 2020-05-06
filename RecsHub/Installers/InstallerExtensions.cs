using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RecsHub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbInstaller.Installers
{
    public static class InstallerExtensions
    {
        public static void InstallServicesInAssembly(this IServiceCollection services, IConfiguration Configuration)
        {
            var installers = typeof(Startup).Assembly.ExportedTypes.Where(c => typeof(IInstaller).IsAssignableFrom(c) && !c.IsInterface && !c.IsAbstract).Select(Activator.CreateInstance).Cast<IInstaller>().ToList();
            installers.ForEach(installer => installer.IntallServices(services, Configuration));

        }
    }
}
