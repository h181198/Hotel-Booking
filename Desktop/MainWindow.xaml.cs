using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Core.Models;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;

namespace Desktop
{
    public partial class MainWindow : Window
    {
        private readonly BookingEntities db = new BookingEntities();
        private DbSet<room> rooms;
        private DbSet<reservation> reservations;
        private DbSet<task> tasks;
        private DbSet<user> users;

        public MainWindow()
        {
            rooms = db.rooms;
            reservations = db.reservations;
            tasks = db.tasks;
            users = db.users;

            InitializeComponent();
        }
    }
}
