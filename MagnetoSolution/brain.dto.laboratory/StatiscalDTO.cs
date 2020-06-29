using Newtonsoft.Json;

namespace brain.dto.laboratory
{
    public class StatiscalDTO
    {
        [JsonProperty(PropertyName = "count_mutant_dna")]
        public int MutantNumber
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "count_human_dna")]
        public int HumanNumber
        {
            get;
            set;
        }

        [JsonProperty(PropertyName = "ratio")]
        public decimal Ratio
        {
            get;
            set;
        }
    }
}
