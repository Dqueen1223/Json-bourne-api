using System;
using System.Collections.Generic;

namespace Catalyte.Apparel.DTOs
{
    /// <summary>
    /// Describes a data transfer object for a user.
    /// </summary>
    public class UserDTO
    {
        public int Id { get; set; }

        public DateTime LastActive { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Street { get; set; }

        public string Street2 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

        public string Phone { get; set; }

        public List<int> Wishlist { get; set; }
    }
}
