using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace citizenkraft.UpsStreetAddressValidation.Entities
{
	public class AddressValidationResult
	{
		public enum ResponseStatus
		{
			CorrectionFound,
			NoCorrectionFound,
			ErrorInResponse,
			Exception
		}
		public ResponseStatus Status { get; set; }
		public string ResponseMessage { get; set; }
		public Address CorrectedAddress { get; set; }
		public ErrorDetail ErrorDetail { get; set; }
	
		public AddressValidationResult(Exception ex)
		{
			this.ResponseMessage = ex.Message;
			this.Status = ResponseStatus.Exception;
		}
		internal AddressValidationResult(AddressValidationResponse response)
		{
			if (response.XAVResponse != null)
			{
				this.Status = (response.XAVResponse.HasCandidate ? ResponseStatus.CorrectionFound : ResponseStatus.NoCorrectionFound);
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
				this.Status = ResponseStatus.ErrorInResponse;
				this.ResponseMessage = "An error has occured.";
				this.ErrorDetail = response.Fault.detail.Errors.ErrorDetail;
			}
		}
	}
}
