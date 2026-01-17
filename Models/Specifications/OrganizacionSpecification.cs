using seguridad.api.Models.Domain;
using seguridad.api.Models.Interfaces;
using System.Linq.Expressions;

namespace seguridad.api.Models.Specifications
{
    public class OrganizacionSpecification : ISpecification<Organizacion>
    {
        public Expression<Func<Organizacion, bool>> Criteria { get; }
        public List<string> IncludeStrings { get; set; }
        public OrganizacionSpecification(FiltroGlobal filtro)
        {
            Criteria = p =>
                (filtro.IncluirInactivos || (p.Activo));
        }
    }
}
