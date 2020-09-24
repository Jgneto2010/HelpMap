using AutoMapper;
using HelpMap.Domain.Filtros;
using HelpMap.Domain.Models.Categories;
using HelpMap.Domain.Models.Grupos;
using HelpMap.Domain.Models.Reunioes;
using HelpMap.ViewModels;
using HelpMap.ViewModels.Endereco;
using HelpMap.ViewModels.Grupo;
using HelpMap.ViewModels.Reuniao;

namespace HelpMap.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ReuniaoViewModel, Reuniao>();
            CreateMap<AddReuniaoViewModel, Reuniao>();
            CreateMap<ReuniaoAbertaViewModel, ReuniaoAberta>();
            CreateMap<AddReuniaoAbertaViewModel, ReuniaoAberta>();

            CreateMap<EnderecoViewModel, Endereco>();
            CreateMap<AddEnderecoViewModel, Endereco>();
            CreateMap<UpdateEnderecoViewModel, Endereco>();

            CreateMap<CategoriaViewModel, Categoria>();
            CreateMap<AddCategoria, Categoria>();

            CreateMap<GrupoViewModel, Grupo>();
            CreateMap<AddGrupoViewModel, Grupo>();
            CreateMap<UpdateGrupoViewModel, Grupo>();
            
            CreateMap<BuscaGrupoFiltroViewModel, FiltroBuscaGrupo>();
            CreateMap<EventoViewModel, Evento>();
        }
    }
    
}
