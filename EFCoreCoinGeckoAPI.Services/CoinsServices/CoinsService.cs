using EFCoreCoinGeckoAPI.Database.Entities;
using EFCoreCoinGeckoAPI.Database.GenericRepository;
using Newtonsoft.Json;

namespace EFCoreCoinGeckoAPI.Services.CoinsServices
{
	public class CoinsService : ICoinsService
	{
		private readonly IGenericRepository<CoinsEntity> _coinsRepository;

		public CoinsService(IGenericRepository<CoinsEntity> coinsRepository)
		{
			_coinsRepository = coinsRepository;
		}

		public async Task<bool> Create(CoinsEntity category)
		{
			try
			{
				await _coinsRepository.CreateAsync(category);
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

		public async Task<CoinsEntity> GetCoinsFromAPIAsync(string URL)
		{
			try
			{
				var client = new HttpClient();
				var message = await client.GetAsync(URL);
				message.EnsureSuccessStatusCode();
				var context = await message.Content.ReadAsStringAsync();
				var categories = JsonConvert.DeserializeObject<CoinsEntity>(context);
				return categories;
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
