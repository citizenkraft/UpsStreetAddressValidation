using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using citizenkraft.UpsStreetAddressValidation.Entities;
using System.Net;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;

namespace citizenkraft.UpsStreetAddressValidation
{
	public class UpsStreetAddressValidator
	{
		public string Username { get; set; }
		public string Password { get; set; }
		public string LicenseNumber { get; set; }
		public bool IsTest { get; set; }
		private string UpsEndpoint { get { return (IsTest ? "https://wwwcie.ups.com/rest/XAV" : "https://onlinetools.ups.com/rest/XAV"); } }

		public UpsStreetAddressValidator (string username, string password, string licenseNumber, bool isTest)
		{
			this.Username = username;
			this.Password = password;
			this.LicenseNumber = licenseNumber;
			this.IsTest = isTest;
		}

		private AddressValidationResponse ValidateAddress(Address address)
		{
			var req = new AddressValidationRequest(this.Username, this.Password, this.LicenseNumber, address);
			var jsonReq = JsonConvert.SerializeObject(req);
			string result = "";
			using (var client = new WebClient())
			{
				client.Headers[HttpRequestHeader.ContentType] = "application/json";
				result = client.UploadString(this.UpsEndpoint, "POST", jsonReq);
			}
			return JsonConvert.DeserializeObject<AddressValidationResponse>(result);
		}
		public AddressValidationResult ValidateAddress(string street, string city, string state, string postalCode, string countryCode)
		{
			try
			{
				var addressToValidate = new Address(street, city, state, postalCode, countryCode);
				var result = new AddressValidationResult(ValidateAddress(addressToValidate), addressToValidate);
				
				return result;
			}
			catch (Exception ex)
			{
				return new AddressValidationResult(ex);
			}
			
		}
	}

}
