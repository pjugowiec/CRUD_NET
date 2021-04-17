using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace server.Domain.Models
{
    [Serializable]
    public class EmployeeModify
    {
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public DateTime DateBirth { get; set; }

        [Required]
        public UserModify User { get; set; }

        [Required]
        public AddressModify Address { get; set; }
    }
}
