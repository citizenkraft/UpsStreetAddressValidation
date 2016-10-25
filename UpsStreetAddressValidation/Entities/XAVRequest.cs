using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace citizenkraft.UpsStreetAddressValidation.Entities
{
	internal class XAVRequest
	{
		public object Request { get; set; }
		public string MaximumListSize { get; set; }
		public Address AddressKeyFormat { get; set; }
		public XAVRequest(Address address)
		{
			this.Request = new
			{
				RequestOption = "1",
				TransactionReference = new
				{
					CustomerContext = "Address Verification" 
				}
			};
			this.MaximumListSize = "10";
			this.AddressKeyFormat = address;
		}

	}
}
