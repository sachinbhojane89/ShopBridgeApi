using ShopBridge.Data.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopBridge.Data
{
    public class ShopBridgeDataContext : DbContext
    {
        public ShopBridgeDataContext()
            : base()
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ShopBridgeDataContext>()); //used only for demo
        }
        public DbSet<Product> Products { get; set; }
    }
}
