﻿using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sariyerpedo.Areas.admin.Data.AuthorizationHandler
{
    public class CustomUserRequireClaim : IAuthorizationRequirement
    {
        public CustomUserRequireClaim(string claimType)
        {
            this.ClaimType = claimType;
        }
        public string ClaimType { get; set; }
    }
}
