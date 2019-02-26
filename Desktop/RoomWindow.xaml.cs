using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Core.Models;
using Core.Services;
using Desktop.AddWindows;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for RoomWindow.xaml
    /// </summary>
    public partial class RoomWindow : Window
    {
        private IRoomService roomService;

        public RoomWindow()
        {
            roomService = new RoomService();

            InitializeComponent();
        }

        private void RoomNumberTextChanged(object sender, TextChangedEventArgs e)
        {
            int id = 0;
            bool isNumber = true;
            try
            {
                id = int.Parse(roomNr.Text);
            }
            catch (FormatException exception)
            {
                roomList.Items.Clear();
                roomList.Items.Add("Please enter a number");
                isNumber = false;
            }

            if(isNumber) {
                room r = roomService.Find(id);
                roomList.Items.Clear();
                AddToList(r);
            }
        }

        private void BedsNumberTextChanged(object sender, TextChangedEventArgs e)
        {
            int bedsNumber = 0;
            bool isNumber = true;
            try
            {
                bedsNumber = int.Parse(bedsNr.Text);
            }
            catch (FormatException exception)
            {
                roomList.Items.Clear();
                roomList.Items.Add("Please enter a number");
                isNumber = false;
            }

            if (isNumber)
            {
                List<room> rooms = roomService.FindRoomsFromBeds(bedsNumber);
                AddAllRooms(rooms);
            }
        }

        private void AddRoomClicked(object sender, RoutedEventArgs e)
        {
            var addRoomWindow = new AddRoomWindow();
            addRoomWindow.Show();
        }

        private void FinishedClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddAllRooms(List<room> rooms)
        {
            roomList.Items.Clear();
            foreach(room r in rooms)
            {
                AddToList(r);
            }
        }

        private void AddToList(room room)
        {
            roomList.Items.Add("room number: " + room.id + "\tNumber of beds: " + room.beds 
                                + "\tStatus: " + room.status + "\tQuality: " + room.quality );
        }
    }
}
