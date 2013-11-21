namespace HotLikes.Data
{
    using HotLikes.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class HotLikesContext : IdentityDbContext<ExtendedUser, UserClaim, UserSecret, UserLogin, Role, UserRole, Token, UserManagement>
    {
        public HotLikesContext()
            : base("HotLikesConnection")
        {
        }
       
    }
}