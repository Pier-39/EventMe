namespace EventMe.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Country
    {
        [Key]
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
