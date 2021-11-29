using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using example.DataBase.Models;

namespace example.DataBase.Context
{
    public partial class ExampleDbContext : DbContext
    {
        public ExampleDbContext()
        {
        }

        public ExampleDbContext(DbContextOptions<ExampleDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<actor> actors { get; set; } = null!;
        public virtual DbSet<actor_info> actor_infos { get; set; } = null!;
        public virtual DbSet<address> addresses { get; set; } = null!;
        public virtual DbSet<category> categories { get; set; } = null!;
        public virtual DbSet<city> cities { get; set; } = null!;
        public virtual DbSet<country> countries { get; set; } = null!;
        public virtual DbSet<customer> customers { get; set; } = null!;
        public virtual DbSet<customer_list> customer_lists { get; set; } = null!;
        public virtual DbSet<film> films { get; set; } = null!;
        public virtual DbSet<film_actor> film_actors { get; set; } = null!;
        public virtual DbSet<film_category> film_categories { get; set; } = null!;
        public virtual DbSet<film_list> film_lists { get; set; } = null!;
        public virtual DbSet<film_text> film_texts { get; set; } = null!;
        public virtual DbSet<inventory> inventories { get; set; } = null!;
        public virtual DbSet<language> languages { get; set; } = null!;
        public virtual DbSet<nicer_but_slower_film_list> nicer_but_slower_film_lists { get; set; } = null!;
        public virtual DbSet<payment> payments { get; set; } = null!;
        public virtual DbSet<rental> rentals { get; set; } = null!;
        public virtual DbSet<sales_by_film_category> sales_by_film_categories { get; set; } = null!;
        public virtual DbSet<sales_by_store> sales_by_stores { get; set; } = null!;
        public virtual DbSet<staff> staff { get; set; } = null!;
        public virtual DbSet<staff_list> staff_lists { get; set; } = null!;
        public virtual DbSet<store> stores { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=127.0.0.1;port=3306;uid=root;password=ClickNext!1234;database=sakila", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.21-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<actor>(entity =>
            {
                entity.HasKey(e => e.actor_id)
                    .HasName("PRIMARY");

                entity.ToTable("actor");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.last_name, "idx_actor_last_name");

                entity.Property(e => e.first_name).HasMaxLength(45);

                entity.Property(e => e.last_name).HasMaxLength(45);

                entity.Property(e => e.last_update)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<actor_info>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("actor_info");

                entity.Property(e => e.film_info)
                    .HasColumnType("text")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.first_name)
                    .HasMaxLength(45)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.last_name)
                    .HasMaxLength(45)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<address>(entity =>
            {
                entity.HasKey(e => e.address_id)
                    .HasName("PRIMARY");

                entity.ToTable("address");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.city_id, "idx_fk_city_id");

                entity.Property(e => e.address1)
                    .HasMaxLength(50)
                    .HasColumnName("address");

                entity.Property(e => e.address2).HasMaxLength(50);

                entity.Property(e => e.district).HasMaxLength(20);

                entity.Property(e => e.last_update)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.phone).HasMaxLength(20);

                entity.Property(e => e.postal_code).HasMaxLength(10);

                entity.HasOne(d => d.city)
                    .WithMany(p => p.addresses)
                    .HasForeignKey(d => d.city_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_address_city");
            });

