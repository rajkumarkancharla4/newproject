using WebApplication1.Entities;
using WebApplication1.Interfaceses;

namespace WebApplication1.Serviceses
{
    public class InsertSkillHistroryService : IInsertSkillhistoryService
    {
        private readonly IInsertSkillHistroryRepository _inserSkilldataRepository;
        public InsertSkillHistroryService(IInsertSkillHistroryRepository inserSkilldataRepository)
        {
            _inserSkilldataRepository= inserSkilldataRepository;
            
        }
        public async  Task<bool> insSkillHistory(List<WdlcompleteDataEntity> wdlcompleteDataEntities)
        {
            var res= await  _inserSkilldataRepository.InSkillhistoryasync(wdlcompleteDataEntities);
            return res;
        }
    }
}
