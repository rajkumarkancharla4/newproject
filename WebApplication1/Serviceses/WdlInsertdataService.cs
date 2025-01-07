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
        public async Task<bool> wdlinsert(List<WdlcompleteDataEntity> wdlcompleteDataEntities)
        {
            try
            {
                var result = await _repository.WdlInserRepo(wdlcompleteDataEntities);

                return result;

            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
