using AutoMapper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Model.Contract.Dto;
using Model.Contract.Interfaces.Business;
using ModelContract;
using ModelContract.Entities;
using ModelRepository;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Business
{
    public class UserFacade : IUserFacade
    {
        private MainApiDbContextInstance _dbInstanceProperties;
        private const int _saltPwdSize = 1 << 3;
        private IMapper _mapper;

        public UserFacade(IMapper mapper, MainApiDbContextInstance dbInstanceProperties)
        {
            _dbInstanceProperties = dbInstanceProperties;
            _mapper = mapper;
        }

        public async Task<UserDto> GetByEmail(string email)
        {
            using (var uow = new UnitOfWork(_dbInstanceProperties))
            {
                var searchResult = (await uow.GetRepository<User>()
                                        .Search(f => f.Email == email))
                                        .SingleOrDefault();

                var userDto = _mapper.Map<UserDto>(searchResult);

                return userDto;
            }
        }

        public async Task<bool> RegisterNewUser(UserSignUpDto userDto)
        {
            var userEntity = _mapper.Map<User>(userDto);
            
            if (userEntity != null)
            {
                EncryptPasswordForUser(userEntity);

                using (var uow = new UnitOfWork(_dbInstanceProperties))
                {
                    var successCreation = await uow.GetRepository<User>().Create(userEntity);
                    await uow.SaveChangesAsync();

                    return true;
                }
            }

            return false;
        }

        public bool MatchPassword(User user, string rawPassword)
        {
            return user.HashedPassword.Equals(EncodeString(rawPassword, user.PasswordSalt));
        }

        private byte[] GenerateSalt()
        {
            byte[] salt = new byte[_saltPwdSize];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return salt;
        }

        public void EncryptPasswordForUser(User user)
        {
            user.PasswordSalt = GenerateSalt();
            string hashedPassword = EncodeString(user.HashedPassword, user.PasswordSalt);

            user.HashedPassword = hashedPassword;
        }
                
        private string EncodeString (string stringToHash, byte[] salt)
        {
            string encodedString = Convert.ToBase64String(
                                            KeyDerivation.Pbkdf2(
                                            password: stringToHash,
                                            salt: salt,
                                            prf: KeyDerivationPrf.HMACSHA512,
                                            iterationCount: 5000,
                                            numBytesRequested: _saltPwdSize
                                        ));

            return encodedString;
        }
    }
}
