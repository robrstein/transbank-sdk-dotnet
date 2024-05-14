using System;
using System.Globalization;
using System.Net.Http;
using Transbank.Common;
using Transbank.Exceptions;
using Transbank.PatpassComercio.Requests;
using Transbank.PatpassComercio.Responses;

namespace Transbank.PatpassComercio
{
    public class Inscription : BaseOptions
    {
        // The authentication headers for this product are different, these have
        // to be used. You can put them in the Perform method of the RequestService
        private readonly string _apiKeyHeaderName = "Authorization";
        private readonly string _commerceCodeHeaderName = "commerceCode";

        private readonly RequestServiceHeaders _headers;

        private Inscription() {
            _headers = new RequestServiceHeaders(_apiKeyHeaderName, _commerceCodeHeaderName);
        }
        public Inscription(Options options, HttpClient httpClient = null) : base(options, httpClient) {
            _headers = new RequestServiceHeaders(_apiKeyHeaderName, _commerceCodeHeaderName);
        }
        public Inscription(string commerceCode, string apiKey, IIntegrationType integrationType, HttpClient httpClient = null)
            : base(commerceCode, apiKey, integrationType, httpClient) {
            _headers = new RequestServiceHeaders(_apiKeyHeaderName, _commerceCodeHeaderName);
        }

        public Inscription(Options options)
        {
            Options = options;
            _headers = new RequestServiceHeaders(_apiKeyHeaderName, _commerceCodeHeaderName);
        }

        public static Inscription buildForProduction(string commerceCode, string apiKey)
        {
            Inscription inscription = new Inscription();
            inscription.ConfigureForProduction(commerceCode, apiKey);
            return inscription;
        }

        public static Inscription buildForIntegration(string commerceCode, string apiKey)
        {

            Inscription inscription = new Inscription();
            inscription.ConfigureForIntegration(commerceCode, apiKey);
           
            return inscription;

        }

        public StartResponse Start(
            string url,
            string name,
            string lastName,
            string secondLastName,
            string rut,
            string serviceId,
            string finalUrl,
            decimal maxAmount,
            string phone,
            string cellPhone,
            string patpassName,
            string personEmail,
            string commerceEmail,
            string address,
            string city
        )
        {
            // set culture to es-CL, since webpay only works with clp we are forcing to anyone to use clp currency standard.
            CultureInfo myCiIntl = new CultureInfo("es-CL", false);
            string mAmount = maxAmount <= 0 ? "" : maxAmount.ToString(myCiIntl);
            return ExceptionHandler.Perform<StartResponse, InscriptionStartException>(() =>
            {
                var request = new StartRequest(
                    url, name, lastName, secondLastName, rut, serviceId, finalUrl,
                    Options.CommerceCode, mAmount, phone, cellPhone,
                    patpassName, personEmail, commerceEmail, address, city
                );
                return _requestService.Perform<StartResponse, InscriptionStartException>(request, Options, _headers);
            });

        }

        public StatusResponse Status(string token)
        {
            return ExceptionHandler.Perform<StatusResponse, InscriptionStatusException>(() =>
            {
                var statusRequest = new StatusRequest(token);
                return _requestService.Perform<StatusResponse, InscriptionStatusException>(
                    statusRequest, Options, _headers);
            });
        }

        /*
        |--------------------------------------------------------------------------
        | Environment Configuration
        |--------------------------------------------------------------------------
        */

        public void ConfigureForIntegration(String commerceCode, String apiKey)
        {
            Configure(commerceCode, apiKey, PatpassComercioIntegrationType.Test);
        }

        public void ConfigureForProduction(String commerceCode, String apiKey)
        {
            Configure(commerceCode, apiKey, PatpassComercioIntegrationType.Live);
        }

        public void ConfigureForTesting()
        {
            ConfigureForIntegration(IntegrationCommerceCodes.PATPASS_COMERCIO, IntegrationApiKeys.PATPASS_COMERCIO);
        }
    }

}
