using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApi.Domain.Entities
{
    [Table("employees_projects")]
    public class EmployeeProjectEntity 
    {
        public long EmployeeId { get; set; }
        public EmployeeEntity EmployeeEntity { get; set; }

        public long ProjectId { get; set; }
        public ProjectEntity ProjectEntity { get; set; }

        public EmployeeProjectEntity()
        {
        }
    }
}
