using WebApplication1.Entities;

namespace WebApplication1.Interfaceses
{
    public interface IGetCourseInfoService
    {
        public Task<List<CourseInfoEntity>> GetCourseInfoServiceAsync(List<String> EntityId);
    }
}
