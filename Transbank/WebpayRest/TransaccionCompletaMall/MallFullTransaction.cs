using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.Webpay.Common;
using Transbank.Webpay.TransaccionCompletaMall.Common;
using Transbank.Webpay.TransaccionCompletaMall.Requests;
using Transbank.Webpay.TransaccionCompletaMall.Responses;

namespace Transbank.Webpay.TransaccionCompletaMall
{
    public class MallFullTransaction
    {
        private static string _commerceCode = "";
        private static string _apiKey = "";
        
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

        public static MallCreateResponse MallCreate(
            string buyOrder,
            string sessionId,
            string cardNumber,
            string cardExpirationDate,
            List<CreateDetails> details)
        {
            return MallCreate(buyOrder, sessionId, cardNumber, cardExpirationDate, details);
        }

        public static MallCreateResponse MallCreate(
            string buyOrder,
            string sessionId,
            string cardNumber,
            string cardExpirationDate,
            List<CreateDetails> details,
            Options options)
        {
            return ExceptionHandler.Perform<MallCreateResponse, MallTransactionCreateException>(() =>
            {
                var mallCreateRequest = new MallCreateRequest(
                    buyOrder,
                    sessionId,
                    cardNumber,
                    cardExpirationDate,
                    details);
                var response = RequestService.Perform<MallTransactionCreateException>(mallCreateRequest, options);

                return JsonConvert.DeserializeObject<MallCreateResponse>(response);
            });
        }

        public static MallInstallmentsResponse MallInstallments(
            string token,
            string commerceCode,
            string buyOrder,
            int installmentsAmount)
        {
            return MallInstallments(
                token,
                commerceCode,
                buyOrder,
                installmentsAmount);
        }

        public static MallInstallmentsResponse MallInstallments(
            string token,
            string commerceCode,
            string buyOrder,
            int installmentsNumber,
            Options options)
        {
            return ExceptionHandler.Perform<MallInstallmentsResponse, MallTransactionInstallmentsExceptions>(() =>
            {
                var mallInstallmentsResponse = new MallInstallmentsRequest(
                    token,
                    commerceCode,
                    buyOrder,
                    installmentsNumber);
                var response = RequestService.Perform<MallTransactionInstallmentsExceptions>(mallInstallmentsResponse, options);

                return JsonConvert.DeserializeObject<MallInstallmentsResponse>(response);
            });
        }

        public static MallInstallmentsDetailsResponse MallInstallments(
            string token,
            List<MallInstallmentsDetails> details)
        {
            return MallInstallments(token, details);
        }

        public static MallInstallmentsDetailsResponse MallInstallments(
            string token,
            List<MallInstallmentsDetails> detailsGroup,
            Options options)
        {
            return ExceptionHandler.Perform<MallInstallmentsDetailsResponse, MallTransactionInstallmentsExceptions>(() =>
            {
               List<MallInstallmentsResponse> details = new List<MallInstallmentsResponse>();

               foreach (MallInstallmentsDetails req in detailsGroup)
               {
                   var request = new MallInstallmentsRequest(
                       token,
                       req.CommerceCode,
                       req.BuyOrder,
                       req.InstallmentsNumber);

                   var response = RequestService.Perform<MallTransactionInstallmentsExceptions>(request, options);
                   var json = JsonConvert.DeserializeObject<MallInstallmentsResponse>(response);
                   
                   details.Add(new MallInstallmentsResponse(json.InstallmentsAmount, json.IdQueryInstallments, json.DeferredPeriods));

               }

              

               return JsonConvert.DeserializeObject<MallInstallmentsDetailsResponse>(details.ToString());
            });
        }

        public static MallCommitResponse MallCommit(
            string token,
            List<MallCommitDetails> details)
        {
            return MallCommit(
                token, 
                details);
        }

        public static MallCommitResponse MallCommit(
            string token,
            List<MallCommitDetails> details,
            Options options)
        {
            return ExceptionHandler.Perform<MallCommitResponse, MallTransactionCommitException>(() =>
            {
                var mallCommitRequest = new MallCommitRequest(
                    token,
                    details);
                var response = RequestService.Perform<MallTransactionCommitException>(mallCommitRequest, options);

                return JsonConvert.DeserializeObject<MallCommitResponse>(response);
            });
        }

        public static MallRefundResponse MallRefund(
            string token,
            string buyOrder,
            string commerceCode,
            int amount)
        {
            return MallRefund(token, buyOrder, commerceCode, amount);
        }

        public static MallRefundResponse MallRefund(
            string token,
            string buyOrder,
            string commerceCode,
            int amount,
            Options options)
        {
            return ExceptionHandler.Perform<MallRefundResponse, MallTransactionRefundException>(() =>
            {
                var mallRefundRequest = new MallRefundRequest(
                    token,
                    buyOrder,
                    commerceCode, 
                    amount);
                var response = RequestService.Perform<MallTransactionRefundException>(mallRefundRequest, options);

                return JsonConvert.DeserializeObject<MallRefundResponse>(response);

            });
        }

        public static MallStatusResponse MallStatus(
            string token)
        {
            return MallStatus(token);
        }

        public static MallStatusResponse MallStatus(
            string token,
            Options options)
        {
            return ExceptionHandler.Perform<MallStatusResponse, MallTransactionStatusException>(() =>
            {
                var mallStatusRequest = new MallStatusRequest(
                    token);
                var response = RequestService.Perform<MallTransactionStatusException>(mallStatusRequest, options);

                return JsonConvert.DeserializeObject<MallStatusResponse>(response);
            });
        }
    }
 }
