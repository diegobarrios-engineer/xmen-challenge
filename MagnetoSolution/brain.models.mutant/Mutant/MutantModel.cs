using System;
using System.Collections.Generic;
using brain.models.mutant.Abstract;

namespace brain.models.mutant.Mutant
{
    public class MutantModel : PersonAbstract
    {
        public MutantModel()
        {
            MutantGenes = new List<string>();
        }

        public List<string> MutantGenes { get; set; }
    }
}
