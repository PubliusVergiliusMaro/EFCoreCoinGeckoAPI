using EFCoreCoinGeckoAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreCoinGeckoAPI.Database.Configurations
{
	public class CoinConfiguration : IEntityTypeConfiguration<CoinEntity>
	{
		public void Configure(EntityTypeBuilder<CoinEntity> builder)
		{
			builder.ToTable("Coins").HasKey(coins => coins.Id);

			builder
				.HasOne<CoinsEntity>(coin=>coin.Coins)
				.WithMany(coin => coin.CoinList)
				.HasForeignKey(coin=>coin.CoinsFK)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
