using System.Collections.Generic;
using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Webpay.Common.Requests;
using Transbank.Webpay.Common.Responses;

namespace Transbank.Webpay.Common
{
    
    public static class TransactionDeferredUtil
    {

        public static IncreaseAmountResponse IncreaseAmount(string token, string buyOrder, string authorizationCode, decimal amount, string commerceCode, Options options)
        {
            return ExceptionHandler.Perform<IncreaseAmountResponse, IncreaseAmountException>(() =>
            {
                var captureRequest = new IncreaseAmountRequest(token, buyOrder, authorizationCode, amount, commerceCode);
                var response = RequestService.Perform<IncreaseAmountException>(captureRequest, options);
                return JsonConvert.DeserializeObject<IncreaseAmountResponse>(response);
            });
        }

        public static IncreaseAuthorizationDateResponse IncreaseAuthorizationDate(string token, string buyOrder, string authorizationCode, string commerceCode, Options options)
        {
            return ExceptionHandler.Perform<IncreaseAuthorizationDateResponse, IncreaseAuthorizationDateException>(() =>
            {
                var captureRequest = new IncreaseAuthorizationDateRequest(token, buyOrder, authorizationCode, commerceCode);
                var response = RequestService.Perform<IncreaseAuthorizationDateException>(captureRequest, options);
                return JsonConvert.DeserializeObject<IncreaseAuthorizationDateResponse>(response);
            });
        }

        public static ReversePreAuthorizedAmountResponse ReversePreAuthorizedAmount(string token, string buyOrder, string authorizationCode, decimal amount, string commerceCode, Options options)
        {
            return ExceptionHandler.Perform<ReversePreAuthorizedAmountResponse, ReversePreAuthorizedAmountException>(() =>
            {
                var captureRequest = new ReversePreAuthorizedAmountRequest(token, buyOrder, authorizationCode, amount, commerceCode);
                var response = RequestService.Perform<ReversePreAuthorizedAmountException>(captureRequest, options);
                return JsonConvert.DeserializeObject<ReversePreAuthorizedAmountResponse>(response);
            });
        }



        public static List<DeferredCaptureHistoryResponse> DeferredCaptureHistory(string token, string buyOrder, string commerceCode, Options options)
        {
            return ExceptionHandler.Perform<List<DeferredCaptureHistoryResponse>, DeferredCaptureHistoryException>(() =>
            {
                var captureRequest = new DeferredCaptureHistoryRequest(token, buyOrder, commerceCode);
                var response = RequestService.Perform<DeferredCaptureHistoryException>(captureRequest, options);
                return JsonConvert.DeserializeObject<List<DeferredCaptureHistoryResponse>>(response);
            });
        }




        public static MallIncreaseAmountResponse MallIncreaseAmount(string token, string buyOrder, string authorizationCode, decimal amount, string commerceCode, Options options)
        {
            return ExceptionHandler.Perform<MallIncreaseAmountResponse, MallIncreaseAmountException>(() =>
            {
                var captureRequest = new MallIncreaseAmountRequest(token, buyOrder, authorizationCode, amount, commerceCode);
                var response = RequestService.Perform<MallIncreaseAmountException>(captureRequest, options);
                return JsonConvert.DeserializeObject<MallIncreaseAmountResponse>(response);
            });
        }

        public static MallIncreaseAuthorizationDateResponse MallIncreaseAuthorizationDate(string token, string buyOrder, string authorizationCode, string commerceCode, Options options)
        {
            return ExceptionHandler.Perform<MallIncreaseAuthorizationDateResponse, MallIncreaseAuthorizationDateException>(() =>
            {
                var captureRequest = new MallIncreaseAuthorizationDateRequest(token, buyOrder, authorizationCode, commerceCode);
                var response = RequestService.Perform<MallIncreaseAuthorizationDateException>(captureRequest, options);
                return JsonConvert.DeserializeObject<MallIncreaseAuthorizationDateResponse>(response);
            });
        }

        public static MallReversePreAuthorizedAmountResponse MallReversePreAuthorizedAmount(string token, string buyOrder, string authorizationCode, decimal amount, string commerceCode, Options options)
        {
            return ExceptionHandler.Perform<MallReversePreAuthorizedAmountResponse, MallReversePreAuthorizedAmountException>(() =>
            {
                var captureRequest = new MallReversePreAuthorizedAmountRequest(token, buyOrder, authorizationCode, amount, commerceCode);
                var response = RequestService.Perform<MallReversePreAuthorizedAmountException>(captureRequest, options);
                return JsonConvert.DeserializeObject<MallReversePreAuthorizedAmountResponse>(response);
            });
        }



        public static List<MallDeferredCaptureHistoryResponse> MallDeferredCaptureHistory(string token, string buyOrder, string commerceCode, Options options)
        {
            return ExceptionHandler.Perform<List<MallDeferredCaptureHistoryResponse>, MallDeferredCaptureHistoryException>(() =>
            {
                var captureRequest = new MallDeferredCaptureHistoryRequest(token, buyOrder, commerceCode);
                var response = RequestService.Perform<MallDeferredCaptureHistoryException>(captureRequest, options);
                return JsonConvert.DeserializeObject<List<MallDeferredCaptureHistoryResponse>>(response);
            });
        }

    }
}
