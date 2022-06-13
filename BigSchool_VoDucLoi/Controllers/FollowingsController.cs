using BigSchool_VoDucLoi.DTOs;
using BigSchool_VoDucLoi.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;


namespace BigSchool_VoDucLoi.Controllers
{
    public class FollowingsController : ApiController
    {
        private readonly ApplicationDbContext _dbContext;
     
        public FollowingsController()
        {
            _dbContext = new ApplicationDbContext();
        }


        [System.Web.Http.HttpPost]
        public IHttpActionResult Follow(FollowingDto followingDto)
        {
            var userId = User.Identity.GetUserId();
            if (_dbContext.Followings.Any(f => f.FollowerId == userId && f.FolloweerId == followingDto.FolloweeId))
                return BadRequest("Follwing already exits!");

            var folowing = new Following
            {
                FollowerId = userId,
                FolloweerId = followingDto.FolloweeId
            };
            _dbContext.Followings.Add(folowing);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
