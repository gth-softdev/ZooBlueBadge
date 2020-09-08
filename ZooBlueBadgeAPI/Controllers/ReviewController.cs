using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZooBlue.Data;
using ZooBlue.Models;
using ZooBlue.Models.ReviewModels;
using ZooBlue.Services;

namespace ZooBlueBadgeAPI.Controllers
{
    [Authorize]
    public class ReviewController : ApiController
    {
        public IHttpActionResult Get()
        {
            ReviewService reviewService = CreateReviewService();
            var reviews = reviewService.GetReviews();
            return Ok(reviews);
        }
        public IHttpActionResult Post(ReviewCreate review)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReviewService();

            if (!service.CreateReview(review))
                return InternalServerError();

            return Ok();
        }
        private ReviewService CreateReviewService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var postService = new ReviewService(userId);
            return postService;
        }
        public IHttpActionResult Get(int id)
        {
            ReviewService postService = CreateReviewService();
            var note = postService.GetReviewById(id);
            return Ok(note);
        }

        public IHttpActionResult Put(ReviewEdit review)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateReviewService();

            if (!service.ReviewEdit(review))
                return InternalServerError();

            return Ok();
        }

        public IHttpActionResult Delete(int id)
        {
            var service = CreateReviewService();

            if (!service.DeleteReview(id))
                return InternalServerError();

            return Ok();
        }
    }
}
