using System;
using server.Domain.Models;
using webApi.Domain.Entities;

namespace server.Services
{
    public interface IAddressService
    {

        public AddressEntity GetAddressEntityByDto(AddressCreate address);
    }
}
