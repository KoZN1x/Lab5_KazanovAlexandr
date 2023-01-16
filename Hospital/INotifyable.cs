using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hospital
{
    internal interface INotifyable
    {
        public void Notify(Patient patient);
    }
}
