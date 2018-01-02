using ModelContract.Entities;
using System.Collections.Generic;

namespace Model.Contract.Dto
{
    public class UserSignUpDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public IEnumerable<Cv> Cvs { get; set; }
    }
}
