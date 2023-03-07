using EFCoreCoinGeckoAPI.Database.Entities;
using EFCoreCoinGeckoAPI.Database.GenericRepository;
using Newtonsoft.Json;

namespace EFCoreCoinGeckoAPI.Services.ExchangeServices
{
	public class ExchangeService : IExchangeService
	{
		private readonly IGenericRepository<ExchangeEntity> _exchangeRepository;

		public ExchangeService(IGenericRepository<ExchangeEntity> exchangeRepository)
		{
			_exchangeRepository = exchangeRepository;
		}

		public async Task<bool> Create(ExchangeEntity category)
		{
			try
			{
				await _exchangeRepository.CreateAsync(category);
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

		public async Task<List<ExchangeEntity>> GetExchangesFromAPIAsync(string URL)
		{
			try
			{
				var client = new HttpClient();
				var message = await client.GetAsync(URL);
				message.EnsureSuccessStatusCode();
				var context = await message.Content.ReadAsStringAsync();
				var categories = JsonConvert.DeserializeObject<List<ExchangeEntity>>(context);
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
