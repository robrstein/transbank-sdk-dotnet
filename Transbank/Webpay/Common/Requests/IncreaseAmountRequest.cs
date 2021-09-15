using System.Net.Http;
using Newtonsoft.Json;
using Transbank.Common;

namespace Transbank.Webpay.Common.Requests
{
    internal class IncreaseAmountRequest : BaseRequest
    {
        [JsonProperty("buy_order")]
        internal string BuyOrder { get; set; }

        [JsonProperty("authorization_code")]
        internal string AuthorizationCode { get; set; }

        [JsonProperty("amount")]
        internal decimal Amount { get; set; }

        [JsonProperty("commerce_code", NullValueHandling = NullValueHandling.Ignore)]
        internal string CommerceCode { get; set; }

        internal IncreaseAmountRequest(string token, string buyOrder, string authorizationCode, 
            decimal amount, string commerceCode = null) :
            base($"{Constant.WEBPAY_METHOD}/transactions/{token}/amount", HttpMethod.Put)
        {
            BuyOrder = buyOrder;
            AuthorizationCode = authorizationCode;
            Amount = amount;
            CommerceCode = commerceCode;
        }
    }
}
