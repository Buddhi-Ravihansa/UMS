using System.Collections.Generic;
namespace UMS.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Department> Departments { get; set; }
    }
}