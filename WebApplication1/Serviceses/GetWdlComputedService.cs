using WebApplication1.Entities;
using WebApplication1.Interfaceses;

namespace WebApplication1.Serviceses
{
    public class GetWdlComputedService : IGetWdlCompletionService
    {
        private readonly IGetWdlCompletionRepository _getWdlCompletionRepository;

        public GetWdlComputedService(IGetWdlCompletionRepository getWdlCompletionRepository)
        {
            _getWdlCompletionRepository = getWdlCompletionRepository;
        }
        public async Task <List<WdlcompleteDataEntity>> GetDwlService()
        {
            try
            {
                List<WdlcompleteDataEntity> res = await _getWdlCompletionRepository.GetWdlRepository();

                return res;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
