using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCoinGeckoAPI.Database.Entities
{
	public class IndexesEntity
	{
		public int Id { get; set; }
		[JsonProperty("id")]
		public string IngexesId { get; set; }
		public string Name { get; set; }
	}
}
