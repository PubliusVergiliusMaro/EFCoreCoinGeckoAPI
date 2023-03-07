using EFCoreCoinGeckoAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreCoinGeckoAPI.Database.Configurations
{
	public class CoinsConfiguration : IEntityTypeConfiguration<CoinsEntity>
	{
		public void Configure(EntityTypeBuilder<CoinsEntity> builder)
		{
			builder.ToTable("Coin").HasKey(x => x.Id);
		}
	}
}
