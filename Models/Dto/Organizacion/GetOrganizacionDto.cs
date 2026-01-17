namespace seguridad.api.Models.Dto.Organizacion
{
    public class GetOrganizacionDto
    {
        public Guid id { get; set; }
        public string nombre { get; set; }
        public string Clave { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string responsable { get; set; }
        public bool activo { get; set; }
    }
}
