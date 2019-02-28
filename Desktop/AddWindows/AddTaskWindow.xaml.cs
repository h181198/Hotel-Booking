using Core.Models;
using Core.Services;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Desktop.AddWindows
{
    /// <summary>
    /// Interaction logic for AddTaskWindow.xaml
    /// </summary>
    public partial class AddTaskWindow : Window
    {
        IRoomService roomService;
        ITaskService taskService;

        public AddTaskWindow()
        {
            roomService = new RoomService();
            taskService = new TaskService();
            InitializeComponent();
            InitializeLists();
        }

        private void InitializeLists()
        {
            List<room> rooms = roomService.GetAll().ToList();

            foreach (room r in rooms)
            {
                roomsList.Items.Add(r.id);
            }

            tasksList.Items.Add("Room service");
            tasksList.Items.Add("Cleaning");
            tasksList.Items.Add("Maintenance");
        }

        private void AddClicked(object sender, RoutedEventArgs e)
        {
            if(isValidValues())
            {
                if(tasksList.SelectedItem.ToString().Equals("Cleaning"))
                {
                    roomService.UpdateStatus("Unclean", roomService.Find((int)roomsList.SelectedItem));
                }

                var task = taskService.CreateTask(tasksList.SelectedItem.ToString(), (int) roomsList.SelectedItem, description.Text);
                taskService.Add(task);
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
            displayError("");
            if (roomsList.SelectedItem == null || tasksList.SelectedItem == null)
            {
                isValid = false;
                displayError("Please select a room or/and type");
            }

            return isValid;
        }

        private void displayError(string error)
        {
            errorsBox.Text += error + "\n";
        }
    }
}
