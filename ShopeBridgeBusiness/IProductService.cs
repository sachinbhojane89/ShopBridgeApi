using ShopBridge.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopeBridgeBusiness
{
    public interface IProductService
    {
        /// <summary>
        /// This method return all records from database based on page number and count
        /// </summary>
        /// <param name="pageNo">page number</param>
        /// <param name="countOfRecords">count</param>
        /// <returns>Product details</returns>
        Task<IList<ProductDto>> GetAll(int pageNo, int countOfRecords);

        /// <summary>
        /// This method returns product by product id
        /// </summary>
        /// <param name="Id">product id</param>
        /// <returns>product details</returns>
        Task<ProductDto> GetById(int Id);

        /// <summary>
        /// This method insert new product to database
        /// </summary>
        /// <param name="product">new product</param>
        /// <returns>true/false</returns>
        Task<int> Save(ProductDto product);

        /// <summary>
        /// This method used to delete record from database
        /// </summary>
        /// <param name="Id">product id</param>
        /// <returns>true/false</returns>
        Task<bool> Delete(int Id);

        /// <summary>
        /// This method used to update product
        /// </summary>
        /// <param name="product">updated product</param>
        /// <returns>true/false</returns>
        Task<bool> Update(ProductDto product);
    }
}
