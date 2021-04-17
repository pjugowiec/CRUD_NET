using System;
using server.Domain.Models;
using webApi.Domain.Entities;

namespace server.Mappers.Impl
{
    public class AddressMapper : IAddressMapper
    {
        public AddressMapper()
        {
        }

        public AddressEntity AddressModifyToAddressEntity(AddressModify address)
        {
            return new AddressEntity()
            {
                City = address.City,
                Number = address.Number,
                Street = address.Street
            };
        }
    }
}
