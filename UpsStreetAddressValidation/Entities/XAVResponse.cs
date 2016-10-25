using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace citizenkraft.UpsStreetAddressValidation.Entities
{
	internal class XAVResponse
	{
		public Response Response { get; set; }
		public string ValidAddressIndicator { get; set; }
		public Candidate Candidate { get; set; }
		public string NoCandidatesIndicator { get; set; }

		public bool IsValidResponse { get { return this.ValidAddressIndicator != null; } }
		public bool HasCandidate { get { return this.Candidate != null && this.Candidate.AddressKeyFormat != null; } }
	}

}
