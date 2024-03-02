using _01Kharchenko.ViewModels;
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

namespace _01Kharchenko.Views
{
    /// <summary>
    /// Interaction logic for GoroscopeView.xaml
    /// </summary>
    public partial class GoroscopeView : UserControl
    {
        private GoroscopeViewModel _viewModel;
        public GoroscopeView()
        {
            InitializeComponent();
            DataContext = _viewModel = new GoroscopeViewModel();
        }

        private void Quit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
