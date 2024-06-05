using Entities;

namespace Services
{
    public interface IRatingServices
    {
        Task<Rating> AddRatingAsync(Rating rating);
    }
}