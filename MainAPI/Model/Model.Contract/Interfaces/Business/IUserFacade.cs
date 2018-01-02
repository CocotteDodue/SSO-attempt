using Model.Contract.Dto;
using ModelContract.Entities;
using System.Threading.Tasks;

namespace Model.Contract.Interfaces.Business
{
    public interface IUserFacade
    {
        Task<UserDto> GetByEmail(string email);
        Task<bool> RegisterNewUser(UserSignUpDto userDto);
        bool MatchPassword(User user, string rawPassword);
        void EncryptPasswordForUser(User user);
    }
}
