using EFCoreCoinGeckoAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreCoinGeckoAPI.Database.Configurations
{
	public class CurrencyConfiguration : IEntityTypeConfiguration<CurrencyEntity>
	{
		public void Configure(EntityTypeBuilder<CurrencyEntity> builder)
		{
			builder
			.ToTable("Currencies")
			.HasKey(currency => currency.Id);
		}
	}
}
