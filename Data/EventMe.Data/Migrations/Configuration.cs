namespace EventMe.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using EventMe.Models;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public sealed class Configuration : DbMigrationsConfiguration<EventMeDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(EventMeDbContext context)
        {
            if (!context.Users.Any())
            {
                this.SeedUsers(context);
            }

            if (!context.MessageStatuses.Any())
            {
                this.SeedMessageStatuses(context);
            }

            if (!context.EventStatuses.Any())
            {
                this.SeedEventStatuses(context);
            }


            if (!context.EventTypes.Any())
            {
                this.SeedEventTypes(context);
            }
        }

        private void SeedMessageStatuses(EventMeDbContext context)
        {
            foreach (var messageStatus in Enum.GetValues(typeof(MessageStatusType)))
            {
                var messageStatusEntity = new MessageStatus
                                          {
                                              Type = (MessageStatusType)messageStatus,
                                              Name = messageStatus.ToString()
                                          };
                context.MessageStatuses.Add(messageStatusEntity);
            }

            context.SaveChanges();
        }

        private void SeedEventStatuses(EventMeDbContext context)
        {
            foreach (var eventStatus in Enum.GetValues(typeof(EventStatusType)))
            {
                var eventStatusEntity = new EventStatus
                                        {
                                            Type = (EventStatusType)eventStatus,
                                            Name = eventStatus.ToString()
                                        };
                context.EventStatuses.Add(eventStatusEntity);
            }

            context.SaveChanges();
        }

        private void SeedEventTypes(EventMeDbContext context)
        {
            foreach (var eventType in Enum.GetValues(typeof(EventFieldType)))
            {
                var eventTypeEntity = new EventType
                                      {
                                          Type = (EventFieldType)eventType, 
                                          Name = eventType.ToString()
                                      };

                context.EventTypes.Add(eventTypeEntity);
            }

            context.SaveChanges();
        }

        private void SeedUsers(EventMeDbContext context)
        {
            var usernames = new string[] { "admin", "maria", "peter", "kiro", "didi" };

            var users = new List<ApplicationUser>();
            var userStore = new UserStore<ApplicationUser>(context);
            var userManager = new UserManager<ApplicationUser>(userStore);
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 2,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };

            foreach (var username in usernames)
            {
                var name = username[0].ToString().ToUpper() + username.Substring(1);
                var user = new ApplicationUser
                {
                    UserName = username,
                    FullName = name,
                    Email = username + "@gmail.com",
                    ImageDataUrl = "/Content/Images/Users/incognito-avatar.jpg",
                    RegistrationDate = DateTime.Now
                };

                var password = username;
                var userCreateResult = userManager.Create(user, password);
                if (userCreateResult.Succeeded)
                {
                    users.Add(user);
                }
                else
                {
                    throw new Exception(string.Join("; ", userCreateResult.Errors));
                }
            }

            context.SaveChanges();
        }
    }
}
