using EFCoreCoinGeckoAPI.Database.Entities;
using EFCoreCoinGeckoAPI.Database.GenericRepository;
using Newtonsoft.Json;

namespace EFCoreCoinGeckoAPI.Services.IndexesServices
{
	public class IndexesService : IIndexesService
	{
		private readonly IGenericRepository<IndexesEntity> _indexesRepository;

		public IndexesService(IGenericRepository<IndexesEntity> indexesRepository)
		{
			_indexesRepository = indexesRepository;
		}

		public async Task<bool> Create(IndexesEntity category)
		{
			try
			{
				await _indexesRepository.CreateAsync(category);
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

		public async Task<List<IndexesEntity>> GetIndexesFromAPIAsync(string URL)
		{
			try
			{
				var client = new HttpClient();
				var message = await client.GetAsync(URL);
				message.EnsureSuccessStatusCode();
				var context = await message.Content.ReadAsStringAsync();
				var indexes = JsonConvert.DeserializeObject<List<IndexesEntity>>(context);
				return indexes;
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
