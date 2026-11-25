using Entity;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public class ProductsServices : IProductsServices
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsServices(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
           return await _productsRepository.GetAllProducts();
        }
    }
}
