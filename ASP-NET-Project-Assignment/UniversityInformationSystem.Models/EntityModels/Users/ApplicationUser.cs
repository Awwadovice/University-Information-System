﻿namespace UniversityInformationSystem.Models.EntityModels.Users
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Utillities.Constants;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.InboxMessages = new HashSet<Message>();
            this.SendMessages = new HashSet<Message>();
        }

        [Required]
        [RegularExpression(ValidationConstants.AppUserNameRegex)]
        public string FirstName { get; set; }

        [Required]
        [RegularExpression(ValidationConstants.AppUserNameRegex)]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName => this.FirstName + " " + this.LastName;

        [Required]
        public DateTime BirthDate { get; set; }

        public virtual ICollection<Message> InboxMessages { get; set; }

        public virtual ICollection<Message> SendMessages { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);

            return userIdentity;
        }
    }
}
