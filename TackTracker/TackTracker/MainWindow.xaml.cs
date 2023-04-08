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

namespace TackTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // List<string> Tasks = new List<string>();
        string[] _tasks = new string[] { "купити молоко", "Вивчити С#", "Написати резюме" };
        
        public MainWindow()
        {
            InitializeComponent();
            ToDoListBox.ItemsSource = _tasks;
        }

    }
}
