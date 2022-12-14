using Core.Persistence.Repositories;
using Core.Security.Entities;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Persistence.Context;

namespace Kodlama.io.Devs.Persistence.Repositories.EntityFramework
{
    public class EFOperationClaimRepository : EfRepositoryBase<OperationClaim, BaseDbContext>, IOperationClaimRepository
    {
        public EFOperationClaimRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
