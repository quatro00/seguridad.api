using seguridad.api.Models.Domain;
using seguridad.api.Models.Interfaces;
using System.Linq.Expressions;

namespace seguridad.api.Models.Specifications
{
    public class SistemaSpecification : ISpecification<Sistema>
    {
        public Expression<Func<Sistema, bool>> Criteria { get; }
        public List<string> IncludeStrings { get; set; }
        public SistemaSpecification(FiltroGlobal filtro)
        {
            Criteria = p =>
                (filtro.IncluirInactivos || (p.Activo));
        }
    }
}
