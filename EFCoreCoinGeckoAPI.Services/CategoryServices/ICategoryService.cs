using EFCoreCoinGeckoAPI.Database.Entities;

namespace EFCoreCoinGeckoAPI.Services.CategoryServices
{
	public interface ICategoryService
	{
		Task<bool> Create(CategoryEntity category);

		Task<List<CategoryEntity>> GetCategoriesFromAPI(string ALL_CATEGORIES);
	}
}
