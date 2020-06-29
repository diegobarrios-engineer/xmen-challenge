using System;
using System.Linq;
using System.Threading.Tasks;
using brain.business.mutant;
using brain.models.mutant.Mutant;

namespace brain.services.console
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t = MainAsync(args);
            t.Wait();
        }

        static async Task MainAsync(string[] args)
        {
            //Mutant - { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };

            string[] dnaSequence = { "ATGCGA", "CAGTGC", "TTATGT", "AGAAGG", "CCCCTA", "TCACTG" };
            Console.WriteLine("Welcome to Magneto Solution! \n\n");

            Console.WriteLine("Analyzing this DNA sequence to look for mutant genes:");
            Console.WriteLine(string.Join(", ", dnaSequence));

            MutantModel mutant = (MutantModel) await new MutantBusiness().IsMutant(dnaSequence);
            Console.WriteLine("\nIs mutant? " + mutant.IsMutant.ToString());
            Console.WriteLine("\nConclusion of Analysis? \n" + mutant.ConclusionOfAnalysis);

            if (mutant.IsMutant && mutant.MutantSequences != null && mutant.MutantSequences.Any())
            {
                Console.WriteLine("\nMutant sequences:");
                foreach (string s in mutant.MutantSequences)
                {
                    Console.WriteLine(s.ToString());
                }
            }
            
            Console.ReadLine();
        }
    }
}
