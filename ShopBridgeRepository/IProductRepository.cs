using ShopBridge.Contracts;
using ShopBridge.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopBridgeRepository
{
    public interface IProductRepository
    {
        Task<IList<ProductDto>> GetAll(int pageNo, int countOfRecords);
        Task<ProductDto> GetById(int Id);
        Task<int> Save(ProductDto product);
        Task<bool> Delete(int product);
        Task<bool> Update(ProductDto product);
    }
}
