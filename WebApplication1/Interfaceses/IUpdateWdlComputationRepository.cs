using WebApplication1.Entities;

namespace WebApplication1.Interfaceses
{
    public interface IUpdateWdlComputationRepository
    {
        public Task<List<WdlcompleteDataEntity>> updateWdlComputationAsync(List<WdlcompleteDataEntity> wdlcompleteDataEntities);
    }
}
