namespace ROSPersistence.ROSDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ClubContactInformation")]
    public partial class ClubContactInformation
    {


        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }

        [Required]
        [StringLength(50)]
        public string Street { get; set; }

        [Column("Zip Code")]
        public int Zip_Code { get; set; }

        public int? BoxNo { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        public int ClubId { get; set; }

        public bool Active { get; set; }

        public virtual Club Club { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClubEmailAddress> ClubEmailAddresses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClubPhoneNumber> ClubPhoneNumbers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContactInformationType> ContactInformationTypes { get; set; }
    }
}
