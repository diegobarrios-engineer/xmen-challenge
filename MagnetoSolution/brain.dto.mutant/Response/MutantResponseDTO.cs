using System;
using System.Collections.Generic;

namespace brain.dto.mutant.Response
{
    public class MutantResponseDTO
    {
        public bool IsMutant { get; set; }

        public List<string> MutantSequences { get; set;}
        public string ConclusionOfAnalysis { get; set; }
    }
}
