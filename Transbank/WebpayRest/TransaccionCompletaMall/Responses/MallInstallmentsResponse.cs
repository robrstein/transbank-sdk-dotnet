using System.Collections.Generic;
using Newtonsoft.Json;
using Transbank.Webpay.TransaccionCompletaMall.Common;
    
namespace Transbank.Webpay.TransaccionCompletaMall.Responses
{
    public class MallInstallmentsResponse
    {
        [JsonProperty("installments_amount")]
        public int InstallmentsAmount { get; set; }
        
        [JsonProperty("id_query_installments")]
        public int IdQueryInstallments { get; set; }

        [JsonProperty("deferred_periods")]
        public List<DeferredPeriods> DeferredPeriods { get; set; }
        
        [JsonProperty("details")]
        public List<MallInstallmentsDetailsResponse> Details { get; set; }

        public MallInstallmentsResponse(int installmentsAmount, int idQueryInstallments, List<DeferredPeriods> deferredPeriods)
        {
            InstallmentsAmount = installmentsAmount;
            IdQueryInstallments = idQueryInstallments;
            DeferredPeriods = deferredPeriods;
        }

        public MallInstallmentsResponse(List<MallInstallmentsDetailsResponse> details)
        {
            Details = details;
        }
    }
}
