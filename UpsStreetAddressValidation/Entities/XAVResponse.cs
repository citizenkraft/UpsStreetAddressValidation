using citizenkraft.UpsStreetAddressValidation.Extensions;
using Newtonsoft.Json;
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
		[JsonConverter(typeof(SingleValueArrayConverter<Candidate>))]
		public List<Candidate> Candidate { get; set; }
		public string NoCandidatesIndicator { get; set; }
		public string AmbiguousAddressIndicator { get; set; }
		public bool HasCandidates { get { return this.Candidate != null && this.Candidate.Any(); } }
	}

}
