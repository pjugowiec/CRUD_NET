using System;
using server.Domain.Models;
using webApi.Domain.Entities;

namespace server.Services
{
    public interface IAddressService
    {

        // <summary>Get an object by the DTO, the method is to check
        // whether an identical object does not exist in the database</summary>
        // <param name="address">Object representing the data model for
        // create/update the address</param>
        public AddressEntity GetAddressEntityByDto(AddressModify address);
    }
}
