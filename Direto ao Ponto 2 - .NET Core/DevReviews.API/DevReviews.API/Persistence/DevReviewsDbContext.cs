using DevReviews.API.Entities;
using System.Collections.Generic;

namespace DevReviews.API.Persistence
{
    public class DevReviewsDbContext
    {
        public DevReviewsDbContext()
        {
            Products = new List<Product>();
        }
        public List<Product> Products { get; set; }
    }
}