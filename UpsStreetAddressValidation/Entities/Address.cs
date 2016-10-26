using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace citizenkraft.UpsStreetAddressValidation.Entities
{

	public class Address : IComparable
	{
		[JsonProperty("AddressLine")]
		public string Street { get; set; }
		[JsonProperty("PoliticalDivision2")]
		public string City { get; set; }
		[JsonProperty("PoliticalDivision1")]
		public string State { get; set; }
		[JsonProperty("PostcodePrimaryLow")]
		public string Postcode { get; set; }
		[JsonProperty("PostcodeExtendedLow")]
		public string PostcodeExtension { get; set; }
		public string Region { get; set; }
		public string CountryCode { get; set; }

		public Address(string address, string city, string state, string postalCode, string countryCode)
		{
			this.Street = address;
			this.City = city;
			this.State = state;
			this.CountryCode = countryCode;
			if (postalCode != null && postalCode.Contains('-'))
			{
				var splitPostcode = postalCode.Split('-');
				this.Postcode = splitPostcode.First();
				this.PostcodeExtension = splitPostcode.Last();
			} else
			{
				this.Postcode = postalCode;
				this.PostcodeExtension = string.Empty;
			}
			this.Region = string.Empty;
		}

		public Address() { }

		public string ToHTMLString()
		{
			return string.Format("{0} <br/> {1}, {2} {3}{4}", this.Street, this.City, this.State, this.Postcode, (!string.IsNullOrEmpty(this.PostcodeExtension) ? "-" + this.PostcodeExtension : string.Empty));
			
		}

		public int CompareTo(object obj)
		{
			if (obj == null) return -1;

			Address otherAddress = obj as Address;

			if (this.Street.ToLower().Trim().Equals(otherAddress.Street.ToLower().Trim()) && this.City.ToLower().Trim().Equals(otherAddress.City.ToLower().Trim()) && this.State.ToLower().Trim().Equals(otherAddress.State.ToLower().Trim()) && this.Postcode.ToLower().Trim().Equals(otherAddress.Postcode.ToLower().Trim()) && this.PostcodeExtension.ToLower().Trim().Equals(otherAddress.PostcodeExtension.ToLower().Trim()))
				return 0;

			return 1;
		}
	}
}
