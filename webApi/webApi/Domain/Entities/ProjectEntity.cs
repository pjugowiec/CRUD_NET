using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace webApi.Domain.Entities
{
    [Table("projects")]
    public class ProjectEntity
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int ProjectId { get; set; }

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

        [ForeignKey("department_id")]
        public DepartmentEntity DepartmentEntity { get; set; }

        //Realtion with Employee ManyToMany
        public List<EmployeeProjectEntity> EmployeeProjects { get; set; }

        public ProjectEntity()
        {
        }
    }
}
