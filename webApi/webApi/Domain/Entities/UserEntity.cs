using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace webApi.Domain.Entities
{
    [Table("_adm_users")]
    public class UserEntity
    {
        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int UserId { get; set; }

        [Column("login")]
        [Required]
        [StringLength(50)]
        public string Login { get; set; }

        [Column("password")]
        [Required]
        [StringLength(50)]
        public string Password { get; set; }

        [Column("email")]
        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Column("is_active")]
        [Required]
        public bool isActive { get; set; }

        public EmployeeEntity Employee { get; set; }

        public UserEntity()
        {
        }
    }
}
