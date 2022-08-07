using Makonis.Contracts.Entities;
using Makonis.Contracts.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Makonis.Repository.DataAccess
{
    public class PersonRepository : IPersonRepository
    {
        private readonly IFileHelper _fileHelper;
        public PersonRepository(IFileHelper helper)
        {
            _fileHelper = helper;
        }
        public void Add(Person entity)
        {
            if (entity is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            var persons = GetList();
            if (persons == null)
                persons = new List<Person>();
            persons.Add(entity);
            _fileHelper.WriteFile(JsonConvert.SerializeObject(persons));
        }
        public List<Person> GetList()
        {
            return _fileHelper.ReadFile<Person>();
        }
    }
}
