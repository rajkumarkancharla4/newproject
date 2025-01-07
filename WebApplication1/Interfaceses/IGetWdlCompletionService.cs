using WebApplication1.Entities;

namespace WebApplication1.Interfaceses
{
    public interface IGetWdlCompletionService
    {
        public Task <List<WdlcompleteDataEntity>> GetDwlService();
    }
}
