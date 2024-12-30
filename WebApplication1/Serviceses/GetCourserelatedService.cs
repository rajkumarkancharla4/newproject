using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Interfaceses;

namespace WebApplication1.Serviceses
{
    public class GetCourserelatedService : IGetCourserelateddataService
    {
        private readonly IGetCourserelateddataRepository _getCourserelateddataRepository;
        public GetCourserelatedService(IGetCourserelateddataRepository getCourserelateddataRepository)
        {
            _getCourserelateddataRepository = getCourserelateddataRepository;
        }

      

        public async Task GetCOursedataServcie(List<Entity> entities)
        {

            try
            {
                //List<Entity> coursedetails = new List<Entity>();
                await _getCourserelateddataRepository.GetCOursedataServcie(entities);
             
              

            }
            catch (Exception ex)
            {
                throw;
            }
        }


    }
}
