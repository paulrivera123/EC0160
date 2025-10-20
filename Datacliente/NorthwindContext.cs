using System.Data.Entity;

namespace Datacliente
{
    // Heredamos de DbContext para manejar la conexión con Entity Framework
    public class NorthwindContext : DbContext
    {
        // El nombre "NorthwindEntities1" debe coincidir con el nombre de conexión en tu App.config
        public NorthwindContext() : base("name=NorthwindEntities1") { }

        // Aquí definimos las tablas (entidades) que queremos mapear
        public DbSet<Customer> Customers { get; set; }
    }
}