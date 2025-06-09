namespace Flugg_FilmRegister.Core.Domain
{
    public enum ProfileStatus
    {
        Active,
        Abandoned,
        Deactivated,
        Locked,
        Banned,
        ManualReviewNecessary
    }
    public class UserProfile
    {
        public Guid ID { get; set; }

        public string ApplicationUserID { get; set; }

        public string ScreenName { get; set; }

        public bool IsAdmin { get; set; }
    }
}
