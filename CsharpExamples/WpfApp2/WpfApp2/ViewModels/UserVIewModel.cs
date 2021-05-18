using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Entities;

namespace WpfApp2.ViewModels
{
    public class UserVIewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string MIddleName { get; set; }
        public string LastName { get; set; }

        public static UserVIewModel FromDB(UserData context)
        {
            var user = new UserVIewModel();

            user.Id = context.Id;
            user.Name = context.Name;
            user.MIddleName = context.MiddleName;
            user.LastName = context.LastName;

            return user;
        }
    }
}
