using EFCoreCoinGeckoAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreCoinGeckoAPI.Database.Configurations
{
	public class ItemConfiguration : IEntityTypeConfiguration<ItemEntity>
	{
		public void Configure(EntityTypeBuilder<ItemEntity> builder)
		{
			builder
				.ToTable("Items")
				.HasKey(x => x.Id);
			builder
				.HasOne<CoinEntity>(item => item.CoinEntity)
				.WithOne(coin => coin.Item)
				.HasForeignKey<ItemEntity>(item => item.CoinFK)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
