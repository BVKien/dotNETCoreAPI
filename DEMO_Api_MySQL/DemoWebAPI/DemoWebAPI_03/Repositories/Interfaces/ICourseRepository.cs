using DemoWebAPI_03.DTO;
using System.Collections.Generic;

namespace DemoWebAPI_03.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        IEnumerable<CourseDTO> GetAllCourses();
        CourseDTO GetCourseById(int id);
        void InsertCourse(CourseDTO courseDTO);
        void UpdateCourse(CourseDTO courseDTO);
        void DeleteCourse(int CourseId);
    }
}