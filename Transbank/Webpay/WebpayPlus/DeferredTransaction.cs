using System;
using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Webpay.Common;
using Transbank.Webpay.WebpayPlus.Exceptions;
using Transbank.Webpay.WebpayPlus.Requests;
using Transbank.Webpay.WebpayPlus.Responses;
using Transbank.Webpay.Common.Requests;
using Transbank.Webpay.Common.Responses;
using System.Collections.Generic;

namespace Transbank.Webpay.WebpayPlus
{
    public static class DeferredTransaction
    {
        private static string _commerceCode = "597055555540";
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

        public static CreateResponse Create(string buyOrder, string sessionId,
            decimal amount, string returnUrl)
        {
            return Create(buyOrder, sessionId, amount, returnUrl, DefaultOptions());
        }

        public static CreateResponse Create(string buyOrder, string sessionId,
            decimal amount, string returnUrl, Options options)
        {
            return Transaction.Create(buyOrder, sessionId, amount, returnUrl, options);
        }

        public static CommitResponse Commit(string token)
        {
            return Commit(token, DefaultOptions());
        }

        public static CommitResponse Commit(string token, Options options)
        {
            return Transaction.Commit(token, options);
        }

        public static RefundResponse Refund(string token, decimal amount)
        {
            return Refund(token, amount, DefaultOptions());
        }

        public static RefundResponse Refund(string token, decimal amount, Options options)
        {
            return Transaction.Refund(token, amount, options);
        }

        public static StatusResponse Status(string token)
        {
            return Status(token, DefaultOptions());
        }

        public static StatusResponse Status(string token, Options options)
        {
            return Transaction.Status(token, options);
        }

        public static CaptureResponse Capture(string token, string buyOrder, string authorizationCode,
            decimal captureAmount, string commerceCode = null)
        {
            return Capture(token, buyOrder, authorizationCode, captureAmount, commerceCode, DefaultOptions());
        }

        public static CaptureResponse Capture(string token, string buyOrder, string authorizationCode,
            decimal captureAmount)
        {
            return Capture(token, buyOrder, authorizationCode, captureAmount, null, DefaultOptions());
        }

        public static CaptureResponse Capture(string token, string buyOrder, string authorizationCode, decimal captureAmount, string commerceCode, Options options)
        {
            return ExceptionHandler.Perform<CaptureResponse, TransactionCaptureException>(() =>
            {
                var captureRequest = new CaptureRequest(token, buyOrder, authorizationCode, captureAmount, commerceCode);
                var response = RequestService.Perform<TransactionCaptureException>(captureRequest, options);
                return JsonConvert.DeserializeObject<CaptureResponse>(response);
            });
        }





        public static IncreaseAmountResponse IncreaseAmount(string token, string buyOrder, string authorizationCode, decimal amount, string commerceCode, Options options)
        {
            return TransactionDeferredUtil.IncreaseAmount(token, buyOrder, authorizationCode, amount, commerceCode, options);
        }

        public static IncreaseAmountResponse IncreaseAmount(string token, string buyOrder, string authorizationCode, decimal amount, string commerceCode)
        {
            return TransactionDeferredUtil.IncreaseAmount(token, buyOrder, authorizationCode, amount, commerceCode, DefaultOptions());
        }

        public static IncreaseAuthorizationDateResponse IncreaseAuthorizationDate(string token, string buyOrder, string authorizationCode, string commerceCode, Options options)
        {
            return TransactionDeferredUtil.IncreaseAuthorizationDate(token, buyOrder, authorizationCode, commerceCode, options);
        }

        public static IncreaseAuthorizationDateResponse IncreaseAuthorizationDate(string token, string buyOrder, string authorizationCode, string commerceCode)
        {
            return TransactionDeferredUtil.IncreaseAuthorizationDate(token, buyOrder, authorizationCode, commerceCode, DefaultOptions());
        }

        public static ReversePreAuthorizedAmountResponse ReversePreAuthorizedAmount(string token, string buyOrder, string authorizationCode, decimal amount, string commerceCode, Options options)
        {
            return TransactionDeferredUtil.ReversePreAuthorizedAmount(token, buyOrder, authorizationCode, amount, commerceCode, options);
        }

        public static ReversePreAuthorizedAmountResponse ReversePreAuthorizedAmount(string token, string buyOrder, string authorizationCode, decimal amount, string commerceCode)
        {
            return TransactionDeferredUtil.ReversePreAuthorizedAmount(token, buyOrder, authorizationCode, amount, commerceCode , DefaultOptions());
        }


        public static List<DeferredCaptureHistoryResponse> DeferredCaptureHistory(string token, string buyOrder, string commerceCode, Options options)
        {
            return TransactionDeferredUtil.DeferredCaptureHistory(token, buyOrder, commerceCode, options);
        }

        public static List<DeferredCaptureHistoryResponse> DeferredCaptureHistory(string token, string buyOrder, string commerceCode)
        {
            return TransactionDeferredUtil.DeferredCaptureHistory(token, buyOrder, commerceCode, DefaultOptions());
        }
    }
}
