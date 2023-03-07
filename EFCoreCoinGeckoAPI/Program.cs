using EFCoreCoinGeckoAPI.Database;
using EFCoreCoinGeckoAPI.Database.Entities;
using EFCoreCoinGeckoAPI.Database.GenericRepository;
using EFCoreCoinGeckoAPI.Services.AssetPlatformServices;
using EFCoreCoinGeckoAPI.Services.CategoryServices;
using EFCoreCoinGeckoAPI.Services.CoinsServices;
using EFCoreCoinGeckoAPI.Services.CurrencyServices;
using EFCoreCoinGeckoAPI.Services.ExchangeServices;
using EFCoreCoinGeckoAPI.Services.IndexesServices;

namespace EFCoreCoinGeckoAPI
{
	public class Program
	{
		private const string SUPORTED_VS_CURRENCIES = "https://api.coingecko.com/api/v3/simple/supported_vs_currencies";
		private const string ASSET_PLATFORMS = "https://api.coingecko.com/api/v3/asset_platforms";
		private const string ALL_CATEGORIES = "https://api.coingecko.com/api/v3/coins/categories/list";
		private const string EXCHANGES = "https://api.coingecko.com/api/v3/exchanges/list";
		private const string INDEXES = "https://api.coingecko.com/api/v3/indexes/list";
		private const string TRENDING = "https://api.coingecko.com/api/v3/search/trending";
		private const string COINS = "https://api.coingecko.com/api/v3/search/trending";


		private static HttpClient client;
		static ApplicationDbContext dbContext;
		static IGenericRepository<CurrencyEntity> currencyRepository;
		static IGenericRepository<AssetPlatformEntity> assetPlatformRepository;
		static IGenericRepository<ExchangeEntity> exchangeRepository;
		static IGenericRepository<CategoryEntity> categoryRepository;
		static IGenericRepository<IndexesEntity> indexesRepository;
		static IGenericRepository<CoinsEntity> coinsRepository;
		static ICurrencyService currencyService;
		static IAssetPlatformService assetPlatformService;
		static ICategoryService categoryService;
		static IExchangeService exchangeService;
		static IIndexesService indexesService;
		static ICoinsService coinsService;

		static void Main(string[] args)
		{
			dbContext = new ApplicationDbContext();
			currencyRepository = new GenericRepository<CurrencyEntity>(dbContext);
			assetPlatformRepository = new GenericRepository<AssetPlatformEntity>(dbContext);
			categoryRepository = new GenericRepository<CategoryEntity>(dbContext);
			exchangeRepository = new GenericRepository<ExchangeEntity>(dbContext);
			indexesRepository = new GenericRepository<IndexesEntity>(dbContext);
			coinsRepository = new GenericRepository<CoinsEntity>(dbContext);
			currencyService = new CurrencyService(currencyRepository);
			assetPlatformService = new AssetPlatformService(assetPlatformRepository);
			categoryService = new CategoryService(categoryRepository);
			exchangeService = new ExchangeService(exchangeRepository);
			indexesService = new IndexesService(indexesRepository);
			coinsService = new CoinsService(coinsRepository);
			Method();

			Console.ReadLine();
		}
		static async void Method()
		{
			CoinsEntity coins = await coinsService.GetCoinsFromAPIAsync(COINS);
			await coinsService.Create(coins);

			List<IndexesEntity> indexes = await indexesService.GetIndexesFromAPIAsync(INDEXES);
			foreach (var index in indexes)
			{
				await indexesService.Create(index);
			}

			List<ExchangeEntity> exchangeList = await exchangeService.GetExchangesFromAPIAsync(EXCHANGES);
			foreach (ExchangeEntity exchange in exchangeList)
			{
				await exchangeService.Create(exchange);
			}
			Console.WriteLine(exchangeList.Count);

			List<CategoryEntity> categories = await categoryService.GetCategoriesFromAPI(ALL_CATEGORIES);

			foreach (CategoryEntity category in categories)
			{
				await categoryService.Create(category);
			}
			Console.WriteLine(categories.Count);

			List<AssetPlatformEntity> assets = await assetPlatformService.GetAllAssetPlatformsFromAPIAsync(ASSET_PLATFORMS);
			foreach (AssetPlatformEntity assetPlatform in assets)
			{
				await assetPlatformService.Create(assetPlatform);
			}

			List<CurrencyEntity> currencies = await currencyService.GetSupportedCurrenciesFromAPIAsync(SUPORTED_VS_CURRENCIES);
			foreach (CurrencyEntity currency in currencies)
			{
				currencyService.Create(currency);
			}
			Console.WriteLine(currencies.Count);
			Console.WriteLine("Succes");
		}
	}
}