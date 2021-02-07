using AutoMapper;
using Itbit.WebAPI.Domain.Models;
using Itbit.WebAPI.Inbound.InputModels;
using Itbit.WebAPI.Inbound.ViewModels;

namespace Itbit.WebAPI.Inbound.MapperProfiles
{
    public class UsuarioMapperProfile : Profile
    {
        public UsuarioMapperProfile()
        {
            CreateMap<UsuarioInputModel, Usuario>();
            CreateMap<Usuario, UsuarioViewModel>()
                .ForMember(viewModel => viewModel.Sexo, opt => opt.MapFrom(model => model.Sexo));
        }
    }
}
