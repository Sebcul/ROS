using System.Collections.Generic;

namespace ROSPersistence.ROSDB
{
    public interface IRole
    {
        bool Active { get; set; }
        string Description { get; set; }
        int Id { get; set; }
        ICollection<Member> Members { get; set; }
        string Name { get; set; }
        ICollection<ResponsibleRegattaMember> ResponsibleRegattaMembers { get; set; }
    }
}