using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using brain.entities;
using System.Linq;
using System.Data.Entity;

namespace brain.data.DAL
{
    public class AnalysisLogDAL
    {
        public async Task<bool> AnalysisLogAdd(string[] dnaSequence, bool isMutant)
        {
            try
            {
                using (BrainContext dbContext = new BrainContext())
                {
                    string dna = string.Join(",", dnaSequence);
                    AnalysisLog log = new AnalysisLog()
                    {
                        DnaSequence = dna,
                        IsMutant = isMutant,
                        AnalyzedAt = DateTime.Now,
                        AnalyzedAtUtc = DateTime.UtcNow
                    };
                    dbContext.AnalysisLog.Add(log);
                    await dbContext.SaveChangesAsync();
                    dbContext.Dispose();
                }
                return true;
            }
            catch (Exception e)
            {
                var message = e.ToString();
                return false;
                //TODO: Writing infrastructure log
            }
        }

        public async Task<int> AnalysisLogCount(SubjectType subject)
        {
            try
            {
                int counter = 0;
                bool mutants = subject == SubjectType.Mutant;
                using (BrainContext dbContext = new BrainContext())
                {
                    counter = await dbContext.AnalysisLog.Where(x => x.IsMutant == mutants).CountAsync();
                }
                return counter;
            }
            catch (Exception e)
            {
                var message = e.ToString();
                //TODO: Writing infrastructure log
                return 0;
            }
        }
    }
}
