using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Scheduler.Comparers
{
    class CourseIntCompare : Comparer<int>
    {
        public override int Compare(int x, int y)
        {
            if (x.CompareTo(y) != 0)
            {
                return x.CompareTo(y);
            }
            else
                return 1;
        }
    }
}
