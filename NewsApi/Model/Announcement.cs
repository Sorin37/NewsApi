namespace NewsApi.Model
{
    public class Announcement
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }

    }
}
