using System;
using System.Threading.Tasks;

using brain.data.DAL;
using brain.entities;
using brain.models.laboratory;

namespace brain.business.laboratory
{
    public class StatisticalBusiness
    {
        public async Task<StatiscalModel> StatiscalGet()
        {
            StatiscalModel statiscal = new StatiscalModel();
            try
            {
                AnalysisLogDAL dal = new AnalysisLogDAL();
                statiscal.MutantNumber = await dal.AnalysisLogCount(SubjectType.Mutant);
                statiscal.HumanNumber = await dal.AnalysisLogCount(SubjectType.NoMutant);
                statiscal.Ratio = statiscal.MutantNumber / (statiscal.HumanNumber > 0 ? statiscal.HumanNumber : statiscal.MutantNumber);
            }
            catch (Exception e)
            {
                var ex = e.ToString();
                //TODO: Writing in log
            }
            return statiscal;
        }
    }
}

