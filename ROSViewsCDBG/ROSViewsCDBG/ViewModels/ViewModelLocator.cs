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
        public static ClubAdminView ClubAdminView
        {
            get { return new ClubAdminView(); }
        }
    }
}
