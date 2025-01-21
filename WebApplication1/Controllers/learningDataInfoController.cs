using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using WebApplication1.Entities;
using WebApplication1.Interfaceses;
using WebApplication1.model;
using WebApplication1.Serviceses;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class learningDataInfoController : ControllerBase
    {
        private readonly IlearningDataService _IlearningDataService;
        private readonly IGetCourserelateddataService _getCourserelateddataService;
        private readonly IGetCourseInfoService _getCourseInfoService;
        private readonly IGetSkillInfoService _getSkillInfoService;
        private readonly IInsertWdlComputedDataservice _insertWdlComputedDataservice;
        private readonly IWdldataprocessingService _wdldataprocessing;
        public readonly IGetWdlCompletionService _getWdlCompletionService;
        private readonly IUpdateWdlComputationService _updateWdlComputationService;
        private readonly IInsertSkillhistoryService _insertSkillhistoryService;
        public learningDataInfoController(IlearningDataService ilearningDataService, 
            IGetCourserelateddataService getCourserelateddataService, 
            IGetCourseInfoService getCourseInfoservice, IGetSkillInfoService getSkillInfoService,
            IInsertWdlComputedDataservice insertWdlComputedDataservice,
            IWdldataprocessingService wdldataprocessings,
            IGetWdlCompletionService getWdlCompletionService,
            IUpdateWdlComputationService updateWdlComputationService,
            IInsertSkillhistoryService insertSkillhistoryService
            )
        {
            _IlearningDataService = ilearningDataService;
            _getCourserelateddataService = getCourserelateddataService;
            _getCourseInfoService = getCourseInfoservice;
            _getSkillInfoService = getSkillInfoService;
            _insertWdlComputedDataservice = insertWdlComputedDataservice;
            _wdldataprocessing = wdldataprocessings;
            _getWdlCompletionService = getWdlCompletionService;
            _updateWdlComputationService = updateWdlComputationService;
            _insertSkillhistoryService = insertSkillhistoryService;
        }
        //ActionResult<List<WdlcompleteDataEntity>>
        [HttpGet]
        [Route("DataInfo")]
        public async Task<IActionResult> GetlearningData()
        {
            try
            { // crate global objecte
                var credit = 0;
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
                    
                    if(filteredCourses.CourseType=="Blended" && filteredCourses.CourseType=="ClassRoom"&& filteredCourses.ContentLevel=="Advance" &&filteredCourses.CourseHours>=-4)
                    {
                        credit = -3;

                    }
                    if (filteredCourses.CourseType == "Blended" && filteredCourses.CourseType == "ClassRoom" && filteredCourses.ContentLevel == "beginer" && filteredCourses.ContentLevel=="intermediate" && filteredCourses.CourseHours >= 8)
                    {
                        credit = -3;
                    }
                    if (filteredCourses.CourseType == "Online" && filteredCourses.CourseType == "Digital" && filteredCourses.ContentLevel == "advance" && filteredCourses.ContentLevel == "intermediate" && filteredCourses.CourseHours >= 16)
                    {
                        credit = -3;
                    }
                    //DateTime originalDateTime = item.CompletionDate;
                    //DateTime newDateTime = originalDateTime.AddMonths(-3);
                    //DateTime coursestartdate = new DateTime(result., DateTimeKind.Utc);

                    var skillbyid = skillinfo.Where(s => s.ref_SourceID == item.CourseID).FirstOrDefault();
                   if (skillbyid != null && filteredCourses != null)
                    {



                        var res = new WdlcompleteDataEntity
                        {
                            CourseID = item.CourseID,
                            EmployeeID = item.LearnerID,
                            SkillID = skillbyid.SkillID,
                            SourceSystem = item.SourceName,
                            CourseName = filteredCourses.CourseName,
                            UsagePercentage = "75",
                            //CreatedDateTime = DateTimeOffset.UtcNow,

                            EndDate = DateTimeOffset.UtcNow,
                            IsProcessed = false,
                            ProcessedDateTime = null,

                            //StartDate = item.CompletionDate.AddMonths(credit),
                            StartDate = item.CompletionDate?.AddMonths(credit),

                        };
                        wdlcompleteDataEntities.Add(res);
                    }
                    
                }

               
              var result1= await  _wdldataprocessing.WdldataprocessInterface(wdlcompleteDataEntities);

                return Ok(result1);
            }
            catch (Exception Ex)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("WdlComputeddata")]
        public async Task<IActionResult> WdlData([FromBody]List<WdlcompleteDataEntity> wdlcompleteDataEntities)
        {
            try
            {
                var result = await _insertWdlComputedDataservice.wdlinsert(wdlcompleteDataEntities);
                return Ok(result);
            }catch(Exception ex)
            {
                throw;

            }

        }
        [HttpGet]
        [Route("GetWdlData")]
        public async Task<IActionResult> GetWdlcompletiondata()
        {
            try
            {
                List<WdlcompleteDataEntity> res = await _getWdlCompletionService.GetDwlService();


                var updatedata = await _updateWdlComputationService.UpdateWdlComputationAsync(res);

                var skillhistory = await _insertSkillhistoryService.insSkillHistory(updatedata);
                return Ok(res);
            }
            catch(Exception ex)
            {
                throw;
            }
        }



    }
}
