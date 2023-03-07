using EFCoreCoinGeckoAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreCoinGeckoAPI.Database.Configurations
{
	internal class AssetPlatformConfiguration : IEntityTypeConfiguration<AssetPlatformEntity>
	{
		public void Configure(EntityTypeBuilder<AssetPlatformEntity> builder)
		{
			builder
			.ToTable("Assets")
			.HasKey(currency => currency.Id);
		}
	}
}
