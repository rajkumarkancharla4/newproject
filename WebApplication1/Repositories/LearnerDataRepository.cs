using Microsoft.EntityFrameworkCore;
using WebApplication1.DbContextdatadetails;
using WebApplication1.Entities;
using WebApplication1.Interfaceses;

namespace WebApplication1.Repositories
{
    public class LearnerDataRepository : ILearnerDataRepositories
    {
        private readonly Dbconnect _dbconnect;
        public LearnerDataRepository(Dbconnect dbconnect)
        {
            _dbconnect = dbconnect;
        }

        public async Task<List<Entity>> IlearnigRepository()
        {
            try
            {
                //List<Entity> learningdata =  await _dbconnect.Learningtables.
                //                             Where(x => x.IsProcessed == false && x.Status == "Complete").OrderBy(x => x.SubscriberID)
                //                            .Take(10).Include(x => x.SubscriberID).ToListAsync();
                List<Entity> learningdata = await _dbconnect.Learningtables
    .Where(x => x.IsProcessed == false && x.Status == "Complete")
    .OrderBy(x => x.SubscriberID)
    .Take(10)
    .ToListAsync();

                return learningdata;

            }
            catch (Exception ex)
            {
                throw;

            }
        }
    }
}
