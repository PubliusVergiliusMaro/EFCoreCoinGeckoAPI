namespace EFCoreCoinGeckoAPI.Database.Entities
{
	public class CoinEntity
	{
		public int Id { get; set; }
	

		public int? CoinsFK { get; set; }
		public CoinsEntity Coins { get; set; }
		public ItemEntity Item { get; set; }
	}
}
