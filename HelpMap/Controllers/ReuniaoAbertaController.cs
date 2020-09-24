using AutoMapper;
using HelpMap.Domain.Interfaces;
using HelpMap.Domain.Models.Reunioes;
using HelpMap.Domain.Validacoes;
using HelpMap.ViewModels;
using HelpMap.ViewModels.Reuniao;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HelpMap.Controllers
{
    public class ReuniaoAbertaController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IReuniaoAbertaRepository _reuniaoAbertaRepository;
        public ReuniaoAbertaController(IReuniaoAbertaRepository reuniaoAbertaRepository,
                                 IMapper mapper)
        {
            _reuniaoAbertaRepository = reuniaoAbertaRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("AdicionarReuniaoAberta")]
        public async Task<IActionResult> AdicionarReuniao([FromBody]AddReuniaoAbertaViewModel addReuniaoAbertaModel)
        {
            var reuniaoAberta = _mapper.Map<ReuniaoAberta>(addReuniaoAbertaModel);


            var result = new ValidadorReuniaoAberta();
            var teste = result.Validate(reuniaoAberta).Errors;
            var novaLista = new List<string>();

            foreach (var item in teste)
            {
                novaLista.Add(item.ErrorMessage);

            }

            if (novaLista.Count > 0)
            {
                return Ok(novaLista);
            }

            _reuniaoAbertaRepository.Add(reuniaoAberta);
            _reuniaoAbertaRepository.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("RemoverReuniaoAberta/{id}")]
        public async Task<IActionResult> RemoverReuniao(int id)
        {
            if (id == 0)
                return NotFound();

            _reuniaoAbertaRepository.Remove(id);
            _reuniaoAbertaRepository.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("AlterarReuniaoAberta")]
        public async Task<IActionResult> Put([FromBody]ReuniaoAbertaViewModel reuniaoViewModel)
        {
            var reuniao = _mapper.Map<ReuniaoAberta>(reuniaoViewModel);

            _reuniaoAbertaRepository.UpDate(reuniao);
            _reuniaoAbertaRepository.SaveChanges();
            return Ok();
        }

        [HttpGet]
        [Route("ReuniaoAberta/{idGrupo}")]
        public async Task<IActionResult> GetReuniaoAberta(int idGrupo)
        {
            var reunioes = _mapper.Map<List<ReuniaoAbertaViewModel>>(_reuniaoAbertaRepository.GetReuniaoAbertaGrupo(idGrupo));
            return Ok(reunioes);
        }
    }


}