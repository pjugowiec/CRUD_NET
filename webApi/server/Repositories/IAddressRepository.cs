using System;
using server.Domain.Models;
using webApi.Domain.Entities;

namespace server.Repositories
{
    public interface IAddressRepository
    {
        AddressEntity findByDto(AddressModify address);
    }
}
