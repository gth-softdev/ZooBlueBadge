﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ZooBlue.Models.ZooModels;
using ZooBlue.Services;

namespace ZooBlueBadgeAPI.Controllers
{
    [Authorize]
    // Method that creates the Zoo Service
    public class ZooController : ApiController
    {
        private ZooServices CreateZooService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var zooService = new ZooServices(userId);
            return zooService;
        }

        //Create/Post Zoo method
        public IHttpActionResult Post(ZooCreate zoo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateZooService();

            if (!service.CreateZoo(zoo))
                return InternalServerError();

            return Ok();
        }

        //Read/Get all zoos method
        public IHttpActionResult Get()
        {
            ZooServices zooService = CreateZooService();
            var zoos = zooService.GetZoos();
            return Ok(zoos);
        }

       //Update/Edit method 
    }
}
