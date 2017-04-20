namespace ROSPersistence.ROSDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SocialEventAttendee
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RegisteredUserId { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SocialEventId { get; set; }

        public int? NumberOfFriends { get; set; }

        public virtual RegisteredUser RegisteredUser { get; set; }

        public virtual SocialEvent SocialEvent { get; set; }
    }
}
