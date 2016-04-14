using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LinqXml.Data
{
    public class LinqXmlContext : DbContext
    {
        public LinqXmlContext()
            : base("name=DefaultConnection")  // web config de connection ismi var 
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)  // ? 
        {
            
        }

        public DbSet<Kurlar> Kurlars { get; set; } // database ile bağlantılıyoruz

    }
}