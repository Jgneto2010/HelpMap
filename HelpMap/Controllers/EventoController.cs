using AutoMapper;
using HelpMap.Domain.Interfaces;
using HelpMap.Domain.Models.Grupos;
using HelpMap.Domain.Validacoes;
using HelpMap.Infrastructure.Repository;
using HelpMap.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelpMap.Controllers
{
    public class EventoController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IEventoRepository _eventoRepository;
        public EventoController(IEventoRepository eventoRepository,
                             
        IMapper mapper)
        {
            _eventoRepository = eventoRepository;
            _mapper = mapper;
        }


        [HttpPost]
        [Route("Evento")]
        public async Task<IActionResult> AdicionarEvento([FromBody]EventoViewModel eventoViewModel)
        {
            var eventocr = _mapper.Map<Evento>(eventoViewModel);
            _eventoRepository.Add(eventocr);

            var result = new ValidadorEvento();
            var teste = result.Validate(eventocr).Errors;
            var novaLista = new List<string>();

            foreach (var item in teste)
            {
                novaLista.Add(item.ErrorMessage);

            }

            if (novaLista.Count > 0)
            {
                return Ok(novaLista);
            }
            _eventoRepository.SaveChanges();
            return Ok();
        }
     
        [HttpPut]
        [Route("AlterarEvento")]
        public async Task<IActionResult> Put([FromBody]EventoViewModel eventoViewModel)
        {
            var reuniao = _mapper.Map<Evento>(eventoViewModel);

            _eventoRepository.UpDate(reuniao);
            _eventoRepository.SaveChanges();
            return Ok();

        }

        [HttpDelete]
        [Route("RemoverEvento")]
        public async Task<IActionResult> RemoverGrupo([FromQuery]int id)
        {
            if (id == 0)
                return NotFound();

            _eventoRepository.Remove(id);
            _eventoRepository.SaveChanges();
            return Ok();
        }

    }
}
