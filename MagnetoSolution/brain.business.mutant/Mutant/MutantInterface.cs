using brain.models.mutant.Mutant;

namespace brain.business.mutant.Mutant
{
    public interface MutantInterface
    {
        bool IsMutantGen(string sequence);

        MutantModel IsMutant(string[] prmDna);
    }
}
