using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using WebApplication1.Entities;
using WebApplication1.Interfaceses;
using WebApplication1.model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class learningDataInfoController : ControllerBase
    {
        private IlearningDataService _IlearningDataService;
        private IGetCourserelateddataService _getCourserelateddataService;
        private IGetCourseInfoService _getCourseInfoService;
        private IGetSkillInfoService _getSkillInfoService;
        public learningDataInfoController(IlearningDataService ilearningDataService, IGetCourserelateddataService getCourserelateddataService, IGetCourseInfoService getCourseInfoservice, IGetSkillInfoService getSkillInfoService)
        {
            _IlearningDataService = ilearningDataService;
            _getCourserelateddataService = getCourserelateddataService;
            _getCourseInfoService = getCourseInfoservice;
            _getSkillInfoService = getSkillInfoService;
        }

        [HttpGet]
        [Route("DataInfo")]
        public async Task<ActionResult<List<WdlcompleteDataEntity>>> GetlearningData()
        {
            try
            { // crate global objecte
                List<WdlcompleteDataEntity> wdlcompleteDataEntities = new List<WdlcompleteDataEntity>();
                List<Entity> result = await _IlearningDataService.ILearnerDataService();
                var CourseInfo = new List<CourseInfoEntity>();
                var skillinfo = new List<SkillInfoEntity>();
    

                await _getCourserelateddataService.GetCOursedataServcie(result);
               //result 1
                var learnerresult = result.Where(e => e.CompletionDate != null && e.CourseID != null && e.LearnerID != null).ToList();

                var learnercourseId = learnerresult.Select(item => item.CourseID).ToList();
                //result 2
                CourseInfo = await _getCourseInfoService.GetCourseInfoServiceAsync(learnercourseId);
            //result 3
                skillinfo = await _getSkillInfoService.GetSkillInfoServicedetails(learnercourseId);

                //   // Combine the data as needed\
                foreach (var item in learnerresult)
                {
                    var filteredCourses = CourseInfo.Where(course => course.CourseID == item.CourseID).FirstOrDefault();
                    var skillbyid = skillinfo.Where(s => s.ref_SourceID == item.CourseID).FirstOrDefault();
                   if (skillbyid != null && filteredCourses != null)
                    {
                        var res = new WdlcompleteDataEntity
                        {
                            CourseID = item.CourseID,
                            EmployeeID = item.LearnerID,
                            SourceSystem = item.SourceName,
                            CourseName = filteredCourses.CourseName,
                            CreatedDateTime = DateTimeOffset.UtcNow,
                            EndDate = DateTimeOffset.UtcNow,
                            IsProcessed = false,
                            ProcessedDateTime = null,
                            SkillID = skillbyid.SkillID,
                            StartDate = DateTimeOffset.UtcNow

                        };
                        wdlcompleteDataEntities.Add(res);
                    }
                    
                }

                return wdlcompleteDataEntities;
            }
            catch (Exception Ex)
            {
                throw;
            }


        }


    }
}
