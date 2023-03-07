using EFCoreCoinGeckoAPI.Database.Entities;
using EFCoreCoinGeckoAPI.Database.GenericRepository;
using Newtonsoft.Json;

namespace EFCoreCoinGeckoAPI.Services.CurrencyServices
{
	public class CurrencyService : ICurrencyService
	{
		private readonly IGenericRepository<CurrencyEntity> _currencyRepository;

		public CurrencyService(IGenericRepository<CurrencyEntity> currencyRepository)
		{
			_currencyRepository = currencyRepository;
		}

		public void Create(CurrencyEntity currency)
		{
			_currencyRepository.Create(currency);
		}

		public async Task<List<CurrencyEntity>> GetSupportedCurrenciesFromAPIAsync(string URL)
		{
			var client = new HttpClient();
			var message = await client.GetAsync(URL);
			message.EnsureSuccessStatusCode();
			var context = await message.Content.ReadAsStringAsync();
			try
			{
				var currencyNames = JsonConvert.DeserializeObject<List<string>>(context);
				var currencies = currencyNames.Select(name => new CurrencyEntity { Name = name }).ToList();
				return currencies;
			}
			catch(Exception ex)
			{
				Console.WriteLine(ex.Message);
				return null;
			}

		}
	}
}
