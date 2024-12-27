using WebApplication1.Interfaceses;

namespace WebApplication1.Serviceses
{
    public class LearnerDataServices : IlearningDataService
    {
        private readonly ILearnerDataRepositories _learnerDataRepositories;
        public LearnerDataServices(ILearnerDataRepositories learnerDataRepositories)
        {
            _learnerDataRepositories = learnerDataRepositories;
        }

        public async Task<List<string>> ILearnerDataService()
        {
            try
            {


                List<string> result = await _learnerDataRepositories.IlearnigRepository();
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
