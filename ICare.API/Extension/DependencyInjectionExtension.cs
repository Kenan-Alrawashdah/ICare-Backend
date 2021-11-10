using ICare.Core.Data;
using ICare.Core.ICommon;
using ICare.Core.IRepository;
using ICare.Core.IServices;
using ICare.Infra.Common;
using ICare.Infra.Repository;
using ICare.Infra.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ICare.API.Extension
{
    public static class DependencyInjectionExtension
    {

        public static void DependencyInjection(this IServiceCollection services)
        {

            //DbContext
            services.AddScoped<IDbContext, DbContext>();

            //Repository

            services.AddScoped<ICRUDRepository<PatientDrugs>, PatientDrugsRepository>(); //emad
            services.AddScoped<ICRUDRepository<ScheduleEnum>, ScheduleEnumRepository>(); //emad
            services.AddScoped<ICRUDRepository<DrugDoseTime>, DrugDoseTimeRepository>(); //emad

            //Services
            services.AddScoped<ICRUDServices<DrugDoseTime>, DrugDoseTimeServices>();


        }
    }
}
