using UMS.Models;

namespace UMS.Dtos
{
    public class UserReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public string Role { get; set; }

    }
}