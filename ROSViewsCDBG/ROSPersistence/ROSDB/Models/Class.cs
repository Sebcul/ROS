namespace ROSPersistence.ROSDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Class
    {


        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public double MinHandicap { get; set; }

        public double MaxHandicap { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        public bool Active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RaceEvent> RaceEvents { get; set; }
    }
}
