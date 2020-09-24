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
    public class ReuniaoController : Controller
    {

        private readonly IMapper _mapper;
        private readonly IReuniaoRepository _reuniaoRepository;
        public ReuniaoController(IReuniaoRepository reuniaoRepository,
                                 IMapper mapper)
        {
            _reuniaoRepository = reuniaoRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("AdicionarReuniao")]
        public async Task<IActionResult> AdicionarReuniao([FromBody]AddReuniaoViewModel addReuniaoModel)
        {
            var reuniao = _mapper.Map<Reuniao>(addReuniaoModel);


            var result = new ValidadorReuniao();
            var teste = result.Validate(reuniao).Errors;
            var novaLista = new List<string>();

            foreach (var item in teste)
            {
                novaLista.Add(item.ErrorMessage);

            }

            if (novaLista.Count > 0)
            {
                return Ok(novaLista);
            }

            _reuniaoRepository.Add(reuniao);
            _reuniaoRepository.SaveChanges();
            return Ok();
        }

        [HttpDelete]
        [Route("RemoverReuniao/{id}")]
        public async Task<IActionResult> RemoverReuniao(int id)
        {

            if (id == 0)
            {
                return NotFound();
            }

            _reuniaoRepository.Remove(id);
            _reuniaoRepository.SaveChanges();
            return Ok();
        }

        [HttpPut]
        [Route("AlterarReuniao")]
        public async Task<IActionResult> Put([FromBody]ReuniaoViewModel reuniaoViewModel)
        {
            var reuniao = _mapper.Map<Reuniao>(reuniaoViewModel);

            _reuniaoRepository.UpDate(reuniao);
            _reuniaoRepository.SaveChanges();
            return Ok();
        }


        [HttpGet]
        [Route("Reuniao/{idGrupo}")]
        public async Task<IActionResult> GetReuniaoGrupo(int idGrupo)
        {
            var reunioes = _mapper.Map<List<ReuniaoViewModel>>(_reuniaoRepository.GetReuniaoGrupo(idGrupo));

            return Ok(reunioes);
        }
    }
}
