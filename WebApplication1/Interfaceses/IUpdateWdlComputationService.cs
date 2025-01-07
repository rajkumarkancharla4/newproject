using WebApplication1.Entities;

namespace WebApplication1.Interfaceses
{
    public interface IUpdateWdlComputationService
    {
        public Task<List<WdlcompleteDataEntity>> UpdateWdlComputationAsync(List<WdlcompleteDataEntity> wdlcompleteDataEntities);
    }
}
