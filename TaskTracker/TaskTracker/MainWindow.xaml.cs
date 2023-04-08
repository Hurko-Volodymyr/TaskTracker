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

namespace TaskTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Task> _tasks = new List<Task>() {
        new Task() { Name = "Купити молоко", Description = "Привіт той, хто це читає" },
        new Task() { Name = "Вивчити C#", Description = "Привіт той, хто це читає" },
        new Task() { Name = "Написати резюме", Description = "Привіт той, хто це читає" }
    };

        public MainWindow()
        {
            InitializeComponent();
            ToDoListBox.ItemsSource = _tasks;
            ToDoListBox.DisplayMemberPath = "Name";
        }

        private void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Task selected = ToDoListBox.SelectedItem as Task;
            if (selected != null) 
            {
                MessageBox.Show(selected.Description);
            }            
        }
    }
}
