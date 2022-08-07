using System;
using System.Collections.Generic;
using System.Text;

namespace Makonis.Contracts.Entities
{
    public class Person:BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
