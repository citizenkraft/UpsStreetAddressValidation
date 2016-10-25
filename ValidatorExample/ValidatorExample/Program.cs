using citizenkraft.UpsStreetAddressValidation.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorExample
{
	class Program
	{
		static void Main(string[] args)
		{
			//Usage:

			//create the object
			var validator = new citizenkraft.UpsStreetAddressValidation.UpsStreetAddressValidator("username", "password", "licensekey", false);
			//get the response
			var validatorResponse = validator.ValidateAddress("1865 GAYLORD ST", "DENVER", "CO", "80206", "US");

			switch (validatorResponse.Status)
			{
				case AddressValidationResult.ResponseStatus.CorrectionFound:
					//corrected address can be found here: validatorResponse.CorrectedAddress.Street validatorResponse.CorrectedAddress.Whatever 
					Console.WriteLine(validatorResponse.CorrectedAddress.Street);
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
				default:
					break;
			}
			 //Voila!
		}
	}
}
