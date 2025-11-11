using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Health_Hub.Application.DTOs.Request;
using Health_Hub.Application.DTOs.Response;
using Health_Hub.Domain.Entities;

namespace Health_Hub.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<UsuarioRequest, Usuario>()
                .ForMember(dest => dest.SenhaHash, opt => opt.Ignore());
            CreateMap<Usuario, UsuarioResponse>();

           
            CreateMap<QuestionarioRequest, Questionario>();
            CreateMap<Questionario, QuestionarioResponse>();

            
            CreateMap<RelatorioRequest, Relatorio>();
            CreateMap<Relatorio, RelatorioResponse>();
        }
    }
}
