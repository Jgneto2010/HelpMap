using System;
using System.Collections.Generic;
using System.Text;

namespace HelpMap.Domain.Models
{
    public abstract class Entity
    {
        public int Id { get; protected set; }
    }
}
