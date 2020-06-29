using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using brain.business.mutant;
using brain.dto.request.mutant;
using brain.models.mutant.Mutant;

namespace brain.services.API.Controllers
{
    public class MutantController : ApiController
    {
        // GET api/<controller>
        /// <summary>
        /// Testing API availability
        /// </summary>
        /// <returns></returns>
        public async Task<HttpResponseMessage> Get()
        {
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, "REST API available to look for mutants.");
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString());
            }
        }

        // POST api/<controller>
        /// <summary>
        /// Validating mutant genes in dna sequences
        /// </summary>
        /// <param name="requestModel">dna sequences</param>
        /// <returns>mutants: http-200. no-mutants: http-403.</returns>
        public async Task<HttpResponseMessage> Post([FromBody] MutantRequestDTO requestModel)
        {
            try
            {
                string[] dnaSequence = requestModel.dna;
                MutantModel mutant = (MutantModel) await new MutantBusiness().IsMutant(dnaSequence);

                if (mutant != null && mutant.IsMutant)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.Forbidden);
                }
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString());
            }
        }
    }
}