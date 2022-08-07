using Makonis.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Makonis.Contracts.Interfaces
{
    public interface IPersonRepository
    {
        void Add(Person entity);
        List<Person> GetList();
    }
}
