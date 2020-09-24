using AutoMapper;
using HelpMap.Domain.Interfaces;
using HelpMap.Domain.Models.Categories;
using HelpMap.Domain.Validacoes;
using HelpMap.Infrastructure.Repository;
using HelpMap.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMap.Controllers
{
    [Authorize]
    public class CategoriaController: Controller
    {

        private readonly IMapper _mapper;
        private readonly ICategoriaRepository _categoriaRepository;
        public CategoriaController(ICategoriaRepository categoriaRepository,
                               IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("Categoria")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AdicionarCategoria([FromBody]AddCategoria categoriaViewModel)
        {
            var categoria = _mapper.Map<Categoria>(categoriaViewModel);

            var result = new ValidadorCategoria();
            var teste = result.Validate(categoria).Errors;
            var novaLista = new List<string>();

            foreach (var item in teste)
            {
                novaLista.Add(item.ErrorMessage);

            }

            if (novaLista.Count > 0)
            {
                return Ok(novaLista);
            }

            _categoriaRepository.Add(categoria);
            _categoriaRepository.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("Categoria")]
        public CategoriaViewModel GetCategorias(int id)
        {
            var response = _mapper.Map<CategoriaViewModel>(_categoriaRepository.GetByIdCategoria(id));
            return response;
        }
    }
}
