

namespace EFDAL
{
    using EFModel;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    class DalBaseEntities : DbContext
    {
        public DalBaseEntities()
            : base("name=CCDBEntities")
        {
        }
        public DbSet<MyClass> MyClass { get; set; }
        public DbSet<MyStudent> MyStudent { get; set; }

    }
}
