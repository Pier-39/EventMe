﻿namespace EventMe.WebApplication.ViewModels
{
    using System;
    using System.Linq;
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
                        Type = x.Type,
                        Status = x.Status,
                        Organizer = x.Organizer.UserName,
                        MaxAttendantsAllowed = x.MaxAttendantsAllowed,
                        ImagePath = x.EventGallery.Photos.FirstOrDefault().Path
                    };
            }
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string ImagePath { get; set; }

        public int RatedStars { get; set; }

        public EventType Type { get; set; }

        public EventStatus Status { get; set; }

        public string Organizer { get; set; }

        public int MaxAttendantsAllowed { get; set; }
    }
}