namespace WATickets.Models.Cliente
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ModelCliente : DbContext
    {
        public ModelCliente()
            : base("name=ModelCliente")
        {
        }

        public virtual DbSet<Barrios> Barrios { get; set; }
        public virtual DbSet<BitacoraErrores> BitacoraErrores { get; set; }
        public virtual DbSet<BitacoraMovimientos> BitacoraMovimientos { get; set; }
        public virtual DbSet<Bodegas> Bodegas { get; set; }

        public virtual DbSet<Cantones> Cantones { get; set; }
   


        public virtual DbSet<Distritos> Distritos { get; set; }
    
        public virtual DbSet<Productos> Productos { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<SeguridadModulos> SeguridadModulos { get; set; }
        public virtual DbSet<SeguridadRolesModulos> SeguridadRolesModulos { get; set; }
        public virtual DbSet<Sucursales> Sucursales { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Proveedores> Proveedores { get; set; }







        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Barrios>()
                .Property(e => e.NomBarrio)
                .IsUnicode(false);

            modelBuilder.Entity<BitacoraErrores>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<BitacoraErrores>()
                .Property(e => e.StrackTrace)
                .IsUnicode(false);

            modelBuilder.Entity<BitacoraErrores>()
                .Property(e => e.JSON)
                .IsUnicode(false);

            modelBuilder.Entity<BitacoraMovimientos>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<BitacoraMovimientos>()
                .Property(e => e.Metodo)
                .IsUnicode(false);

            modelBuilder.Entity<Bodegas>()
                .Property(e => e.CodSuc)
                .IsUnicode(false);

    

            modelBuilder.Entity<Bodegas>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

          




            modelBuilder.Entity<Cantones>()
                .Property(e => e.NomCanton)
                .IsUnicode(false);

    

          
          

            modelBuilder.Entity<Distritos>()
                .Property(e => e.NomDistrito)
                .IsUnicode(false);

        

            modelBuilder.Entity<Productos>()
                .Property(e => e.Codigo)
                .IsUnicode(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Productos>()
                .Property(e => e.PrecioUnitario)
                .HasPrecision(19, 4);

    

      

            modelBuilder.Entity<Productos>()
                .Property(e => e.Costo)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Productos>()
                .Property(e => e.Stock)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Roles>()
                .Property(e => e.NombreRol)
                .IsUnicode(false);

            modelBuilder.Entity<SeguridadModulos>()
                .Property(e => e.Descripcion)
                .IsUnicode(false);

            modelBuilder.Entity<Sucursales>()
                .Property(e => e.CodSuc)
                .IsUnicode(false);

            modelBuilder.Entity<Sucursales>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Sucursales>()
                .Property(e => e.TipoCedula)
                .IsUnicode(false);

            modelBuilder.Entity<Sucursales>()
                .Property(e => e.Cedula)
                .IsUnicode(false);

            modelBuilder.Entity<Sucursales>()
                .Property(e => e.Provincia)
                .IsUnicode(false);

            modelBuilder.Entity<Sucursales>()
                .Property(e => e.Canton)
                .IsUnicode(false);

            modelBuilder.Entity<Sucursales>()
                .Property(e => e.Distrito)
                .IsUnicode(false);

            modelBuilder.Entity<Sucursales>()
                .Property(e => e.Barrio)
                .IsUnicode(false);

            modelBuilder.Entity<Sucursales>()
                .Property(e => e.Sennas)
                .IsUnicode(false);

            modelBuilder.Entity<Sucursales>()
                .Property(e => e.Telefono)
                .IsUnicode(false);

            modelBuilder.Entity<Sucursales>()
                .Property(e => e.Correo)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.NombreUsuario)
                .IsUnicode(false);

            modelBuilder.Entity<Usuarios>()
                .Property(e => e.Clave)
                .IsUnicode(false);



        }
    }
}
