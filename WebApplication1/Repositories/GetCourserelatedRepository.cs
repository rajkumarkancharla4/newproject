using Microsoft.EntityFrameworkCore;
using WebApplication1.DbContextdatadetails;
using WebApplication1.Entities;
using WebApplication1.Interfaceses;

namespace WebApplication1.Repositories
{
    public class GetCourserelatedRepository : IGetCourserelateddataRepository
    {
        private readonly Dbconnect _dbContextdatadetails;
        public GetCourserelatedRepository(Dbconnect dbContextdatadetails)
        {
            _dbContextdatadetails = dbContextdatadetails;
        }

        public async Task GetCOursedataServcie(List<Entity> entities)
        {
            try
            {
                //List<Entity> data = new List<Entity>();

                         

                // Save changes to the database
               await _dbContextdatadetails.Learningtables.Where(r => !r.IsProcessed).ExecuteUpdateAsync(x => x.SetProperty(x => x.IsProcessed,true));

               
            }
            catch (Exception ex)
            {
                throw;

            }


        }
}
}
