using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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

        ObservableCollection<Task> _tasks = new ObservableCollection<Task>();

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
            if (index != -1 && !_tasks[index].IsCompleted)
            {
                _tasks[index].IsCompleted = true;
            }
            else if (index != -1 && _tasks[index].IsCompleted)
            {
                _tasks[index].IsCompleted = false;
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

        string _fileName = "data.bin";        
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists(_fileName)) 
            {
                BinaryFormatter _binaryFormatter = new BinaryFormatter();
                Stream file = File.OpenRead(_fileName);
#pragma warning disable SYSLIB0011 // Type or member is obsolete
                _tasks = _binaryFormatter.Deserialize(file) as ObservableCollection<Task>;
#pragma warning restore SYSLIB0011 // Type or member is obsolete
                file.Close();
                ToDoListBox.ItemsSource = _tasks;
            }
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            BinaryFormatter _binaryFormatter = new BinaryFormatter();
            Stream file = File.OpenWrite(_fileName);
#pragma warning disable SYSLIB0011 // Type or member is obsolete
            _binaryFormatter.Serialize(file, _tasks);
#pragma warning restore SYSLIB0011 // Type or member is obsolete
            file.Close();
        }
    }
}
 