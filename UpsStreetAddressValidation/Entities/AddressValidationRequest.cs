using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace citizenkraft.UpsStreetAddressValidation.Entities
{
	[Serializable()]
	internal class AddressValidationRequest
	{
		public object UPSSecurity { get; set; }
		public XAVRequest XAVRequest { get; set; }

		public AddressValidationRequest (string username, string password, string licenseNumber, Address address)
		{
			this.UPSSecurity = new
			{
				UsernameToken = new { Username = username, Password = password },
				ServiceAccessToken = new { AccessLicenseNumber = licenseNumber }
			};
			this.XAVRequest = new XAVRequest(address);
		}
	}
}
