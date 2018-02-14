using ApiClinic.ViewModels;
using AutoMapper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClinic
{
    public class ClinicProfile : Profile
    {
        public ClinicProfile()
        {
            CreateMap<Client, VMClient>().ReverseMap();
                
        }
    }
}
