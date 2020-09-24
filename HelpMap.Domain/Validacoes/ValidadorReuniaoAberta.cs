using FluentValidation;
using HelpMap.Domain.Models.Reunioes;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMap.Domain.Validacoes
{
    public class ValidadorReuniaoAberta : AbstractValidator<ReuniaoAberta>
    {
        public ValidadorReuniaoAberta()
        {
            this.RuleFor(x => x.Dia).NotEmpty().WithMessage("Informe O Dia da Reunião");
            this.RuleFor(x => x.Inicio).NotEmpty().WithMessage("Informe a Data inicio da Reunião");
            this.RuleFor(x => x.Fim).NotEmpty().WithMessage("Informe a Data fim da Reunião");

        }
    }
}
