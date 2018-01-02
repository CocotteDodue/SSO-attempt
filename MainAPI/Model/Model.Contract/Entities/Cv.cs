using System.Collections.Generic;

namespace ModelContract.Entities
{
    public partial class Cv : EntityBase
    {
        public Cv()
        {
            UserCv = new HashSet<UserCv>();
        }

        public string Title { get; set; }
        
        public ICollection<UserCv> UserCv { get; set; }
    }
}
