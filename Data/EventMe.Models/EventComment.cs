namespace EventMe.Models
{
    public class EventComment
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string CommenterId { get; set; }

        public virtual ApplicationUser Commenter { get; set; }

        public int EventId { get; set; }

        public virtual Event Event { get; set; }
    }
}
