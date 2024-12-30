using WebApplication1.DbContextdatadetails;
using WebApplication1.Entities;
using WebApplication1.Interfaceses;

namespace WebApplication1.Repositories
{
    public class GetCourseInfoRepository : IGetCourseInfoRepository
    {
        private readonly Dbconnect _dbConnect;
        public GetCourseInfoRepository(Dbconnect dbconnect)
        {
            _dbConnect = dbconnect;
        }

        public async Task<List<CourseInfoEntity>> GetCourseInfoReprositoryAsnc(List<string> entitycourseId)
        {
            try
            {
                List<CourseInfoEntity> courseInfoEntities = _dbConnect.CourseInfo.Where(x => entitycourseId.Contains(x.CourseID)
                         && x.CurriculumDispCat != "pre-employee"
                         && x.CurriculumDispCat != "pre-completion").ToList();
                return courseInfoEntities;
            }
            catch ( Exception ex)
            {
                throw;
            }
        }
    }
}
