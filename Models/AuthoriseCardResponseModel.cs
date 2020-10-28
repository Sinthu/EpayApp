using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EpayApp.Models
{
    public class AuthoriseCardResponseModel
    {
        private string _statusCode;
        public AuthoriseCardResponseModel()
        {

        }

        [JsonProperty("statusCode")]
        public string StatusCode
        {
            get { return this._statusCode; }
            set { this._statusCode = value; }
        }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("amount")]
        public string Amount { get; set; }

        public string CardHolderName { get; set; }

        [JsonProperty("maskedCardNumber")]
        public string MaskedCardNumber { get; set; }

        [JsonProperty("transactionId")]
        public string TransactionId { get; set; }

        [JsonProperty("merchantId")]
        public string MerchantId { get; set; }

        [JsonProperty("processedDate")]
        public string ProcessedDate { get; set; }
    }
}
