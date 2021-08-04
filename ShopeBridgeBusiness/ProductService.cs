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
        public async Task<IList<ProductDto>> GetAll(int pageNo, int countOfRecords)
        {
            return await _repo.GetAll(pageNo, countOfRecords);
        }

        public async Task<ProductDto> GetById(int Id)
        {
           return await _repo.GetById(Id);
        }

        public async Task<int> Save(ProductDto product)
        {
            return await _repo.Save(product);
        }

        public async Task<bool> Delete(int Id)
        {
            return await _repo.Delete(Id);
        }

        public async Task<bool> Update(ProductDto product)
        {
            return await _repo.Update(product);
        }
    }
}
