using ShopBridgeRepository;
using System.Collections.Generic;
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

        /// <summary>
        /// This method return all records from database based on page number and count
        /// </summary>
        /// <param name="pageNo">page number</param>
        /// <param name="countOfRecords">count</param>
        /// <returns>Product details</returns>
        public async Task<IList<ProductDto>> GetAll(int pageNo, int countOfRecords)
        {
            return await _repo.GetAll(pageNo, countOfRecords);
        }

        /// <summary>
        /// This method returns product by product id
        /// </summary>
        /// <param name="Id">product id</param>
        /// <returns>product details</returns>
        public async Task<ProductDto> GetById(int Id)
        {
           return await _repo.GetById(Id);
        }

        /// <summary>
        /// This method insert new product to database
        /// </summary>
        /// <param name="product">new product</param>
        /// <returns>true/false</returns>
        public async Task<int> Save(ProductDto product)
        {
            return await _repo.Save(product);
        }

        /// <summary>
        /// This method used to delete record from database
        /// </summary>
        /// <param name="Id">product id</param>
        /// <returns>true/false</returns>
        public async Task<bool> Delete(int Id)
        {
            return await _repo.Delete(Id);
        }

        /// <summary>
        /// This method used to update product
        /// </summary>
        /// <param name="product">updated product</param>
        /// <returns>true/false</returns>
        public async Task<bool> Update(ProductDto product)
        {
            return await _repo.Update(product);
        }
    }
}
