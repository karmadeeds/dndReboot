using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dndReboot.Model;

namespace dndReboot.DataAccess
{
    public class FeatureAddedEventArgs : EventArgs
    {
        public FeatureAddedEventArgs(Feature newFeature)
        {
            this.NewFeature = newFeature;
        }
        public Feature NewFeature { get; private set; }
    }
}
