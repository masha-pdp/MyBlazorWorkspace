namespace BlazorApp1.Data
{
   public class CommentEntity

    {
        public long id { set; get; }
        public string text { get; set; }
        public long userid { get; set; }

        public DateTime date { get; set; }

        public UserEntity User { get; set; }
    }
}