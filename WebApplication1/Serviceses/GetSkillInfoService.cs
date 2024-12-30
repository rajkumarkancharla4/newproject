using WebApplication1.Entities;
using WebApplication1.Interfaceses;

namespace WebApplication1.Serviceses
{
    public class GetSkillInfoService : IGetSkillInfoService
    {
        private readonly IGetSkillInfoRepository _getSkillInfoService1;
        public GetSkillInfoService(IGetSkillInfoRepository getSkillInfoRepository)
        {
            _getSkillInfoService1 = getSkillInfoRepository;
        }

        public async Task<List<SkillInfoEntity>> GetSkillInfoServicedetails(List<string> learnercourseId)
        {
   
            try
            {
                List<SkillInfoEntity> skillinfo = await  _getSkillInfoService1.GetSkillInfoRepositorydetails(learnercourseId);
                return skillinfo;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
