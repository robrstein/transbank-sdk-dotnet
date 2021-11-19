using System.Net.Http;
using Transbank.Common;

namespace Transbank.Webpay.Oneclick.Requests
{
    public class MallStatusRequest : BaseRequest
    {
        public MallStatusRequest(string buyOrder)
            : base($"{ApiConstant.ONECLICK_METHOD}/transactions/{buyOrder}", HttpMethod.Get)
        {

        }
    }
}
