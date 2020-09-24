using FluentValidation;
using HelpMap.Domain.Models.Grupos;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMap.Domain.Validacoes
{
    public class ValidadorEvento : AbstractValidator<Evento>
    {
        public ValidadorEvento()
        {
            this.RuleFor(x => x.Titulo).NotEmpty().WithMessage("Adicione o Titulo")
             .Length(1, 40).WithMessage("O Titulo não pode ser maior que 40 caracteres");
            this.RuleFor(x => x.Descricao).NotEmpty().WithMessage("Adicione uma Descrição");
            this.RuleFor(x => x.Valor).NotEmpty().WithMessage("Informe um Valor");
            this.RuleFor(x => x.Dia).NotEmpty().WithMessage("Informe o Dia");
            this.RuleFor(x => x.HorarioInicio).NotEmpty().WithMessage("Informe o Horario de Inicio");
            this.RuleFor(x => x.HorarioInicio).NotEmpty().WithMessage("Informe o Horario do Fim");

        }
        
    }
}
