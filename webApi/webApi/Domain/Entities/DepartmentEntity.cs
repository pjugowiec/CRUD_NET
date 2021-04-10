using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace webApi.Domain.Entities
{
    [Table("departments")]
    public class DepartmentEntity : BaseEntity
    {

        [Column("name")]
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Column("short_name")]
        [Required]
        [StringLength(10)]
        public string ShortName { get; set; }

        // Relation with Employee
        public List<EmployeeEntity> EmployeeEntities { get; set; }

        // Relation with Projects
        public List<ProjectEntity> ProjectEntities { get; set; }

        public DepartmentEntity()
        {
        }
    }
}
