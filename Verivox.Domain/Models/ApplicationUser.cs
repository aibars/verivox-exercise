using Microsoft.AspNetCore.Identity;
using System;

namespace Verivox.Domain.Models
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public DateTime? LastLoginDate { get; set; }
    }
}