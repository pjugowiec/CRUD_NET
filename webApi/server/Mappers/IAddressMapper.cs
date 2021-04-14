using System;
using server.Domain.Models;
using webApi.Domain.Entities;

namespace server.Mappers
{
    public interface IAddressMapper
    {
        public AddressEntity AddressCreateToAddressEntity(AddressCreate address);
    }
}
