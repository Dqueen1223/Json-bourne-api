﻿using Catalyte.Apparel.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;


namespace Catalyte.Apparel.Providers.Interfaces
{
    /// <summary>
    /// This interface provides an abstraction layer for product related service methods.
    /// </summary>
    public interface IPromoProvider
    {
        Task<Promo> CreatePromoAsync(Promo model);

        Task<Promo> GetAllPromosByNameAsync(Promo model);
    }
}
