using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApi.Domain.Entities
{
    [Table("Employees")]
    public class EmployeeEntity
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int EmployeeId { get; set; }

        [Column("name")]
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column("surname")]
        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Column("birth_date")]
        [Required]
        [StringLength(50)]
        public DateTime DateBirth { get; set; }

        public int UserId { get; set; }

        public UserEntity User { get; set; }

        public EmployeeEntity()
        {

        }

    }
}
