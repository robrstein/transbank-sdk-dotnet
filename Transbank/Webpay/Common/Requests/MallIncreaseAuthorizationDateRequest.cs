using System.Net.Http;
using Newtonsoft.Json;
using Transbank.Common;

namespace Transbank.Webpay.Common.Requests
{
    internal class MallIncreaseAuthorizationDateRequest : BaseRequest
    {
        [JsonProperty("buy_order")]
        internal string BuyOrder { get; set; }

        [JsonProperty("authorization_code")]
        internal string AuthorizationCode { get; set; }

        [JsonProperty("commerce_code", NullValueHandling = NullValueHandling.Ignore)]
        internal string CommerceCode { get; set; }

        internal MallIncreaseAuthorizationDateRequest(string token, string buyOrder, string authorizationCode, string commerceCode = null) :
            base($"{Constant.WEBPAY_METHOD}/transactions/{token}/authorization_date", HttpMethod.Put)
        {
            BuyOrder = buyOrder;
            AuthorizationCode = authorizationCode;
            CommerceCode = commerceCode;
        }
    }
}
