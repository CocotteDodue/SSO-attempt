using System.Collections.Generic;

namespace ModelContract.Entities
{
    public partial class User : EntityBase
    {
        public User()
        {
            UserCv = new HashSet<UserCv>();
        }
        
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string HashedPassword { get; set; }
        public byte[] PasswordSalt { get; set; }

        public ICollection<UserCv> UserCv { get; set; }
    }
}
