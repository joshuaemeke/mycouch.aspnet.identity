﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNet.Identity;

namespace MyCouch.AspNet.Identity
{
    [Serializable]
    [Document(DocType = "IdentityUser")]
    public class IdentityUser : IUser
    {
        public string Id { get; set; }
        public string Rev { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public List<string> Roles { get; set; }
        public List<IdentityUserLogin> Logins { get; set; }
        public List<IdentityUserClaim> Claims { get; set; }

        public IdentityUser()
        {
            Roles = new List<string>();
            Logins = new List<IdentityUserLogin>();
            Claims = new List<IdentityUserClaim>();
        }

        public bool HasRole(string role)
        {
            return HasRoles() && Roles.Any(i =>
                i.Equals(role, StringComparison.OrdinalIgnoreCase));
        }

        public bool HasRoles()
        {
            return Roles != null && Roles.Any();
        }

        public virtual bool HasLogin(string loginProvider, string providerKey)
        {
            return HasLogins() && Logins.Any(i =>
                i.LoginProvider.Equals(loginProvider, StringComparison.OrdinalIgnoreCase) &&
                i.ProviderKey.Equals(providerKey, StringComparison.OrdinalIgnoreCase));
        }

        public virtual bool HasLogins()
        {
            return Logins != null && Logins.Any();
        }

        public virtual bool HasClaim(string claimType, string claimValue)
        {
            return HasClaims() && Claims.Any(i =>
                i.ClaimType.Equals(claimType, StringComparison.OrdinalIgnoreCase) &&
                i.ClaimValue.Equals(claimValue, StringComparison.OrdinalIgnoreCase));
        }

        public virtual bool HasClaims()
        {
            return Claims != null && Claims.Any();
        }
    }
}