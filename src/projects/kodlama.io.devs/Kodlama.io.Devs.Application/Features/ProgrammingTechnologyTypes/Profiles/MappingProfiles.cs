using AutoMapper;
using Core.Persistence.Paging;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Commands.CreateProgrammingTechnologyType;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Commands.DeleteProgrammingTechnologyType;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Commands.UpdateProgrammingTechnologyType;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Models;
using Kodlama.io.Devs.Domain.Entities;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProgrammingTechnologyType, CreateProgrammingTechnologyTypeCommand>().ReverseMap();
            CreateMap<ProgrammingTechnologyType, UpdateProgrammingTechnologyTypeCommand>().ReverseMap();
            CreateMap<ProgrammingTechnologyType, DeleteProgrammingTechnologyTypeCommand>().ReverseMap();

            CreateMap<ProgrammingTechnologyType, CreatedProgrammingTechnologyTypeDto>().ReverseMap();
            CreateMap<ProgrammingTechnologyType, UpdatedProgrammingTechnologyTypeDto>().ReverseMap();
            CreateMap<ProgrammingTechnologyType, DeletedProgrammingTechnologyTypeDto>().ReverseMap();

            CreateMap<ProgrammingTechnologyType, ProgrammingTechnologyTypeListDto>().ReverseMap();
            CreateMap<IPaginate<ProgrammingTechnologyType>, ProgrammingTechnologyTypeListModel>().ReverseMap();
        }
    }
}
