using Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class RatingServices : IRatingServices
    {
        private IRatingRepositories ratingRepository;

        public RatingServices(IRatingRepositories _ratingRepository)
        {
            ratingRepository = _ratingRepository;
        }

        public async Task<Rating> AddRatingAsync(Rating rating)
        {
            return await ratingRepository.AddRatingAsync(rating);
        }
    }
}
