using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using WebApplication1.Interfaceses;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class learningDataInfoController : ControllerBase
    {
        private IlearningDataService _IlearningDataService;
        public learningDataInfoController(IlearningDataService ilearningDataService)
        {
            _IlearningDataService= ilearningDataService;
        }

        [HttpGet]
        [Route("DataInfo")]
        public async Task<ActionResult<List<string>>> GetlearningData()
        {
            try
            {
                List<string> result = await _IlearningDataService.ILearnerDataService();
                return result;
                    }
            catch (Exception Ex)
            {
                throw;
            }

           
    }


    }
}
