namespace EventMe.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationUser : IdentityUser
    {
        private ICollection<PersonalMessage> receivedMessages;
        private ICollection<PersonalMessage> sentMessages;
        private ICollection<ApplicationUser> friends;
        private ICollection<Event> attendingEvents;
        private ICollection<Event> events;

        public ApplicationUser()
        {
            this.receivedMessages = new HashSet<PersonalMessage>();
            this.sentMessages = new HashSet<PersonalMessage>();
            this.friends = new HashSet<ApplicationUser>();
            this.attendingEvents = new HashSet<Event>();
            this.events = new HashSet<Event>();
        }

        [Required]
        public string FullName { get; set; }

        public string ImageDataUrl { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime RegistrationDate { get; set; }

        // Complex types MUST be instantiated. 
        // Remove the property's comment when the registration is made to work with ContactInfo.
        // public ContactInfo ContactInfo { get; set; }

        public string CountryCode { get; set; }

        [ForeignKey("CountryCode")]
        public virtual Country Country { get; set; }

        public int? TownId { get; set; }

        public virtual Town Town { get; set; }

        [MinLength(2)]
        [MaxLength(150)]
        public string Summary { get; set; }

        [Url]
        public string Website { get; set; }

        public virtual ICollection<ApplicationUser> Friends
        {
            get
            {
                return this.friends;
            }

            set
            {
                this.friends = value;
            }
        }

        [InverseProperty("Organizer")]
        public virtual ICollection<Event> Events
        {
            get
            {
                return this.events;
            }

            set
            {
                this.events = value;
            }
        }

        [InverseProperty("AttendingUsers")]
        public virtual ICollection<Event> AttendingEvents
        {
            get
            {
                return this.attendingEvents;
            }

            set
            {
                this.attendingEvents = value;
            }
        }

        [InverseProperty("Sender")]
        public virtual ICollection<PersonalMessage> SentMessages
        {
            get
            {
                return this.sentMessages;
            }

            set
            {
                this.sentMessages = value;
            }
        }

        [InverseProperty("Receiver")]
        public virtual ICollection<PersonalMessage> ReceivedMessages
        {
            get
            {
                return this.receivedMessages;
            }

            set
            {
                this.receivedMessages = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
