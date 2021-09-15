using System;
using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Webpay.Common;
using System.Collections.Generic;
using Transbank.Webpay.Oneclick.Responses;
using Transbank.WebpayRest.Oneclick.Requests;
using Transbank.WebpayRest.Oneclick.Responses;
using Transbank.Webpay.Common.Responses;

namespace Transbank.Webpay.Oneclick
{
    public static class MallDeferredTransaction
    {
        private static string _commerceCode = "597055555547";
        private static string _apiKey = "579B532A7440BB0C9079DED94D31EA1615BACEB56610332264630D42D0A36B1C";

        private static WebpayIntegrationType _integrationType = WebpayIntegrationType.Test;
        
        public static string CommerceCode
        {
            get => _commerceCode;
            set => _commerceCode = value ?? throw new ArgumentNullException(
                                       nameof(value), "Commerce code can't be null."
                                   );
        }

        public static string ApiKey
        {
            get => _apiKey;
            set => _apiKey = value ?? throw new ArgumentNullException(
                                 nameof(value), "Api Key can't be null."
                             );
        }

        public static WebpayIntegrationType IntegrationType
        {
            get => _integrationType;
            set => _integrationType = value ?? throw new ArgumentNullException(
                                          nameof(value), "Integration type can't be null."
                                      );
        }

        public static Options DefaultOptions()
        {
            return new Options(CommerceCode, ApiKey, IntegrationType);
        }
        
        public static MallAuthorizeResponse Authorize(string userName, string tbkUser,
            string buyOrder, List<PaymentRequest> details)
        {
            return MallTransaction.Authorize(userName, tbkUser, buyOrder, details, DefaultOptions());
        }

        public static MallAuthorizeResponse Authorize(string userName, string tbkUser, string buyOrder,
            List<PaymentRequest> details, Options options)
        {
            return MallTransaction.Authorize(userName, tbkUser, buyOrder, details, options);
        }

        public static MallRefundResponse Refund(string buyOrder, string childCommerceCode, string childBuyOrder,
            decimal amount)
        {
            return MallTransaction.Refund(buyOrder, childCommerceCode, childBuyOrder, amount, DefaultOptions());
        }

        public static MallRefundResponse Refund(string buyOrder, string childCommerceCode, string childBuyOrder,
            decimal amount, Options options)
        {
            return MallTransaction.Refund(buyOrder, childCommerceCode, childBuyOrder, amount, options);
        }

        public static MallStatusResponse Status(string buyOrder)
        {
            return MallTransaction.Status(buyOrder, DefaultOptions());
        }
        
        public static MallStatusResponse Status(string buyOrder, Options options)
        {
            return MallTransaction.Status(buyOrder, options);
        }

        public static MallCaptureResponse Capture(string commerceCode, string buyOrder, decimal amount, string authorizationCode)
        {
            return Capture(commerceCode, buyOrder, amount, authorizationCode, DefaultOptions());
        }

        public static MallCaptureResponse Capture(string commerceCode, string buyOrder, decimal amount, string authorizationCode, Options options)
        {
            return ExceptionHandler.Perform<MallCaptureResponse, MallCaptureException>(() =>
            {
                long.TryParse(commerceCode, out long ccode);
                var mallCaptureRequest = new MallCaptureRequest(ccode, buyOrder, amount, authorizationCode);
                var response = RequestService.Perform<MallCaptureException>(mallCaptureRequest, options);
                return JsonConvert.DeserializeObject<MallCaptureResponse>(response);
            });
        }





        public static MallIncreaseAmountResponse IncreaseAmount(string token, string buyOrder, string authorizationCode, decimal amount, string commerceCode, Options options)
        {
            return TransactionDeferredUtil.MallIncreaseAmount(token, buyOrder, authorizationCode, amount, commerceCode, options);
        }

        public static MallIncreaseAmountResponse IncreaseAmount(string token, string buyOrder, string authorizationCode, decimal amount, string commerceCode)
        {
            return TransactionDeferredUtil.MallIncreaseAmount(token, buyOrder, authorizationCode, amount, commerceCode, DefaultOptions());
        }

        public static MallIncreaseAuthorizationDateResponse IncreaseAuthorizationDate(string token, string buyOrder, string authorizationCode, string commerceCode, Options options)
        {
            return TransactionDeferredUtil.MallIncreaseAuthorizationDate(token, buyOrder, authorizationCode, commerceCode, options);
        }

        public static MallIncreaseAuthorizationDateResponse IncreaseAuthorizationDate(string token, string buyOrder, string authorizationCode, string commerceCode)
        {
            return TransactionDeferredUtil.MallIncreaseAuthorizationDate(token, buyOrder, authorizationCode, commerceCode, DefaultOptions());
        }

        public static MallReversePreAuthorizedAmountResponse ReversePreAuthorizedAmount(string token, string buyOrder, string authorizationCode, decimal amount, string commerceCode, Options options)
        {
            return TransactionDeferredUtil.MallReversePreAuthorizedAmount(token, buyOrder, authorizationCode, amount, commerceCode, options);
        }

        public static MallReversePreAuthorizedAmountResponse ReversePreAuthorizedAmount(string token, string buyOrder, string authorizationCode, decimal amount, string commerceCode)
        {
            return TransactionDeferredUtil.MallReversePreAuthorizedAmount(token, buyOrder, authorizationCode, amount, commerceCode, DefaultOptions());
        }


        public static List<MallDeferredCaptureHistoryResponse> DeferredCaptureHistory(string token, string buyOrder, string commerceCode, Options options)
        {
            return TransactionDeferredUtil.MallDeferredCaptureHistory(token, buyOrder, commerceCode, options);
        }

        public static List<MallDeferredCaptureHistoryResponse> DeferredCaptureHistory(string token, string buyOrder, string commerceCode)
        {
            return TransactionDeferredUtil.MallDeferredCaptureHistory(token, buyOrder, commerceCode, DefaultOptions());
        }




    }
}
