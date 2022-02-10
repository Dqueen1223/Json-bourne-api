﻿using Catalyte.Apparel.Providers.Interfaces;
using Catalyte.Apparel.Providers.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace Catalyte.Apparel.Providers
{
    /// <summary>
    /// This class provides configuration options for provider services.
    /// </summary>
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddProviders(this IServiceCollection services)
        {
            services.AddScoped<IProductProvider, ProductProvider>();
            services.AddScoped<IPurchaseProvider, PurchaseProvider>();
            services.AddScoped<IUserProvider, UserProvider>();
            services.AddScoped<IReviewProvider, ReviewsProvider>();
            services.AddScoped<IPromoProvider, PromoProvider>();

            return services;
        }
    }
}
