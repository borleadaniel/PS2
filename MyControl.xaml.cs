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

namespace Simulator
{
    /// <summary>
    /// Interaction logic for MyControl.xaml
    /// </summary>
    public partial class MyControl : UserControl
    {
        ViewModel _vm;
        public MyControl()
        {
            InitializeComponent();
            _vm = new ViewModel();
            this.DataContext = _vm;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            _vm.IsRedForCar = !_vm.IsRedForCar;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            _vm.IsYellowForCar = !_vm.IsYellowForCar;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            _vm.IsGreenForCar = !_vm.IsGreenForCar;
        }

        private void Button_Click4(object sender, RoutedEventArgs e)
        {
            _vm.IsRedForPeople = !_vm.IsRedForPeople;
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            _vm.IsGreenForPeople = !_vm.IsGreenForPeople;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_S0(object sender, RoutedEventArgs e)
        {
            _vm.ForceNextState(ProcessState.Off);
        }

        private void Button_Click_S1(object sender, RoutedEventArgs e)
        {
            _vm.ForceNextState(ProcessState.AutoYellow);
        }

        private void Button_Click_S2(object sender, RoutedEventArgs e)
        {
            _vm.ForceNextState(ProcessState.BlinkOn);
        }

        private void Button_Click_S3(object sender, RoutedEventArgs e)
        {
            _vm.ForceNextState(ProcessState.AutoRed);
        }
    }
}
