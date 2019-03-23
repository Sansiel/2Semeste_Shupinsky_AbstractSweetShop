using AbstractSweetShopModel;
using System.Data.Entity;

namespace AbstractSweetShopServiceImplementDataBase
{
    public class DbContext : System.Data.Entity.DbContext
    {
        public DbContext() : base("AbstractDatabase")
        {
            //настройки конфигурации для entity
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            var ensureDLLIsCopied =
            System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
        public virtual DbSet<Buyer> Buyers { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Candy> Candies { get; set; }
        public virtual DbSet<CandyMaterial> CandyMaterials { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<StoreMaterial> StoreMaterials { get; set; }
    }
}
