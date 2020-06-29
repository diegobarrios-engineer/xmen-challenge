using System;
using System.ComponentModel.DataAnnotations;

namespace brain.entities
{
    public class AnalysisLog
    {
        [Key]
        public int Id
        {
            get;
            set;
        }

        public string DnaSequence
        {
            get;
            set;
        }

        public bool IsMutant
        {
            get;
            set;
        }

        public DateTime AnalyzedAt
        {
            get;
            set;
        }

        public DateTime AnalyzedAtUtc
        {
            get;
            set;
        }
    }
}
