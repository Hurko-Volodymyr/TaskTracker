using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        ObservableCollection<Task> _tasks = new ObservableCollection<Task>() {
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

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            NewTaskWindow newTaskWindow = new NewTaskWindow();
            newTaskWindow.Owner = this;
            newTaskWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            if (newTaskWindow.ShowDialog() == true) ;
            {
                Task newTask = newTaskWindow.Result;
                _tasks.Add(newTask);
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            int index = ToDoListBox.SelectedIndex;
            if (index != -1) 
            {
                _tasks.RemoveAt(index);
            }
        }

        private void DoneButton_Click(object sender, RoutedEventArgs e)
        {
            int index = ToDoListBox.SelectedIndex;
            if (index != -1)
            {
                _tasks[index].IsCompleted = true;
            }
        }

        private void AllRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ToDoListBox.ItemsSource = _tasks;
        }

        private void UncompletedRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Task> _uncompletedTasks = new ObservableCollection<Task>();
            foreach (Task task in _tasks) 
            {
                if (!task.IsCompleted) 
                {
                    _uncompletedTasks.Add(task);
                }
            }
            ToDoListBox.ItemsSource = _uncompletedTasks;
        }

        private void CompletedRadioButton_Checked(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Task> _completedTasks = new ObservableCollection<Task>();
            foreach (Task task in _tasks)
            {
                if (task.IsCompleted)
                {
                    _completedTasks.Add(task);
                }
            }
            ToDoListBox.ItemsSource = _completedTasks;
        }
    }
}
