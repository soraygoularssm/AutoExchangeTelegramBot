//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AutoTabadol.DataLayer
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class AutoTabadol_DBEntities : DbContext
    {
        public AutoTabadol_DBEntities()
            : base("name=AutoTabadol_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category_Table> Category_Table { get; set; }
        public virtual DbSet<CloseMember_Table> CloseMember_Table { get; set; }
        public virtual DbSet<Exchanged_Table> Exchanged_Table { get; set; }
        public virtual DbSet<SameCategory_Table> SameCategory_Table { get; set; }
        public virtual DbSet<Tab_Table> Tab_Table { get; set; }
        public virtual DbSet<UserInfo_Table> UserInfo_Table { get; set; }
        public virtual DbSet<Admin_Table> Admin_Table { get; set; }
    }
}
