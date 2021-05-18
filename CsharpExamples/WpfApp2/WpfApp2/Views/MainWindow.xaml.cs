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
using WpfApp2.Entities;
using WpfApp2.ViewModels;
using WpfApp2.Views.Windows;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWinViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();

            DataContext = _viewModel = new MainWinViewModel();
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            new AddUserWindow().ShowDialog();
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var context = new EntityContext())
                {
                    if (_viewModel.SelectedModel == null)
                        throw new ArgumentNullException("User not selected");

                    var user =
                        context.UserData.FirstOrDefault(
                            u => u.Id == _viewModel.SelectedModel.Id);
                    
                    if (user == null)
                        throw new ArgumentNullException("User not found");

                    context.UserData.Remove(user);
                    context.SaveChanges();
                    MessageBox.Show("User was deleted", "!!!", MessageBoxButton.OK, MessageBoxImage.Warning);

                    UsersDataGrid.Items.Clear();
                    _viewModel.FillUsers();
                    UsersDataGrid.ItemsSource = _viewModel.Users;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            
        }
    }
}
