namespace EventMe.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("MessageStatuses")]
    public class MessageStatus
    {
        [Key]
        public MessageStatusType Type { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
