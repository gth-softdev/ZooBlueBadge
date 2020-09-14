using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using ZooBlue.Data;
using ZooBlue.Models;
using ZooBlue.Models.ReviewModels;

namespace ZooBlue.Services
{
    public class ReviewService
    {
        private readonly ApplicationDbContext _context = new ApplicationDbContext();
        private readonly Guid _userId;
        public ReviewService() { }
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
        public ReviewDetail GetReviewById(int id)
        {
            var entity = _context.Reviews.Find(id);
            if (entity == null)
                return null;
                var detail = new ReviewDetail
                {
                    ReviewId = entity.ReviewId,
                    Rating = entity.Rating,
                    ReviewText = entity.ReviewText,
                    VisitDate = entity.VisitDate,
                    ZooId = entity.ZooId,
                    //CreatedUtc = entity.CreatedUtc,
                    //ModifiedUtc = entity.ModifiedUtc
                };
                return detail;
           
        }
        public bool ReviewEdit(ReviewEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Reviews
                        .Single(e => e.ReviewId == model.ReviewId);

                if (model.ReviewText != null && model.ReviewText != entity.ReviewText)
                {
                    entity.ReviewText = model.ReviewText;
                }
                if (model.Rating != entity.Rating)
                {
                    entity.Rating = model.Rating;
                }
                if (model.IsRecommended != entity.IsRecommended)
                {
                    entity.IsRecommended = model.IsRecommended;
                }
                //entity.Content = model.Content;

                if (ctx.ChangeTracker.HasChanges())
                {
                    return ctx.SaveChanges() == 1;

                }
                return true;
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

