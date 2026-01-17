namespace seguridad.api.Models.Dto.Sistema
{
    public class CreateSistemaDto
    {
        public string clave { get; set; }
        public string nombre { get; set; }
        public bool activo { get; set; }
    }
}
