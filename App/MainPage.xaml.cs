using Windows.UI.Popups;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App
{
    public sealed partial class MainPage : Page
    {
        private const string TaskStatusTemplate = "Task status: {0}";
        private const string NextStatusTemplate = "Mark status as {0}";

        private TaskManager taskManager = new TaskManager();
        private StatusHelper statusHelper = new StatusHelper();

        public MainPage()
        {
            this.InitializeComponent();

            AddAllTasks();
        }

        private void TaskList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = e.AddedItems[0];
            var roomNumber = int.Parse(selectedItem.ToString().Split(' ')[1]);
            var task = taskManager.Find(roomNumber);

            taskStatus.Text = string.Format(TaskStatusTemplate, task.Status);
            var status = statusHelper.NextStatus(task.Status);
            nextStatus.Content = string.Format(NextStatusTemplate, status);
        }

        private void NextStatus_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            var roomNumber = int.Parse(taskList.SelectedItem.ToString().Split(' ')[1]);
            var task = taskManager.Find(roomNumber);

            var status = statusHelper.NextStatus(task.Status);
            task.Status = status;
            taskStatus.Text = status;
            var nextStatusString = statusHelper.NextStatus(status);
            nextStatus.Content = string.Format(NextStatusTemplate, nextStatusString);
        }

        private void AddAllTasks()
        {
            foreach (var task in taskManager.GetTasks())
            {
                taskList.Items.Add("Room " + task.RoomId);
            }

            taskList.SelectedIndex = 0;
        }
    }
}
