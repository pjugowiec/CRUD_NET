using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace webApi.Domain.Entities
{
    [Table("addresses")]
    public class AddressEntity
    {

        [Column("id")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int AddressId { get; set; }

        [Column("street")]
        [Required]
        [StringLength(100)]
        public string Street { get; set; }

        [Column("number")]
        [Required]
        public int Number { get; set; }

        [Column("city")]
        [Required]
        [StringLength(50)]
        public string City { get; set; }

        // Relation with Employee
        public List<EmployeeEntity> EmployeeEntities { get; set; }

        public AddressEntity()
        {
        }
    }
}
