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
            services.AddScoped<IHealthReportRepository, HealthReportRepository>();
            services.AddScoped<IHealthReportTypesRepository, HealthReportTypesRepository>();
            services.AddScoped<INotificationRepository, NotificationRepository>();
            services.AddScoped<INotificationTypesRepository, NotificationTypesRepository>();
            services.AddScoped<IPatientRepository, PatientRepository>();
            services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();
            services.AddScoped<ISubscriptionTypeRepository, SubscriptionTypeRepository>();

            //Services
            services.AddScoped<IHealthReportServices, HealthReportServices>();
            services.AddScoped<IHealthReportTypesServices, HealthReportTypesServices>();
            services.AddScoped<INotificationServices, NotificationServices>();
            services.AddScoped<INotificationTypesServices, NotificationTypesServices>();
            services.AddScoped<IPatientServices, PatientServices>();
            services.AddScoped<ISubscriptionServices, SubscriptionServices>();
            services.AddScoped<ISubscriptionTypeServices, SubscriptionTypeServices>();

        }
    }
}
