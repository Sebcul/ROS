using System;
using System.Collections.Generic;

namespace ROSPersistence.ROSDB
{
    public interface IUser
    {
        bool Active { get; set; }
        string Description { get; set; }
        string Email { get; set; }
        ICollection<Entry> Entries { get; set; }
        string FirstName { get; set; }
        int Id { get; set; }
        string LastName { get; set; }
        ICollection<Member> Members { get; set; }
        ICollection<NextOfKin> NextOfKins { get; set; }
        byte[] PasswordHash { get; set; }
        ICollection<RegisteredUser> RegisteredUsers { get; set; }
        Guid? Salt { get; set; }
        ICollection<UserContactInformation> UserContactInformations { get; set; }
    }
}