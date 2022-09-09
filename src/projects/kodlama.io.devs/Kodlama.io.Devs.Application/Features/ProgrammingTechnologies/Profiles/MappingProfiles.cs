using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.DeleteProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.UpdateProgrammingTechnology;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Models;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingTechnology, CreateProgrammingTechnologyCommand>().ReverseMap();
            CreateMap<ProgrammingTechnology, UpdateProgrammingTechnologyCommand>().ReverseMap();
            CreateMap<ProgrammingTechnology, DeleteProgrammingTechnologyCommand>().ReverseMap();

            CreateMap<ProgrammingTechnology, CreatedProgrammingTechnologyDto>()
                .ForMember(p => p.ProgrammingLanguageName,
                opt => opt.MapFrom(m => m.ProgrammingLanguage.Name))
                .ForMember(p => p.ProgrammingTechnologyTypeName,
                opt => opt.MapFrom(m => m.ProgrammingTechnologyType.Name))
                .ReverseMap();

            CreateMap<ProgrammingTechnology, UpdatedProgrammingTechnologyDto>()
                .ForMember(p => p.ProgrammingLanguageName,
                opt => opt.MapFrom(m => m.ProgrammingLanguage.Name))
                .ForMember(p => p.ProgrammingTechnologyTypeName,
                opt => opt.MapFrom(m => m.ProgrammingTechnologyType.Name))
                .ReverseMap();

            CreateMap<ProgrammingTechnology, DeletedProgrammingTechnologyDto>()
                .ForMember(p => p.ProgrammingLanguageName,
                opt => opt.MapFrom(m => m.ProgrammingLanguage.Name))
                .ForMember(p => p.ProgrammingTechnologyTypeName,
                opt => opt.MapFrom(m => m.ProgrammingTechnologyType.Name))
                .ReverseMap();

            CreateMap<ProgrammingTechnology, ProgrammingTechnologyListDto>()
                .ForMember(p => p.ProgrammingLanguageName,
                opt => opt.MapFrom(m => m.ProgrammingLanguage.Name))
                .ForMember(p => p.ProgrammingTechnologyTypeName,
                opt => opt.MapFrom(m => m.ProgrammingTechnologyType.Name))
                .ReverseMap();

            CreateMap<IPaginate<ProgrammingTechnology>, ProgrammingTechnologyListModel>().ReverseMap();
        }
    }
}
