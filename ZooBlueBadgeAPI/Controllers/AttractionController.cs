using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using ZooBlue.Data;
using ZooBlue.Services;

namespace ZooBlueBadgeAPI.Controllers
{
    [Authorize]
    [RoutePrefix("api/Attraction")]
    public class AttractionController : ApiController
    {
        private IHttpActionResult CreateAttractionService()
        {
            var zooId = int.Parse(Zoo.Identity.GetZooId());
            var attractionService = new AttractionService(zooId);
            return attractionService;
        }

        private AttractionService GetAttraction(int id)
        {
            AttractionService attractionService = CreateAttractionService();
            var attractions = attractionService.GetAttractionByZoo(id);
            return Ok(attractions);
        }
    }
}