namespace ROSPersistence.ROSDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CrewMember
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RegisteredUserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TeamId { get; set; }

        public int CrewRoleId { get; set; }

        public bool Active { get; set; }

        public virtual CrewRole CrewRole { get; set; }

        public virtual RegisteredUser RegisteredUser { get; set; }

        public virtual Team Team { get; set; }
    }
}
