using brain.models.mutant.Mutant;
using System.Threading.Tasks;

namespace brain.business.mutant.Mutant
{
    public interface MutantInterface
    {
        bool IsMutantGen(string sequence);
        Task<MutantModel> IsMutant(string[] prmDna);
    }
}
