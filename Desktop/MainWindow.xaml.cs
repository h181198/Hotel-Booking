using Desktop.AddWindows;
using System.Windows;

namespace Desktop
{
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ReservationButtonClicked(object sender, RoutedEventArgs e) 
        {
            var reservationWindow = new ReservationWindow();
            reservationWindow.Show();
        }

        private void RoomButtonClicked(object sender, RoutedEventArgs e)
        {
            var roomWindow = new RoomWindow();
            roomWindow.Show();
        }

        private void TaskButtonClicked(object sender, RoutedEventArgs e)
        {
            var addTaskWindow = new AddTaskWindow();
            addTaskWindow.Show();
        }
    }
}
