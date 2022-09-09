using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Commands.CreateProgrammingTechnologyType
{
    public class CreateProgrammingTechnologyTypeCommand : IRequest<CreatedProgrammingTechnologyTypeDto>
    {
        public string Name { get; set; }

        public class CreateProgrammingTechnologyTypeCommandHandler : IRequestHandler<CreateProgrammingTechnologyTypeCommand, CreatedProgrammingTechnologyTypeDto>
        {
            private readonly IProgrammingTechnologyTypeRepository _programmingTechnologyTypeRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyTypeBusinessRules _programmingTechnologyTypeBusinessRules;

            public CreateProgrammingTechnologyTypeCommandHandler(IProgrammingTechnologyTypeRepository programmingTechnologyTypeRepository, IMapper mapper, ProgrammingTechnologyTypeBusinessRules programmingTechnologyTypeBusinessRules)
            {
                _programmingTechnologyTypeRepository = programmingTechnologyTypeRepository;
                _mapper = mapper;
                _programmingTechnologyTypeBusinessRules = programmingTechnologyTypeBusinessRules;
            }

            public async Task<CreatedProgrammingTechnologyTypeDto> Handle(CreateProgrammingTechnologyTypeCommand request, CancellationToken cancellationToken)
            {
                await _programmingTechnologyTypeBusinessRules.ProgrammingTechnologyTypeNameCanNotBeDuplicatedWhenInserted(request.Name);

                ProgrammingTechnologyType mappedProgrammingTechnologyType = _mapper.Map<ProgrammingTechnologyType>(request);
                ProgrammingTechnologyType programmingTechnologyType = await _programmingTechnologyTypeRepository.AddAsync(mappedProgrammingTechnologyType);

                CreatedProgrammingTechnologyTypeDto createdProgrammingTechnologyTypeDto = _mapper.Map<CreatedProgrammingTechnologyTypeDto>(programmingTechnologyType);
                return createdProgrammingTechnologyTypeDto;
            }
        }
    }
}
