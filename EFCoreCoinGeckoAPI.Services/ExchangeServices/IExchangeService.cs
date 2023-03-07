using EFCoreCoinGeckoAPI.Database.Entities;

namespace EFCoreCoinGeckoAPI.Services.ExchangeServices
{
	public interface IExchangeService
	{
		Task<bool> Create(ExchangeEntity category);
		Task<List<ExchangeEntity>> GetExchangesFromAPIAsync(string URL);
	}
}
