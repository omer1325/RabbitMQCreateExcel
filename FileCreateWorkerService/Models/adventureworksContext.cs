using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FileCreateWorkerService.Models
{
    public partial class adventureworksContext : DbContext
    {
        public adventureworksContext()
        {
        }

        public adventureworksContext(DbContextOptions<adventureworksContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Product> Products { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("tablefunc")
                .HasPostgresExtension("uuid-ossp")
                .HasAnnotation("Relational:Collation", "Turkish_Turkey.1254");

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product", "production");

                entity.HasComment("Products sold or used in the manfacturing of sold products.");

                entity.Property(e => e.Productid)
                    .HasColumnName("productid")
                    .HasComment("Primary key for Product records.");

                entity.Property(e => e.Class)
                    .HasMaxLength(2)
                    .HasColumnName("class")
                    .IsFixedLength(true)
                    .HasComment("H = High, M = Medium, L = Low");

                entity.Property(e => e.Color)
                    .HasMaxLength(15)
                    .HasColumnName("color")
                    .HasComment("Product color.");

                entity.Property(e => e.Daystomanufacture)
                    .HasColumnName("daystomanufacture")
                    .HasComment("Number of days required to manufacture the product.");

                entity.Property(e => e.Discontinueddate)
                    .HasColumnName("discontinueddate")
                    .HasComment("Date the product was discontinued.");

                entity.Property(e => e.Finishedgoodsflag)
                    .IsRequired()
                    .HasColumnName("finishedgoodsflag")
                    .HasDefaultValueSql("true")
                    .HasComment("0 = Product is not a salable item. 1 = Product is salable.");

                entity.Property(e => e.Listprice)
                    .HasColumnName("listprice")
                    .HasComment("Selling price.");

                entity.Property(e => e.Makeflag)
                    .IsRequired()
                    .HasColumnName("makeflag")
                    .HasDefaultValueSql("true")
                    .HasComment("0 = Product is purchased, 1 = Product is manufactured in-house.");

                entity.Property(e => e.Modifieddate)
                    .HasColumnName("modifieddate")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .HasComment("Name of the product.");

                entity.Property(e => e.Productline)
                    .HasMaxLength(2)
                    .HasColumnName("productline")
                    .IsFixedLength(true)
                    .HasComment("R = Road, M = Mountain, T = Touring, S = Standard");

                entity.Property(e => e.Productmodelid)
                    .HasColumnName("productmodelid")
                    .HasComment("Product is a member of this product model. Foreign key to ProductModel.ProductModelID.");

                entity.Property(e => e.Productnumber)
                    .IsRequired()
                    .HasMaxLength(25)
                    .HasColumnName("productnumber")
                    .HasComment("Unique product identification number.");

                entity.Property(e => e.Productsubcategoryid)
                    .HasColumnName("productsubcategoryid")
                    .HasComment("Product is a member of this product subcategory. Foreign key to ProductSubCategory.ProductSubCategoryID.");

                entity.Property(e => e.Reorderpoint)
                    .HasColumnName("reorderpoint")
                    .HasComment("Inventory level that triggers a purchase order or work order.");

                entity.Property(e => e.Rowguid)
                    .HasColumnName("rowguid")
                    .HasDefaultValueSql("uuid_generate_v1()");

                entity.Property(e => e.Safetystocklevel)
                    .HasColumnName("safetystocklevel")
                    .HasComment("Minimum inventory quantity.");

                entity.Property(e => e.Sellenddate)
                    .HasColumnName("sellenddate")
                    .HasComment("Date the product was no longer available for sale.");

                entity.Property(e => e.Sellstartdate)
                    .HasColumnName("sellstartdate")
                    .HasComment("Date the product was available for sale.");

                entity.Property(e => e.Size)
                    .HasMaxLength(5)
                    .HasColumnName("size")
                    .HasComment("Product size.");

                entity.Property(e => e.Sizeunitmeasurecode)
                    .HasMaxLength(3)
                    .HasColumnName("sizeunitmeasurecode")
                    .IsFixedLength(true)
                    .HasComment("Unit of measure for Size column.");

                entity.Property(e => e.Standardcost)
                    .HasColumnName("standardcost")
                    .HasComment("Standard cost of the product.");

                entity.Property(e => e.Style)
                    .HasMaxLength(2)
                    .HasColumnName("style")
                    .IsFixedLength(true)
                    .HasComment("W = Womens, M = Mens, U = Universal");

                entity.Property(e => e.Weight)
                    .HasPrecision(8, 2)
                    .HasColumnName("weight")
                    .HasComment("Product weight.");

                entity.Property(e => e.Weightunitmeasurecode)
                    .HasMaxLength(3)
                    .HasColumnName("weightunitmeasurecode")
                    .IsFixedLength(true)
                    .HasComment("Unit of measure for Weight column.");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
