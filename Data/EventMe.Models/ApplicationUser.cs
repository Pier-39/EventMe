namespace EventMe.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }

        public string ImageDataUrl { get; set; }

        // Complex types MUST be instantiated. 
        // Remove the property's comment when the registration is made to work with ContactInfo.
        // public ContactInfo ContactInfo { get; set; }

        public string CountryCode { get; set; }

        [ForeignKey("CountryCode")]
        public virtual Country Country { get; set; }

        public int? TownId { get; set; }

        public virtual Town Town { get; set; }

        public virtual ICollection<ApplicationUser> Friends { get; set; }

        public virtual ICollection<Event> Events { get; set; }

        public virtual ICollection<PersonalMessage> SentMessages { get; set; }

        public virtual ICollection<PersonalMessage> ReceivedMessages { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
