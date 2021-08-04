using ShopBridge.Contracts;
using ShopBridge.Data;
using ShopBridge.Data.Entities;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using System.Threading.Tasks;

namespace ShopBridgeRepository
{
    /// <summary>
    /// Repository class which add wrapper over data access layer
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private ShopBridgeDataContext _context = new ShopBridgeDataContext();

        public ProductRepository()
        {
            AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<AutomapperProfile>());
        }
        public async Task<IList<ProductDto>> GetAll(int pageNo, int countOfRecords)
        {
            if (pageNo == 0) pageNo = 1;
            var skippedCount = (pageNo-1) * countOfRecords;
            var list = await Task.Run(()=> _context.Products.ToList().Skip(skippedCount).Take(countOfRecords));
            return  Mapper.Map<IList<ProductDto>>(list);
        }

        public async Task<ProductDto> GetById(int Id)
        {
            var product = await _context.Products.FindAsync(Id);
            if (product == null) return null;

            return Mapper.Map<ProductDto>(product);
        }

        public async Task<int> Save(ProductDto product)
        {
            var productEntity = Mapper.Map<Product>(product);
            _context.Products.Add(productEntity);
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(int id)
        {
            bool deleted = false;
            var product = _context.Products.SingleOrDefault(x => x.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                deleted = true;
            }
            return deleted;
        }

        public async Task<bool> Update(ProductDto product)
        {
            bool updated = false;
            var existing = _context.Products.SingleOrDefault(x => x.Id == product.Id);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Price = product.Price;
                existing.Description = product.Description;
                await _context.SaveChangesAsync();
                updated = true;
            }

            return updated;
        }
    }
}
