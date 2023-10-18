using Api_03.Models;
namespace Api_03.DTO
{
    public class CourseDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int? Category { get; set; }
        //public string? CategoryName { get; set; } // Thêm trường để lưu tên của category
    }
}
