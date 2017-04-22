namespace ROSPersistence.ROSDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Event : IEvent
    {


        public int Id { get; set; }

        public int No { get; set; }

        [Required]
        [StringLength(10)]
        public string Name { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        public int RegattaId { get; set; }

        public bool Active { get; set; }

        public virtual Regatta Regatta { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventsFee> EventsFees { get; set; }

        public virtual RaceEvent RaceEvent { get; set; }

        public virtual SocialEvent SocialEvent { get; set; }
    }
}
