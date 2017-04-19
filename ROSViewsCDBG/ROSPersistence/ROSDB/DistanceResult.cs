namespace ROSPersistence.ROSDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DistanceResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ResultId { get; set; }

        public double Distance { get; set; }

        public double CalculatedDistance { get; set; }

        public DateTime? OverTime { get; set; }

        public int? DistanceMeasuredRaceEventId { get; set; }

        public virtual DistanceMeasuredRaceEvent DistanceMeasuredRaceEvent { get; set; }

        public virtual Result Result { get; set; }
    }
}
