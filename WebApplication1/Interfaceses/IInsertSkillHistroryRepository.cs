using WebApplication1.Entities;

namespace WebApplication1.Interfaceses
{
    public interface IInsertSkillHistroryRepository
    {
        public Task<bool> InSkillhistoryasync(List<WdlcompleteDataEntity>  wdlcompleteDataEntities);
    }
}
