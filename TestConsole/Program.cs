using citizenkraft.UpsStreetAddressValidation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole
{
	class Program
	{
		static void Main(string[] args)
		{
			var validator = new citizenkraft.UpsStreetAddressValidation.UpsStreetAddressValidator("username", "password", "license key", false);
			//get the response
			//multiple address candidates
			var validatorResponse = validator.ValidateAddress("809 Broadway st", "lenoir city", "tn", "37771", "US");

			//single address candidate response
			var validatorResponse1 = validator.ValidateAddress("1865 Gaylord St", "Denver", "co", "80206", "US");

			//Not US or PR address
			var validatorResponse2 = validator.ValidateAddress("51 westendstrasse", "Munchen", "Bavaria", "", "DE");

			//just garbage
			var validatorResponse3 = validator.ValidateAddress("1234 Whatever Ln", "Fourside", "Eagleland", "12345", "US");
	
			//Usage:
			switch (validatorResponse.Status)
			{
				case AddressValidationResult.ResponseStatus.CorrectionsFound:
					//corrected address can be found here: validatorResponse.CorrectedAddress.Street validatorResponse.AddressCandidates[0].Whatever 
					Console.WriteLine(validatorResponse.AddressCandidates.First().Street);
					break;
				case AddressValidationResult.ResponseStatus.NoCorrectionFound:
					//no corrected address was found, but everything went fine.
					Console.WriteLine(validatorResponse.ResponseMessage);
					break;
				case AddressValidationResult.ResponseStatus.ErrorInResponse:
					//there was an error sent back from UPS, usually bad credentials.  Find the details under validatorResponse.ErrorDetail.whatever
					Console.WriteLine(validatorResponse.ErrorDetail.PrimaryErrorCode.Description);
					break;
				case AddressValidationResult.ResponseStatus.Exception:
					//big break, bad connection probably.  I pass the sometimes helpful exception message back
					Console.WriteLine(validatorResponse.ResponseMessage);
					break;
				case AddressValidationResult.ResponseStatus.NotUSAddress:
					//UPS only supports looking up US and Puerto Rican addresses.
					Console.WriteLine(validatorResponse.ResponseMessage);
					break;
				default:
					break;
			}
			//Voila!
		}
	}
}
