using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace citizenkraft.UpsStreetAddressValidation.Entities
{
	internal class Fault
	{
		public string faultcode { get; set; }
		public string faultstring { get; set; }
		public Detail detail { get; set; }
	}
	public class PrimaryErrorCode
	{
		public string Code { get; set; }
		public string Description { get; set; }
	}

	public class Location
	{
		public string LocationElementName { get; set; }
		public string XPathOfElement { get; set; }
		public string OriginalValue { get; set; }
	}

	public class SubErrorCode
	{
		public string Code { get; set; }
		public string Description { get; set; }
	}

	public class ErrorDetail
	{
		public string Severity { get; set; }
		public PrimaryErrorCode PrimaryErrorCode { get; set; }
		public Location Location { get; set; }
		public SubErrorCode SubErrorCode { get; set; }
	}

	internal class Errors
	{
		public ErrorDetail ErrorDetail { get; set; }
	}

	internal class Detail
	{
		public Errors Errors { get; set; }
	}

}
