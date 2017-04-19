namespace ROSPersistence.ROSDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TimeMeasuredRaceEvent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TimeMeasuredRaceEvent()
        {
            TimeResults = new HashSet<TimeResult>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RaceEventId { get; set; }

        public virtual RaceEvent RaceEvent { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TimeResult> TimeResults { get; set; }
    }
}
