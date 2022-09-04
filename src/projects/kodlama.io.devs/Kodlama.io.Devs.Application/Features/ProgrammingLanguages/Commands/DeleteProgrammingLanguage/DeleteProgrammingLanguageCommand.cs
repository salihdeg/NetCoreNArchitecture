using AutoMapper;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Rules;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kodlama.io.Devs.Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommand : IRequest<DeletedProgrammingLanguageDto>
    {
        public int Id { get; set; }

        public class DeleteProgrammingLangueageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeletedProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public DeleteProgrammingLangueageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<DeletedProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                await _programmingLanguageBusinessRules.ProgrammingLanguageShouldBeExist(request.Id);

                ProgrammingLanguage programmingLanguage = await _programmingLanguageRepository.GetAsync(r => r.Id == request.Id);
                ProgrammingLanguage deletedProgrammingLanguage = await _programmingLanguageRepository.DeleteAsync(programmingLanguage);

                DeletedProgrammingLanguageDto deletedProgrammingLanguageDto = _mapper.Map<DeletedProgrammingLanguageDto>(deletedProgrammingLanguage);

                return deletedProgrammingLanguageDto;
            }
        }
    }
}
