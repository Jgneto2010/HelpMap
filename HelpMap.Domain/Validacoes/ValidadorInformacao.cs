using FluentValidation;
using HelpMap.Domain.Models.Categorias;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMap.Domain.Validacoes
{
    public class ValidadorInformacao : AbstractValidator<Informacao>
    {
        public ValidadorInformacao()
        {
            this.RuleFor(x => x.Titulo).NotEmpty().WithMessage("Adicione o Titulo")
            .Length(1, 40).WithMessage("O Titulo não pode ser maior que 40 caracteres");
            this.RuleFor(x => x.Texto).NotEmpty().WithMessage("Adicione um Texto");
        }
    }
}
