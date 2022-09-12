using Core.Persistence.Repositories;
using Kodlama.io.Devs.Application.Services.Repositories;
using Kodlama.io.Devs.Domain.Entities;
using Kodlama.io.Devs.Persistence.Context;

namespace Kodlama.io.Devs.Persistence.Repositories.EntityFramework
{
    public class EFUserProfileSocialAccountRepository : EfRepositoryBase<UserProfileSocialAccount, BaseDbContext>, IUserProfileSocialAccountRepository
    {
        public EFUserProfileSocialAccountRepository(BaseDbContext context) : base(context)
        {
        }
    }
}
