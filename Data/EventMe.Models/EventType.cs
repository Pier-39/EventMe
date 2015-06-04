namespace EventMe.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("EventTypes")]
    public class EventType
    {
        [Key]
        public EventFieldType Type { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
