namespace ROSPersistence.ROSDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class NextOfKinPhoneNumber
    {
        public int NextOfKinId { get; set; }

        [Key]
        [StringLength(50)]
        public string PhoneNumber { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        public bool Active { get; set; }

        public virtual NextOfKin NextOfKin { get; set; }
    }
}
