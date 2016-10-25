using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace citizenkraft.UpsStreetAddressValidation.Entities
{

	public class Address
	{
		[JsonProperty("AddressLine")]
		public string Street { get; set; }
		[JsonProperty("PoliticalDivision2")]
		public string City { get; set; }
		[JsonProperty("PoliticalDivision1")]
		public string State { get; set; }
		[JsonProperty("PostcodePrimaryLow")]
		public string PostCode { get; set; }
		[JsonProperty("PostcodeExtendedLow")]
		public string PostcodeExtension { get; set; }
		public string Region { get; set; }
		public string CountryCode { get; set; }

		public Address(string address, string city, string state, string postalCode, string countryCode)
		{
			this.Street = address;
			this.City = city;
			this.State = state;
			this.PostCode = postalCode;
			this.CountryCode = countryCode;
		}

		public string ToHTMLString()
		{
			return string.Format("{0} <br/> {1}, {2} {3}{4}", this.Street, this.City, this.State, this.PostCode, (!string.IsNullOrEmpty(this.PostcodeExtension) ? "-" + this.PostcodeExtension : string.Empty));
			
		}
	}
}
