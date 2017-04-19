using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ROSViewsCDBG.Views.UserControls
{
    /// <summary>
    /// Interaction logic for ClubAdminView.xaml
    /// </summary>
    public partial class ClubAdminView : UserControl
    {
        public ClubAdminView()
        {
            InitializeComponent();
        }

        public static event EventHandler<EventArgs> OpenCreateRegattaView;

        public void Create_Regatta_Button(object sender, EventArgs e)
        {
            OpenCreateRegattaView?.Invoke(this, new EventArgs());
        }
    }
}
