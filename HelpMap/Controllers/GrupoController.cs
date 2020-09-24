using AutoMapper;
using HelpMap.Domain.Filtros;
using HelpMap.Domain.Interfaces;
using HelpMap.Domain.Models.Categories;
using HelpMap.Domain.Models.Grupos;
using HelpMap.Domain.Validacoes;
using HelpMap.ViewModels;
using HelpMap.ViewModels.Grupo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NetTopologySuite;
using NetTopologySuite.Algorithm;
using NetTopologySuite.Geometries;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;

namespace HelpMap.Controllers
{
    public class GrupoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IGrupoRepository _grupoRepository;
        private readonly ICategoriaRepository _categoriaRepository;
        public GrupoController(IGrupoRepository grupoRepository,
                               ICategoriaRepository categoriaRepository,
        IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _grupoRepository = grupoRepository;
            _mapper = mapper;
        }

        [HttpPut]
        [Route("Grupo")]
        public async Task<IActionResult> AlterarGrupo([FromBody]UpdateGrupoViewModel updateGrupoViewModel)
        {
            var point = new Point(updateGrupoViewModel.Endereco.Latidude, updateGrupoViewModel.Endereco.Longitude) { SRID = 4326 };

            var grupo = _mapper.Map<Grupo>(updateGrupoViewModel);
            grupo.IdCategoria = updateGrupoViewModel.Categoria.Id;
            grupo.Endereco.Localizacao = point;

            _grupoRepository.UpDate(grupo);
            _grupoRepository.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [Route("Grupo")]
        public async Task<IActionResult> AdicionarGrupo([FromBody]AddGrupoViewModel addGrupoViewModel)
        {

            var point = new Point(addGrupoViewModel.Endereco.Latidude, addGrupoViewModel.Endereco.Longitude) { SRID = 4326 };

            var grupo = _mapper.Map<Grupo>(addGrupoViewModel);

            var result = new ValidadorGrupo();
            var teste = result.Validate(grupo).Errors;
            var novaLista = new List<string>();

            foreach (var item in teste)
            {
                novaLista.Add(item.ErrorMessage);

            }

            if (novaLista.Count > 0)
            {
                return Ok(novaLista);
            }


            grupo.Endereco.Localizacao = point;

            _grupoRepository.Add(grupo);
            _grupoRepository.SaveChanges();
            return Ok();
        }

        [HttpPost]
        [Route("GrupoPorFiltro")]
        public async Task<IActionResult> BuscarGruposFiltro([FromQuery]int idCategoria, [FromBody]BuscaGrupoFiltroViewModel addGrupoViewModel)
        {
            var gruposModel = _grupoRepository.GetGruposPorFiltro(idCategoria, _mapper.Map<FiltroBuscaGrupo>(addGrupoViewModel));
            var grupos = _mapper.Map<List<GrupoViewModel>>(gruposModel);

            foreach (var grupo in grupos)
            {
                grupo.Endereco.Latidude = grupo.Endereco.Localizacao.Coordinate.X;
                grupo.Endereco.Longitude = grupo.Endereco.Localizacao.Coordinate.Y;
                grupo.Endereco.Localizacao = null;
            }

            return Ok(grupos);
        }

        [HttpDelete]
        [Route("RemoverGrupo")]
        public async Task<IActionResult> RemoverGrupo([FromQuery]int id)
        {
            if (id == 0)
                return NotFound();

            _grupoRepository.Remove(id);
            _grupoRepository.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("GruposCategoria")]
        public async Task<IActionResult> GetGruposCategoria([FromQuery]int idCategoria)
        {
            var rca =  _grupoRepository.GetGruposCategoria(idCategoria);
            var grupo = _mapper.Map<List<GrupoViewModel>>(rca);
            return Ok(grupo);
        }

        [HttpGet]
        [Route("Grupo/nome")]
        public async Task<IActionResult> Get( string nomeGrupo)
        {
            var result =  _grupoRepository.GetByName(nomeGrupo);

            if (result == default)
                return NotFound();
            var rest = _mapper.Map<GrupoViewModel>(result);

            rest.Endereco.Latidude = rest.Endereco.Localizacao.Coordinate.X;
            rest.Endereco.Longitude = rest.Endereco.Localizacao.Coordinate.Y;

            rest.Endereco.Localizacao = null;

            return Ok(rest);
        }

        [HttpGet]
        [Route("Grupo/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var grupo = _mapper.Map<GrupoViewModel>(_grupoRepository.GetByIdGrupo(id));

            grupo.Endereco.Latidude = grupo.Endereco.Localizacao.Coordinate.X;
            grupo.Endereco.Longitude = grupo.Endereco.Localizacao.Coordinate.Y;

            grupo.Endereco.Localizacao = null;

            return Ok(grupo);
        }
    }
}
