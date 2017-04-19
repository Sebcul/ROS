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

namespace ROSViewsCDBG
{
    /// <summary>
    /// Interaction logic for RegattaInfoView.xaml
    /// </summary>
    public partial class RegattaInfoView : UserControl
    {
        public RegattaInfoView()
        {
            InitializeComponent();
        }

        public static event EventHandler<EventArgs> OpenCreateEntryView;

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            OpenCreateEntryView?.Invoke(this, new EventArgs());
        }
    }
}
