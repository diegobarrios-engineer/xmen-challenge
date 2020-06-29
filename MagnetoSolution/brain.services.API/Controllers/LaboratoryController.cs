using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Threading.Tasks;

using brain.dto.request.mutant;
using brain.dto.mutant.Response;
using brain.models.mutant.Mutant;
using brain.business.mutant;

namespace brain.services.API.Controllers
{
    public class LaboratoryController : ApiController
    {
        // POST api/<controller>
        /// <summary>
        /// Validating mutant genes in dna sequences
        /// </summary>
        /// <param name="requestModel">dna sequences</param>
        /// <returns>Model filled with analysis details</returns>
        [HttpPost]
        public async Task<HttpResponseMessage> Post([FromBody] MutantRequestDTO requestModel)
        {
            try
            {
                string[] dnaSequence = requestModel.dna;
                MutantResponseDTO responseDTO = new MutantResponseDTO();
                MutantModel mutant = (MutantModel) await new MutantBusiness().IsMutant(dnaSequence);

                if (mutant != null)
                {
                    responseDTO.IsMutant = mutant.IsMutant;
                    responseDTO.MutantSequences = mutant?.MutantSequences;
                    responseDTO.ConclusionOfAnalysis = mutant?.ConclusionOfAnalysis;
                }

                return Request.CreateResponse(HttpStatusCode.OK, responseDTO);
            }
            catch (Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e.ToString());
            }
        }
    }
}
