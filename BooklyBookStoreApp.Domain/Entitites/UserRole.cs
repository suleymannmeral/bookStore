using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooklyBookStoreApp.Domain.Entitites
{
    public sealed class UserRole 
    {
        public UserRole()
        {
            Id = Guid.NewGuid().ToString();
        }
        public string Id { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Role")]
        public string RoleId { get; set; }
        public Role Role { get; set; }
    }
}
