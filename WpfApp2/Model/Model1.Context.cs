//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WpfApp2.Model
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class autoinspecEntities1 : DbContext
    {
        public autoinspecEntities1()
            : base("name=autoinspecEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Auto> Auto { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Class_DTP> Class_DTP { get; set; }
        public virtual DbSet<Color> Color { get; set; }
        public virtual DbSet<Drivers> Drivers { get; set; }
        public virtual DbSet<DTP> DTP { get; set; }
        public virtual DbSet<EngineType> EngineType { get; set; }
        public virtual DbSet<licence> licence { get; set; }
        public virtual DbSet<Members_DTP> Members_DTP { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Status_history_change> Status_history_change { get; set; }
        public virtual DbSet<TypeOfDrive> TypeOfDrive { get; set; }
        public virtual DbSet<DTP_Photo> DTP_Photo { get; set; }
    }
}
