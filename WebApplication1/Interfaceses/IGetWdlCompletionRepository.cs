using WebApplication1.Entities;

namespace WebApplication1.Interfaceses
{
    public interface IGetWdlCompletionRepository
    {
        public Task <List<WdlcompleteDataEntity>> GetWdlRepository();
    }
}
