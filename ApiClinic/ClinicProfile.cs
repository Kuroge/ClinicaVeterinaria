using ApiClinic.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using Model.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClinic
{
    public class ClinicProfile : Profile
    {
        IRepository<Client> clientRepository;
        IRepository<Kind> kindRepository;
        public ClinicProfile(IRepository<Client> clientRepository, IRepository<Kind> kindRepository)
        {
            this.kindRepository = kindRepository;
            this.clientRepository = clientRepository;
        }
        public ClinicProfile()
        {
            CreateMap<Client, VMClient>().ReverseMap();
            CreateMap<Client, VMClientAnimal>().ReverseMap();
            CreateMap<Animal, VMAnimal>()
                .ForMember(x => x.OwnerName, x => x.MapFrom(y => y.Owner.FirstName))
                .ForMember(x => x.OwnerPhone, x => x.MapFrom(y => y.Owner.Phone))
                .ForMember(x => x.KindName, x => x.MapFrom(y => y.Species.Name))
                .ForMember(x => x.Age, x => x.MapFrom(y => GetAge(y.BirthDate))).ReverseMap();

            CreateMap<Animal, VMAnimalList>()
                .ForMember(x => x.SpecieId, x => x.MapFrom(y => y.Species.Id))
                .ForMember(x => x.ClientId, x => x.MapFrom(y => y.Owner.Id))
                .ForMember(x => x.Species, x => x.Ignore())
                .ForMember(x => x.Clients, x => x.Ignore())
                .ReverseMap()
                .ForMember(x => x.Owner, x => x.Ignore())
                .ForMember(x => x.Species, x => x.Ignore());

            CreateMap<Kind, SelectListItem>()
                .ForMember(dest => dest.Value, x => x.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Text, x => x.MapFrom(src => src.Name));

            CreateMap<Client, SelectListItem>()
                .ForMember(dest => dest.Value, x => x.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Text, x => x.MapFrom(src => src.LastName + ", " + src.FirstName));
        }
        public int GetAge(DateTime bdate)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - bdate.Year;
            if (now < bdate.AddYears(age)) age--;
            return age;
        }
    }
}
