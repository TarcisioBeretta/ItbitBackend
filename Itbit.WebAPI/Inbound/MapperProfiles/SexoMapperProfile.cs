using AutoMapper;
using Itbit.WebAPI.Domain.Models;
using Itbit.WebAPI.Inbound.InputModels;
using Itbit.WebAPI.Inbound.ViewModels;

namespace Itbit.WebAPI.Inbound.MapperProfiles
{
public class SexoMapperProfile : Profile
    {
        public SexoMapperProfile()
        {
            CreateMap<SexoInputModel, Sexo>();
            CreateMap<Sexo, SexoViewModel>();
        }
    }
}
