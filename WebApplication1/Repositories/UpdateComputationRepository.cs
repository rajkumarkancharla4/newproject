using WebApplication1.DbContextdatadetails;
using WebApplication1.Entities;
using WebApplication1.Interfaceses;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebApplication1.Repositories
{
    public class UpdateComputationRepository : IUpdateWdlComputationRepository
    {
        private readonly Dbconnect _dbconnect;
        public UpdateComputationRepository( Dbconnect dbconnect)
        {
            _dbconnect = dbconnect;
        }
        public async Task<List<WdlcompleteDataEntity>> updateWdlComputationAsync(List<WdlcompleteDataEntity> wdlcompleteDataEntities)
        {
            try
            {

                List<WdlcompleteDataEntity> upateddat = new List<WdlcompleteDataEntity>();

                foreach (var details in wdlcompleteDataEntities)

                {

                    details.ProcessedDateTime = DateTime.Now;
                    details.IsProcessed = true;
                    // Update datetime column
                    upateddat.Add(details);
                }
               _dbconnect.WdlcomputedData.UpdateRange(upateddat);
                 var res=   await _dbconnect.SaveChangesAsync();
                return upateddat;
                    


            }
            catch(Exception ex)
            {
                throw;
            }

        }
    }
}
