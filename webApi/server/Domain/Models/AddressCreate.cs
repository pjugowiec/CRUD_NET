using System;
using System.ComponentModel.DataAnnotations;

namespace server.Domain.Models
{
    [Serializable]
    public class AddressCreate
    {
        [Required]
        public string Street { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public string City { get; set; }

        public AddressCreate()
        {
        }
    }
}
