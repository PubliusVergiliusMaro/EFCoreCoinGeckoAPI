using Newtonsoft.Json;

namespace EFCoreCoinGeckoAPI.Database.Entities
{
	public class ExchangeEntity
	{
		public int Id { get; set; }
		[JsonProperty("id")]
		public string ExchangeId { get; set;}
		public string Name { get; set; }
	}
}
