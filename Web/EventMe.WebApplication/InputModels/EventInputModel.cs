namespace EventMe.WebApplication.InputModels
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    using EventMe.Models;

    public class EventInputModel
    {
        [Required]
        public string Title { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }

        [Required]
        [StringLength(maximumLength: 10000, ErrorMessage = "Your description must be between {1} and {2} characters long.", MinimumLength = 10)]
        public string Description { get; set; }

        [DisplayName("Type")]
        public EventFieldType FieldType { get; set; }

        [DisplayName("Maximum Attendants")]
        [Range(typeof(int), "1", "10000", ErrorMessage = "The number of allowed attendants must be between {1} and {2}.")]
        public int MaxAttendantsAllowed { get; set; }

        public string PhotoUrl { get; set; }
    }
}