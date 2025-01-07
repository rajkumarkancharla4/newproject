using WebApplication1.Entities;

namespace WebApplication1.Interfaceses
{
    public interface IInsertSkillhistoryService
    {

        public Task<bool> insSkillHistory(List<WdlcompleteDataEntity> wdlcompleteDataEntities);
    }
}
