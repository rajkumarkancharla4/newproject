using WebApplication1.Entities;

namespace WebApplication1.Interfaceses
{
    public interface IInsertWdlComputedDataservice
    {
        public Task wdlinsert(List<WdlcompleteDataEntity> wdlcompleteDataEntities);
    }
   
}
