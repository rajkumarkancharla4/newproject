using WebApplication1.Entities;
using WebApplication1.Interfaceses;

namespace WebApplication1.Serviceses
{
    public class InsertSkillHistroryService : IInsertSkillhistoryService
    {
        private readonly IInsertSkillhistoryService _insertSkillhistoryService;
        public InsertSkillHistroryService(IInsertSkillhistoryService insertSkillhistoryService)
        {
            _insertSkillhistoryService=insertSkillhistoryService;
            
        }
        public async  Task<bool> insSkillHistory(List<WdlcompleteDataEntity> wdlcompleteDataEntities)
        {
            var res= await  _insertSkillhistoryService.insSkillHistory(wdlcompleteDataEntities);
            return res;
        }
    }
}
