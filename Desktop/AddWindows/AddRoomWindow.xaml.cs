using Core.Models;
using Core.Services;
using System;
using System.Windows;

namespace Desktop.AddWindows
{
    /// <summary>
    /// Interaction logic for AddRoomWindow.xaml
    /// </summary>
    public partial class AddRoomWindow : Window
    {
        IRoomService roomService;

        public AddRoomWindow()
        {
            roomService = new RoomService();

            InitializeComponent();

            InitializeLists();
        }

        private void AddClicked(object sender, RoutedEventArgs e)
        {
            if(isValidValues())
            {
                room r = CreateRoom(int.Parse(bedsNr.Text), int.Parse(roomNr.Text), 
                                    (string) quality.SelectedItem, (string) status.SelectedItem);
                roomService.Add(r);

                this.Close();
            }
        }

        private void CancelClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void InitializeLists()
        {
            status.Items.Add("Clean");
            status.Items.Add("Unclean");

            quality.Items.Add("Great");
            quality.Items.Add("Good");
            quality.Items.Add("Bad");
        }

        private bool isValidValues()
        {
            bool isValid = true;
            errorsBox.Text = "";
            try
            {
                int.Parse(bedsNr.Text);
                int roomNumber = int.Parse(roomNr.Text);
                var doesExist = roomService.Find(roomNumber);
                if(doesExist != null)
                {
                    displayError("Roomnumber already in use");
                    isValid = false;
                }
            }
            catch (Exception e)
            {
                displayError("Either your beds number or your room number\n is not a valid number \nremember to check for spaces");
                isValid = false;
            }

            if(status.SelectedItem == null)
            {
                displayError("Please select a status for the room");
            } 
            if(quality.SelectedItem == null)
            {
                displayError("Please select a quality for the room");
            }

            return isValid && status.SelectedItem != null && quality.SelectedItem != null;
        }

        private room CreateRoom(int beds, int roomNumber, string quality, string status)
        {
            room r = new room();
            r.beds = beds;
            r.id = roomNumber;
            r.status = status;
            r.quality = quality;

            return r;
        }

        private void displayError(string error)
        {
            errorsBox.Text += error + "\n";
        }
    }
}
