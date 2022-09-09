using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;

namespace Kodlama.io.Devs.Application.Features.ProgrammingTechnologyTypes.Commands.DeleteProgrammingTechnologyType
{
    public class DeleteProgrammingTechnologyTypeCommand : IRequest<DeletedProgrammingTechnologyTypeDto>
    {
        public int Id { get; set; }
        public class DeleteProgrammingTechnologyTypeCommandHandler : IRequestHandler<DeleteProgrammingTechnologyTypeCommand, DeletedProgrammingTechnologyTypeDto>
        {
            private readonly IProgrammingTechnologyTypeRepository _programmingTechnologyTypeRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingTechnologyTypeBusinessRules _programmingTechnologyTypeBusinessRules;

            public DeleteProgrammingTechnologyTypeCommandHandler(IProgrammingTechnologyTypeRepository programmingTechnologyTypeRepository, IMapper mapper, ProgrammingTechnologyTypeBusinessRules programmingTechnologyTypeBusinessRules)
            {
                _programmingTechnologyTypeRepository = programmingTechnologyTypeRepository;
                _mapper = mapper;
                _programmingTechnologyTypeBusinessRules = programmingTechnologyTypeBusinessRules;
            }

            public async Task<DeletedProgrammingTechnologyTypeDto> Handle(DeleteProgrammingTechnologyTypeCommand request, CancellationToken cancellationToken)
            {
                await _programmingTechnologyTypeBusinessRules.ProgrammingTechnologyTypeMustBeExist(request.Id);

                ProgrammingTechnologyType programmingTechnologyType = await _programmingTechnologyTypeRepository.GetAsync(p => p.Id == request.Id);
                DeletedProgrammingTechnologyTypeDto deletedProgrammingTechnologyTypeDto = _mapper.Map<DeletedProgrammingTechnologyTypeDto>(programmingTechnologyType);
                return deletedProgrammingTechnologyTypeDto;
            }
        }
    }
}
