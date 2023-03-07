using EFCoreCoinGeckoAPI.Database.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCoinGeckoAPI.Services.CoinsServices
{
	public interface ICoinsService
	{
		Task<bool> Create(CoinsEntity category);
		Task<CoinsEntity> GetCoinsFromAPIAsync(string URL);
	}
}
