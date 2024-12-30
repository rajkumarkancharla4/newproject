using WebApplication1.Entities;

namespace WebApplication1.Interfaceses
{
    public interface IGetCourseInfoRepository
    {
        public Task<List<CourseInfoEntity>> GetCourseInfoReprositoryAsnc(List<string> EntitycourseId);
    }
}
