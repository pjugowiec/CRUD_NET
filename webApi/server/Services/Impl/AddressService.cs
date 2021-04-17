using System;
using server.Domain.Models;
using server.Mappers;
using server.Repositories;
using webApi.Domain.Entities;

namespace server.Services.Impl
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _addressRepo;
        private readonly IAddressMapper _addressMapper;

        public AddressService(IAddressRepository addressRepo, IAddressMapper addressMapper)
        {
            _addressRepo = addressRepo;
            _addressMapper = addressMapper;
        }


        public AddressEntity GetAddressEntityByDto(AddressModify address)
        {
            AddressEntity addressEntity = _addressRepo.findByDto(address);

            return addressEntity == null ? _addressMapper.AddressModifyToAddressEntity(address) : addressEntity;
        }
    }
}
