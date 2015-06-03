namespace EventMe.Models
{
    using System;

    public class PersonalMessage
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime SentDate { get; set; }

        public string SenderId { get; set; }

        public virtual ApplicationUser Sender { get; set; }

        public string ReceiverId { get; set; }

        public virtual ApplicationUser Receiver { get; set; }

        public MessageStatusType StatusType { get; set; }

        public virtual MessageStatus Status { get; set; }
    }
}
