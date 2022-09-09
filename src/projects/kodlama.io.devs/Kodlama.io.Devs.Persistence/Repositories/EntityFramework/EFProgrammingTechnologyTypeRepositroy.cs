using Core.Persistence.Repositories;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Context;

namespace Kodlama.io.Devs.Persistence.Repositories.EntityFramework
{
    public class EFProgrammingTechnologyTypeRepositroy : EfRepositoryBase<ProgrammingTechnologyType, BaseDbContext>, IProgrammingTechnologyTypeRepository
    {
        public EFProgrammingTechnologyTypeRepositroy(BaseDbContext context) : base(context)
        {
        }
    }
}
