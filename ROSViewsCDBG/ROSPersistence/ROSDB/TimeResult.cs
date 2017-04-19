namespace ROSPersistence.ROSDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class TimeResult
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ResultId { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime FinishTime { get; set; }

        public int? CalculatedTimeInSeconds { get; set; }

        public int? TimeMeasuredRaceEventId { get; set; }

        public virtual Result Result { get; set; }

        public virtual TimeMeasuredRaceEvent TimeMeasuredRaceEvent { get; set; }
    }
}
