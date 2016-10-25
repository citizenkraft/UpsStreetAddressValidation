using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace citizenkraft.UpsStreetAddressValidation.Entities
{
	public class AddressValidationResult
	{
		public string ResponseMessage { get; set; }
		public bool Success { get; set; }
		public Address CorrectedAddress { get; set; }
		public ErrorDetail ErrorDetail { get; set; }
	
		public AddressValidationResult(Exception ex)
		{
			this.ResponseMessage = ex.Message;
			this.Success = false;
		}
		internal AddressValidationResult(AddressValidationResponse response)
		{
			if (response.XAVResponse != null)
			{
				this.Success = response.XAVResponse.IsValidResponse;
				if (response.XAVResponse.HasCandidate)
				{
					this.ResponseMessage = "A correction has been suggested";
					this.CorrectedAddress = response.XAVResponse.Candidate.AddressKeyFormat;
				}
				else
				{
					this.ResponseMessage = "No correction has been suggested";
				}
			} else
			{
				this.Success = false;
				this.ResponseMessage = "An error has occured.";
				this.ErrorDetail = response.Fault.detail.Errors.ErrorDetail;
			}
		}
	}
}
