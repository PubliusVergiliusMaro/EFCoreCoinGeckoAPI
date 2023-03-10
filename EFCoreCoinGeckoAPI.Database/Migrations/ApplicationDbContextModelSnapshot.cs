// <auto-generated />
using System;
using EFCoreCoinGeckoAPI.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EFCoreCoinGeckoAPI.Database.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EFCoreCoinGeckoAPI.Database.Entities.AssetPlatformEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AssetId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ChainId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Shortname")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Assets", (string)null);
                });

            modelBuilder.Entity("EFCoreCoinGeckoAPI.Database.Entities.CategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CategoryId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);
                });

            modelBuilder.Entity("EFCoreCoinGeckoAPI.Database.Entities.CoinEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CoinsFK")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CoinsFK");

                    b.ToTable("Coins", (string)null);
                });

            modelBuilder.Entity("EFCoreCoinGeckoAPI.Database.Entities.CoinsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.HasKey("Id");

                    b.ToTable("Coin", (string)null);
                });

            modelBuilder.Entity("EFCoreCoinGeckoAPI.Database.Entities.CurrencyEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Currencies", (string)null);
                });

            modelBuilder.Entity("EFCoreCoinGeckoAPI.Database.Entities.ExchangeEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ExchangeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Exchangs", (string)null);
                });

            modelBuilder.Entity("EFCoreCoinGeckoAPI.Database.Entities.IndexesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("IngexesId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Indexes", (string)null);
                });

            modelBuilder.Entity("EFCoreCoinGeckoAPI.Database.Entities.ItemEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CoinFK")
                        .HasColumnType("int");

                    b.Property<int>("CoinId")
                        .HasColumnType("int");

                    b.Property<string>("ItemId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Large")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MarketCapRank")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PriceBtc")
                        .HasColumnType("float");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Small")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Symbol")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Thumb")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CoinFK")
                        .IsUnique()
                        .HasFilter("[CoinFK] IS NOT NULL");

                    b.ToTable("Items", (string)null);
                });

            modelBuilder.Entity("EFCoreCoinGeckoAPI.Database.Entities.CoinEntity", b =>
                {
                    b.HasOne("EFCoreCoinGeckoAPI.Database.Entities.CoinsEntity", "Coins")
                        .WithMany("CoinList")
                        .HasForeignKey("CoinsFK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Coins");
                });

            modelBuilder.Entity("EFCoreCoinGeckoAPI.Database.Entities.ItemEntity", b =>
                {
                    b.HasOne("EFCoreCoinGeckoAPI.Database.Entities.CoinEntity", "CoinEntity")
                        .WithOne("Item")
                        .HasForeignKey("EFCoreCoinGeckoAPI.Database.Entities.ItemEntity", "CoinFK")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("CoinEntity");
                });

            modelBuilder.Entity("EFCoreCoinGeckoAPI.Database.Entities.CoinEntity", b =>
                {
                    b.Navigation("Item")
                        .IsRequired();
                });

            modelBuilder.Entity("EFCoreCoinGeckoAPI.Database.Entities.CoinsEntity", b =>
                {
                    b.Navigation("CoinList");
                });
#pragma warning restore 612, 618
        }
    }
}
