using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace EFCoreCoinGeckoAPI.Database.Entities
{
	public class CategoryEntity
	{
			public int Id { get; set; }
      		[JsonProperty("category_id")]
			public string? CategoryId { get; set; }
	     	public string Name { get; set; }   
	}
}
