﻿//------------------------------------------------------------------------------
// <auto-generated>
//    Этот код был создан из шаблона.
//
//    Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//    Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcTest.Models.Databases
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Duris4eDbEntities : DbContext
    {
        public Duris4eDbEntities()
            : base("name=Duris4eDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public DbSet<h_dates> h_dates { get; set; }
        public DbSet<holidays> holidays { get; set; }
    }
}
