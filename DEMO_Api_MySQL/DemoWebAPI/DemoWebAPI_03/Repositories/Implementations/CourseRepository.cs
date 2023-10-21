using DemoWebAPI_03.Models;
using DemoWebAPI_03.DTO;
using DemoWebAPI_03.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DemoWebAPI_03.Repositories.Implementations
{
    public class CourseRepository : ICourseRepository
    {
        private readonly f8dbContext db;

        public CourseRepository(f8dbContext db)
        {
            this.db = db;
        }

        public IEnumerable<CourseDTO> GetAll()
        {
            var courses = db.Courses.Select(c => new CourseDTO
            {
                CourseId = c.CourseId,
                CourseName = c.CourseName,
                Description = c.Description,
                CourseInfo = c.CourseInfo,
                Image = c.Image,
                VideoIntro = c.VideoIntro,
                Fee = c.Fee,
                Status = c.Status,
                CategoryCategoryId = c.CategoryCategoryId,
                UserUserId = c.UserUserId
            }).ToList();

            return courses;
        }
    }
}