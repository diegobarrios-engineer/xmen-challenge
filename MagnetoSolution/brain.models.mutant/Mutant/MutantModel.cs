using System;
using System.Collections.Generic;
using brain.models.mutant.Abstract;

namespace brain.models.mutant.Mutant
{
    public class MutantModel : PersonAbstract
    {
        public MutantModel()
        {
            MutantSequences = new List<string>();
        }

        public List<string> MutantSequences { get; set; }
    }
}
