using WebApplication1.Entities;

namespace WebApplication1.Interfaceses
{
    public interface IWdldataprocessingService
    {
        public Task<bool> WdldataprocessInterface(List<WdlcompleteDataEntity> wdlcompleteDataEntities);

    }
}
