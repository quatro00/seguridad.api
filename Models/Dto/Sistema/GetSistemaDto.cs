namespace seguridad.api.Models.Dto.Sistema
{
    public class GetSistemaDto
    {
        public Guid id { get; set; }
        public string clave { get; set; }
        public string nombre { get; set; }
        public bool activo { get; set; }
    }
}
