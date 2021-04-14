using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace server.Domain.Models
{
    [Serializable]
    public class EmployeeCreate
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public DateTime DateBirth { get; set; }

        [Required]
        public UserCreate user { get; set; }

        [Required]
        public AddressCreate address { get; set; }

        [Required]
        public List<long> projectsIds { get; set; }
    }
}
