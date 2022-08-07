using System;
using System.Collections.Generic;
using System.Text;

namespace Makonis.Contracts.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
