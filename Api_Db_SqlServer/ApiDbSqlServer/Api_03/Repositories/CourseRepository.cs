/*
using Api_03.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_03.Repositories
{
    public class CourseRepository
    {
        public readonly ApiDB_03Context db;
        public CourseRepository(ApiDB_03Context db)
        {
            this.db = db;
        }

        public IEnumerable<Course> GetCourses()
        {
            return db.Courses.ToList();
        }
    }
}
*/

using Api_03.DTO;
using Api_03.Models;
using System.Collections.Generic;
using System.Linq;

namespace Api_03.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly ApiDB_03Context db;

        public CourseRepository(ApiDB_03Context db)
        {
            this.db = db;
        }

        /*
        public IEnumerable<Course> GetCourses()
        {
            return db.Courses.ToList();
        }
        */

        public IEnumerable<CourseDTO> GetCourses()
        {
            var courseDtos = db.Courses
                .Join(
                    db.Categories,
                    course => course.Category,
                    category => category.Id,
                    (course, category) => new CourseDTO
                    {
                        Id = course.Id,
                        Name = course.Name,
                        Category = course.Category,
                        //CategoryName = category.Name
                    })
                .ToList();

            return courseDtos;
        }

        public Course GetCourseById(int id)
        {
            return db.Courses.FirstOrDefault(course => course.Id == id);
        }

        public void AddCourse(Course course)
        {
            db.Courses.Add(course);
            db.SaveChanges();
        }

        public void DeleteCourse(Course course)
        {
            db.Courses.Remove(course);
            db.SaveChanges();
        }

        /*
        public void UpdateCourse(Course course)
        {
            var existingCourse = db.Courses.FirstOrDefault(c => c.Id == course.Id);

            if (existingCourse != null)
            {
                // Cập nhật thông tin của khóa học
                existingCourse.Id = course.Id;
                existingCourse.Name = course.Name;
                existingCourse.Category = course.Category;

                db.SaveChanges();
            }
        }
        */

        public void UpdateCourse(Course updatedCourse)
        {
            var existingCourse = db.Courses.FirstOrDefault(c => c.Id == updatedCourse.Id);

            if (existingCourse != null)
            {
                // Cập nhật thông tin của khóa học
                existingCourse.Id = updatedCourse.Id;
                existingCourse.Name = updatedCourse.Name;
                existingCourse.Category = updatedCourse.Category;

                db.SaveChanges();
            }
        }

    }
}