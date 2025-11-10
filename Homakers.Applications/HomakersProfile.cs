using AutoMapper;
using Homakers.Applications.DTOs;
using Homakers.Domain.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Homakers.Applications
{
    public class HomakersProfile : Profile
    {
        public HomakersProfile()
        {
            CreateMap<Customers, CustomerDto>().ReverseMap();
            CreateMap<Professionals, ProfessionalsDto>().ReverseMap();
            CreateMap<Profession, ProfessionsDto>().ReverseMap();
        }
    }

}
