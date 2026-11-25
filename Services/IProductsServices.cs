using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services
{
    public interface IProductsServices
    {
        Task<IEnumerable<Product>> GetAllProducts();
    }
}
