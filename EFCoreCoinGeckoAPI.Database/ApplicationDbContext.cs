using EFCoreCoinGeckoAPI.Database.Configurations;
using EFCoreCoinGeckoAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreCoinGeckoAPI.Database
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<CurrencyEntity> Currencies { get; set; }
		public DbSet<AssetPlatformEntity> Assets { get; set; }
		public DbSet<CategoryEntity> Categories { get; set; }
		public DbSet<ExchangeEntity> Exchanges { get; set; }
		public DbSet<IndexesEntity> Indexes { get; set; }
		public DbSet<CoinEntity> Coin { get; set; }
		public DbSet<CoinsEntity> Coins { get; set; }
		public DbSet<ItemEntity> Items { get; set; }
		public ApplicationDbContext()
		{
			Database.Migrate();
		}
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Data Source=localhost;Database=EFCoreСoinGeckoAPI;Trusted_Connection=True;TrustServerCertificate=True;");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new CurrencyConfiguration());
			modelBuilder.ApplyConfiguration(new AssetPlatformConfiguration());
			modelBuilder.ApplyConfiguration(new CategoryConfiguration());
			modelBuilder.ApplyConfiguration(new ExchangeConfiguration());
			modelBuilder.ApplyConfiguration(new IndexesConfiguration());
			modelBuilder.ApplyConfiguration(new CoinConfiguration());
			modelBuilder.ApplyConfiguration(new ItemConfiguration());
			modelBuilder.ApplyConfiguration(new CoinsConfiguration());

		}
	}
}
