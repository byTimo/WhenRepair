using System.Collections.Generic;

namespace WhenRepair.Repository.Types
{
	public class DistrictInfo
	{
		public DistrictInfo(string name)
		{
			Name = name;
			Addresses = new List<AddressInfo>();
		}

		public string Name { get; set; }
		public List<AddressInfo> Addresses { get; set; }
	}
}