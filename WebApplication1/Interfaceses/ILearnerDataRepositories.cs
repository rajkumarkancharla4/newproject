using WebApplication1.Entities;

namespace WebApplication1.Interfaceses
{
    public interface ILearnerDataRepositories
    {
        public Task<List<Entity>> IlearnigRepository();
    }
}
