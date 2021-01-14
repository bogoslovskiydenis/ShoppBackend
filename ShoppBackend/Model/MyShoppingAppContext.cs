using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ShoppBackend.Model
{
    public partial class MyShoppingAppContext : DbContext
    {
        public MyShoppingAppContext()
        {
        }

        public MyShoppingAppContext(DbContextOptions<MyShoppingAppContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Colour> Colours { get; set; }
        public virtual DbSet<Fabric> Fabrics { get; set; }
        public virtual DbSet<FeatureImg> FeatureImgs { get; set; }
        public virtual DbSet<JacketModel> JacketModels { get; set; }
        public virtual DbSet<Pattern> Patterns { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductColour> ProductColours { get; set; }
        public virtual DbSet<ProductFabric> ProductFabrics { get; set; }
        public virtual DbSet<ProductImage> ProductImages { get; set; }
        public virtual DbSet<ProductJacketModel> ProductJacketModels { get; set; }
        public virtual DbSet<ProductPattern> ProductPatterns { get; set; }
        public virtual DbSet<ProductSize> ProductSizes { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<SubCategory> SubCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-R87RB2O\\SQLEXPRESS;Database=MyShoppingApp;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Banner>(entity =>
            {
                entity.HasKey(e => e.BannerImgId);

                entity.ToTable("BANNER");

                entity.Property(e => e.BannerImgId).HasColumnName("BANNER_IMG_ID");

                entity.Property(e => e.BannerImgUrl)
                    .HasMaxLength(4000)
                    .HasColumnName("BANNER_IMG_URL");

                entity.Property(e => e.BannerText)
                    .HasMaxLength(50)
                    .HasColumnName("BANNER_TEXT");

                entity.Property(e => e.CategoryId).HasColumnName("CATEGORY_ID");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("CATEGORY");

                entity.Property(e => e.CategoryId).HasColumnName("CATEGORY_ID");

                entity.Property(e => e.CategoryImg)
                    .HasMaxLength(4000)
                    .HasColumnName("CATEGORY_IMG");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .HasColumnName("CATEGORY_NAME");
            });

            modelBuilder.Entity<Colour>(entity =>
            {
                entity.ToTable("COLOUR");

                entity.Property(e => e.ColourId).HasColumnName("COLOUR_ID");

                entity.Property(e => e.ColourName)
                    .HasMaxLength(50)
                    .HasColumnName("COLOUR_NAME");
            });

            modelBuilder.Entity<Fabric>(entity =>
            {
                entity.ToTable("FABRIC");

                entity.Property(e => e.FabricId).HasColumnName("FABRIC_ID");

                entity.Property(e => e.FabricName)
                    .HasMaxLength(50)
                    .HasColumnName("FABRIC_NAME");
            });

            modelBuilder.Entity<FeatureImg>(entity =>
            {
                entity.ToTable("FEATURE_IMG");

                entity.Property(e => e.FeatureImgId).HasColumnName("FEATURE_IMG_ID");

                entity.Property(e => e.CategoryId).HasColumnName("CATEGORY_ID");

                entity.Property(e => e.FeatureImgUrl)
                    .HasMaxLength(4000)
                    .HasColumnName("FEATURE_IMG_URL");
            });

            modelBuilder.Entity<JacketModel>(entity =>
            {
                entity.ToTable("JACKET_MODEL");

                entity.Property(e => e.JacketModelId).HasColumnName("JACKET_MODEL_ID");

                entity.Property(e => e.JacketModelName)
                    .HasMaxLength(50)
                    .HasColumnName("JACKET_MODEL_NAME");
            });

            modelBuilder.Entity<Pattern>(entity =>
            {
                entity.ToTable("PATTERN");

                entity.Property(e => e.PatternId).HasColumnName("PATTERN_ID");

                entity.Property(e => e.PatternName)
                    .HasMaxLength(50)
                    .HasColumnName("PATTERN_NAME");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("PRODUCT");

                entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");

                entity.Property(e => e.ProductCode)
                    .HasMaxLength(500)
                    .HasColumnName("PRODUCT_CODE");

                entity.Property(e => e.ProductCreateDate)
                    .HasColumnType("date")
                    .HasColumnName("PRODUCT_CREATE_DATE")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ProductDescription)
                    .HasMaxLength(4000)
                    .HasColumnName("PRODUCT_DESCRIPTION");

                entity.Property(e => e.ProductIsSale).HasColumnName("PRODUCT_IS_SALE");

                entity.Property(e => e.ProductName)
                    .HasMaxLength(50)
                    .HasColumnName("PRODUCT_NAME");

                entity.Property(e => e.ProductNewPrice).HasColumnName("PRODUCT_NEW_PRICE");

                entity.Property(e => e.ProductOldPrice).HasColumnName("PRODUCT_OLD_PRICE");

                entity.Property(e => e.ProductOrderNumber).HasColumnName("PRODUCT_ORDER_NUMBER");

                entity.Property(e => e.ProductSaleText)
                    .HasMaxLength(50)
                    .HasColumnName("PRODUCT_SALE_TEXT");

                entity.Property(e => e.ProductShortDescription)
                    .HasMaxLength(1000)
                    .HasColumnName("PRODUCT_SHORT_DESCRIPTION");

                entity.Property(e => e.ProductSubText)
                    .HasMaxLength(50)
                    .HasColumnName("PRODUCT_SUB_TEXT");

                entity.Property(e => e.SubCategoryId).HasColumnName("SUB_CATEGORY_ID");

                entity.HasOne(d => d.SubCategory)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.SubCategoryId)
                    .HasConstraintName("FK_PRODUCT_SUB_CATEGORY");
            });

            modelBuilder.Entity<ProductColour>(entity =>
            {
                entity.HasKey(e => new { e.ColourId, e.ProductId });

                entity.ToTable("PRODUCT_COLOUR");

                entity.Property(e => e.ColourId).HasColumnName("COLOUR_ID");

                entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");

                entity.HasOne(d => d.Colour)
                    .WithMany(p => p.ProductColours)
                    .HasForeignKey(d => d.ColourId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_COLOUR_COLOUR");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductColours)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_COLOUR_PRODUCT");
            });

            modelBuilder.Entity<ProductFabric>(entity =>
            {
                entity.HasKey(e => new { e.FabricId, e.ProductId });

                entity.ToTable("PRODUCT_FABRIC");

                entity.Property(e => e.FabricId).HasColumnName("FABRIC_ID");

                entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");

                entity.HasOne(d => d.Fabric)
                    .WithMany(p => p.ProductFabrics)
                    .HasForeignKey(d => d.FabricId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_FABRIC_FABRIC");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductFabrics)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_FABRIC_PRODUCT");
            });

            modelBuilder.Entity<ProductImage>(entity =>
            {
                entity.HasKey(e => e.ImgId);

                entity.ToTable("PRODUCT_IMAGE");

                entity.Property(e => e.ImgId).HasColumnName("IMG_ID");

                entity.Property(e => e.ImgUrl)
                    .HasMaxLength(4000)
                    .HasColumnName("IMG_URL");

                entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductImages)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_PRODUCT_IMAGE_PRODUCT");
            });

            modelBuilder.Entity<ProductJacketModel>(entity =>
            {
                entity.HasKey(e => new { e.JacketModelId, e.ProductId });

                entity.ToTable("PRODUCT_JACKET_MODEL");

                entity.Property(e => e.JacketModelId).HasColumnName("JACKET_MODEL_ID");

                entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");

                entity.HasOne(d => d.JacketModel)
                    .WithMany(p => p.ProductJacketModels)
                    .HasForeignKey(d => d.JacketModelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_JACKET_MODEL_JACKET_MODEL");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductJacketModels)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_JACKET_MODEL_PRODUCT");
            });

            modelBuilder.Entity<ProductPattern>(entity =>
            {
                entity.HasKey(e => new { e.PatternId, e.ProductId });

                entity.ToTable("PRODUCT_PATTERN");

                entity.Property(e => e.PatternId).HasColumnName("PATTERN_ID");

                entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");

                entity.HasOne(d => d.Pattern)
                    .WithMany(p => p.ProductPatterns)
                    .HasForeignKey(d => d.PatternId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_PATTERN_PATTERN");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductPatterns)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_PATTERN_PRODUCT");
            });

            modelBuilder.Entity<ProductSize>(entity =>
            {
                entity.HasKey(e => new { e.SizeId, e.ProductId });

                entity.ToTable("PRODUCT_SIZE");

                entity.Property(e => e.SizeId).HasColumnName("SIZE_ID");

                entity.Property(e => e.ProductId).HasColumnName("PRODUCT_ID");

                entity.Property(e => e.Number).HasColumnName("NUMBER");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ProductSizes)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_SIZE_PRODUCT");

                entity.HasOne(d => d.Size)
                    .WithMany(p => p.ProductSizes)
                    .HasForeignKey(d => d.SizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PRODUCT_SIZE_SIZE");
            });

            modelBuilder.Entity<Size>(entity =>
            {
                entity.ToTable("SIZE");

                entity.Property(e => e.SizeId).HasColumnName("SIZE_ID");

                entity.Property(e => e.SizeName)
                    .HasMaxLength(50)
                    .HasColumnName("SIZE_NAME");
            });

            modelBuilder.Entity<SubCategory>(entity =>
            {
                entity.ToTable("SUB_CATEGORY");

                entity.Property(e => e.SubCategoryId).HasColumnName("SUB_CATEGORY_ID");

                entity.Property(e => e.CategoryId).HasColumnName("CATEGORY_ID");

                entity.Property(e => e.SubCategoryName)
                    .HasMaxLength(50)
                    .HasColumnName("SUB_CATEGORY_NAME");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.SubCategories)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_SUB_CATEGORY_CATEGORY");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
