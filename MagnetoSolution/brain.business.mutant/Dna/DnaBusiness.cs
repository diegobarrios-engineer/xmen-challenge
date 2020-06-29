using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using brain.business.mutant.Dna;

namespace brain.business.mutant.DNA
{
    public class DnaBusiness: DnaInterface
    {
        //checking if the sequence is a valid DNA sample
        public KeyValuePair<bool, string> IsDnaSampleValid(string[] prmDna)
        {
            int n;
            string subsequence;
            string[] dna = prmDna;
            bool isDnavalid = true;
            string validAdnPatern;
            string message = string.Empty;

            try
            {
                if (dna != null && dna.Any())
                {
                    n = dna.Length;
                    validAdnPatern = string.Format(Resource.MessageResource.DnaRegexPatter, n);

                    for (int r = 0; r < n; r++)
                    {
                        subsequence = dna[r]?.Trim()?.ToUpper();
                        isDnavalid = subsequence.Length == n;
                        if (!isDnavalid)
                        {
                            message = Resource.MessageResource.DnaLengthError;
                            break;
                        }
                        else
                        {
                            isDnavalid = Regex.Matches(subsequence, @validAdnPatern).Count != 0;
                            if (!isDnavalid)
                            {
                                message = Resource.MessageResource.DnaCharacterError;
                                break;
                            }
                        }
                    }
                }
            } 
            catch (Exception e)
            {
                message = e.ToString();
            }
            return new KeyValuePair<bool, string>(isDnavalid, message);
        }

        //getting DNA board(matrix) from a linear sequence
        public string[,] GetDnaBoard(string[] prmDna)
        {
            int n = prmDna.Length;
            string[] dna = prmDna;

            string[,] dnaStructure = new string[n, n];
            for (int r = 0; r < n; r++)
            {
                string AdnSubsequence = dna[r]?.Trim()?.ToUpper();
                for (int c = 0; c < n; c++)
                {
                    dnaStructure[r, c] = AdnSubsequence[c].ToString();
                }
            }
            return dnaStructure;
        }
    }
}
