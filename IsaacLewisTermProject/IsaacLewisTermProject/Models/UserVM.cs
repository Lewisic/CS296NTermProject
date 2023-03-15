﻿using Microsoft.AspNetCore.Identity;

namespace IsaacLewisTermProject.Models
{
    public class UserVM
    {
        public IEnumerable<AppUser> Users { get; set; } = null!;
        public IEnumerable<IdentityRole> Roles { get; set; } = null!;
    }
}
