using DemoWebAPI_03.Models;
using DemoWebAPI_03.DTO;
using DemoWebAPI_03.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebAPI_03.Repositories.Implementations
{
    public class CourseRepository : ICourseRepository
    {
        private readonly f8dbContext db;
        public CourseRepository(f8dbContext db)
        {
            this.db = db;
        }

        // get all courses
        public IEnumerable<CourseDTO> GetAllCourses()
        {
            // linq den model moi
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

        // get course by id
        public CourseDTO GetCourseById(int id)
        {
            var course = db.Courses.FirstOrDefault(c => c.CourseId == id);
            if (course != null)
            {
                return new CourseDTO
                {
                    CourseId = course.CourseId,
                    CourseName = course.CourseName,
                    Description = course.Description,
                    CourseInfo = course.CourseInfo,
                    Image = course.Image,
                    VideoIntro = course.VideoIntro,
                    Fee = course.Fee,
                    Status = course.Status,
                    CategoryCategoryId = course.CategoryCategoryId,
                    UserUserId = course.UserUserId
                };
            }
            else
            {
                return null;
            }
        }

        // insert course
        public void InsertCourse(CourseDTO courseDTO)
        {
            // khoi tao 1 course dto moi
            var course = new Course
            {
                CourseName = courseDTO.CourseName,
                Description = courseDTO.Description,
                CourseInfo = courseDTO.CourseInfo,
                Image = courseDTO.Image,
                VideoIntro = courseDTO.VideoIntro,
                Fee = courseDTO.Fee,
                Status = courseDTO.Status,
                CategoryCategoryId = courseDTO.CategoryCategoryId,
                UserUserId = courseDTO.UserUserId
            };

            db.Courses.Add(course);
            db.SaveChanges();
        }

        // update course
        public void UpdateCourse(CourseDTO courseDTO)
        {
            // tim course theo find id
            var course = db.Courses.FirstOrDefault(c=>c.CourseId == courseDTO.CourseId);
            // check != null -> update
            if(course != null)
            {
                course.CourseName = courseDTO.CourseName;
                course.Description = courseDTO.Description;
                course.CourseInfo = courseDTO.CourseInfo;
                course.Image = courseDTO.Image;
                course.VideoIntro = courseDTO.VideoIntro;
                course.Fee = courseDTO.Fee;
                course.Status = courseDTO.Status;
                course.CategoryCategoryId = courseDTO.CategoryCategoryId;
                course.UserUserId = courseDTO.UserUserId;

                db.SaveChanges();
            }
        }

        // delete course 
        public void DeleteCourse(int CourseId) 
        {
            // find course have id
            var course = db.Courses.FirstOrDefault(c => c.CourseId == CourseId);
            // check null -> remove
            if(course != null)
            {
                db.Courses.Remove(course);
                db.SaveChanges() ;
            }
        }

    }
}