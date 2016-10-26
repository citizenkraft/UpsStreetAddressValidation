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
			CorrectionsFound,
			NoCorrectionFound,
			ErrorInResponse,
			Exception,
			NotUSAddress
		}
		public ResponseStatus Status { get; set; }
		public string ResponseMessage { get; set; }
		public List<Address> AddressCandidates { get; set; }
		public ErrorDetail ErrorDetail { get; set; }
	
		internal AddressValidationResult(string message, ResponseStatus status)
		{
			this.ResponseMessage = message;
			this.Status = status;
		}
		internal AddressValidationResult(Exception ex)
		{
			this.ResponseMessage = ex.Message;
			this.Status = ResponseStatus.Exception;
		}
		internal AddressValidationResult(AddressValidationResponse response, Address addressToValidate)
		{
			if (response.XAVResponse != null)
			{
				if (response.XAVResponse.HasCandidates && response.XAVResponse.Candidate.Count == 1 && response.XAVResponse.Candidate.First().AddressKeyFormat.CompareTo(addressToValidate) == 0)
				{
					this.ResponseMessage = "Corrected address was the same as the submitted address";
					this.Status = ResponseStatus.NoCorrectionFound;
				}
				else if (response.XAVResponse.HasCandidates)
				{
					this.ResponseMessage = string.Format("{0} correction{1} found", response.XAVResponse.Candidate.Count, (response.XAVResponse.Candidate.Count == 1 ? " was" : "s were"));
					this.AddressCandidates = response.XAVResponse.Candidate.Select(x=> x.AddressKeyFormat).ToList();
					this.Status = ResponseStatus.CorrectionsFound;
				}
				else
				{
					this.ResponseMessage = "No corrections were found";
					this.Status = ResponseStatus.NoCorrectionFound;
				}
			}
			else
			{
				this.Status = ResponseStatus.ErrorInResponse;
				this.ResponseMessage = "An error has occured";
				this.ErrorDetail = response.Fault.detail.Errors.ErrorDetail;
			}
		}
	}
}
