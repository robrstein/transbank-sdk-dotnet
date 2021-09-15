using System.Net.Http;
using Newtonsoft.Json;
using Transbank.Common;

namespace Transbank.Webpay.Common.Requests
{
    internal class DeferredCaptureHistoryRequest : BaseRequest
    {
        [JsonProperty("commerce_code", NullValueHandling = NullValueHandling.Ignore)]
        internal string CommerceCode { get; set; }
        [JsonProperty("buy_order")]
        internal string BuyOrder { get; set; }
        internal DeferredCaptureHistoryRequest(string token, string buyOrder, string commerceCode = null) :
            base($"{Constant.WEBPAY_METHOD}/transactions/{token}/details", HttpMethod.Put)
        {
            BuyOrder = buyOrder;
            CommerceCode = commerceCode;
        }

    }
}
