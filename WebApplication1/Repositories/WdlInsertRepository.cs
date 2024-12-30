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
        public Task WdlInserRepo(List<WdlcompleteDataEntity> wdlcompleteDataEntities)
        {
            throw new NotImplementedException();
        }
    }
}
