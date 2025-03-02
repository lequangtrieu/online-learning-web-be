namespace OnlineLearningWebAPI.DTOs.request.PaymentRequest
{
	public class PaymentSuccessRequest
	{
		public string Code { get; set; }
		public string Id { get; set; }
		public bool Cancel { get; set; }
		public string Status { get; set; }
		public int OrderCode { get; set; }
	}

}
