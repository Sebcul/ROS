namespace ROSPersistence.ROSDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DistanceMeasuredRaceEvent
    {


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RaceEventId { get; set; }

        public virtual RaceEvent RaceEvent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DistanceResult> DistanceResults { get; set; }
    }
}
