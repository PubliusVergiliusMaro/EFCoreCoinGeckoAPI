using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCoinGeckoAPI.Database.Entities
{
	public class CoinsEntity
	{
		public int Id { get; set; }
		[JsonProperty("coins")]
		public List<CoinEntity> CoinList { get; set; }
	}
}