            modelBuilder.Entity<category>(entity =>
            {
                entity.HasKey(e => e.category_id)
                    .HasName("PRIMARY");

                entity.ToTable("category");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.category_id).ValueGeneratedOnAdd();

                entity.Property(e => e.last_update)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.name).HasMaxLength(25);
            });

            modelBuilder.Entity<city>(entity =>
            {
                entity.HasKey(e => e.city_id)
                    .HasName("PRIMARY");

                entity.ToTable("city");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.country_id, "idx_fk_country_id");

                entity.Property(e => e.city1)
                    .HasMaxLength(50)
                    .HasColumnName("city");

                entity.Property(e => e.last_update)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.country)
                    .WithMany(p => p.cities)
                    .HasForeignKey(d => d.country_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_city_country");
            });

            modelBuilder.Entity<country>(entity =>
            {
                entity.HasKey(e => e.country_id)
                    .HasName("PRIMARY");

                entity.ToTable("country");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.country1)
                    .HasMaxLength(50)
                    .HasColumnName("country");

                entity.Property(e => e.last_update)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");
            });

            modelBuilder.Entity<customer>(entity =>
            {
                entity.HasKey(e => e.customer_id)
                    .HasName("PRIMARY");

                entity.ToTable("customer");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.address_id, "idx_fk_address_id");

                entity.HasIndex(e => e.store_id, "idx_fk_store_id");

                entity.HasIndex(e => e.last_name, "idx_last_name");

                entity.Property(e => e.active)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.create_date).HasColumnType("datetime");

                entity.Property(e => e.email).HasMaxLength(50);

                entity.Property(e => e.first_name).HasMaxLength(45);

                entity.Property(e => e.last_name).HasMaxLength(45);

                entity.Property(e => e.last_update)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.address)
                    .WithMany(p => p.customers)
                    .HasForeignKey(d => d.address_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_customer_address");

                entity.HasOne(d => d.store)
                    .WithMany(p => p.customers)
                    .HasForeignKey(d => d.store_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_customer_store");
            });

            modelBuilder.Entity<customer_list>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("customer_list");

                entity.Property(e => e.address)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.city)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.country)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.name)
                    .HasMaxLength(91)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.notes)
                    .HasMaxLength(6)
                    .HasDefaultValueSql("''")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.phone)
                    .HasMaxLength(20)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.zip_code)
                    .HasMaxLength(10)
                    .HasColumnName("zip code")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<film>(entity =>
            {
                entity.HasKey(e => e.film_id)
                    .HasName("PRIMARY");

                entity.ToTable("film");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.language_id, "idx_fk_language_id");

                entity.HasIndex(e => e.original_language_id, "idx_fk_original_language_id");

                entity.HasIndex(e => e.title, "idx_title");

                entity.Property(e => e.description).HasColumnType("text");

                entity.Property(e => e.last_update)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.rating)
                    .HasColumnType("enum('G','PG','PG-13','R','NC-17')")
                    .HasDefaultValueSql("'G'");

                entity.Property(e => e.release_year).HasColumnType("year");

                entity.Property(e => e.rental_duration).HasDefaultValueSql("'3'");

                entity.Property(e => e.rental_rate)
                    .HasPrecision(4, 2)
                    .HasDefaultValueSql("'4.99'");

                entity.Property(e => e.replacement_cost)
                    .HasPrecision(5, 2)
                    .HasDefaultValueSql("'19.99'");

                entity.HasOne(d => d.language)
                    .WithMany(p => p.filmlanguages)
                    .HasForeignKey(d => d.language_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_film_language");

                entity.HasOne(d => d.original_language)
                    .WithMany(p => p.filmoriginal_languages)
                    .HasForeignKey(d => d.original_language_id)
                    .HasConstraintName("fk_film_language_original");
            });

            modelBuilder.Entity<film_actor>(entity =>
            {
                entity.HasKey(e => new { e.actor_id, e.film_id })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("film_actor");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.film_id, "idx_fk_film_id");

                entity.Property(e => e.last_update)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.actor)
                    .WithMany(p => p.film_actors)
                    .HasForeignKey(d => d.actor_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_film_actor_actor");

                entity.HasOne(d => d.film)
                    .WithMany(p => p.film_actors)
                    .HasForeignKey(d => d.film_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_film_actor_film");
            });

            modelBuilder.Entity<film_category>(entity =>
            {
                entity.HasKey(e => new { e.film_id, e.category_id })
                    .HasName("PRIMARY")
                    .HasAnnotation("MySql:IndexPrefixLength", new[] { 0, 0 });

                entity.ToTable("film_category");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.category_id, "fk_film_category_category");

                entity.Property(e => e.last_update)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.category)
                    .WithMany(p => p.film_categories)
                    .HasForeignKey(d => d.category_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_film_category_category");

                entity.HasOne(d => d.film)
                    .WithMany(p => p.film_categories)
                    .HasForeignKey(d => d.film_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_film_category_film");
            });

            modelBuilder.Entity<film_list>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("film_list");

                entity.Property(e => e.FID).HasDefaultValueSql("'0'");

                entity.Property(e => e.actors)
                    .HasColumnType("text")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.category)
                    .HasMaxLength(25)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.description)
                    .HasColumnType("text")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.price)
                    .HasPrecision(4, 2)
                    .HasDefaultValueSql("'4.99'");

                entity.Property(e => e.rating)
                    .HasColumnType("enum('G','PG','PG-13','R','NC-17')")
                    .HasDefaultValueSql("'G'")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.title)
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<film_text>(entity =>
            {
                entity.HasKey(e => e.film_id)
                    .HasName("PRIMARY");

                entity.ToTable("film_text");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => new { e.title, e.description }, "idx_title_description")
                    .HasAnnotation("MySql:FullTextIndex", true);

                entity.Property(e => e.film_id).ValueGeneratedNever();

                entity.Property(e => e.description).HasColumnType("text");
            });

            modelBuilder.Entity<inventory>(entity =>
            {
                entity.HasKey(e => e.inventory_id)
                    .HasName("PRIMARY");

                entity.ToTable("inventory");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.film_id, "idx_fk_film_id");

                entity.HasIndex(e => new { e.store_id, e.film_id }, "idx_store_id_film_id");

                entity.Property(e => e.inventory_id).HasColumnType("mediumint unsigned");

                entity.Property(e => e.last_update)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.film)
                    .WithMany(p => p.inventories)
                    .HasForeignKey(d => d.film_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inventory_film");

                entity.HasOne(d => d.store)
                    .WithMany(p => p.inventories)
                    .HasForeignKey(d => d.store_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_inventory_store");
            });

            modelBuilder.Entity<language>(entity =>
            {
                entity.HasKey(e => e.language_id)
                    .HasName("PRIMARY");

                entity.ToTable("language");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.Property(e => e.language_id).ValueGeneratedOnAdd();

                entity.Property(e => e.last_update)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.name)
                    .HasMaxLength(20)
                    .IsFixedLength();
            });

            modelBuilder.Entity<nicer_but_slower_film_list>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("nicer_but_slower_film_list");

                entity.Property(e => e.FID).HasDefaultValueSql("'0'");

                entity.Property(e => e.actors)
                    .HasColumnType("text")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.category)
                    .HasMaxLength(25)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.description)
                    .HasColumnType("text")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.price)
                    .HasPrecision(4, 2)
                    .HasDefaultValueSql("'4.99'");

                entity.Property(e => e.rating)
                    .HasColumnType("enum('G','PG','PG-13','R','NC-17')")
                    .HasDefaultValueSql("'G'")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.title)
                    .HasMaxLength(255)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<payment>(entity =>
            {
                entity.HasKey(e => e.payment_id)
                    .HasName("PRIMARY");

                entity.ToTable("payment");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.rental_id, "fk_payment_rental");

                entity.HasIndex(e => e.customer_id, "idx_fk_customer_id");

                entity.HasIndex(e => e.staff_id, "idx_fk_staff_id");

                entity.Property(e => e.amount).HasPrecision(5, 2);

                entity.Property(e => e.last_update)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.payment_date).HasColumnType("datetime");

                entity.HasOne(d => d.customer)
                    .WithMany(p => p.payments)
                    .HasForeignKey(d => d.customer_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_payment_customer");

                entity.HasOne(d => d.rental)
                    .WithMany(p => p.payments)
                    .HasForeignKey(d => d.rental_id)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("fk_payment_rental");

                entity.HasOne(d => d.staff)
                    .WithMany(p => p.payments)
                    .HasForeignKey(d => d.staff_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_payment_staff");
            });

            modelBuilder.Entity<rental>(entity =>
            {
                entity.HasKey(e => e.rental_id)
                    .HasName("PRIMARY");

                entity.ToTable("rental");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.customer_id, "idx_fk_customer_id");

                entity.HasIndex(e => e.inventory_id, "idx_fk_inventory_id");

                entity.HasIndex(e => e.staff_id, "idx_fk_staff_id");

                entity.HasIndex(e => new { e.rental_date, e.inventory_id, e.customer_id }, "rental_date")
                    .IsUnique();

                entity.Property(e => e.inventory_id).HasColumnType("mediumint unsigned");

                entity.Property(e => e.last_update)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.rental_date).HasColumnType("datetime");

                entity.Property(e => e.return_date).HasColumnType("datetime");

                entity.HasOne(d => d.customer)
                    .WithMany(p => p.rentals)
                    .HasForeignKey(d => d.customer_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rental_customer");

                entity.HasOne(d => d.inventory)
                    .WithMany(p => p.rentals)
                    .HasForeignKey(d => d.inventory_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rental_inventory");

                entity.HasOne(d => d.staff)
                    .WithMany(p => p.rentals)
                    .HasForeignKey(d => d.staff_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_rental_staff");
            });

            modelBuilder.Entity<sales_by_film_category>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("sales_by_film_category");

                entity.Property(e => e.category)
                    .HasMaxLength(25)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.total_sales).HasPrecision(27, 2);
            });

            modelBuilder.Entity<sales_by_store>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("sales_by_store");

                entity.Property(e => e.manager)
                    .HasMaxLength(91)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.store)
                    .HasMaxLength(101)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.total_sales).HasPrecision(27, 2);
            });

            modelBuilder.Entity<staff>(entity =>
            {
                entity.HasKey(e => e.staff_id)
                    .HasName("PRIMARY");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.address_id, "idx_fk_address_id");

                entity.HasIndex(e => e.store_id, "idx_fk_store_id");

                entity.Property(e => e.staff_id).ValueGeneratedOnAdd();

                entity.Property(e => e.active)
                    .IsRequired()
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.email).HasMaxLength(50);

                entity.Property(e => e.first_name).HasMaxLength(45);

                entity.Property(e => e.last_name).HasMaxLength(45);

                entity.Property(e => e.last_update)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.Property(e => e.password)
                    .HasMaxLength(40)
                    .UseCollation("utf8_bin");

                entity.Property(e => e.picture).HasColumnType("blob");

                entity.Property(e => e.username).HasMaxLength(16);

                entity.HasOne(d => d.address)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.address_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_staff_address");

                entity.HasOne(d => d.store)
                    .WithMany(p => p.staff)
                    .HasForeignKey(d => d.store_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_staff_store");
            });

            modelBuilder.Entity<staff_list>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("staff_list");

                entity.Property(e => e.address)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.city)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.country)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.name)
                    .HasMaxLength(91)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.phone)
                    .HasMaxLength(20)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.zip_code)
                    .HasMaxLength(10)
                    .HasColumnName("zip code")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<store>(entity =>
            {
                entity.HasKey(e => e.store_id)
                    .HasName("PRIMARY");

                entity.ToTable("store");

                entity.HasCharSet("utf8")
                    .UseCollation("utf8_general_ci");

                entity.HasIndex(e => e.address_id, "idx_fk_address_id");

                entity.HasIndex(e => e.manager_staff_id, "idx_unique_manager")
                    .IsUnique();

                entity.Property(e => e.store_id).ValueGeneratedOnAdd();

                entity.Property(e => e.last_update)
                    .HasColumnType("timestamp")
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("CURRENT_TIMESTAMP");

                entity.HasOne(d => d.address)
                    .WithMany(p => p.stores)
                    .HasForeignKey(d => d.address_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_store_address");

                entity.HasOne(d => d.manager_staff)
                    .WithOne(p => p.storeNavigation)
                    .HasForeignKey<store>(d => d.manager_staff_id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_store_staff");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
