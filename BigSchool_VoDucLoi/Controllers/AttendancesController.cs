using BigSchool_VoDucLoi.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BigSchool_VoDucLoi.DTOs;

namespace BigSchool_VoDucLoi.Controllers
{   
    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _dbContext;
        public AttendancesController()
        {
            _dbContext = new ApplicationDbContext();
        }

        [HttpPost]
        //public IHttpActionResult Attend([FromBody] int courseId)
        //{
        //    var UserId = User.Identity.GetUserId();
        //    if (_dbContext.Attendances.Any(a => a.AttendeeId == UserId && a.CourseId == courseId)) 
        //        return BadRequest(" The Attendance already exitss!");
        //    var attendances = new Attendance
        //    {
        //        CourseId = courseId,
        //        AttendeeId = UserId
        //    };

        //    _dbContext.Attendances.Add(attendances);
        //    _dbContext.SaveChanges();

        //    return Ok();
        //}
        public IHttpActionResult Attend(AttendanceDto attendanceDto)
        {
            var UserId = User.Identity.GetUserId();
            if (_dbContext.Attendances.Any(a => a.AttendeeId == UserId && a.CourseId == attendanceDto.CourseId))
                return BadRequest(" The Attendance already exitss!");
            var attendances = new Attendance
            {
                CourseId = attendanceDto.CourseId,
                AttendeeId = UserId
            };

            _dbContext.Attendances.Add(attendances);
            _dbContext.SaveChanges();

            return Ok();
        }
    }
}
