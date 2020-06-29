using System;
using System.Linq;
using brain.business.mutant;
using brain.models.mutant.Mutant;

namespace brain.services.console
{
    class Program
    {
        static void Main(string[] args)
        {
            //Mutant - { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };

            string[] dnaSequence = { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };
            Console.WriteLine("Welcome to Magneto Solution! \n\n");

            Console.WriteLine("Analyzing this DNA sequence to look for mutant genes:");
            Console.WriteLine(string.Join(", ", dnaSequence));

            MutantModel mutant = (MutantModel) new MutantBusiness().IsMutant(dnaSequence);
            Console.WriteLine("\nIs mutant? " + mutant.IsMutant.ToString());
            Console.WriteLine("\nConclusion of Analysis? \n" + mutant.ConclusionOfAnalysis);

            if (mutant.IsMutant && mutant.MutantGenes != null && mutant.MutantGenes.Any())
            {
                Console.WriteLine("\nMutant sequences:");
                foreach (string s in mutant.MutantGenes)
                {
                    Console.WriteLine(s.ToString());
                }
            }

            Console.ReadLine();
        }
    }
}
