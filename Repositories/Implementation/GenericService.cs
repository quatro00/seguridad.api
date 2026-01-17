using seguridad.api.Models.Domain;
using seguridad.api.Repositories.Interface;

namespace seguridad.api.Repositories.Implementation
{
    public class GenericService
    {
        private readonly IGenericRepository<Organizacion> _orgRepo;
        private readonly IGenericRepository<Sistema> _sisRepo;

        public GenericService(
        IGenericRepository<Organizacion> orgRepo,
        IGenericRepository<Sistema> sisRepo)
        {
            _orgRepo = orgRepo;
            _sisRepo = sisRepo;
        }
    }
}
