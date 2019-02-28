using Core.Models;
using Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Desktop.AddWindows
{
    /// <summary>
    /// Interaction logic for AddReservationWindow.xaml
    /// </summary>
    public partial class AddReservationWindow : Window
    {
        IRoomService roomService;
        IReservationService reservationService;
        IUserService userService;

        public AddReservationWindow()
        {
            userService = new UserService();
            roomService = new RoomService();
            reservationService = new ReservationService();

            InitializeComponent();
            InitializeMenu();
        }

        private void AddClicked(object sender, RoutedEventArgs e)
        {
            if (isValidValues())
            {
                var users = userService.FindEmail(userEmail.Text);
                user user;
                if(!users.Any())
                {
                    user = userService.Create(userEmail.Text);
                }
                else
                {
                    user = users.First();
                }

                var res = reservationService.CreateReservation(startDate.SelectedDate.Value.Date, endDate.SelectedDate.Value.Date, 
                                                                        user.id, (int) roomsList.SelectedItem);
                reservationService.Add(res);

                this.Close();
            }
        }

        private void CancelClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool isValidValues()
        {
            bool isValid = true;
            DateTime today = new DateTime();
            displayError("");
            if(roomsList.SelectedItem == null)
            {
                isValid = false;
                displayError("Please select a room");
            } 
            else
            {
                var room = roomService.Find((int) roomsList.SelectedItem);
                if(!roomService.FindAvailable(startDate.SelectedDate.Value.Date, endDate.SelectedDate.Value.Date).Contains(room))
                {
                    isValid = false;
                    displayError("Room not available at selected time");
                }
            }
            if(today > endDate.SelectedDate.Value.Date || today > startDate.SelectedDate.Value.Date)
            {
                isValid = false;
                displayError("Start/End date can not be before today date");
            }

            return isValid;
        }

        private void InitializeMenu()
        {
            List<room> rooms = roomService.GetAll().ToList();

            foreach(room r in rooms)
            {
                roomsList.Items.Add(r.id);
            }
        }

        private void displayError(string error)
        {
            errorsBox.Text += error + "\n";
        }
    }
}
