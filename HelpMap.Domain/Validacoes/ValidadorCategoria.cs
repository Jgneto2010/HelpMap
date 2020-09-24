using FluentValidation;
using HelpMap.Domain.Models.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMap.Domain.Validacoes
{
    public class ValidadorCategoria : AbstractValidator<Categoria>
    {
        public ValidadorCategoria()
        {
            this.RuleFor(x => x.Nome).NotEmpty().WithMessage("Informe o Nome da Categoria");
            this.RuleFor(x => x.Nome).Length(1, 40).WithMessage("O Nome da Categoria não pode ser maior que 40 caracteres");
        }
    }
}
