using System;
using System.Collections.Generic;
using System.Text;
using Vital_Repository.Interface;
using Vital_Repository.Implementation;
using Microsoft.Extensions.DependencyInjection;

namespace Vital_BusinessLogic
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection RegisterBusinessDependencies(this IServiceCollection services)
        {
            services.AddTransient<IVitalRepository, VitalRepository>();
            services.AddTransient<IPatientVisitRepository, PatientVisitRepository>();
            return services;
        }
    }
}
