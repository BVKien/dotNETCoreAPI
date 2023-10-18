using Api_03.DTO;
using Api_03.Models;

namespace Api_03.Repositories
{
    public interface ICourseRepository
    {
        IEnumerable<CourseDTO> GetCourses();
        Course GetCourseById(int id);
        void AddCourse(Course course);
        void DeleteCourse(Course course);
        void UpdateCourse(Course updatedCourse);
    }
}
