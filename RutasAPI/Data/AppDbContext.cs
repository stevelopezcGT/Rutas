using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


namespace RutasAPI.Data {

    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblAutobuse> TblAutobuses { get; set; }

        public virtual DbSet<TblRecorridosRuta> TblAutobusesRuta { get; set; }

        public virtual DbSet<TblCiudades> TblCiudades { get; set; }

        public virtual DbSet<TblConductores> TblConductores { get; set; }

        public virtual DbSet<TblRecorridosRuta> TblRecorridosRuta { get; set; }

        public virtual DbSet<TblRuta> TblRutas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseSqlServer("data source=.\\SQL2019;initial catalog=ISBELASOFT_DB;user id=sa;password=sasa;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TblAutobuse>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__TblAutob__3214EC073A27C741");

                entity.Property(e => e.EstaEliminado).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdConductorNavigation).WithMany(p => p.TblAutobuses).HasConstraintName("FK__TblAutobu__IdCon__5BE2A6F2");
            });

            modelBuilder.Entity<TblAutobusesRuta>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__TblAutob__3214EC075E938C74");

                entity.Property(e => e.EstaEliminado).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdAutobusNavigation).WithMany(p => p.TblAutobusesRuta).HasConstraintName("FK__TblAutobu__IdAut__628FA481");

                entity.HasOne(d => d.IdRutaNavigation).WithMany(p => p.TblAutobusesRuta).HasConstraintName("FK__TblAutobu__IdRut__6383C8BA");
            });

            modelBuilder.Entity<TblCiudades>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__TblCiuda__3214EC074684FF2A");

                entity.Property(e => e.EstaEliminado).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblConductores>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__TblCondu__3214EC07798EB435");

                entity.Property(e => e.EstaEliminado).HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<TblRecorridosRuta>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__TblRecor__3214EC074AA3C0DE");

                entity.Property(e => e.EstaEliminado).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.IdCiudadNavigation).WithMany(p => p.TblRecorridosRuta).HasConstraintName("FK__TblRecorr__IdCiu__6B24EA82");

                entity.HasOne(d => d.IdRutaNavigation).WithMany(p => p.TblRecorridosRuta).HasConstraintName("FK__TblRecorr__IdRut__6A30C649");
            });

            modelBuilder.Entity<TblRuta>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__TblRutas__3214EC0778967015");

                entity.Property(e => e.EstaEliminado).HasDefaultValueSql("((0))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }

}