using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ROSViewsCDBG.Views.UserControls;
using ROSViewsCDBG.Views.Windows;

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

        public static ClubMemberViewModel ClubMemberViewModel
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

        public static ListUsersResultsViewModel ListUsersResultsViewModel
        {
            get { return new ListUsersResultsViewModel(); }
        }

        public static ListUsersTeamsViewModel ListUsersTeamsViewModel
        {
            get { return new ListUsersTeamsViewModel(); }
        }

        public static RegattaAdminViewModel RegattaAdminViewModel
        {
            get { return new RegattaAdminViewModel(); }
        }

        public static RegattaInfoViewModel RegattaInfoViewModel
        {
            get { return new RegattaInfoViewModel(); }
        }

        public static RegisterToRaceEventViewModel RegisterToRaceEventViewModel
        {
            get { return new RegisterToRaceEventViewModel(); }
        }

        public static RegisterToSocialEventViewModel RegisterToSocialEventViewModel
        {
            get { return new RegisterToSocialEventViewModel(); }
        }

        public static RegisterToTeamViewModel RegisterToTeamViewModel
        {
            get { return new RegisterToTeamViewModel(); }
        }

        public static RegisterUserWindowViewModel RegisterUserWindowViewModel
        {
            get { return new RegisterUserWindowViewModel(); }
        }

        public static SocialEventInfoViewModel SocialEventInfoViewModel
        {
            get { return new SocialEventInfoViewModel(); }
        }

        public static TeamInfoViewModel TeamInfoViewModel
        {
            get { return new TeamInfoViewModel(); }
        }

        public static TimeMeasuredRaceEventInfoViewModel TimeMeasuredRaceEventInfoViewModel
        {
            get { return new TimeMeasuredRaceEventInfoViewModel(); }
        }

        public static UserInfoViewModel UserInfoViewModel
        {
            get { return new UserInfoViewModel(); }
        }

        public static LoginWindowViewModel LoginWindowViewModel
        {
            get { return new LoginWindowViewModel(); }
        }

        public static MainWindowViewModel MainWindowViewModel
        {
            get { return new MainWindowViewModel(); }
        }

        public static AddPhoneNumberViewModel AddPhoneNumberViewModel
        {
            get { return new AddPhoneNumberViewModel(); }
        }

        public static AddUserAddressWindow AddUserAddressWindow
        {
            get { return new AddUserAddressWindow(); }
        }
        
    }
}
