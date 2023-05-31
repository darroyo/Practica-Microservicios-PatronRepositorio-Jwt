using PatronRepositorio.Dtos;

namespace PatronRepositorio.Services
{
    public interface IFoodService
    {
        public Task<IEnumerable<ComidaDto>> GetAlitas();

        public Task<IEnumerable<ComidaDto>> GetHamburguesas();

        public Task<IEnumerable<ComidaDto>> GetAll();
    }
}
