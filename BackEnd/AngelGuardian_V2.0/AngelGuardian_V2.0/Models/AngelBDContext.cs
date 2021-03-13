using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace AngelGuardian_V2._0.Models
{
    public class AngelBDContext : DbContext
    {
        public DbSet<Comprobante> Comprobantes { get; set; }
        public DbSet<ComprobanteDetalle> ComprobanteDetalles { get; set; }
        public DbSet<Direcccion> Direcccions { get; set; }
        public DbSet<Estatus> Estatus { get; set; }
        public DbSet<Imagen> Imagen { get; set; }
        public DbSet<Negocio> Negocios { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public AngelBDContext() { }
        public void OnConfiguring(DbContextOptions optionsBuilder) { }
        public override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Comprobante>(Comprobantes => {
                Comprobantes.HasKey(e => e.IdComprobante);

                Comprobantes.Property(e => e.IdUsuario).IsRequired();
                Comprobantes.Property(e => e.IdNegocio).IsRequired();
                Comprobantes.Property(e => e.IdEstatus).IsRequired();
                Comprobantes.Property(e => e.IdDireccion).IsRequired();
                Comprobantes.Property(e => e.Puntuacion).IsRequired();
                Comprobantes.Property(e => e.Precio).IsRequired();
                Comprobantes.Property(e => e.Efectivo).IsRequired();
                Comprobantes.Property(e => e.Fecha).IsRequired();

                Comprobantes
                    .HasOne(e => e.Negocio)
                    .WithMany(y => y.Comprobantes)
                    .HasForeignKey("fk_Comprobante_Negocio");
                Comprobantes
                    .HasOne(e => e.Usuario)
                    .WithMany(y => y.Comprobantes)
                    .HasForeignKey("fk_Comprobante_Usuario");
                Comprobantes
                    .HasOne(e => e.Estatus)
                    .WithOne(y => y.Comprobantes)
                    .HasForeignKey("fk_Comprobante_Estatus");
                Comprobantes
                    .HasOne(e => e.Direcccion)
                    .WithMany(y => y.Comprobantes)
                    .HasForeignKey("fk_Comprobante_Direccion");
            });
            modelBuilder.Entity<ComprobanteDetalle>(ComprobanteDetalles =>
            {
                ComprobanteDetalles.HasKey(e => e.IdComprobanteDetalle);
                ComprobanteDetalles.Property(e => e.IdComprobante).IsRequired();
                ComprobanteDetalles.Property(e => e.IdEstatus).IsRequired();
                ComprobanteDetalles.Property(e => e.IdServicio).IsRequired();
                ComprobanteDetalles.Property(e => e.Puntuacion).IsRequired();
                ComprobanteDetalles.Property(e => e.Precio).IsRequired();
                ComprobanteDetalles.Property(e => e.Cambio).IsRequired(false);
                ComprobanteDetalles.Property(e => e.Fecha).IsRequired();

                ComprobanteDetalles
                    .HasOne(e => e.Comprobante)
                    .WithMany(y => y.ComprobanteDetalles)
                    .HasForeignKey("fk_ComprobanteDetalle_Comprobante");
                ComprobanteDetalles
                    .HasOne(e => e.Estatus)
                    .WithOne(y => y.ComprobanteDetalles)
                    .HasForeignKey("fk_ComprobanteDetalle_Estatus");
                ComprobanteDetalles
                    .HasOne(e => e.Servicio)
                    .WithOne(y => y.ComprobanteDetalles)
                    .HasForeignKey("fk_ComprobanteDetalle_Servicio");
            });
            modelBuilder.Entity<Servicio>(Servicios =>
            {
                Servicios.HasKey(e => e.IdServicio);
                Servicios.Property(e => e.IdNegocio).IsRequired();
                Servicios.Property(e => e.Puntuacion).IsRequired();
                Servicios.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .IsRequired();
                Servicios.Property(e => e.Descripcion)
                    .IsUnicode(false)
                    .IsRequired();
                Servicios.Property(e => e.Duracion)
                    .IsRequired();
                Servicios.Property(e => e.Precio)
                    .IsRequired();
                Servicios.Property(e => e.Fecha)
                    .IsRequired();

                Servicios
                    .HasOne(e => e.Negocio)
                    .WithMany(y => y.Servicios)
                    .HasForeignKey("fk_Servicio_Negocio");
            });
            modelBuilder.Entity<Negocio>(Negocios => {
                Negocios.HasKey(e => e.IdNegocio);
                Negocios.Property(e => e.IdImagen).IsRequired();
                Negocios.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(100);
                Negocios.Property(e => e.RazonSocial)
                    .IsRequired()
                    .IsUnicode(false);
                Negocios.Property(e => e.PuntuacionFinal).IsRequired();
                Negocios.Property(e => e.Fecha).IsRequired();

                Negocios
                    .HasOne(e => e.Imagen)
                    .WithOne(y => y.Negocio)
                    .HasForeignKey("fk_Negocio_Imagen");
            });
            modelBuilder.Entity<Estatus>(Estatus => {
                Estatus.HasKey(e => e.IdEstatus);
                Estatus.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(50);
                Estatus.Property(e => e.Fecha).IsRequired();
            });
            modelBuilder.Entity<Imagen>(Imagen => {
                Imagen.HasKey(e => e.IdImagen);
                Imagen.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(500);
                Imagen.Property(e => e.Ruta)
                    .IsRequired()
                    .IsUnicode(false);
                Imagen.Property(e => e.Size).IsRequired();
                Imagen.Property(e => e.Fecha).IsRequired();

            });
            modelBuilder.Entity<Usuario>(Usuario => {
                Usuario.HasKey(e => e.IdUsuario);
                Usuario.Property(e => e.NickName)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(50);
                Usuario.Property(e => e.Nombre)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(200);
                Usuario.Property(e => e.ApellidoPaterno)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(50);
                Usuario.Property(e => e.ApellidoMaterno)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(50);
                Usuario.Property(e => e.Celular).IsRequired();
                Usuario.Property(e => e.Email)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(50);
                Usuario.Property(e => e.Consumidor).IsRequired();
                Usuario.Property(e => e.Fecha).IsRequired();
            });
            modelBuilder.Entity<Direcccion>(Direcccions => {
                Direcccions.HasKey(e => e.IdDireccion);
                Direcccions.Property(e => e.Latitud).IsRequired();
                Direcccions.Property(e => e.Longitud).IsRequired();
                Direcccions.Property(e => e.Referencia)
                    .IsRequired()
                    .IsUnicode(false);
                Direcccions.Property(e => e.NumeroExterior).IsRequired();
                Direcccions.Property(e => e.Lugar)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(200);
                Direcccions.Property(e => e.Calle)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasMaxLength(200);
            });
        }
    }
}
