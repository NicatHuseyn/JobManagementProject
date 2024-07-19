﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KormosalaWebApi.Domain.Entities.Identity
{
    public class AppUser:IdentityUser<int>
    {
        public string FullName { get; set; }
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
    }
}
