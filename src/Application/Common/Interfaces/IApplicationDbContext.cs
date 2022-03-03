
using Anagrama.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Anagrama.Api.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Word> Words { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
