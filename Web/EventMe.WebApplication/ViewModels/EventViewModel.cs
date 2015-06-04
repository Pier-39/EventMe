namespace EventMe.WebApplication.ViewModels
{
    using System;
    using System.Linq.Expressions;

    using EventMe.Models;

    public class EventViewModel
    {
        public static Expression<Func<Event, EventViewModel>> ViewModel
        {
            get
            {
                return
                    x =>
                    new EventViewModel
                    {
                        Id = x.Id,
                        Title = x.Title,
                        Description = x.Description,
                        Date = x.Date,
                        RatedStars = x.RatedStars,
                        Type = x.FieldType.ToString(),
                        Organizer = x.Organizer.UserName,
                        MaxAttendantsAllowed = x.MaxAttendantsAllowed,
                        ImagePath = x.PhotoUrl ?? "/Content/Images/Events/DefaultEventImage.jpg",
                        CommentsCount = x.Comments.Count,
                        AttendantsCount = x.AttendingUsers.Count
                    };
            }
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string ImagePath { get; set; }

        public int RatedStars { get; set; }

        public string Type { get; set; }

        public string Organizer { get; set; }

        public int MaxAttendantsAllowed { get; set; }

        public int CommentsCount { get; set; }

        public int AttendantsCount { get; set; }
    }
}