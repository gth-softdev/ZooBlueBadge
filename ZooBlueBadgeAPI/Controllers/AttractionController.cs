using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ZooBlue.Data;
using ZooBlue.Models;
using ZooBlue.Models.AttractionModels;
using ZooBlue.Services;

namespace ZooBlueBadgeAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Attraction")]
    public class AttractionController : ApiController
    {

        private AttractionService CreateAttractionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId()); 
            var attractionService = new AttractionService(userId);
            return attractionService;
        }
        [HttpPost]
        public IHttpActionResult Post(AttractionCreate attraction)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAttractionService();

            if (!service.CreateAttraction(attraction))
                return InternalServerError();

            return Ok();
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            AttractionService attService = CreateAttractionService();
            var note = attService.GetAttractions();
            return Ok(note);
        }
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            AttractionService attService = CreateAttractionService();
            var note = attService.GetAttractionById(id);
            return Ok(note);
        }
        [HttpPut]
        public IHttpActionResult Put (AttractionEdit attraction)
        {
            if (attraction == null)
                return BadRequest("Received model was null.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateAttractionService();

            if (!service.UpdateAttraction(attraction))
                return InternalServerError();

            return Ok();
        }
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var service = CreateAttractionService();

            if (!service.DeleteAttraction(id))
                return InternalServerError();

            return Ok();
        }

    }
}