using WebApplication1.Entities;
using WebApplication1.Interfaceses;


namespace WebApplication1.Serviceses
{
    public class UpdateWdlComputationService : IUpdateWdlComputationService
    {

        public readonly IUpdateWdlComputationRepository _updateWdlComputationRepository;
        public UpdateWdlComputationService(IUpdateWdlComputationRepository updateWdlComputationRepository)
        {
            _updateWdlComputationRepository = updateWdlComputationRepository;
        }
        public async  Task<List<WdlcompleteDataEntity>> UpdateWdlComputationAsync(List<WdlcompleteDataEntity> wdlcompleteDataEntities)
        {
            try
            {
                var res = await _updateWdlComputationRepository.updateWdlComputationAsync(wdlcompleteDataEntities);
                return res;

            }
            catch(Exception ex)
            {
                throw;
            }
         
        }
    }
}
