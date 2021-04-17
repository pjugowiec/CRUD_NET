using System;
using server.Domain.Models;
using server.Utils;
using webApi.Domain.Entities;

namespace server.Mappers.Impl
{
    public class UserMapper : IUserMapper
    {
        public UserMapper()
        {
        }

        public UserEntity UserModifyToUserEntity(UserModify user)
        {
            return new UserEntity()
            {
                Login = user.Login,
                Password = CommonUtils.EncodePasswordToBase64(user.Password),
                Email = user.Email,
                IsActive = true
            };
        }

        public UserEntity UpdateUserEntityByUserModify(UserModify user, UserEntity userEntity)
        {
            if(user.Password != null)
            {
                userEntity.Password = CheckPasswordsSame(user.Password, userEntity.Password)
                ? userEntity.Password
                : CommonUtils.EncodePasswordToBase64(user.Password);
            }
            userEntity.Login = user.Login == userEntity.Login ? userEntity.Login : user.Login;
            userEntity.Email = user.Email == userEntity.Email ? userEntity.Email : user.Email;
            return userEntity;
        }

        private bool CheckPasswordsSame(string newPassword, string oldPassword)
        {
            string decodedPassword = CommonUtils.DecodeFrom64(oldPassword);

            return decodedPassword == newPassword;
        }
    }
}
