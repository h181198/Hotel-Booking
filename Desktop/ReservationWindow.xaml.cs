using Core.Models;
using Core.Services;
using Desktop.AddWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for ReservationWindow.xaml
    /// </summary>
    public partial class ReservationWindow : Window
    {
        IReservationService reservationService;
        IUserService userService;

        public ReservationWindow()
        {
            reservationService = new ReservationService();
            userService = new UserService();

            InitializeComponent();
        }

        private void RoomNumberTextChanged(object sender, TextChangedEventArgs e)
        {
            int roomId = 0;
            bool isNumber = true;
            try
            {
                roomId = int.Parse(roomNr.Text);
            }
            catch (FormatException exception)
            {
                reservationList.Items.Clear();
                reservationList.Items.Add("Please enter a number");
                isNumber = false;
            }

            if (isNumber)
            {
                List<reservation> res = reservationService.FindRoomReservations(roomId);
                AddAllReservations(res);
            }
        }

        private void UserEmailTextChanged(object sender, TextChangedEventArgs e)
        {
            var usersWithEmail = userService.FindEmail(userEmail.Text);
            var res = new List<reservation>();
            foreach(user u in usersWithEmail)
            {
                res.AddRange(reservationService.FindReservationUser(u.id));
            }

            if (res.Any())
            {
                AddAllReservations(res);
            }
            else
            {
                reservationList.Items.Clear();
                reservationList.Items.Add("No recorded reservations for the specified user email");
            }
        }

        private void SearchClicked(object sender, RoutedEventArgs e)
        {
            DateTime startTime = startDate.SelectedDate.Value.Date;
            DateTime endTime = endDate.SelectedDate.Value.Date;

            var reservations = reservationService.FindReservationInterval(startTime, endTime);
            AddAllReservations(reservations);
        }

        private void AddReservationClicked(object sender, RoutedEventArgs e)
        {
            var addReservationWindow = new AddReservationWindow();
            addReservationWindow.Show();
        }

        private void FinishedClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddAllReservations(List<reservation> reservations)
        {
            reservationList.Items.Clear();
            if(reservations.Any()) {
                foreach (reservation res in reservations)
                {
                    AddToList(res);
                }
            }
            else
            {
                reservationList.Items.Add("There are no reservations on this room");
            }
        }

        private void AddToList(reservation res)
        {
            string email = res.user == null ? "No email" : res.user.email;
            reservationList.Items.Add("Customer email: " + email + "\tRoom number: " + res.room_id 
                                        + "\t\tStart date: " + res.start_time + "\tEnd date: " + res.end_time);
        }

    }
}
