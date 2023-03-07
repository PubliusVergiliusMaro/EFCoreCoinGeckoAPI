using EFCoreCoinGeckoAPI.Database.Entities;

namespace EFCoreCoinGeckoAPI.Services.CurrencyServices
{
	public interface ICurrencyService
	{
		void Create(CurrencyEntity currency);
		Task<List<CurrencyEntity>> GetSupportedCurrenciesFromAPIAsync(string URL);
	}
}
