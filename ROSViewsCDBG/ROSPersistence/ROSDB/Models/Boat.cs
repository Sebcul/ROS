namespace ROSPersistence.ROSDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Boat : IBoat
    {

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public int SailNo { get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        public double Handicap { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        public bool Active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entry> Entries { get; set; }
    }
}
