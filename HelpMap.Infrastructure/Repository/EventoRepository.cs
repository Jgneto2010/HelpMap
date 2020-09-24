using HelpMap.Domain.Interfaces;
using HelpMap.Domain.Models.Grupos;
using HelpMap.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMap.Infrastructure.Repository
{
    public class EventoRepository : Repository<Evento>, IEventoRepository
    {
        public EventoRepository(ContextEntity context) : base(context)
        {

        }
    }
}
