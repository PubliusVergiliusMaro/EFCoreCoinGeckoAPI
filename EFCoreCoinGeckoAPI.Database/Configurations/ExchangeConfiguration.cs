using EFCoreCoinGeckoAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreCoinGeckoAPI.Database.Configurations
{
	public class ExchangeConfiguration : IEntityTypeConfiguration<ExchangeEntity>
	{
		public void Configure(EntityTypeBuilder<ExchangeEntity> builder)
		{
			builder.ToTable("Exchangs").HasKey(e => e.Id);
		}
	}
}
