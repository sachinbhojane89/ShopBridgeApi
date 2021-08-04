using ShopBridge.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeBridgeBusiness
{
    public interface IProductService
    {
        Task<IList<ProductDto>> GetAll(int pageNo, int countOfRecords);
        Task<ProductDto> GetById(int Id);
        Task<int> Save(ProductDto product);
        Task<bool> Delete(int Id);
        Task<bool> Update(ProductDto product);
    }
}
