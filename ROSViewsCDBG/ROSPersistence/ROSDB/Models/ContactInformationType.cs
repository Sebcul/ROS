namespace ROSPersistence.ROSDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ContactInformationType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ContactInformationType()
        {
            ClubContactInformations = new HashSet<ClubContactInformation>();
            UserContactInformations = new HashSet<UserContactInformation>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Type { get; set; }

        [StringLength(10)]
        public string Description { get; set; }

        public bool Active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClubContactInformation> ClubContactInformations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserContactInformation> UserContactInformations { get; set; }
    }
}
