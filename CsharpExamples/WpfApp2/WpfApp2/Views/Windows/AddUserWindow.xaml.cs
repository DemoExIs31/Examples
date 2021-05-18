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
using WpfApp2.ViewModels;

namespace WpfApp2.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddUserWindow.xaml
    /// </summary>
    public partial class AddUserWindow : Window
    {
        private AddUserViewModel _vm;
        public AddUserWindow()
        {
            InitializeComponent();

            DataContext = _vm = new AddUserViewModel();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new Entities.EntityContext())
            {
                context.Database.ExecuteSqlCommand(
                    $"exec [NewUser] " +
                    $"@name = '{NmaeBox.Text}', " +
                    $"@middlename = '{MiddleNmaeBox.Text}', " +
                    $"@lastname = '{LastNmaeBox.Text}'," +
                    $"@login ='{LoginBox.Text}'," +
                    $"@passwd = '{PasswodBox.Text}', " +
                    $"@position = '{_vm.SelectedModel}'");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
