using EFCoreCoinGeckoAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreCoinGeckoAPI.Database.Configurations
{
	public class IndexesConfiguration : IEntityTypeConfiguration<IndexesEntity>
	{
		public void Configure(EntityTypeBuilder<IndexesEntity> builder)
		{
			builder.ToTable("Indexes").HasKey(i => i.Id);
		}
	}
}
