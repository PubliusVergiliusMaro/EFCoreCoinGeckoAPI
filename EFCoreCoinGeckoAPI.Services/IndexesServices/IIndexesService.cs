using EFCoreCoinGeckoAPI.Database.Entities;

namespace EFCoreCoinGeckoAPI.Services.IndexesServices
{
	public interface IIndexesService
	{
		Task<bool> Create(IndexesEntity category);
		Task<List<IndexesEntity>> GetIndexesFromAPIAsync(string URL);
	}
}
