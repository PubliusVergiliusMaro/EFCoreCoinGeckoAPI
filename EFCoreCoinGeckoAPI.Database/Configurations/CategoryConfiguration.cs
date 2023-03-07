using EFCoreCoinGeckoAPI.Database.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreCoinGeckoAPI.Database.Configurations
{
	public class CategoryConfiguration : IEntityTypeConfiguration<CategoryEntity>
	{
		public void Configure(EntityTypeBuilder<CategoryEntity> builder)
		{
			builder
			.ToTable("Categories")
			.HasKey(category => category.Id);
		}
	}
}
