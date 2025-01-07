using Microsoft.EntityFrameworkCore;
using WebApplication1.DbContextdatadetails;
using WebApplication1.Entities;
using WebApplication1.Interfaceses;

namespace WebApplication1.Repositories
{
    public class InsertSkillHistoryRepository : IInsertSkillHistroryRepository
    {
        private readonly Dbconnect _dbconnect;
        public InsertSkillHistoryRepository(Dbconnect dbconnect)
        {
            _dbconnect = dbconnect;
            
        }
        public async Task<bool> InSkillhistoryasync(List<WdlcompleteDataEntity> skillHistoryEntities)
        {
            try
            {
                List<SkillHistoryEntity> skillhistory = new List<SkillHistoryEntity>();

                foreach (var skill in skillHistoryEntities)
                {
                    var data = new SkillHistoryEntity();
                    data.ID = skill.ID;
                    data.EmployeeID = skill.EmployeeID;
                    data.SkillID = skill.SkillID;
                    data.StartDate = skill.StartDate;
                    data.EndDate = skill.EndDate;
                    data.UsagePercentage = skill.UsagePercentage;
                    data.SourceSystem = skill.SourceSystem;
                    data.CourseID = skill.CourseID;
                    data.CreatedDateTime = skill.CreatedDateTime;
                    data.ProcessedDateTime = skill.ProcessedDateTime;
                    skillhistory.Add(data);
                    var res = await _dbconnect.SkillHistory.AnyAsync(x => x.CourseID == data.CourseID
                   && x.EmployeeID == data.EmployeeID
                   && x.SkillID == data.SkillID
                   && x.StartDate == data.StartDate
                   && x.EndDate == data.EndDate);

                    if (!res)
                    {
                        await _dbconnect.SkillHistory.AddAsync(data);
                    }
                }

                var res1 = await _dbconnect.SaveChangesAsync();

                return res1 > 0 ? true : false;
            }
            catch(Exception ex)
            {
                throw;

            }

        }
    }
}
