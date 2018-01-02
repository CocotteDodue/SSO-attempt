using ModelContract.Entities;
using System.Collections.Generic;

namespace Model.Contract.Dto
{
    public class UserDto
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<CvDto> Cvs { get; set; }
    }
}
