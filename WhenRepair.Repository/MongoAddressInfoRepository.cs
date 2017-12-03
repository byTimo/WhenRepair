using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using WhenRepair.Application;
using WhenRepair.Repository.Types;

namespace WhenRepair.Repository
{
	public class MongoAddressInfoRepository : IAddressInfoRepository
	{
		private readonly IMongoClient client;

		private IMongoCollection<AddressInfo> Collection =>
			client.GetDatabase("repairs-db").GetCollection<AddressInfo>("districts");

		public MongoAddressInfoRepository(string connectionString)
		{
			client = new MongoClient(connectionString);
		}

		public async Task<IEnumerable<AddressInfo>> GetByDistrictAndYear(string district, int year)
		{
			var res = await Collection.FindAsync(
				Builders<AddressInfo>.Filter.And(
					Builders<AddressInfo>.Filter.Where(a => a.DistrictName.Equals(district)),
					Builders<AddressInfo>.Filter.Where(a => a.Works.Any(w => year >= w.PlannedStartYear && year <= w.PlannedEndYear))
					));

			return res.ToList();
		}

		public async Task<IDictionary<string, int>> GetYears()
		{
			var res = await Collection
				.Find(FilterDefinition<AddressInfo>.Empty)
				.ToListAsync();

			return res.SelectMany(a => a.Works)
				.Select(w => $"{w.PlannedStartYear}-{w.PlannedEndYear}")
				.GroupBy(w => w)
				.ToDictionary(w => w.Key, w => w.Count());
		}

		public Task<List<GeoCoordinate>> GetBuildingsByYears(string years)
		{
			var parts = years.Split('-').Select(int.Parse).ToArray();
			return GetBuildingsByYears(parts[0], parts[1]);
		}
		
		private async Task<List<GeoCoordinate>> GetBuildingsByYears(int start, int end)
		{
			var res = Collection.Find(
					Builders<AddressInfo>.Filter.And(
						Builders<AddressInfo>.Filter.Where(info => info.Works.Any(w => w.PlannedStartYear == start)),
						Builders<AddressInfo>.Filter.Where(info => info.Works.Any(w => w.PlannedEndYear == end))
					))
				.Project(a => new GeoCoordinate {Latitude = $"{a.Lattitude}", Longitude = $"{a.Longitude}"});
			return await res.ToListAsync();
		}
	}
}