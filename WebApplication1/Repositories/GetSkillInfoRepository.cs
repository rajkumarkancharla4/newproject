using Microsoft.EntityFrameworkCore;
using WebApplication1.DbContextdatadetails;
using WebApplication1.Entities;
using WebApplication1.Interfaceses;

namespace WebApplication1.Repositories
{
    public class GetSkillInfoRepository : IGetSkillInfoRepository
    {
        private readonly Dbconnect _dbconnect;
        public GetSkillInfoRepository(Dbconnect dbconnect)
        {
            _dbconnect = dbconnect; 
        }
       public async Task<List<SkillInfoEntity>> GetSkillInfoRepositorydetails(List<string> learnercourseId)
        {
            try
            {
                List<SkillInfoEntity> skillInfoEntities = await _dbconnect.skillInfo.Where(x => learnercourseId.Contains(x.ref_SourceID)).ToListAsync();
                return skillInfoEntities;
            }catch(Exception ex)
            {
                throw;
            }
        }
    }
}
