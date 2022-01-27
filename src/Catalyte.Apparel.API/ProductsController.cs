﻿using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Catalyte.Apparel.DTOs.Products;
using Catalyte.Apparel.Providers.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Catalyte.Apparel.API.Controllers
{
    /// <summary>
    /// The ProductsController exposes endpoints for product related actions.
    /// </summary>
    [ApiController]
    [Route("/products")]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductProvider _productProvider;
        private readonly IMapper _mapper;

        public ProductsController(
            ILogger<ProductsController> logger,
            IProductProvider productProvider,
            IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
            _productProvider = productProvider;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProductsAsync(Nullable<bool> active, string brand, string category, string color,
                                                                                  string demographic, string material,
                                                                                  decimal price, string type)
        {
            _logger.LogInformation("Request received for GetProductsAsync");

            var products = await _productProvider.GetProductsAsync(active, brand, category, color,
                                                                   demographic, material,
                                                                   price, type);
            var productDTOs = _mapper.Map<IEnumerable<ProductDTO>>(products);

            return Ok(productDTOs);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProductByIdAsync(int id)
        {
            _logger.LogInformation($"Request received for GetProductByIdAsync for id: {id}");

            var product = await _productProvider.GetProductByIdAsync(id);
            var productDTO = _mapper.Map<ProductDTO>(product);

            return Ok(productDTO);
        }

        [HttpGet("/products/categories")]
        public async Task<ActionResult<IEnumerable<string>>> GetAllUniqueProductCategoriesAsync()
        {
            _logger.LogInformation($"Request received for GetAllUniqueProductCategoriesAsync");
            var productCategories = await _productProvider.GetAllUniqueProductCategoriesAsync();
            return Ok(productCategories);

        }

        [HttpGet("/products/types")]
        public async Task<ActionResult<IEnumerable<string>>> GetAllUniqueProductTypesAsync()
        {
            _logger.LogInformation($"Request received for GetAllUniqueProductTypesAsync");
            var productTypes = await _productProvider.GetAllUniqueProductTypesAsync();
            return Ok(productTypes);

        }

    }
}