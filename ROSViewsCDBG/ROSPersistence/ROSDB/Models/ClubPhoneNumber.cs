namespace ROSPersistence.ROSDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ClubPhoneNumber
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClubContactInformationId { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        public bool Active { get; set; }

        public virtual ClubContactInformation ClubContactInformation { get; set; }
    }
}
