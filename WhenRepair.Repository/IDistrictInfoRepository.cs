using System.Collections.Generic;
using System.Threading.Tasks;
using WhenRepair.Repository.Types;

namespace WhenRepair.Repository
{
	public interface IDistrictInfoRepository
	{
		Task<IEnumerable<DistrictInfo>> GetDistrictInfosAsync();
	}
}
