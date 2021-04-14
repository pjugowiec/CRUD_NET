using System;
namespace server.Domain.Models
{
    [Serializable]
    public class Employee
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }
        public bool IsActive { get; set; }
        public int CountOfProjects { get; set; }

        public Employee()
        {
        }
    }
}
