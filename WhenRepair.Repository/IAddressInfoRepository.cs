using System.Collections.Generic;
using System.Threading.Tasks;
using WhenRepair.Application;

namespace WhenRepair.Repository
{
	public interface IAddressInfoRepository
	{
		Task<IDictionary<(int start, int end), int>> GetYears();
		Task<IDictionary<(int start, int end), List<GeoCoordinate>>> GetBuildingsByYears((int start, int end) years);
		Task<IDictionary<(int start, int end), List<GeoCoordinate>>> GetBuildingsByYears(int startYear, int endYear);
	}
}
