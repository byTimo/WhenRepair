using System.Collections.Generic;
using System.Threading.Tasks;
using WhenRepair.Repository.Types;

namespace WhenRepair.Repository
{
	public class MongoDistrictInfoRepository : IDistrictInfoRepository
	{
		public Task<IEnumerable<DistrictInfo>> GetDistrictInfosAsync()
		{
			throw new System.NotImplementedException();
		}
	}
}