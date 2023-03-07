using EFCoreCoinGeckoAPI.Database.Entities;
using EFCoreCoinGeckoAPI.Database.GenericRepository;
using Newtonsoft.Json;

namespace EFCoreCoinGeckoAPI.Services.CategoryServices
{
	public class CategoryService : ICategoryService
	{
		private readonly IGenericRepository<CategoryEntity> _categoryRepository;

		public CategoryService(IGenericRepository<CategoryEntity> categoryRepository)
		{
			_categoryRepository = categoryRepository;
		}

		public async Task<bool> Create(CategoryEntity category)
		{
			try
			{
				await _categoryRepository.CreateAsync(category);
				return true;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Error creating category: {ex.Message}");
				if (ex.InnerException != null)
				{
					Console.WriteLine("Inner exception: " + ex.InnerException.Message);
				}
				return false;
			}
		}

		public async Task<List<CategoryEntity>> GetCategoriesFromAPI(string ALL_CATEGORIES)
		{
			try
			{
				var client = new HttpClient();
				var message = await client.GetAsync(ALL_CATEGORIES);
				message.EnsureSuccessStatusCode();
				var context = await message.Content.ReadAsStringAsync();
				var categories = JsonConvert.DeserializeObject<List<CategoryEntity>>(context);
				return categories;

				//	var currencyNames = JsonConvert.DeserializeObject<List<string>>(context);
				//	var currencies = currencyNames.Select(name => new CurrencyEntity { Name = name }).ToList();
				//	return currencies;
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"Error retrieving categories from API: {ex.Message}");
				return null;
			}
			catch (JsonException ex)
			{
				Console.WriteLine($"Error deserializing categories: {ex.Message}");
				return null;
			}
		}
	}
}
