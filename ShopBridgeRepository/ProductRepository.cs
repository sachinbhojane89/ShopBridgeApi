using ShopBridge.Contracts;
using ShopBridge.Data;
using ShopBridge.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace ShopBridgeRepository
{
    /// <summary>
    /// Repository class which add wrapper over data access layer
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private ShopBridgeDataContext _context = new ShopBridgeDataContext();
        public IList<ProductDto> GetAll()
        {
            var list = _context.Products.ToList();
            var dtos = new List<ProductDto>();

            foreach (var p in list)
            {
                dtos.Add(new ProductDto
                {
                    Description = p.Description,
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price
                });
            }

            return dtos;
        }

        public ProductDto GetById(int Id)
        {
            var product = _context.Products.FirstOrDefault(x => x.Id == Id);

            if (product == null) return null;

            return new ProductDto
            {
                Description = product.Description,
                Id = product.Id,
                Name = product.Name,
                Price = product.Price
            };
        }

        public int Save(ProductDto product)
        {
            _context.Products.Add(new Product
            {
                Description = product.Description,
                Id = product.Id,
                Price = product.Price,
                Name = product.Name
            });
            return _context.SaveChanges();
        }

        public bool Delete(int id)
        {
            bool deleted = false;
            var product = _context.Products.SingleOrDefault(x => x.Id == id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
                deleted = true;
            }
            return deleted;
        }

        public bool Update(ProductDto product)
        {
            bool updated = false;
            var existing = _context.Products.SingleOrDefault(x => x.Id == product.Id);
            if (existing != null)
            {
                existing.Name = product.Name;
                existing.Price = product.Price;
                existing.Description = product.Description;
                _context.SaveChanges();
                updated = true;
            }

            return updated;
        }
    }
}
