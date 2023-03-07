using EFCoreCoinGeckoAPI.Database.Entities;
namespace EFCoreCoinGeckoAPI.Services.AssetPlatformServices
{
	public interface IAssetPlatformService
	{
		Task<bool> Create(AssetPlatformEntity category);
		Task<List<AssetPlatformEntity>> GetAllAssetPlatformsFromAPIAsync(string URL);
	}
}
