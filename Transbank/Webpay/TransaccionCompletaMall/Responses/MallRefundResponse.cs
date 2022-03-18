using System;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;
using Transbank.Common;

namespace Transbank.Webpay.TransaccionCompletaMall.Responses
{
    public class MallRefundResponse : BaseResponse
    {
        [JsonProperty("type")]
        public string Type { get; set; }
        
        [JsonProperty("authorization_code")]
        public string AuthorizationCode { get; set; }
        
        [JsonProperty("authorization_date")]
        public DateTime? AuthorizationDate { get; set; }
        
        [JsonProperty("nullified_amount")]
        public decimal? NullifiedAmount { get; set; }
        
        [JsonProperty("balance")]
        public decimal? Balance { get; set; }
        
        [JsonProperty("response_code")]
        public int? ResponseCode { get; set; }
        [JsonProperty("prepaid_balance")]
        public decimal? PrepaidBalance { get; set; }

        public MallRefundResponse(
            string type,
            string authorizationCode,
            DateTime authorizationDate,
            decimal nullifiedAmount,
            decimal balance,
            int responseCode,
            decimal prepaidBalance)
        {
            Type = type;
            AuthorizationCode = authorizationCode;
            AuthorizationDate = authorizationDate;
            NullifiedAmount = nullifiedAmount;
            Balance = balance;
            ResponseCode = responseCode;
            PrepaidBalance = prepaidBalance;
        }

        public override string ToString()
        {
            var properties = new List<string>();
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(this))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(this);
                properties.Add($"{name}={value}");
            }
            return String.Join(",\n", properties);
        }
    }
}
