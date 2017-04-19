namespace ROSPersistence.ROSDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Club
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Club()
        {
            ClubContactInformations = new HashSet<ClubContactInformation>();
            Regattas = new HashSet<Regatta>();
            Members = new HashSet<Member>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime RegistrationDate { get; set; }

        [StringLength(300)]
        public string LogoURL { get; set; }

        [StringLength(300)]
        public string WebsiteURL { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        public bool Active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClubContactInformation> ClubContactInformations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Regatta> Regattas { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Member> Members { get; set; }
    }
}
