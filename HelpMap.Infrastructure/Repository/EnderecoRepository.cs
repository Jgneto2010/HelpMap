using HelpMap.Domain.Interfaces;
using HelpMap.Domain.Models.Grupos;
using HelpMap.Infrastructure.Context;

namespace HelpMap.Infrastructure.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(ContextEntity context) : base(context)
        {
        }
    }
}
