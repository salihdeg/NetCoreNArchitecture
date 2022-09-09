using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologies.Commands.CreateProgrammingTechnology
{
    public class CreateProgrammingTechnologyCommand : IRequest<CreatedProgrammingTechnologyDto>
    {
        public int ProgrammingLanguageId { get; set; }
        public int ProgrammingTechnologyTypeId { get; set; }
        public string Name { get; set; }

        public class CreateProgrammingTechnologyCommandHandler : IRequestHandler<CreateProgrammingTechnologyCommand, CreatedProgrammingTechnologyDto>
        {
            private readonly IProgrammingTechnologyRepository _programmingTechnologyRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyBusinessRules _programmingTechnologyBusinessRules;

            public CreateProgrammingTechnologyCommandHandler(IProgrammingTechnologyRepository programmingTechnologyRepository, IMapper mapper, ProgrammingTechnologyBusinessRules programmingTechnologyBusinessRules)
            {
                _programmingTechnologyRepository = programmingTechnologyRepository;
                _mapper = mapper;
                _programmingTechnologyBusinessRules = programmingTechnologyBusinessRules;
            }

            public async Task<CreatedProgrammingTechnologyDto> Handle(CreateProgrammingTechnologyCommand request, CancellationToken cancellationToken)
            {
                ProgrammingTechnology mappedProgrammingTechnology = _mapper.Map<ProgrammingTechnology>(request);

                ProgrammingTechnology programmingTechnology = await _programmingTechnologyRepository.AddAsync(mappedProgrammingTechnology);

                ProgrammingTechnology? addedProgrammingTechnology =
                    await _programmingTechnologyRepository.GetAsync(
                    predicate: p => p.Id == programmingTechnology.Id
                    && p.ProgrammingTechnologyTypeId == programmingTechnology.ProgrammingTechnologyTypeId
                    && p.ProgrammingLanguageId == programmingTechnology.ProgrammingLanguageId,
                    include: p => p.Include(m => m.ProgrammingLanguage).Include(c => c.ProgrammingLanguage));

                CreatedProgrammingTechnologyDto createdProgrammingTechnologyDto = _mapper.Map<CreatedProgrammingTechnologyDto>(addedProgrammingTechnology);
                return createdProgrammingTechnologyDto;
            }
        }
    }
}
