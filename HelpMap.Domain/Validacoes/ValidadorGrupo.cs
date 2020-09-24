using FluentValidation;
using HelpMap.Domain.Models.Grupos;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMap.Domain.Validacoes
{
    public class ValidadorGrupo : AbstractValidator<Grupo>
    {
        public ValidadorGrupo()
        {
            this.RuleFor(x => x.Nome).NotEmpty().WithMessage("O Nome do Grupo é obrigatório")
                .Length(1, 40).WithMessage("O Nome não pode ser maior que 40 caracteres");
            this.RuleFor(x => x.Endereco.Cep).NotEmpty().WithMessage("O Cep é obrigatório");
            this.RuleFor(x => x.Endereco.Logradouro).NotEmpty().WithMessage("O Logradouro é obrigatório");
            this.RuleFor(x => x.Endereco.PontoReferencia).NotEmpty().WithMessage("O Ponto de Referência é obrigatório");


        }
    }
}
