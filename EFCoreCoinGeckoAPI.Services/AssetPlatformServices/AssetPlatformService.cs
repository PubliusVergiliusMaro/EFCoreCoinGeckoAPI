using EFCoreCoinGeckoAPI.Database.Entities;
using EFCoreCoinGeckoAPI.Database.GenericRepository;
using Newtonsoft.Json;

namespace EFCoreCoinGeckoAPI.Services.AssetPlatformServices
{
	public class AssetPlatformService : IAssetPlatformService
	{
	    private readonly IGenericRepository<AssetPlatformEntity> _assetPlatformRepository;

		public AssetPlatformService(IGenericRepository<AssetPlatformEntity> assetPlatformRepository)
		{
			_assetPlatformRepository = assetPlatformRepository;
		}

		public async Task<bool> Create(AssetPlatformEntity asset)
		{
			try
			{
				await _assetPlatformRepository.CreateAsync(asset);
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

		public async Task<List<AssetPlatformEntity>> GetAllAssetPlatformsFromAPIAsync(string URL)
		{
			var client = new HttpClient();
			var message = await client.GetAsync(URL);
			message.EnsureSuccessStatusCode();
			var context = await message.Content.ReadAsStringAsync();
			try
			{
				var assets = JsonConvert.DeserializeObject<List<AssetPlatformEntity>>(context);
				return assets;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return null;
			}

		}
	}
}
