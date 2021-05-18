using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp2.Entities;

namespace WpfApp2.ViewModels
{
    public class AddUserViewModel
    {
        public string SelectedModel { get; set; }
        public ObservableCollection<string> Positions { get; set; }

        public AddUserViewModel()
        {
            Positions = new ObservableCollection<string>();

            using (var context = new EntityContext())
            {
                foreach (var position in context.Position)
                    Positions.Add(position.Value);
            }
        }
    }
}
