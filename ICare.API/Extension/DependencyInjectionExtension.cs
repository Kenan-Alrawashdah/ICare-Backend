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
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<IDeliveryRepository, DeliveryRepository>();
            services.AddScoped<IDrugCategoryRepository, DrugCategoryRepository>();
            services.AddScoped<IDrugRepository, DrugRepository>();
            services.AddScoped<IOrderDrugsRepository, OrderDrugsRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();

            //Services
            services.AddScoped<ICartService, CartService>();
            services.AddScoped<IDeliveryService, DeliveryService>();
            services.AddScoped<IOrderDrugsService, OrderDrugsService>();
            services.AddScoped<IDrugCategoryService, DrugCategoryService>();
            services.AddScoped<IDrugService, DrugService>();
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
