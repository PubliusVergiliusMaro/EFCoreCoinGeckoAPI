using Microsoft.EntityFrameworkCore.Query;
using Newtonsoft.Json;

namespace EFCoreCoinGeckoAPI.Database.Entities
{
	public class ItemEntity
	{
		public int Id { get; set; }
		[JsonProperty("id")]
		public string ItemId { get; set; }
		[JsonProperty("coin_id")]
		public int CoinId { get; set; }
		public string Name { get; set; }
		public string Symbol { get; set; }
		[JsonProperty("market_cap_rank")]
		public int MarketCapRank { get; set; }
		public string Thumb { get; set; }
		public string Small { get; set; }
		public string Large { get; set; }
		public string Slug { get; set; }
		[JsonProperty("price_btc")]
		public double PriceBtc { get; set; }
		public int Score { get; set; }

		public int? CoinFK { get; set; }
		public CoinEntity CoinEntity { get; set; }
	}
}
