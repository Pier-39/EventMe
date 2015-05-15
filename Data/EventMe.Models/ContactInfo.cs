namespace EventMe.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    [ComplexType]
    public class ContactInfo
    {
        public string FacebookAccount { get; set; }

        public string TwitterAccount { get; set; }

        public string LinkedinAccount { get; set; }
    }
}
