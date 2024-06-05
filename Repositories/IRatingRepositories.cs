using Entities;

namespace Repositories
{
    public interface IRatingRepositories
    {
        Task<Rating> AddRatingAsync(Rating rating);
    }
}