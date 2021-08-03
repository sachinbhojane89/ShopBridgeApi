using ShopBridge.Contracts;
using ShopBridge.Data.Entities;
using System.Collections.Generic;

namespace ShopBridgeRepository
{
    public interface IProductRepository
    {
        IList<ProductDto> GetAll();
        ProductDto GetById(int Id);
        int Save(ProductDto product);
        bool Delete(int product);
        bool Update(ProductDto product);
    }
}
