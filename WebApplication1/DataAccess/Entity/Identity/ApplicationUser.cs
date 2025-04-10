﻿using Microsoft.AspNetCore.Identity;

namespace WebApplication1.Data.Entity.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? DisplayName { get; set; }
    }
}
