namespace EventMe.Models
{
    using System;
    using System.Collections.Generic;

    public class Event
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public int RatedStars { get; set; }

        public EventFieldType FieldType { get; set; }

        public virtual EventType Field { get; set; }

        public string OrganizerId { get; set; }

        public virtual ApplicationUser Organizer { get; set; }

        public int MaxAttendantsAllowed { get; set; }

        public string PhotoUrl { get; set; }

        public virtual ICollection<ApplicationUser> AttendingUsers { get; set; }

        public virtual ICollection<EventComment> Comments { get; set; }
    }
}
