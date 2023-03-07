using Newtonsoft.Json;

namespace EFCoreCoinGeckoAPI.Database.Entities
{
	public class AssetPlatformEntity
	{
		public int Id { get; set; }
		[JsonProperty("id")]
		public string AssetId { get; set; }
		[JsonProperty("chain_identifier")]
		public string? ChainId { get; set; }
		public string Name { get; set; }
		public string? Shortname { get; set; }
	}
}
