using ShopBridgeRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShopBridge.Contracts;

namespace ShopeBridgeBusiness
{
    /// <summary>
    /// Business class for product
    /// </summary>
    public class ProductService : IProductService
    {
        private IProductRepository _repo = null;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }
        public IList<ProductDto> GetAll()
        {
            return _repo.GetAll();
        }

        public ProductDto GetById(int Id)
        {
           return _repo.GetById(Id);
        }

        public int Save(ProductDto product)
        {
            return _repo.Save(product);
        }

        public bool Delete(int Id)
        {
            return _repo.Delete(Id);
        }

        public bool Update(ProductDto product)
        {
            return _repo.Update(product);
        }
    }
}
