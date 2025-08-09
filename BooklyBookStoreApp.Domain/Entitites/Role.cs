using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooklyBookStoreApp.Domain.Entitites
{
    public class Role:IdentityRole<string>
    {
        public Role()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
