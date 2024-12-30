using WebApplication1.Entities;
using WebApplication1.Interfaceses;

namespace WebApplication1.Serviceses
{
    public class WdlInsertdataService : IInsertWdlComputedDataservice
    {
        private readonly IInsertWdlComputedDataRepository _repository;

        public WdlInsertdataService(IInsertWdlComputedDataRepository insertWdlComputedDataRepository)
        {
            _repository=insertWdlComputedDataRepository;
        }
        public Task wdlinsert(List<WdlcompleteDataEntity> wdlcompleteDataEntities)
        {
            throw new NotImplementedException();
        }
    }
}
