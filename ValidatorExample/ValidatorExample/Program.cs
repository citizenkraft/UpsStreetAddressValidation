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

			//Voila!
		}
	}
}
