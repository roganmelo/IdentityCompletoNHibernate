using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System;

namespace IdentityCompletoNHibernate.Models
{
    public class IdentityRole : IRole
    {
        public IdentityRole()
        {
            Id = Guid.NewGuid().ToString();
            Users = new List<IdentityUser>();
        }

        public IdentityRole(string roleName) : this()
        {
            Id = Guid.NewGuid().ToString();
            Name = roleName;
        }

        public virtual string Id { get; set; }

        public virtual string Name { get; set; }

        public virtual ICollection<IdentityUser> Users { get; protected set; }
    }
}
