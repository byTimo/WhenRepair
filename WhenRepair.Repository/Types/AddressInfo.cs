using System.Collections.Generic;

namespace WhenRepair.Repository.Types
{
	public class AddressInfo
	{
		public AddressInfo(string address)
		{
			Address = address;
			Works = new List<WorksInfo>();
		}

		public string Address { get; set; }
		public List<WorksInfo> Works { get; set; }
	}
}
