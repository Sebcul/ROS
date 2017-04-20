namespace ROSPersistence.ROSDB
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Entry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Entry()
        {
            RegisteredUsers = new HashSet<RegisteredUser>();
            EventsFees = new HashSet<EventsFee>();
            RegattasFees = new HashSet<RegattasFee>();
            Teams = new HashSet<Team>();
        }

        public int Id { get; set; }

        public int No { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RegistrationDate { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal? TotalSumPaid { get; set; }

        [StringLength(1024)]
        public string Description { get; set; }

        public int SkipperId { get; set; }

        public int BoatId { get; set; }

        public int RegattadId { get; set; }

        public bool Active { get; set; }

        public virtual Boat Boat { get; set; }

        public virtual Regatta Regatta { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegisteredUser> RegisteredUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EventsFee> EventsFees { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RegattasFee> RegattasFees { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Team> Teams { get; set; }
    }
}
