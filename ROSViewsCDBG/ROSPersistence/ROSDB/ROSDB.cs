namespace ROSPersistence.ROSDB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ROSDB : DbContext
    {
        public ROSDB()
            : base("name=ROSDB")
        {
        }

        public virtual DbSet<Boat> Boats { get; set; }
        public virtual DbSet<Class> Classes { get; set; }
        public virtual DbSet<ClubContactInformation> ClubContactInformations { get; set; }
        public virtual DbSet<ClubEmailAddress> ClubEmailAddresses { get; set; }
        public virtual DbSet<ClubPhoneNumber> ClubPhoneNumbers { get; set; }
        public virtual DbSet<Club> Clubs { get; set; }
        public virtual DbSet<ContactInformationType> ContactInformationTypes { get; set; }
        public virtual DbSet<CrewMember> CrewMembers { get; set; }
        public virtual DbSet<CrewRole> CrewRoles { get; set; }
        public virtual DbSet<DistanceMeasuredRaceEvent> DistanceMeasuredRaceEvents { get; set; }
        public virtual DbSet<DistanceResult> DistanceResults { get; set; }
        public virtual DbSet<Entry> Entries { get; set; }
        public virtual DbSet<Event> Events { get; set; }
        public virtual DbSet<EventsFee> EventsFees { get; set; }
        public virtual DbSet<Fee> Fees { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<NextOfKinPhoneNumber> NextOfKinPhoneNumbers { get; set; }
        public virtual DbSet<NextOfKin> NextOfKins { get; set; }
        public virtual DbSet<RaceEvent> RaceEvents { get; set; }
        public virtual DbSet<Regatta> Regattas { get; set; }
        public virtual DbSet<RegattasFee> RegattasFees { get; set; }
        public virtual DbSet<RegisteredUser> RegisteredUsers { get; set; }
        public virtual DbSet<ResponsibleRegattaMember> ResponsibleRegattaMembers { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SocialEventAttendee> SocialEventAttendees { get; set; }
        public virtual DbSet<SocialEvent> SocialEvents { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<TimeMeasuredRaceEvent> TimeMeasuredRaceEvents { get; set; }
        public virtual DbSet<TimeResult> TimeResults { get; set; }
        public virtual DbSet<UserContactInformation> UserContactInformations { get; set; }
        public virtual DbSet<UserPhoneNumber> UserPhoneNumbers { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Boat>()
                .HasMany(e => e.Entries)
                .WithRequired(e => e.Boat)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Class>()
                .HasMany(e => e.RaceEvents)
                .WithMany(e => e.Classes)
                .Map(m => m.ToTable("RaceEventsClasses").MapLeftKey("ClassId").MapRightKey("RaceEventId"));

            modelBuilder.Entity<ClubContactInformation>()
                .HasMany(e => e.ClubEmailAddresses)
                .WithRequired(e => e.ClubContactInformation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClubContactInformation>()
                .HasMany(e => e.ClubPhoneNumbers)
                .WithRequired(e => e.ClubContactInformation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ClubContactInformation>()
                .HasMany(e => e.ContactInformationTypes)
                .WithMany(e => e.ClubContactInformations)
                .Map(m => m.ToTable("ClubContactTypes").MapLeftKey("ClubContactInformationId").MapRightKey("ContactInformationTypeId"));

            modelBuilder.Entity<ClubEmailAddress>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<ClubPhoneNumber>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.ClubContactInformations)
                .WithRequired(e => e.Club)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.Regattas)
                .WithRequired(e => e.Club)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Club>()
                .HasMany(e => e.Members)
                .WithMany(e => e.Clubs)
                .Map(m => m.ToTable("ClubsMembers").MapLeftKey("ClubId").MapRightKey("MemberId"));

            modelBuilder.Entity<ContactInformationType>()
                .Property(e => e.Description)
                .IsFixedLength();

            modelBuilder.Entity<CrewRole>()
                .HasMany(e => e.CrewMembers)
                .WithRequired(e => e.CrewRole)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DistanceMeasuredRaceEvent>()
                .HasMany(e => e.DistanceResults)
                .WithOptional(e => e.DistanceMeasuredRaceEvent)
                .HasForeignKey(e => e.DistanceMeasuredRaceEventId);

            modelBuilder.Entity<Entry>()
                .Property(e => e.TotalSumPaid)
                .HasPrecision(10, 4);

            modelBuilder.Entity<Entry>()
                .HasMany(e => e.RegisteredUsers)
                .WithRequired(e => e.Entry)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Entry>()
                .HasMany(e => e.EventsFees)
                .WithRequired(e => e.Entry)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Entry>()
                .HasMany(e => e.RegattasFees)
                .WithRequired(e => e.Entry)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Entry>()
                .HasMany(e => e.Teams)
                .WithRequired(e => e.Entry)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .Property(e => e.Name)
                .IsFixedLength();

            modelBuilder.Entity<Event>()
                .HasMany(e => e.EventsFees)
                .WithRequired(e => e.Event)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Event>()
                .HasOptional(e => e.RaceEvent)
                .WithRequired(e => e.Event);

            modelBuilder.Entity<Event>()
                .HasOptional(e => e.SocialEvent)
                .WithRequired(e => e.Event);

            modelBuilder.Entity<Fee>()
                .Property(e => e.Sum)
                .HasPrecision(10, 4);

            modelBuilder.Entity<Fee>()
                .HasMany(e => e.EventsFees)
                .WithRequired(e => e.Fee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Fee>()
                .HasMany(e => e.RegattasFees)
                .WithRequired(e => e.Fee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.ResponsibleRegattaMembers)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Users)
                .WithMany(e => e.Members)
                .Map(m => m.ToTable("UsersMembers").MapLeftKey("MemberId").MapRightKey("UserId"));

            modelBuilder.Entity<NextOfKinPhoneNumber>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<NextOfKin>()
                .HasMany(e => e.NextOfKinPhoneNumbers)
                .WithRequired(e => e.NextOfKin)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RaceEvent>()
                .HasOptional(e => e.DistanceMeasuredRaceEvent)
                .WithRequired(e => e.RaceEvent);

            modelBuilder.Entity<RaceEvent>()
                .HasOptional(e => e.TimeMeasuredRaceEvent)
                .WithRequired(e => e.RaceEvent);

            modelBuilder.Entity<RaceEvent>()
                .HasMany(e => e.Teams)
                .WithMany(e => e.RaceEvents)
                .Map(m => m.ToTable("TeamsRaceEvents").MapLeftKey("RaceEventId").MapRightKey("TeamId"));

            modelBuilder.Entity<Regatta>()
                .HasMany(e => e.Entries)
                .WithRequired(e => e.Regatta)
                .HasForeignKey(e => e.RegattadId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Regatta>()
                .HasMany(e => e.Events)
                .WithRequired(e => e.Regatta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Regatta>()
                .HasMany(e => e.RegattasFees)
                .WithRequired(e => e.Regatta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Regatta>()
                .HasMany(e => e.ResponsibleRegattaMembers)
                .WithRequired(e => e.Regatta)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RegisteredUser>()
                .HasMany(e => e.CrewMembers)
                .WithRequired(e => e.RegisteredUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RegisteredUser>()
                .HasMany(e => e.SocialEventAttendees)
                .WithRequired(e => e.RegisteredUser)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Result>()
                .Property(e => e.Flag)
                .IsUnicode(false);

            modelBuilder.Entity<Result>()
                .HasOptional(e => e.DistanceResult)
                .WithRequired(e => e.Result);

            modelBuilder.Entity<Result>()
                .HasOptional(e => e.TimeResult)
                .WithRequired(e => e.Result);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.Members)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.ResponsibleRegattaMembers)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SocialEvent>()
                .HasMany(e => e.SocialEventAttendees)
                .WithRequired(e => e.SocialEvent)
                .HasForeignKey(e => e.SocialEventId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.CrewMembers)
                .WithRequired(e => e.Team)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Team>()
                .HasMany(e => e.Results)
                .WithRequired(e => e.Team)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TimeMeasuredRaceEvent>()
                .HasMany(e => e.TimeResults)
                .WithOptional(e => e.TimeMeasuredRaceEvent)
                .HasForeignKey(e => e.TimeMeasuredRaceEventId);

            modelBuilder.Entity<UserContactInformation>()
                .HasMany(e => e.UserPhoneNumbers)
                .WithRequired(e => e.UserContactInformation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UserContactInformation>()
                .HasMany(e => e.ContactInformationTypes)
                .WithMany(e => e.UserContactInformations)
                .Map(m => m.ToTable("UserContactTypes").MapLeftKey("UserContactInformationId").MapRightKey("ContactInformationTypeId"));

            modelBuilder.Entity<UserPhoneNumber>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PasswordHash)
                .IsFixedLength();

            modelBuilder.Entity<User>()
                .HasMany(e => e.Entries)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.SkipperId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.NextOfKins)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.RegisteredUsers)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.UserContactInformations)
                .WithRequired(e => e.User)
                .WillCascadeOnDelete(false);

            
            
        }
    }
}
