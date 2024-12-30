using WebApplication1.Entities;
using WebApplication1.Interfaceses;

namespace WebApplication1.Serviceses
{
    public class GetCourseInfoService : IGetCourseInfoService
    {
        private readonly IGetCourseInfoRepository _getCourseInfoRepository;
        public GetCourseInfoService(IGetCourseInfoRepository getCourseInfoRepository)
        {
            _getCourseInfoRepository = getCourseInfoRepository;
            
        }
        public async Task<List<CourseInfoEntity>> GetCourseInfoServiceAsync(List<string> entityCourseId)
        {
            try
            {
                List<CourseInfoEntity> courseInfo = await _getCourseInfoRepository.GetCourseInfoReprositoryAsnc(entityCourseId);
                return courseInfo;
                    }
            catch(Exception ex)
            {
                throw;
            }

        }
    }
}
