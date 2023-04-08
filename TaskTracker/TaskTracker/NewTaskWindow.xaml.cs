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

namespace TaskTracker
{
    /// <summary>
    /// Interaction logic for NewTaskWindow.xaml
    /// </summary>
    public partial class NewTaskWindow : Window
    {
        public Task Result { get; set; }
        public NewTaskWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var task = new Task();
            task.Name = NameTextBox.Text;
            task.Description = DescriptionTextBox.Text;
            task.IsCompleted = IsCompletedCheckBox.IsChecked.Value;
            Result = task;

            if (NameTextBox.Text != "")
            {
                Result.Name = NameTextBox.Text;
                DialogResult = true;
            }
            else 
            {
                NameTextBox.Background = Brushes.Red;
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
