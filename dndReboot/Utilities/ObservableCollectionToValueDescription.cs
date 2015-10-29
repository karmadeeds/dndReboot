using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dndReboot.Model;

namespace dndReboot.Utilities
{
    public static class ObservableCollectionToValueDescription
    {
        public static void Convert(ObservableCollection<WeaponProficiency> list)
        {
            for (int ii = 0; ii < list.Count; ii++)
            {
                WeaponProficiency all;
                all = WeaponProficiency.None | list[ii];
            }
            
        }
    }
}
