using bigSchool2.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace bigSchool2.Controllers
{
    public class AttendancesController : ApiController
    {
        private DataBase db = new DataBase();
        [HttpPost]
        public IHttpActionResult Attend(Course attendanceDto)
        {
            var userID = User.Identity.GetUserId();
            
            if (db.Attendances.Any(p => p.Attendee == userID && p.CourseId ==
           attendanceDto.Id))
            {
                // return BadRequest("The attendance already exists!");
                // xóa thông tin khóa học đã đăng ký tham gia trong bảng Attendances
                db.Attendances.Remove(db.Attendances.SingleOrDefault(p =>
               p.Attendee == userID && p.CourseId == attendanceDto.Id));
                db.SaveChanges();
                return Ok("cancel");
            }
            var attendance = new Attendance()
            {
                CourseId= attendanceDto.Id,
                Attendee =
           User.Identity.GetUserId()
            };
            db.Attendances.Add(attendance);
            db.SaveChanges();
            return Ok();
        }
    }
}
