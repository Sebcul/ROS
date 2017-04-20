namespace ROSPersistence.ROSDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Result : IResult
    {
        public int Id { get; set; }

        public int No { get; set; }

        public int? Rank { get; set; }

        [StringLength(50)]
        public string Penalty { get; set; }

        public int? Points { get; set; }

        [StringLength(3)]
        public string Flag { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        public int TeamId { get; set; }

        public bool Active { get; set; }

        public virtual DistanceResult DistanceResult { get; set; }

        public virtual Team Team { get; set; }

        public virtual TimeResult TimeResult { get; set; }
    }
}
