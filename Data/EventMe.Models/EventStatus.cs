namespace EventMe.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EventStatuses")]
    public class EventStatus
    {
        [Key]
        public EventStatusType Type { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
