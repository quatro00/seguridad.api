using AutoMapper;
using seguridad.api.Models.Domain;
using seguridad.api.Models.Dto.Organizacion;
using seguridad.api.Models.Dto.Sistema;

namespace seguridad.api
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //organizacion
            CreateMap<Organizacion, GetOrganizacionDto>();

            CreateMap<CreateOrganizacionDto, Organizacion>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.UsuarioCreacion, opt => opt.Ignore())
                .ForMember(x => x.FechaCreacion, opt => opt.Ignore());

            CreateMap<UpdateOrganizacionDto, Organizacion>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore());


            //sistema
            CreateMap<Sistema, GetSistemaDto>();

            CreateMap<CreateSistemaDto, Sistema>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.UsuarioCreacion, opt => opt.Ignore())
                .ForMember(x => x.FechaCreacion, opt => opt.Ignore());

            CreateMap<UpdateSistemaDto, Sistema>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.UsuarioCreacion, opt => opt.Ignore())
                .ForMember(dest => dest.FechaCreacion, opt => opt.Ignore());
        }
    }
}
