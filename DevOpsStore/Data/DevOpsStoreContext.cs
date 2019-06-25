using DevOpsStore.Models;
using Microsoft.EntityFrameworkCore;

namespace DevOpsStore.Data
{
    public class DevOpsStoreContext : DbContext
    {
        public DevOpsStoreContext (DbContextOptions<DevOpsStoreContext> options)
            : base(options)
        {
        }

        public DbSet<StoreItem> StoreItem { get; set; }
    }
}
