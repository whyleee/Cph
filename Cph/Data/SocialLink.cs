namespace Cph.Data
{
    public class SocialLink
    {
        public int Id { get; set; }

        public string Url { get; set; }

        public virtual SocialService Service { get; set; }
    }
}