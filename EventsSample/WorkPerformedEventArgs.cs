using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventsSample
{
    public class WorkPerformedEventArgs : EventArgs
    {
        public int Hours { get; set; }
        public WorkType WorkType { get; set; }
    }
}
