using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Entities;

namespace WpfApp2.ViewModels
{
    public class MainWinViewModel
    {
        public UserVIewModel SelectedModel { get; set; }
        public ObservableCollection<UserVIewModel> Users { get; set; }

        public MainWinViewModel()
        {
            FillUsers();
        }

        public void FillUsers()
        {
            Users = new ObservableCollection<UserVIewModel>();

            using (var context = new EntityContext())
            {
                foreach (UserData user in context.UserData)
                {
                    if (user.IsDeleted == false)
                        Users.Add(UserVIewModel.FromDB(user));
                }
            }
        }
    }
}
