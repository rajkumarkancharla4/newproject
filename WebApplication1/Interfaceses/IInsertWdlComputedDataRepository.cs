using WebApplication1.Entities;

namespace WebApplication1.Interfaceses
{
    public interface IInsertWdlComputedDataRepository
    {
        public Task WdlInserRepo(List<WdlcompleteDataEntity> wdlcompleteDataEntities);
    }
}
