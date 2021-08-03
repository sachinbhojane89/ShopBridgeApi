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
        IList<ProductDto> GetAll();
        ProductDto GetById(int Id);
        int Save(ProductDto product);
        bool Delete(int Id);
        bool Update(ProductDto product);
    }
}
