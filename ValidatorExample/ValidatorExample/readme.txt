//Usage:

//create the object
var validator = new citizenkraft.UpsStreetAddressValidation.UpsStreetAddressValidator("username", "password", "licensekey", true / false value to hit test or production);
//get the response
var validatorResponse = validator.ValidateAddress("1865 GAYLORD ST", "DENVER", "CO", "80206", "US");

//Voila!