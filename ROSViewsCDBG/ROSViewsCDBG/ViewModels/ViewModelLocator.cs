using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROSViewsCDBG.Views.UserControls;

namespace ROSViewsCDBG.ViewModels
{
    public class ViewModelLocator
    {
        public static ClubAdminViewModel ClubAdminViewModel
        {
            get { return new ClubAdminViewModel(); }
        }

        public static ClubInfoViewModel ClubInfoViewModel
        {
            get { return new ClubInfoViewModel(); }
        }

        public static ClubMemberViewModel ClubMemberView
        {
            get { return new ClubMemberViewModel(); }
        }

        public static ClubRegistrationViewModel ClubRegistrationViewModel
        {
            get { return new ClubRegistrationViewModel(); }
        }

        public static CreateClubViewModel CreateClubViewModel
        {
            get { return new CreateClubViewModel(); }
        }

        public static CreateEntryViewModel CreateEntryViewModel
        {
            get { return new CreateEntryViewModel(); }
        }

        public static CreateRaceEventViewModel CreateRaceEventViewModel
        {
            get { return new CreateRaceEventViewModel(); }
        }

        public static CreateRegattaViewModel CreateRegattaViewModel
        {
            get { return new CreateRegattaViewModel(); }
        }

        public static CreateSocialEventViewModel CreateSocialEventViewModel
        {
            get { return new CreateSocialEventViewModel(); }
        }

        public static DistanceMeasuredRaceEventInfoViewModel DistanceMeasuredRaceEventInfoViewModel
        {
            get { return new DistanceMeasuredRaceEventInfoViewModel(); }
        }

        public static EditUserInfoViewModel EditUserInfoViewModel
        {
            get { return new EditUserInfoViewModel(); }
        }

        public static EntryInfoViewModel EntryInfoViewModel
        {
            get { return new EntryInfoViewModel(); }
        }

        public static ListUsersClubsViewModel ListUsersClubViewModel
        {
            get { return new ListUsersClubsViewModel(); }
        }

        public static ListUsersRegattasViewModel ListUsersRegattasViewModel
        {
            get { return new ListUsersRegattasViewModel(); }
        }
        
    }
}
