namespace EventMe.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Town
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string CountryCode { get; set; }

        [ForeignKey("CountryCode")]
        public virtual Country Country { get; set; }
    }
}
