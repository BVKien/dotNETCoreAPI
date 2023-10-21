using DemoWebAPI_03.DTO;
using System.Collections.Generic;

namespace DemoWebAPI_03.Repositories.Interfaces
{
    public interface ICourseRepository
    {
        IEnumerable<CourseDTO> GetAll();
    }
}