using System.Collections.Generic;
namespace brain.business.mutant.Dna
{
    public interface DnaInterface
    {
        string[,] GetDnaBoard(string[] prmDna);

        KeyValuePair<bool, string> IsDnaSampleValid(string[] prmDna);
    }
}
