using System;
using System.Collections.Generic;

namespace ROSPersistence.ROSDB
{
    public interface IClub
    {
        bool Active { get; set; }
        ICollection<ClubContactInformation> ClubContactInformations { get; set; }
        string Description { get; set; }
        int Id { get; set; }
        string LogoURL { get; set; }
        ICollection<Member> Members { get; set; }
        string Name { get; set; }
        ICollection<Regatta> Regattas { get; set; }
        DateTime RegistrationDate { get; set; }
        string WebsiteURL { get; set; }
    }
}