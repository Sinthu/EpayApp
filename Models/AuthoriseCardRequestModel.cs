using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EpayApp.Models
{
    public class AuthoriseCardRequestModel
    {
        public int Id { get; set; }
        private string _transactionId = Guid.NewGuid().ToString().Substring(0, 6);
        private string _merchantId = Guid.NewGuid().ToString().Substring(0, 6);

        [StringLength(maximumLength: 40, MinimumLength = 1)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the card holder name")]
        [RegularExpression(@"^(?:[A-Za-z]+ ?){1,3}$", ErrorMessage = "The card holder name format is incorrect")]
        [DisplayName("Card Holder Name")]
        [JsonProperty("cardHolderName")]
        public string CardHolderName { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the card number")]
        [DisplayName("Card Number")]
        [RegularExpression(@"^(\d{4}[- ]){3}\d{4}|\d{19}$", ErrorMessage = "The card number is not in the correct format")]
        [StringLength(maximumLength: 19, MinimumLength = 16, ErrorMessage = "The card number is incorrect")]
        [JsonProperty("cardNumber")]
        public string CardNumber { get; set; }


        [Required(ErrorMessage = "Please enter the expiry month")]
        [Range(1, 12)]
        [JsonProperty("month")]
        public int ExpiryMonth { get; set; }


        [Required(ErrorMessage = "Please enter the expiry year")]
        [JsonProperty("year")]
        [Range(2020, 2050)]
        public int ExpiryYear { get; set; }


        [StringLength(maximumLength: 4, MinimumLength = 3)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the Cvv value")]
        [RegularExpression(@"(^\d{4}$)|(^\d{3}$)", ErrorMessage = "The Cvv is not in the correct format")]
        [JsonProperty("cvv")]
        public string Cvv { get; set; }


        [StringLength(3)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the currency")]
        [RegularExpression(@"/^|AED|AFN|ALL|AMD|ANG|AOA|ARS|AUD|AWG|AZN|BAM|BBD|BDT|BGN|BHD|BIF|BMD|BND|BOB|BRL|BSD|BTN|BWP|BYR|BZD|CAD|CDF|CHF|CLP|CNY|COP|CRC|CUC|CUP|CVE|CZK|DJF|DKK|DOP|DZD|EGP|ERN|ETB|EUR|FJD|FKP|GBP|GEL|GGP|GHS|GIP|GMD|GNF|GTQ|GYD|HKD|HNL|HRK|HTG|HUF|IDR|ILS|IMP|INR|IQD|IRR|ISK|JEP|JMD|JOD|JPY|KES|KGS|KHR|KMF|KPW|KRW|KWD|KYD|KZT|LAK|LBP|LKR|LRD|LSL|LYD|MAD|MDL|MGA|MKD|MMK|MNT|MOP|MRO|MUR|MVR|MWK|MXN|MYR|MZN|NAD|NGN|NIO|NOK|NPR|NZD|OMR|PAB|PEN|PGK|PHP|PKR|PLN|PYG|QAR|RON|RSD|RUB|RWF|SAR|SBD|SCR|SDG|SEK|SGD|SHP|SLL|SOS|SPL|SRD|STD|SVC|SYP|SZL|THB|TJS|TMT|TND|TOP|TRY|TTD|TVD|TWD|TZS|UAH|UGX|USD|UYU|UZS|VEF|VND|VUV|WST|XAF|XCD|XDR|XOF|XPF|YER|ZAR|ZMW|ZWD|$/",
ErrorMessage = "The currency is not in the correct format")]
        [JsonProperty("currency")]
        public string Currency { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "Please enter the amount to pay")]
        [DataType(DataType.Currency, ErrorMessage = "The value is not in the correct format")]
        [RegularExpression(@"^\$?\d+(\.(\d{2}))?$", ErrorMessage = "The value is not in the correct format")]
        [JsonProperty("amount")]
        public string Amount { get; set; }


        [JsonProperty("transactionId")]
        public string TransactionId
        {
            get { return _transactionId; }
            set { _transactionId = value; }
        }


        [JsonProperty("merchantId")]
        public string MerchantId
        {
            get { return _merchantId; }
            set { _merchantId = value; }
        }

        [JsonProperty("maskedCardNumber")]
        public string MaskedCardNumber
        {
            get { return CardNumber.Substring(CardNumber.Length-4,4); }
        }
        
    }
}
