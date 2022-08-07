using AutoMapper;
using Makonis.API.ViewModels;
using Makonis.Contracts.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Makonis.API.Helpers
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<PersonVM, Person>();
        }
    }
}
