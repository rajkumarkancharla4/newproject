using WebApplication1.Entities;

namespace WebApplication1.Interfaceses
{
    public interface IInsertWdlComputedDataRepository
    {
        public Task<bool> WdlInserRepo(List<WdlcompleteDataEntity> wdlcompleteDataEntities);
    }
}
