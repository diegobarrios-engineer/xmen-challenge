using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

using brain.business.laboratory;
using brain.models.laboratory;
using brain.dto.laboratory;

namespace brain.services.API.Controllers
{
    public class StatsController :  ApiController
    {
        // GET api/<controller>
        /// <summary>
        /// Getting statiscal information
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Get()
        {
            try
            {
                StatisticalBusiness staticalBusiness = new StatisticalBusiness();
                StatiscalModel statiscalInfo = await staticalBusiness.StatiscalGet();

                StatiscalDTO response = new StatiscalDTO()
                {
                    Ratio = statiscalInfo.Ratio,
                    HumanNumber = statiscalInfo.HumanNumber,
                    MutantNumber = statiscalInfo.MutantNumber
                };

                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString());
            }
        }
    }
}