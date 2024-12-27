using Microsoft.EntityFrameworkCore;
using WebApplication1.DbContextdatadetails;
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

        public async Task<List<string>> IlearnigRepository()
        {
            try
            {
                List<string> learningdata = await _dbconnect.Learningtables.Where(x => x.IsProcessed == false && x.Status == "Complete").OrderBy(x => x.SubscriberID).Take(10).Select(x => x.SubscriberID.ToString()) // Assuming SubscriberID is a string or convertible to string
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
