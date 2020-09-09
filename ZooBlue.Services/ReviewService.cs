using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZooBlue.Data;
using ZooBlue.Models;
using ZooBlue.Models.ReviewModels;

namespace ZooBlue.Services
{
    public class ReviewService

    {
        private readonly Guid _userId;
        public ReviewService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateReview(ReviewCreate model)
        {
            var entity =
                new Review()
                {

                    ReviewId = model.ReviewId,
                    Rating = model.Rating,
                    ReviewText = model.ReviewText,
                    VisitDate = model.VisitDate,
                    ZooId = model.ZooId,
                    IsRecommended = model.IsRecommended,
                };
            using (var ctx = new ApplicationDbContext())
            {
                //entity.Author = ctx.Users.Where(e => e.Id == _userId).First();
                ctx.Reviews.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
        public IEnumerable<ReviewListItem> GetReviews()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Reviews
                        //.Where(e => e.Author == _userId)
                        .Select(
                            e =>
                                new ReviewListItem
                                {
                                    ReviewId = e.ReviewId,
                                    ReviewText = e.ReviewText,
                                    VisitDate = e.VisitDate
                                }
                        );
                return query.ToArray();
            }
        }
        public Review GetReviewById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewId == id);
                return
                    new Review
                    {
                        ReviewId = entity.ReviewId,
                        Rating = entity.Rating,
                        ReviewText = entity.ReviewText,
                        VisitDate = entity.VisitDate,
                        ZooId = entity.ZooId,
                        //CreatedUtc = entity.CreatedUtc,
                        //ModifiedUtc = entity.ModifiedUtc
                    };
            }
        }
        public bool ReviewEdit(ReviewEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewId == model.ReviewId);

                entity.ReviewText = model.ReviewText;
                entity.IsRecommended = model.IsRecommended;
                entity.Rating = model.Rating;
                //entity.Content = model.Content;

                return ctx.SaveChanges() == 1;
            }
        }
        public bool DeleteReview(int reviewId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewId == reviewId);

                ctx.Reviews.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

