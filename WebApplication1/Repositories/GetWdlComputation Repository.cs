
using Microsoft.EntityFrameworkCore;
using WebApplication1.DbContextdatadetails;
using WebApplication1.Entities;
using WebApplication1.Interfaceses;

namespace WebApplication1.Repositories
{
    public class GetWdlComputation_Repository : IGetWdlCompletionRepository
    {
        private readonly Dbconnect _dbconnect;
        public GetWdlComputation_Repository( Dbconnect dbconnect)
        {
            _dbconnect =dbconnect;
        }
        public async  Task <List<WdlcompleteDataEntity>> GetWdlRepository()
        {

            try
            {


                List<WdlcompleteDataEntity> res = await _dbconnect.WdlcomputedData .Where(x =>x.IsProcessed==false) // Filter records where IsProcess is true
                         .OrderBy(x => x.EmployeeID)      
                         .ToListAsync();
                //if(res !=null)
                //{
                //    res.Proc = DateTime.Now; // Update datetime column
                //    _dbconnect.WdlcomputedData.Update(recordToUpdate);
                //}

                return res;
            }
            catch (Exception ex)
            {

                throw;
                    }
        }
    }
}
