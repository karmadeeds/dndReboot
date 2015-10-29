using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dndReboot.Utilities
{
    public static class ObservableExtension
    {
        public static bool Contain<T>(this ObservableCollection<T> collection, EnumBase obj)
        {
            bool temp = false;
            foreach (T item in collection)
            {
                if ((item as EnumBase).Description == obj.Description)
                {
                    return true;
                }
            }
            return temp;
        }
    }
}
