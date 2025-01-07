using Microsoft.EntityFrameworkCore;
using WebApplication1.DbContextdatadetails;
using WebApplication1.Entities;
using WebApplication1.Interfaceses;

namespace WebApplication1.Repositories
{
   
    public class WdlInsertRepository : IInsertWdlComputedDataRepository
    {
        private readonly Dbconnect _dbconnect;
        public WdlInsertRepository(Dbconnect dbconnect)
        {
            _dbconnect = dbconnect;
        }
        public async Task<bool> WdlInserRepo(List<WdlcompleteDataEntity> wdlcompleteDataEntities)
        {
            try
            {
              

                  await _dbconnect.WdlcomputedData.AddRangeAsync(wdlcompleteDataEntities);
                    var result = await _dbconnect.SaveChangesAsync();
                    if (result>0)
                    {
                        return true;

                    }
                    else
                    {
                        return false;
                    }
                }
              
            
            catch(Exception ex)
            {
                throw;
            }
        }
    }
}
