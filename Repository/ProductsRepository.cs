using System;
using System.Collections.Generic;
using System.Text;
using Entity;

namespace Repository
{
    public class ProductsRepository : IProductsRepository
    {
        public ProductsRepository()
        {
            
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            throw new NotImplementedException();
        }
    }
}
