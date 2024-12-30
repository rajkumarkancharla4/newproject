using WebApplication1.Entities;

namespace WebApplication1.Interfaceses
{
    public interface IGetCourserelateddataRepository
    {
        public Task GetCOursedataServcie(List<Entity> entities );
    }
}
