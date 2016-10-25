using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace citizenkraft.UpsStreetAddressValidation.Entities
{
	internal class AddressValidationResponse
	{
		public XAVResponse XAVResponse { get; set; }
		public Fault Fault { get; set; }
	}
}
