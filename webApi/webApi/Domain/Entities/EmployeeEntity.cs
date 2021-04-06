﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApi.Domain.Entities
{
    [Table("employees")]
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
        public DateTime DateBirth { get; set; }

        // Relation with User OneToOne
        [ForeignKey("user_id")]
        public UserEntity UserEntity { get; set; }

        // Relation with Address OneToMany
        [ForeignKey("address_id")]
        public AddressEntity AddressEntity { get; set; }

        //Relation with Department OneToMany
        [ForeignKey("department_id")]
        public DepartmentEntity DepartmentEntity { get; set; }

        //Realtion with Project ManyToMany
        public List<EmployeeProjectEntity> EmployeeProjects { get; set; }

        public EmployeeEntity()
        {

        }

    }
}