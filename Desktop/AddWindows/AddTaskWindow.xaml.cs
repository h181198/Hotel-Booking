using Core.Models;
using Core.Services;
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
using System.Windows.Shapes;

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
            //TODO implement add method
        }

        private void CancelClicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
