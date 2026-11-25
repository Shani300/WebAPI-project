using Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IProductsRepository
    {
        Task<IEnumerable<Product>> GetAllProducts();

    }
}
