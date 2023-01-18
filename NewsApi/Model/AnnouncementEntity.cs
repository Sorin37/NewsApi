namespace NewsApi.Model
{
    public class AnnouncementEntity
    {
        public string Title { get; set; }
        public string Message { get; set; }
        public string Category { get; set; }
        public string Author { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }

        public Announcement EntityToModel()
        {
            return new Announcement { 
                Title = Title, 
                Message = Message, 
                Category = Category,
                Author = Author,
                ImageUrl = ImageUrl,
                Description = Description,
                CategoryId = CategoryId
            };
        }
    }
}
