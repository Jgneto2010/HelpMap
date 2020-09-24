using AutoMapper;
using HelpMap.Domain.Models.Categorias;
using HelpMap.Domain.Models.Categories;
using HelpMap.Domain.Models.Grupos;
using HelpMap.Domain.Models.Reunioes;
using HelpMap.ViewModels;

namespace HelpMap.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Grupo, GrupoViewModel>();
            CreateMap<Reuniao, ReuniaoViewModel>();
            CreateMap<Endereco, EnderecoViewModel>();
            CreateMap<Categoria, CategoriaViewModel>();
            CreateMap<ReuniaoAberta, ReuniaoAbertaViewModel>();
            CreateMap<Informacao, InformacaoViewModel>();
            CreateMap<Evento, EventoViewModel>();
        }
    }
}
