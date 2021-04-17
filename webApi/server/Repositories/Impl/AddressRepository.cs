using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using server.Domain.Models;
using webApi;
using webApi.Domain.Entities;

namespace server.Repositories.Impl
{
    public class AddressRepository : IAddressRepository
    {
        private DbSet<AddressEntity> _entities;

        public AddressRepository(AppDbContext context)
        {
            _entities = context.Set<AddressEntity>();
        }

        public AddressEntity findByDto(AddressModify address)
        {
            AddressEntity addressEntity = _entities.FirstOrDefault(addEnt =>
            addEnt.City == address.City &&
            addEnt.Number == address.Number &&
            addEnt.Street == address.Street
            );

            return addressEntity;
        }
    }
}
