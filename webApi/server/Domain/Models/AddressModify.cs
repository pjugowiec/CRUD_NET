using System;
using System.ComponentModel.DataAnnotations;

namespace server.Domain.Models
{
    [Serializable]
    public class AddressModify
    {
        public long Id { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public string City { get; set; }

        public AddressModify()
        {
        }
    }
}
