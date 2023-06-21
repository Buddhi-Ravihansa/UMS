namespace UMS.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}
