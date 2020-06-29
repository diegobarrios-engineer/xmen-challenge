using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using brain.business.mutant.DNA;
using brain.business.mutant.Utility;
using brain.models.mutant.Abstract;
using brain.models.mutant.Mutant;

namespace brain.business.mutant
{
    public class MutantBusiness
    {
        public MutantBusiness()
        { 
        
        }

        //this method look for mutant genes
        public bool IsMutantGen(string sequence)
        {
            return Regex.Matches(sequence, Resource.MessageResource.NitrogenousBaseA).Count > 0
                || Regex.Matches(sequence, Resource.MessageResource.NitrogenousBaseC).Count > 0
                || Regex.Matches(sequence, Resource.MessageResource.NitrogenousBaseG).Count > 0
                || Regex.Matches(sequence, Resource.MessageResource.NitrogenousBaseT).Count > 0;
        }

        //this method look for mutation
        public MutantModel IsMutant(string[] prmDna)
        {
            DnaBusiness DnaValidator = new DnaBusiness();
            MutantModel mutantModel = new MutantModel();

            var isDnaSampleValid = DnaValidator.IsDnaSampleValid(prmDna);
            if (isDnaSampleValid.Key)
            {
                string rowWord;
                string colWord;
                int n = prmDna.Length;
                int numberOfGenForMutation = Convert.ToInt32(Resource.MessageResource.NumberOfGensForMutation);

                string[,] dnaBoard = DnaValidator.GetDnaBoard(prmDna);
                Array2nUtility<string> arrayUtility = new Array2nUtility<string>();

                List<string> diagonals = arrayUtility.GetDiagonals(dnaBoard, n);

                if (IsMutantGen(diagonals[0]))
                {
                    mutantModel.MutantGenes.Add(diagonals[0]);
                }
                if (IsMutantGen(diagonals[1]))
                {
                    mutantModel.MutantGenes.Add(diagonals[1]);
                }

                for (int r = 0; r < n; r++)
                {
                    rowWord = string.Join("", arrayUtility.GetRow(dnaBoard, r));
                    colWord = string.Join("", arrayUtility.GetColumn(dnaBoard, r));

                    if (IsMutantGen(rowWord))
                    {
                        mutantModel.MutantGenes.Add(rowWord);
                    }
                    if (IsMutantGen(colWord))
                    {
                        mutantModel.MutantGenes.Add(colWord);
                    }
                    if (mutantModel.MutantGenes.Count >= numberOfGenForMutation)
                    {
                        mutantModel.IsMutant = true;
                        break;
                    }
                }
                
                mutantModel.ConclusionOfAnalysis = mutantModel.IsMutant ? Resource.MessageResource.MutantFounded : Resource.MessageResource.MutantNotFounded;
                return mutantModel;
            }
            else 
            {
                mutantModel.ConclusionOfAnalysis = isDnaSampleValid.Value;
                return mutantModel;
            }
        }
    }
}
