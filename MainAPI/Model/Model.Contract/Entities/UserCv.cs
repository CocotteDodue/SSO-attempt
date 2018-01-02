namespace ModelContract.Entities
{
    public partial class UserCv : EntityBase
    {
        public int UserId { get; set; }
        public int CvId { get; set; }
        public Cv Cv { get; set; }
        public User User { get; set; }
    }
}
