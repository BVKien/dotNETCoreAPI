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

using Api_03.Models;
using System.Collections.Generic;
using System.Linq;

namespace Api_03.Repositories
{
    public class CourseRepository
    {
        private readonly ApiDB_03Context db;

        public CourseRepository(ApiDB_03Context db)
        {
            this.db = db;
        }

        public IEnumerable<Course> GetCourses()
        {
            return db.Courses.ToList();
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

    }
}