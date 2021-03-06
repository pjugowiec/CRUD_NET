using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace webApi.Domain.Entities
{
    [Table("projects")]
    public class ProjectEntity : BaseEntity
    {

        [Column("name")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column("end_date")]
        public DateTime EndDate { get; set; }

        [Column("start_date")]
        [Required]
        public DateTime StartDate { get; set; }

        [Column("budget")]
        [Required]
        public long Budget { get; set; }

        //Realtion with Employee ManyToMany
        public List<EmployeeProjectEntity> EmployeeProjects { get; set; }

        public ProjectEntity()
        {
        }
    }
}
