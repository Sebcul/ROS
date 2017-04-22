namespace ROSPersistence.ROSDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RaceEvent : IRaceEvent
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int EventId { get; set; }

        [Required]
        [StringLength(100)]
        public string StartPosition { get; set; }

        [Required]
        [StringLength(100)]
        public string EndPosition { get; set; }

        public virtual DistanceMeasuredRaceEvent DistanceMeasuredRaceEvent { get; set; }

        public virtual Event Event { get; set; }

        public virtual TimeMeasuredRaceEvent TimeMeasuredRaceEvent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Class> Classes { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Team> Teams { get; set; }
    }
}
