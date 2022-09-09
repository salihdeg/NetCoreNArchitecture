using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Commands.UpdateProgrammingTechnologyType
{
    public class UpdateProgrammingTechnologyTypeCommand : IRequest<UpdatedProgrammingTechnologyTypeDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class UpdateProgrammingTechnologyTypeCommandHandler : IRequestHandler<UpdateProgrammingTechnologyTypeCommand, UpdatedProgrammingTechnologyTypeDto>
        {
            private readonly IProgrammingTechnologyTypeRepository _programmingTechnologyTypeRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyTypeBusinessRules _programmingTechnologyTypeBusinessRules;

            public UpdateProgrammingTechnologyTypeCommandHandler(IProgrammingTechnologyTypeRepository programmingTechnologyTypeRepository, IMapper mapper, ProgrammingTechnologyTypeBusinessRules programmingTechnologyTypeBusinessRules)
            {
                _programmingTechnologyTypeRepository = programmingTechnologyTypeRepository;
                _mapper = mapper;
                _programmingTechnologyTypeBusinessRules = programmingTechnologyTypeBusinessRules;
            }

            public async Task<UpdatedProgrammingTechnologyTypeDto> Handle(UpdateProgrammingTechnologyTypeCommand request, CancellationToken cancellationToken)
            {
                await _programmingTechnologyTypeBusinessRules.ProgrammingTechnologyTypeNameCanNotBeDuplicatedWhenInserted(request.Name);
                await _programmingTechnologyTypeBusinessRules.ProgrammingTechnologyTypeMustBeExist(request.Id);

                ProgrammingTechnologyType programmingTechnologyType = _mapper.Map<ProgrammingTechnologyType>(request);
                ProgrammingTechnologyType updatedProgrammingTechnology = await _programmingTechnologyTypeRepository.UpdateAsync(programmingTechnologyType);

                UpdatedProgrammingTechnologyTypeDto updatedProgrammingTechnologyTypeDto = _mapper.Map<UpdatedProgrammingTechnologyTypeDto>(updatedProgrammingTechnology);
                return updatedProgrammingTechnologyTypeDto;
            }
        }
    }
}
