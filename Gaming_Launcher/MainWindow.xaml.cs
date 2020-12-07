using Gaming_Launcher.UC;
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

namespace Gaming_Launcher
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Switcher.pageSwitcher = this;
            Switcher.Switch(new MainControl());
        }
        public void Navigate(UserControl nextPage)
        {
            this.Content = nextPage;
        }
        public void Navigate(UserControl nextPage, object state)
        {
            this.Content = nextPage;
            ISwichable s = nextPage as ISwichable;

            if (s != null)
                s.UtilizeState(state);
            else
                throw new ArgumentException("NextPage ist kein ISwitchable!" + nextPage.Name.ToString());
        }
    }
}
