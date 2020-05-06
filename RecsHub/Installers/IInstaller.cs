using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbInstaller.Installers
{
    public interface IInstaller
    {
        void IntallServices(IServiceCollection services, IConfiguration Configuration);
    }
}
