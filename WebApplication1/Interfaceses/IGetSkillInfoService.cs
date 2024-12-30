using WebApplication1.Entities;

namespace WebApplication1.Interfaceses
{
    public interface IGetSkillInfoService
    {
        public Task<List<SkillInfoEntity>> GetSkillInfoServicedetails(List<string> learnercourseId);
    }
}
