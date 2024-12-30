using WebApplication1.Entities;

namespace WebApplication1.Interfaceses
{
    public interface IGetSkillInfoRepository
    {
        public Task<List<SkillInfoEntity>> GetSkillInfoRepositorydetails(List<string> learnercourseId);
    }
}
